using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestServer.Dtos.Locataires;

namespace RestApiClient.Controllers
{
	public class LocatairesController
	{
		public static async Task<IEnumerable<LocataireReadDto>> LoadComic(int comicNumber = 0)
		{
			string url = "locataires";

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					IEnumerable<LocataireReadDto> comic = await response.Content.ReadAsAsync<IEnumerable<LocataireReadDto>>();

					return comic;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
