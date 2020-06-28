using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Couche_Classe;
using FlatControls.Controls;
using Wallon.Controllers;
using Wallon.Controllers.BaseConsulter;
using Wallon.Pages.Vue.Taches;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerConsulter
	{
		private readonly RepositoryTaches _taches;
		private readonly Mutex _mutex = new Mutex();
		private Consulter _page;
		private Waiting _waiting;

		private readonly List<object[]> _list;

		public ControllerConsulter(Consulter page)
		{
			_page = page;

			_taches = new RepositoryTaches();
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
				("Modifier", ColonnesCliquables.Cliquable.Edit)
			);
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		public async Task GetDataAsync()
		{
			List<Couche_Classe.Taches> taches = await _taches.LireAsync("datteFin"); // récupère les données dans la bdd

			// parrallel async mais problème de désordre
			//List<Task> tasks = new List<Task>();

			/*foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
				tasks.Add(Task.Run(() => AddToDgv(tache)));*/

			foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
				await Task.Run(() => AddToDgv(tache));

			//await Task.WhenAll(tasks);

			foreach (object[] element in _list)
				_page.FillDgv(element);
		}

		/// <summary>
		/// Ajoute une tâche dans la dgv
		/// </summary>
		/// <param name="tache">Données à insérer</param>
		private void AddToDgv(Couche_Classe.Taches tache)
		{
			//_mutex.WaitOne();

			string dateFin;

			if (tache.Cycle == 0) // si la tâche n'a pas de cycle fixe
				dateFin = "";
			else // sinon on ajoute le cycle à la date de fin
				dateFin = tache.DatteFin.AddDays(tache.Cycle).ToShortDateString();

			int idLocataireSuivant = new ControllerTaches().LocataireSuivant(tache.Id, tache.LocataireCourant); // récupère l'id du locataire suivant
			Locataire locataireSuivant = new RepositoryLocataires().LireId(idLocataireSuivant);

			_list.Add(
				new object[]
				{
					tache.Id,
					tache.Nom,
					_taches.NomLocataireCourant(tache.LocataireCourant),
					locataireSuivant.Nom,
					dateFin
				}
			);

			//_mutex.ReleaseMutex();
		}

		/// <summary>
		/// Event lors du clic sur un élément de la dgv
		/// </summary>
		/// <param name="sender">Objet qui lance l'event</param>
		/// <param name="args">Arguments optionnels</param>
		public void Clic(object sender, DataGridViewCellMouseEventArgs args)
		{
			int ligne = args.RowIndex;
			int colonne = args.ColumnIndex;

			if (colonne == _page.FlatDataGridView.GetColumnId("Modifier")) // si la colonne cliquée correspond
			{
				int? idColonne = _page.FlatDataGridView.GetColumnId("Id"); // trouve l'idde la colonne Id

				if(idColonne == null) // si pas trouvé on sort
					return;

				int idTache = Convert.ToInt32(_page.FlatDataGridView.Get(ligne, (int) idColonne)); // récupère l'id de la tâche à passer en paramètre

				// charge la page d'ajout afin de modifier la tâche avec en paramètre l'id de la tâche
				_page.LoadPage("Taches.Ajouter", idTache);
			}
		}

		public void HideControls(params Type[] controlsArray)
		{
			/*List<Type> types = new List<Type>(controlsArray.Length);

			foreach (Control control in controlsArray)
				types.Add(control.GetType());*/

			foreach (Control control in _page.Controls) // parcours tous les controles
				if(controlsArray.Contains(control.GetType()))
					control.Visible = false;
		}

		public void SetLoading(Panel panel, bool state)
		{
			if (state)
			{
				if(_waiting == null)
					_waiting = new Waiting();
				_waiting.Name = "waiting";
				_waiting.Location = new Point(
					(panel.Width - _waiting.Width) / 2,
					(panel.Height - _waiting.Height) / 2
				);

				panel.Controls.Add(_waiting);

				_page.FlatDataGridView.DataSourceChanged(DataAddedToDgv);
				_page.FlatDataGridView.Visible = false;
			}
			else
			{
				_page.Controls.RemoveByKey("waiting");

				_page.FlatDataGridView.Visible = true;
			}
		}

		public void DataAddedToDgv(object sender, EventArgs e)
		{
			SetLoading(null, false);
		}
	}
}
