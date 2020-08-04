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

			FillBaseMethods(
				BaseMethod.GetAll,
				BaseMethod.GetId,
				BaseMethod.Post,
				BaseMethod.Update,
				BaseMethod.Delete
			);
		}

		public async Task<IList<TacheReadDto>> GetTachesFromLocataire(int id)
		{
			string url = MakeUrl("duLocataire", id);

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					IList<TacheReadDto> data = await response.Content.ReadAsAsync<IList<TacheReadDto>>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
