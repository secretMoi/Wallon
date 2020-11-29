using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mobile.Core.Logger;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using RestApiClient.Controllers;
using RestApiClient.Interfaces;

namespace Mobile.Controllers.Tache
{
	public class TacheController : ITacheController
	{
		private ITachesApiController _tachesApi;
		private ILiaisonsApiController _liaisonsApi;

		private static readonly Lazy<ITacheController> Lazy = new Lazy<ITacheController>(() => new TacheController());

		//public static ITacheController Instance => Lazy.Value;

		public static ITacheController Instance(ITachesApiController tachesApiController, ILiaisonsApiController liaisonsApi)
		{
			((TacheController) Lazy.Value)._tachesApi = tachesApiController;
			((TacheController) Lazy.Value)._liaisonsApi = liaisonsApi;
			return Lazy.Value;
		}

		private TacheController()
		{

		}

		/**
		 * <summary>Trouve le prochain locataire dans l'ordre des locataires</summary>
		 * <param name="idTache">Id de la tâche concernée</param>
		 * <param name="idLocataire">Id du locataire courant</param>
		 * <returns>Les données du locataire trouvé</returns>
		 */
		public async Task<LocataireReadDto> TrouveLocataireSuivant(int idTache, int idLocataire)
		{
			List<LocataireReadDto> liaison = (await _liaisonsApi.ListeLocataires(idTache)).ToList(); // liste des locataires participant à la tâche

			int indexActuel = liaison.FindIndex(l => l.Id == idLocataire); // situe le locataire actuel dans la liste
			if (indexActuel == -1) // si la liste ne le contient pas
				return null;

			return ProchainLocataire(indexActuel, liaison); // renvoie l'id du prochain locataire
		}

		/// <summary>
		/// Passe à l'élément suivant dans la liste
		/// </summary>
		/// <param name="indexActuel">Position actuelle dans la liste</param>
		/// <param name="listeLocataires">Liste en lecture seule à parcourir</param>
		/// <returns>La prochaine position dans la liste</returns>
		private LocataireReadDto ProchainLocataire(int indexActuel, IReadOnlyList<LocataireReadDto> listeLocataires)
		{
			if (indexActuel + 1 < listeLocataires.Count) // si il y encore des locataires dans la liste
				return listeLocataires[indexActuel + 1]; // renvoie le suivant

			return listeLocataires[0]; // renvoie le premier
		}


		/**
		 * <summary>Met à jour le locataire courant en passant au suivant</summary>
		 * <param name="id">Id de la tâche concernée</param>
		 * <param name="idLocataire">Id du locataire à mettre</param>
		 */
		public async Task LocataireSuivant(int id, int idLocataire)
		{
			try
			{
				TacheReadDto tacheReadDto = await _tachesApi.GetById<TacheReadDto>(id); // récupère les infos du locataire actuel

				tacheReadDto.DateFin = tacheReadDto.DateFin.AddDays(tacheReadDto.Cycle); // met à jour la datte de fin
				tacheReadDto.LocataireId = idLocataire; // met à jour le locataire courant

				//Initialize the mapper
				MapperConfiguration config = new MapperConfiguration(cfg =>
					cfg.CreateMap<TacheReadDto, TacheUpdateDto>()
				);
				Mapper mapper = new Mapper(config);
				TacheUpdateDto tacheUpdateDto = mapper.Map<TacheUpdateDto>(tacheReadDto);

				await _tachesApi.Update(tacheUpdateDto); // met à jour le locataire
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de modifier la tâche avec l'id " + id + "  : \n" + ex.Message);
			}
		}

		/**
		 * <summary>Permet de créer une tâche</summary>
		 * <param name="tache">Données de la tâche à créer du type <see cref="TacheCreateDto"/></param>
		 * <returns>Renvoie la tâche créée en <see cref="TacheReadDto"/></returns>
		 */
		public async Task<TacheReadDto> PostAsync(TacheCreateDto tache)
		{
			return await _tachesApi.Post<TacheCreateDto, TacheReadDto>(tache);
		}

		/**
		 * <summary>Récupère toutes les tâches</summary>
		 * <returns>Une liste des toutes les tâches, null si une erreur a été rencontrée</returns>
		 * <exception cref="Exception">Une erreur s'est produite avec null</exception>
		 */
		public async Task<IList<TacheReadDto>> GetAllAsync()
		{
			try
			{
				return await _tachesApi.GetAll<TacheReadDto>();
			}
			catch (Exception e)
			{
				//Logger.LogError(e.Message);
				App.Container.GetService<ILogger>().LogError(e.Message);

				return null;
			}
		}

		/**
		 * <summary>Récupère une tâche de la bdd par son id</summary>
		 * <param name="id">Id de la tâche à récupérer</param>
		 * <returns>Retourne une <see cref="TacheReadDto"/> contenant les infos de la tâche</returns>
		 */
		public async Task<TacheReadDto> GetByIdAsync(int id)
		{
			return await _tachesApi.GetById<TacheReadDto>(id);
		}

		public async Task UpdateAsync(TacheUpdateDto tache)
		{
			await _tachesApi.Update(tache);
		}

		public async Task<IList<TacheReadDto>> GetTachesFromLocataireAsync(int idLocataire)
		{
			return await _tachesApi.GetTachesFromLocataire(idLocataire);
		}

		public async Task DeleteAsync(int id)
		{
			await _tachesApi.Delete(id);
		}
	}
}
