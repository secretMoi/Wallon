using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models.Dtos.Locataires;

namespace RestApiClient.Controllers
{
	public class LiaisonsController : BaseController
	{
		public LiaisonsController()
		{
			Url = "liaisons";

			FillBaseMethods(
				BaseMethod.GetId,
				BaseMethod.Post,
				BaseMethod.Delete
			);
		}

		public async Task<IList<LocataireReadDto>> ListeLocataires(int id)
		{
			string url = MakeUrl("fromTache", id);

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					IList<LocataireReadDto> data = await response.Content.ReadAsAsync<IList<LocataireReadDto>>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
