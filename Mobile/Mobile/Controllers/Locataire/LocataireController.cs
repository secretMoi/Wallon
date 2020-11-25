using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;
using RestApiClient.Controllers;

namespace Mobile.Controllers.Locataire
{
	public class LocataireController : ILocataireController
	{
		private readonly LocatairesController _taches = new LocatairesController();

		private static readonly Lazy<ILocataireController> Lazy = new Lazy<ILocataireController>(() => new LocataireController());

		public static ILocataireController Instance => Lazy.Value;

		private LocataireController()
		{

		}

		public async Task<IList<LocataireReadDto>> GetAllAsync()
		{
			return await _taches.GetAll<LocataireReadDto>();
		}
	}
}
