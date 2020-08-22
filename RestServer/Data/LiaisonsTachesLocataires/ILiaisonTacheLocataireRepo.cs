using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;

namespace RestServer.Data.LiaisonsTachesLocataires
{
	public interface ILiaisonTacheLocataireRepo : IBaseRepo<LiaisonTacheLocataire>
	{
		Task<IEnumerable<LiaisonTacheLocataire>> GetTachesFromLocataire(int idLocataire);
		Task<ICollection<LiaisonTacheLocataire>> LiaisonsFromTache(int idTache);
	}
}