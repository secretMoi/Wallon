using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Locataires;

namespace Mobile.Controllers.Liaison
{
	public interface ILiaisonController
	{
		static ILiaisonController Instance { get; }

		Task<LiaisonReadDto> PostAsync(LiaisonCreateDto liaison);

		Task DeleteLiaisonsFromTacheAsync(int idTache);

		Task<IList<LocataireReadDto>> ListeLocatairesAsync(int idTache);
	}
}