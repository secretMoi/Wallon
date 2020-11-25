using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;

namespace RestApiClient.Interfaces
{
	public interface ILiaisonsController : IBaseController
	{
		/// <summary>
		/// Récupère tous les locataires d'une tâche donnée
		/// </summary>
		/// <param name="idTache">Id de la tâche</param>
		/// <returns>Renvoie une liste des locataires</returns>
		Task<IList<LocataireReadDto>> ListeLocataires(int idTache);

		/// <summary>
		/// Supprime les liaisons en rapport avec la tâche donnée en paramètre
		/// </summary>
		/// <param name="idTache">Id de la tâche</param>
		Task DeleteLiaisonsFromTache(int idTache);
	}
}