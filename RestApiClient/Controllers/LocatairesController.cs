using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestApiClient.Dtos.Locataires;
using RestServer.Dtos.Locataires;

namespace RestApiClient.Controllers
{
	//todo héritage ?
	public class LocatairesController
	{
		public static async Task<IEnumerable<LocataireReadDto>> GetAllLocataires()
		{
			string url = "locataires";

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					IEnumerable<LocataireReadDto> locatairesReadDtos = await response.Content.ReadAsAsync<IEnumerable<LocataireReadDto>>();

					return locatairesReadDtos;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}

		public static async Task<LocataireReadDto> GetLocataireById(int id)
		{
			string url = "locataires/" + id;

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					LocataireReadDto locataireReadDto = await response.Content.ReadAsAsync<LocataireReadDto>();

					return locataireReadDto;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}

		public static async Task<string> PostLocataire(LocataireCreateDto locataire)
		{
			string url = "locataires";

			string json = JsonConvert.SerializeObject(locataire);
			StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

			string result;

			using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, data))
			{
				result = response.Content.ReadAsStringAsync().Result;
			}

			return result;
		}

		public static async Task<string> UpdateLocataire(int id, LocataireCreateDto locataire)
		{
			string url = "locataires/" + id;

			// fais une req sur l'url et attend la réponse
			string json = JsonConvert.SerializeObject(locataire);
			StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

			string result;

			using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, data))
			{
				result = response.Content.ReadAsStringAsync().Result;
			}

			return result;
		}
	}
}
