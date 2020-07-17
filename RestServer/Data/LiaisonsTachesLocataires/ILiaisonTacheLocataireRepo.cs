using System.Collections.Generic;
using RestServer.Models;

namespace RestServer.Data.LiaisonsTachesLocataires
{
	public interface ILiaisonTacheLocataireRepo : IBaseRepo<LiaisonTacheLocataire>
	{
		IEnumerable<LiaisonTacheLocataire> GetTachesFromLocataire(int idLocataire);
	}
}