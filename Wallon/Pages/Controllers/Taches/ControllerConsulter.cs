using System.Collections.Generic;
using Core;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerConsulter
	{
		private readonly RepositoryTaches _taches;

		public ControllerConsulter()
		{
			_taches = new RepositoryTaches();
		}

		/// <summary>
		/// Indique la liste des colonnes à afficher dans la dgv
		/// </summary>
		/// <returns>Un tableau du nom des colonnes</returns>
		public string[] ListeColonnes()
		{
			/*List<(string, Type)> locataire = new Locataire().GetChamps();
			string[] listeColonnes = new string[locataire.Count];

			for (int i = 0; i < locataire.Count; i++)
				listeColonnes[i] = locataire[i].Item1;*/

			return new[] { "Nom", "DatteFin" };
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		/// <param name="useGridView">Dgv où insérer les données trouvées</param>
		public void GetData(UseGridView useGridView)
		{
			List<Couche_Classe.Taches> taches = _taches.Lire("id"); // récupère les données dans la bdd

			foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
				useGridView.Add(
					tache.Nom,
					tache.DatteFin.ToShortDateString()
				);
		}
	}
}
