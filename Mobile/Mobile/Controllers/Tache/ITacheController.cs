using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;

namespace Mobile.Controllers.Tache
{
	public interface ITacheController
	{
		static ITacheController Instance { get; }

		/**
		 * <summary>Trouve le prochain locataire dans l'ordre des locataires</summary>
		 * <param name="idTache">Id de la tâche concernée</param>
		 * <param name="idLocataire">Id du locataire courant</param>
		 * <returns>Les données du locataire trouvé</returns>
		 */
		Task<LocataireReadDto> TrouveLocataireSuivant(int idTache, int idLocataire);

		/**
		 * <summary>Met à jour le locataire courant en passant au suivant</summary>
		 * <param name="id">Id de la tâche concernée</param>
		 * <param name="idLocataire">Id du locataire à mettre</param>
		 */
		Task LocataireSuivant(int id, int idLocataire);

		/**
		 * <summary>Permet de créer une tâche</summary>
		 * <param name="tache">Données de la tâche à créer du type <see cref="TacheCreateDto"/></param>
		 * <returns>Renvoie la tâche créée en <see cref="TacheReadDto"/></returns>
		 */
		Task<TacheReadDto> PostAsync(TacheCreateDto tache);

		Task<IList<TacheReadDto>> GetAllAsync();

		Task<TacheReadDto> GetByIdAsync(int id);

		Task UpdateAsync(TacheUpdateDto tache);

		Task<IList<TacheReadDto>> GetTachesFromLocataireAsync(int idLocataire);

		Task DeleteAsync(int id);
	}
}