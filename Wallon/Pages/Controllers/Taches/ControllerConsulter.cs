using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlatControls.Controls;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using Wallon.Controllers;
using Wallon.Controllers.BaseConsulter;
using Wallon.Fenetres;
using Wallon.Pages.Vue.Taches;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerConsulter
	{
		private readonly RepositoryLocataires _repositoryLocataires = RepositoryLocataires.Instance;
		private readonly RepositoryTaches _taches = RepositoryTaches.Instance;
		private readonly Consulter _page;
		private bool _pageLoaded;
		private FlatLabel _labelNoItem;
		private Waiting _waiting;

		private readonly List<object[]> _list;

		public ControllerConsulter(Consulter page)
		{
			_page = page;

			_list = new List<object[]>();
		}

		/// <summary>
		/// Indique la liste des colonnes à afficher dans la dgv
		/// </summary>
		/// <returns>Un tableau du nom des colonnes</returns>
		public void ListeColonnes()
		{
			_page.SetColonnes("Id", "Nom", "Locataire en charge", "Prochain", "Date de fin" );

			_page.AddColumnsFill(
				("Nom", DataGridViewAutoSizeColumnMode.Fill),
				("Prochain", DataGridViewAutoSizeColumnMode.DisplayedCells),
				("Date de fin", DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)
			);

			_page.FlatDataGridView.HideColonne("Id");

			_page.EnableColumn(
				("Modifier", ColonnesCliquables.Cliquable.Edit),
				("Supprimer", ColonnesCliquables.Cliquable.Delete)
			);
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		public async Task GetDataAsync()
		{
			IList<TacheReadDto> taches = await _taches.LireAsync(); // récupère les données dans la bdd

			// parrallel async mais problème de désordre
			//List<Task> tasks = new List<Task>();

			/*foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
				tasks.Add(Task.Run(() => AddToDgv(tache)));*/

			foreach (TacheReadDto tache in taches) // les lie à la dgv
				await AddToDgv(tache);
			//await Task.Run(() => AddToDgv(tache));

			//await Task.WhenAll(tasks);

			foreach (object[] element in _list)
				_page.FillDgv(element);
		}

		/// <summary>
		/// Ajoute une tâche dans la dgv
		/// </summary>
		/// <param name="tache">Données à insérer</param>
		private async Task AddToDgv(TacheReadDto tache)
		{
			string dateFin;

			if (tache.Cycle == 0) // si la tâche n'a pas de cycle fixe
				dateFin = "";
			else // sinon on ajoute le cycle à la date de fin
				dateFin = tache.DateFin.ToShortDateString();

			LocataireReadDto idLocataireSuivant = await new ControllerTaches().LocataireSuivant(tache.Id, tache.LocataireId); // récupère l'id du locataire suivant
			
			LocataireReadDto locataireSuivant = await _repositoryLocataires.LireId(idLocataireSuivant.Id);
			// todo mettre la datte de fin en rouge si dépassée
			_list.Add(
				new object[]
				{
					tache.Id,
					tache.Nom,
					tache.Locataire.Nom,
					locataireSuivant.Nom,
					dateFin
				}
			);
		}

		/// <summary>
		/// Event lors du clic sur un élément de la dgv
		/// </summary>
		/// <param name="sender">Objet qui lance l'event</param>
		/// <param name="args">Arguments optionnels</param>
		public async Task Clic(object sender, DataGridViewCellMouseEventArgs args)
		{
			int ligne = args.RowIndex;
			int colonne = args.ColumnIndex;

			if (colonne == _page.FlatDataGridView.GetColumnId("Modifier")) // si la colonne cliquée correspond
			{
				int? idTache = FindTache(ligne);
				if (idTache == null) return;

				// charge la page d'ajout afin de modifier la tâche avec en paramètre l'id de la tâche
				_page.LoadPage("Taches.Ajouter", idTache);
			}

			else if (colonne == _page.FlatDataGridView.GetColumnId("Supprimer")) // si la colonne cliquée correspond
			{
				int? idTache = FindTache(ligne);
				if(idTache == null) return;

				DialogResult result =  Dialog.ShowYesNo(
					$"Voulez-vous vraiment supprimer la tâche {_page.FlatDataGridView.Get(ligne, "Nom")} ?");

				if(result == DialogResult.No) return;

				await new ControllerTaches().Delete((int) idTache);

				_page.LoadPage("Taches.Consulter");
			}

			else if (colonne == _page.FlatDataGridView.GetColumnId("Nom")) // si la colonne cliquée correspond
			{
				int? idTache = FindTache(ligne);
				if (idTache == null) return;

				_page.LoadPage("Taches.Lecture", idTache);
			}
		}

		/// <summary>
		/// Récupère l'id de la tâche lors du clic sur une ligne de la dgv
		/// </summary>
		/// <param name="ligne">Ligne cliquée</param>
		/// <returns>Id de la tâche si trouvée, null sinon</returns>
		private int? FindTache(int ligne)
		{
			int? idColonne = _page.FlatDataGridView.GetColumnId("Id"); // trouve l'id de la colonne Id

			if (idColonne == null) // si pas trouvé on sort
				return null;

			return Convert.ToInt32(_page.FlatDataGridView.Get(ligne, (int)idColonne)); // récupère l'id de la tâche à passer en paramètre
		}

		/// <summary>
		/// Permet de cacher les types de controls demandés
		/// </summary>
		/// <param name="controlsArray">Liste des types de controls à masquer</param>
		public void HideControls(params Type[] controlsArray)
		{
			foreach (Control control in _page.Controls) // parcours tous les controles
				if(controlsArray.Contains(control.GetType())) // si le control est dans la liste
					control.Visible = false; // le masque
		}

		/// <summary>
		/// Définit si l'animation de chargement soit s'afficher ou non
		/// </summary>
		/// <param name="panel">Panel dans lequel insérer l'animation de chargement, null si pas de chargement</param>
		public void SetLoading(Panel panel)
		{
			// débute le chargement
			if (panel != null && _pageLoaded == false) // si on active le chargement
			{
				if(_waiting == null)
					_waiting = new Waiting(); // crée le control si pas encore fait
				_waiting.Name = "waiting"; // nom permettant de le supprimer plus facilement
				_waiting.Location = new Point(
					(panel.Width - _waiting.Width) / 2,
					(panel.Height - _waiting.Height) / 2
				);

				panel.Controls.Add(_waiting); // ajout l'animation de chargement au panel

				_page.FlatDataGridView.DataSourceChanged(DataAddedToDgv); // méthode de callback à appeler lorsque les données sont chargées (fin du chargement)
				_page.FlatDataGridView.Visible = false; // désactive la dgv durant le chargement
			}
			// fin du chargement et présence de donnée
			else if(_page.FlatDataGridView.Rows.Count != 0 && _pageLoaded)
			{
				_waiting.Dispose(); // retire l'animation de chargement

				_page.FlatDataGridView.Visible = true; // affiche les données
			}
			// fin du chargement et absence de donnée
			else if (_page.FlatDataGridView.Rows.Count == 0 && _pageLoaded)
			{
				Control parent;

				if (!_waiting.IsDisposed)
				{
					parent = _waiting.Parent;
					_waiting.Dispose();

					_labelNoItem = new FlatLabel()
					{
						ForeColor = Theme.BackLight,
						AutoSize = true,
						Font = new Font(Theme.Font.FontFamily, 24, FontStyle.Bold),
						Text = @"Aucune tâche à afficher"
					};

					parent.Controls.Add(_labelNoItem);
				}
				else
					parent = _labelNoItem.Parent;

				_labelNoItem.Left = (parent.Width - _labelNoItem.Width) / 2;
				_labelNoItem.Top = (parent.Height - _labelNoItem.Height) / 2;
			}
		}

		/// <summary>
		/// Méthode appelée lors de la fin du chargement des données
		/// </summary>
		public void DataAddedToDgv(object sender, EventArgs e)
		{
			_pageLoaded = true;
			SetLoading(null);
		}
	}
}
