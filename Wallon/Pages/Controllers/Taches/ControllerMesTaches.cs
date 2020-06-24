using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FlatControls.Controls;
using FlatControls.Core;
using Wallon.Controllers;
using Wallon.Pages.Vue;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerMesTaches
	{
		private readonly FlatDataGridView _flatDataGridView;
		private readonly RepositoryTaches _repositoryTaches;
		private List<Couche_Classe.Taches> _taches; // associe id bdd et id dgv
		private readonly ThemePanel _vue;

		public ControllerMesTaches(FlatDataGridView flatDataGridView, ThemePanel vue)
		{
			_flatDataGridView = flatDataGridView;
			_vue = vue;
			_repositoryTaches = new RepositoryTaches();
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
			baseConsulter.EnableColumn("valider");
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		/// <param name="useGridView">Dgv où insérer les données trouvées</param>
		/// <param name="baseConsulter">Classe contenant les images à afficher dans les colonnes</param>
		public void GetData(UseGridView useGridView, BaseConsulter baseConsulter)
		{
			_flatDataGridView.HideColonne("Id");

			// récupère les tâches dont le locataire connecté est le locataireCourant
			_taches = _repositoryTaches.TachesCourantesDuLocataire(Settings.IdLocataire);

			foreach (Couche_Classe.Taches tache in _taches)
			{
				// ajoute à la dgv
				useGridView.Add(
					tache.Id,
					tache.Nom,
					(tache.DatteFin - DateTime.Now.Date).Days,
					baseConsulter._imageValider
				);
			}
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

			if (colonne == _flatDataGridView.GetColumnId("Valider")) // si la colonne cliquée correspond
			{
				int locataireSuivant = new ControllerTaches().LocataireSuivant(_taches[ligne].Id, Settings.IdLocataire); // récupère l'id du locataire suivant

				_repositoryTaches.ModifierLocataireCourant(_taches[ligne].Id, locataireSuivant); // modifie le locataire devant effectuer la tâche

				// recharge la page avec un message de validation
				string texteValide = "Vous avez validé la tâche " + _taches[ligne].Nom;
				_vue.LoadPage("Taches.MesTaches", texteValide);
			}
		}
	}
}
