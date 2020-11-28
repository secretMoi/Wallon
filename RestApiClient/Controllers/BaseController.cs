using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models.Dtos;
using Newtonsoft.Json;
using RestApiClient.Interfaces;

namespace RestApiClient.Controllers
{
	public class BaseController : IBaseController
	{
		protected string Url;
		protected List<BaseMethod> BaseMethods;

		protected enum BaseMethod
		{
			GetAll,
			GetId,
			Update,
			Post,
			Delete
		}

		public BaseController()
		{
			BaseMethods = new List<BaseMethod>();
		}

		protected void FillBaseMethods(params BaseMethod[] methods)
		{
			foreach (BaseMethod method in methods)
				BaseMethods.Add(method);
		}

		protected StringContent SerializeAsJson<T>(T dto)
		{
			string json = JsonConvert.SerializeObject(dto);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}

		protected string MakeUrl(params object[] suffix)
		{
			StringBuilder url = new StringBuilder(Url);

			foreach (object element in suffix)
				url.Append("/" + element);

			return url.ToString();
		}

		public virtual async Task<bool> InitConnection()
		{
			var url = MakeUrl();

			try
			{
				await ApiHelper.ApiClient.GetAsync(url);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		} 

		public virtual async Task<T> GetById<T>(int id) where T : class, IRead
		{
			if (!BaseMethods.Contains(BaseMethod.GetId)) return default;

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

		public virtual async Task<IList<T>> GetAll<T>() where T : class, IRead
		{
			if (!BaseMethods.Contains(BaseMethod.GetAll)) return default;

			string url = MakeUrl();

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					IList<T> data = await response.Content.ReadAsAsync<IList<T>>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}

		public virtual async Task Update<T>(T data) where T : IUpdate
		{
			if (!BaseMethods.Contains(BaseMethod.Update)) return;

			string url = MakeUrl(data.Id);

			StringContent dataJson = SerializeAsJson(data);

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, dataJson))
			{
				await response.Content.ReadAsStringAsync();
			}
		}

		public virtual async Task<TU> Post<T, TU>(T input) where TU : IRead
		{
			if (!BaseMethods.Contains(BaseMethod.Post)) return default;

			string url = MakeUrl();

			StringContent dataJson = SerializeAsJson(input);

			TU result;

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, dataJson))
			{
				result = await response.Content.ReadAsAsync<TU>();
			}

			return result;
		}

		public virtual async Task<bool> Delete(int id)
		{
			if (!BaseMethods.Contains(BaseMethod.Delete)) return false;

			string url = MakeUrl(id);

			try
			{
				return (await ApiHelper.ApiClient.DeleteAsync(url)).IsSuccessStatusCode;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
			
		}
	}
}
