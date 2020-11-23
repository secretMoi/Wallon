using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Locataires;
using RestApiClient.Controllers;

namespace Mobile.Controllers.Liaison
{
	public class LiaisonController : ILiaisonController
	{
		private readonly LiaisonsController _liaisons = new LiaisonsController();

		private static readonly Lazy<ILiaisonController> Lazy = new Lazy<ILiaisonController>(() => new LiaisonController());

		public static ILiaisonController Instance => Lazy.Value;

		private LiaisonController()
		{

		}

		public async Task<LiaisonReadDto> PostAsync(LiaisonCreateDto liaison)
		{
			return await _liaisons.Post<LiaisonCreateDto, LiaisonReadDto>(liaison);
		}

		public async Task DeleteLiaisonsFromTacheAsync(int idTache)
		{
			await _liaisons.DeleteLiaisonsFromTache(idTache);
		}

		public async Task<IList<LocataireReadDto>> ListeLocatairesAsync(int idTache)
		{
			return await _liaisons.ListeLocataires(idTache);
		}
	}
}
