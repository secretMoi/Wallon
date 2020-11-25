using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Taches;

namespace RestApiClient.Interfaces
{
	public interface ITachesController : IBaseController
	{
		/// <summary>
		/// Récupère les tâches où est inscrit un locataire
		/// </summary>
		/// <param name="idLocataire">Id du locataire</param>
		/// <returns>Renvoie une liste des tâches</returns>
		Task<IList<TacheReadDto>> GetTachesFromLocataire(int idLocataire);
	}
}