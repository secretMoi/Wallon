using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;
using RestApiClient.Interfaces;

namespace Mobile.Controllers.Locataire
{
	public class LocataireController : ILocataireController
	{
		private ILocatairesApiController _locataires;

		private static readonly Lazy<ILocataireController> Lazy = new Lazy<ILocataireController>(() => new LocataireController());

		public static ILocataireController Instance(ILocatairesApiController locataireApiController)
		{
			((LocataireController) Lazy.Value)._locataires = locataireApiController;
			return Lazy.Value;
		}

		private LocataireController()
		{

		}

		public async Task<IList<LocataireReadDto>> GetAllAsync()
		{
			return await _locataires.GetAll<LocataireReadDto>();
		}
		
		public async Task<LocataireReadDto> GetByIdAsync(int id)
		{
			return await _locataires.GetById<LocataireReadDto>(id);
		}

		public async Task UpdateAsync(LocataireUpdateDto locataireUpdateDto)
		{
			await _locataires.Update(locataireUpdateDto);
		}
	}
}
