using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlatControls.Controls;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using Wallon.Controllers;
using Wallon.Controllers.BaseConsulter;
using Wallon.Pages.Vue;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerMesTaches
	{
		private readonly FlatDataGridView _flatDataGridView;
		private readonly RepositoryTaches _repositoryTaches = RepositoryTaches.Instance;
		private IList<TacheReadDto> _taches; // associe id bdd et id dgv
		private readonly ThemePanel _vue;

		public ControllerMesTaches(FlatDataGridView flatDataGridView, ThemePanel vue)
		{
			_flatDataGridView = flatDataGridView;
			_vue = vue;
		}

		/// <summary>
		/// Indique la liste des colonnes à afficher dans la dgv
		/// </summary>
		/// <returns>Un tableau du nom des colonnes</returns>
		public string[] ListeColonnes()
		{
			return new[]
			{
				"Id",
				"Nom",
				"Temps restant (en jours)"
			};
		}

		public void ColonnesCliquables(BaseConsulter baseConsulter)
		{
			baseConsulter.EnableColumn(
				("Valider", Wallon.Controllers.BaseConsulter.ColonnesCliquables.Cliquable.Add)
			);

			baseConsulter.AddColumnsFill(("Nom", DataGridViewAutoSizeColumnMode.Fill));
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		/// <param name="baseConsulter">Classe contenant les images à afficher dans les colonnes</param>
		public async Task GetData(BaseConsulter baseConsulter)
		{
			_flatDataGridView.HideColonne("Id");

			// récupère les tâches dont le locataire connecté est le locataireCourant
			_taches = await _repositoryTaches.TachesCourantesDuLocataire(Settings.IdLocataire);

			foreach (TacheReadDto tache in _taches)
			{
				// ajoute à la dgv
				baseConsulter.FillDgv(
					tache.Id,
					tache.Nom,
					(tache.DateFin - DateTime.Now.Date).Days
				);
			}
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

			if (colonne == _flatDataGridView.GetColumnId("Valider")) // si la colonne cliquée correspond
			{
				LocataireReadDto locataireSuivant = await new ControllerTaches().LocataireSuivant(_taches[ligne].Id, Settings.IdLocataire); // récupère l'id du locataire suivant

				await _repositoryTaches.ModifierLocataireCourant(_taches[ligne].Id, locataireSuivant.Id); // modifie le locataire devant effectuer la tâche

				// recharge la page avec un message de validation
				string texteValide = "Vous avez validé la tâche " + _taches[ligne].Nom;
				_vue.LoadPage("Taches.MesTaches", texteValide);
			}
		}
	}
}
