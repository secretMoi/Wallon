using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestApiClient.Controllers
{
	public class BaseController
	{
		protected string Url;

		public BaseController()
		{

		}

		protected StringContent SerializeAsJson<T>(T dto)
		{
			string json = JsonConvert.SerializeObject(dto);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}

		protected string MakeUrl(int id = Int32.MinValue)
		{
			if (id == Int32.MinValue)
				return Url;
			else
				return $"{Url}/{id}";
		}

		public virtual async Task<T> GetById<T>(int id)
		{
			string url = MakeUrl(id);

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					T data = await response.Content.ReadAsAsync<T>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}

		public virtual async Task<IEnumerable<T>> GetAll<T>()
		{
			string url = MakeUrl();

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					IEnumerable<T> data = await response.Content.ReadAsAsync<IEnumerable<T>>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}

		// todo mettre l'id dans le dto
		public async Task<string> Update<T>(int id, T data)
		{
			string url = MakeUrl(id);

			StringContent dataJson = SerializeAsJson(data);

			string result;

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, dataJson))
			{
				result = response.Content.ReadAsStringAsync().Result;
			}

			return result;
		}

		public async Task<string> Post<T>(T data)
		{
			string url = MakeUrl();

			StringContent dataJson = SerializeAsJson(data);

			string result;

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, dataJson))
			{
				result = response.Content.ReadAsStringAsync().Result;
			}

			return result;
		}
	}
}
