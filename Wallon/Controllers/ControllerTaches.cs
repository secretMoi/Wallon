using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Dtos.Locataires;
using Wallon.Repository;

namespace Wallon.Controllers
{
	public class ControllerTaches
	{
		public async Task<LocataireReadDto> LocataireSuivant(int idTache, int idLocataire)
		{
			var test = await RepositoryLiaisonTachesLocataires.Instance.ListeLocataires(idTache);
			List<LocataireReadDto> liaison = (await RepositoryLiaisonTachesLocataires.Instance.ListeLocataires(idTache)).ToList(); // liste des locataires participant à la tâche

			int indexActuel = liaison.FindIndex(l => l.Id == idLocataire); // situe le locataire actuel dans la liste
			if (indexActuel == -1) // si la liste ne le contient pas
				return null;
			//throw new Exception("Le locataire " + indexActuel + " n'est pas dans la tâche " + idTache);

			return ProchainLocataire(indexActuel, liaison); // renvoie l'id du prochain locataire
		}

		/// <summary>
		/// Passe à l'élément suivant dans la liste
		/// </summary>
		/// <param name="indexActuel">Position actuelle dans la liste</param>
		/// <param name="listeLocataires">Liste en lecture seule à parcourir</param>
		/// <returns>La prochaine position dans la liste</returns>
		private LocataireReadDto ProchainLocataire(int indexActuel, IReadOnlyList<LocataireReadDto> listeLocataires)
		{
			if (indexActuel + 1 < listeLocataires.Count) // si il y encore des locataires dans la liste
				return listeLocataires[indexActuel + 1]; // renvoie le suivant

			return listeLocataires[0]; // renvoie le premier
		}
	}
}
