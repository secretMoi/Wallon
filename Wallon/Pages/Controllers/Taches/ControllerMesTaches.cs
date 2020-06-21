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
		private readonly RepositoryLiaisonTachesLocataires _repositoryLiaison;
		private List<Couche_Classe.Taches> _taches; // associe id bdd et id dgv
		private readonly ThemePanel _vue;

		public ControllerMesTaches(FlatDataGridView flatDataGridView, ThemePanel vue)
		{
			_flatDataGridView = flatDataGridView;
			_vue = vue;
			_repositoryTaches = new RepositoryTaches();
			_repositoryLiaison = new RepositoryLiaisonTachesLocataires();
		}

		/// <summary>
		/// Indique la liste des colonnes à afficher dans la dgv
		/// </summary>
		/// <returns>Un tableau du nom des colonnes</returns>
		public string[] ListeColonnes()
		{
			return new[]
			{
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
			_taches = _repositoryTaches.TachesCourantesDuLocataire(Settings.IdLocataire);

			foreach (Couche_Classe.Taches tache in _taches)
			{
				useGridView.Add(
					tache.Nom,
					(tache.DatteFin - DateTime.Now.Date).Days,
					baseConsulter._imageValider
				);
			}
		}

		public void Clic(object sender, DataGridViewCellMouseEventArgs args)
		{
			int ligne = args.RowIndex;
			int colonne = args.ColumnIndex;

			//todo faire une fonction pour la condition
			if (colonne == _flatDataGridView.Column["Valider"]?.DisplayIndex) // si la colonne cliquée correspond
			{
				int locataireSuivant = new ControllerTaches().LocataireSuivant(_taches[ligne].Id);

				_repositoryTaches.ModifierLocataireCourant(_taches[ligne].Id, locataireSuivant);

				// todo message de conformation + actualisation dgv
				string texteValide = "Vous avez validé la tâche " + _taches[ligne].Nom;
				_vue.LoadPage("Taches.MesTaches", texteValide);
			}
		}
	}
}
