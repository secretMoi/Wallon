using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;

namespace Mobile.Controllers.Locataire
{
	public interface ILocataireController
	{
		static ILocataireController Instance { get; }

		Task<IList<LocataireReadDto>> GetAllAsync();
	}
}