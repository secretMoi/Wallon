using System.Collections.Generic;
using Core;
using Couche_Classe;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerListe
	{
		private readonly RepositoryLocataires _locataire;

		public ControllerListe()
		{
			_locataire = new RepositoryLocataires();
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

			return new []{"Nom"};
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		/// <param name="useGridView">Dgv où insérer les données trouvées</param>
		public void GetData(UseGridView useGridView)
		{
			List<Locataire> locataires = _locataire.Lire("id"); // récupère les données dans la bdd

			foreach (Locataire locataire in locataires) // les lie à la dgv
				useGridView.Add(
					locataire.Nom
				);
		}
	}
}
