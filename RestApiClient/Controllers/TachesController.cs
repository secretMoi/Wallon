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

		/// <summary>
		/// Récupère les tâches où est inscrit un locataire
		/// </summary>
		/// <param name="idLocataire">Id du locataire</param>
		/// <returns>Renvoie une liste des tâches</returns>
		public async Task<IList<TacheReadDto>> GetTachesFromLocataire(int idLocataire)
		{
			string url = MakeUrl("duLocataire", idLocataire);

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
