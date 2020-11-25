using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;
using RestApiClient.Interfaces;

namespace Mobile.Controllers.Locataire
{
	public class LocataireController : ILocataireController
	{
		private ILocatairesApiController _taches;

		private static readonly Lazy<ILocataireController> Lazy = new Lazy<ILocataireController>(() => new LocataireController());

		//public static ILocataireController Instance => Lazy.Value;

		public static ILocataireController Instance(ILocatairesApiController locataireApiController)
		{
			((LocataireController) Lazy.Value)._taches = locataireApiController;
			return Lazy.Value;
		}

		private LocataireController()
		{

		}

		public async Task<IList<LocataireReadDto>> GetAllAsync()
		{
			return await _taches.GetAll<LocataireReadDto>();
		}
	}
}
