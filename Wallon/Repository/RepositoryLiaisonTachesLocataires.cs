using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using RestApiClient.Controllers;

namespace Wallon.Repository
{
	public class RepositoryLiaisonTachesLocataires
	{
		// singleton lazy et thread-safe
		private static readonly Lazy<RepositoryLiaisonTachesLocataires> Lazy = new Lazy<RepositoryLiaisonTachesLocataires>(() => new RepositoryLiaisonTachesLocataires());

		public static RepositoryLiaisonTachesLocataires Instance => Lazy.Value;

		private RepositoryLiaisonTachesLocataires()
		{
		}

		private static LiaisonsApiController _apiClientApiController;

		private LiaisonsApiController ApiController
		{
			get
			{
				if (_apiClientApiController == null)
					_apiClientApiController = new LiaisonsApiController();

				return _apiClientApiController;
			}
		}

		public async Task Supprimer(int id)
		{
			try
			{
				await ApiController.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception($"Impossible de supprimer l'id de liaison : {id} \n" + ex.Message);
			}
		}

		public async Task DeleteLiaisonsFromTache(int idTache)
		{
			try
			{
				await ApiController.DeleteLiaisonsFromTache(idTache);
			}
			catch (Exception ex)
			{
				throw new Exception($"Impossible de supprimer les liaisons de la tâche : {idTache} \n" + ex.Message);
			}
		}

		public async Task<IList<LocataireReadDto>> ListeLocataires(int idTache)
		{
			try
			{
				return await ApiController.ListeLocataires(idTache);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la liaison : \n" + ex.Message);
			}
		}

		public async Task<TacheReadDto> Ajouter(LiaisonCreateDto liaison)
		{
			try
			{
				return await ApiController.Post<LiaisonCreateDto, TacheReadDto>(liaison);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible d'ajouter la liason : \n" + ex.Message);
			}
		}

		public async Task<TacheReadDto> Ajouter(int locataire, int tache)
		{
			LiaisonCreateDto liaison = new LiaisonCreateDto()
			{
				LocataireId = locataire,
				TacheId = tache
			};

			return await Ajouter(liaison);
		}
	}
}
