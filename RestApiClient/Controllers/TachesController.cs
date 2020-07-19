using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models.Dtos.Taches;

namespace RestApiClient.Controllers
{
	public class TachesController : BaseController
	{
		public TachesController()
		{
			Url = "taches";
		}

		public async Task<IEnumerable<TacheReadDto>> GetTachesFromLocataire(int id)
		{
			string url = MakeUrl("duLocataire", id);

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					IEnumerable<TacheReadDto> data = await response.Content.ReadAsAsync<IEnumerable<TacheReadDto>>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
