using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FlatControls.Controls;
using FlatControls.Core;
using Wallon.Controllers;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerMesTaches
	{
		private readonly FlatDataGridView _flatDataGridView;
		private readonly RepositoryTaches _taches;
		private List<int> _id; // associe id bdd et id dgv

		public ControllerMesTaches(FlatDataGridView flatDataGridView)
		{
			_flatDataGridView = flatDataGridView;
			_taches = new RepositoryTaches();
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
			List<Couche_Classe.Taches> taches = _taches.Lire("id"); // récupère les données dans la bdd
			_id = new List<int>(taches.Count);

			//todo lire les taches seulement de l'utilisateur courant
			//todo ajout event valider

			foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
			{
				useGridView.Add(
					tache.Nom,
					(tache.DatteFin - DateTime.Now.Date).Days,
					baseConsulter._imageValider
				);

				_id.Add(tache.Id); // ajout l'id pour associer la ligne de la dgv à la bdd
			}
		}

		public void Clic(object sender, DataGridViewCellMouseEventArgs args)
		{
			int ligne = args.RowIndex;
			int colonne = args.ColumnIndex;

			//todo faire une fonction pour la condition
			if (colonne == _flatDataGridView.Column["Valider"]?.DisplayIndex) // si la colonne cliquée correspond
			{
				int test= new ControllerTaches().LocataireSuivant(_id[ligne]);
			}
				//LoadPage(reflection.LastItemNamespace + ".ConsulterDetailVente", _id[ligne]); // charge la page de détail
		}
	}
}
