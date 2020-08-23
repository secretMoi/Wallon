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

		/// <summary>
		/// Récupère tous les locataires d'une tâche donnée
		/// </summary>
		/// <param name="idTache">Id de la tâche</param>
		/// <returns>Renvoie une liste des locataires</returns>
		public async Task<IList<LocataireReadDto>> ListeLocataires(int idTache)
		{
			string url = MakeUrl("fromTache", idTache);

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

		/// <summary>
		/// Supprime les liaisons en rapport avec la tâche donnée en paramètre
		/// </summary>
		/// <param name="idTache">Id de la tâche</param>
		public async Task DeleteLiaisonsFromTache(int idTache)
		{
			string url = MakeUrl("deleteFromTache", idTache);

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
			{
				if (!response.IsSuccessStatusCode)
					throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
