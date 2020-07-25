using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Models.Dtos.Taches;
using RestApiClient.Controllers;
using Wallon.Controllers;

namespace Wallon.Repository
{
	public class RepositoryTaches
	{
		/*private readonly GestionTaches _gestion;

		public RepositoryTaches()
		{
			_gestion = new GestionTaches(Settings.Connection);
		}*/

		// singleton lazy et thread-safe
		private static readonly Lazy<RepositoryTaches> Lazy = new Lazy<RepositoryTaches>(() => new RepositoryTaches());

		public static RepositoryTaches Instance => Lazy.Value;

		private RepositoryTaches()
		{
		}

		private static TachesController _apiClientController;

		private TachesController Controller
		{
			get
			{
				if (_apiClientController == null)
					_apiClientController = new TachesController();

				return _apiClientController;
			}
		}

		public async Task<IList<TacheReadDto>> Lire()
		{
			try
			{
				return await Controller.GetAll<TacheReadDto>();
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire les tâches : \n" + ex.Message);
			}
		}

		public async Task<IList<TacheReadDto>> LireAsync()
		{
			return await Task.Run(() => Lire());
		}

		public async Task<TacheReadDto> LireId(int id)
		{
			try
			{
				return await Controller.GetById<TacheReadDto>(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la tâche " + id + "  : \n" + ex.Message);
			}
		}

		public async void Supprimer(int id)
		{
			try
			{
				await Controller.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception($"Impossible de supprimer l'id de la tâche : {id} \n" + ex.Message);
			}
		}

		/// <summary>
		/// Récupère les tâches que le locataire doit effectuer
		/// </summary>
		/// <param name="idLocataireCourant">Id du locataire</param>
		/// <returns>La liste des tâches</returns>
		public async Task<IList<TacheReadDto>> TachesCourantesDuLocataire(int idLocataireCourant)
		{
			try
			{
				return await Controller.GetTachesFromLocataire(idLocataireCourant);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire les tâches du locataire " + idLocataireCourant + "  : \n" + ex.Message);
			}
		}

		/*public int Supprimer(int index)
		{
			try
			{
				return _gestion.Supprimer(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de supprimer le locataire avec l'id " + index + "  : \n" + ex.Message);
			}
		}*/

		public async Task<TacheReadDto> Ajouter(TacheCreateDto tache)
		{
			try
			{
				return await Controller.Post<TacheCreateDto, TacheReadDto>(tache);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible d'ajouter la tâche " + tache.Nom + "  : \n" + ex.Message);
			}
		}

		/// <summary>
		/// Met à jour la tâche et définit un nouveau locataire devant effectuer la tâche
		/// </summary>
		/// <param name="id">Id de la tâche</param>
		/// <param name="idLocataire">Id du locataire devant effectuer la tâche</param>
		public async Task ModifierLocataireCourant(int id, int idLocataire)
		{
			try
			{
				//todo optimiser avec un patch au lieu de put
				TacheReadDto tacheReadDto = await Controller.GetById<TacheReadDto>(id);

				tacheReadDto.DateFin = tacheReadDto.DateFin.AddDays(tacheReadDto.Cycle); // met à jour la datte de fin
				tacheReadDto.LocataireId = idLocataire; // met à jour le locataire courant

				//Initialize the mapper
				MapperConfiguration config = new MapperConfiguration(cfg =>
					cfg.CreateMap<TacheReadDto, TacheUpdateDto>()
				);
				Mapper mapper = new Mapper(config);
				TacheUpdateDto tacheUpdateDto = mapper.Map<TacheUpdateDto>(tacheReadDto);
				//TacheUpdateDto tacheUpdateDto = mapper.Map<TacheReadDto, TacheUpdateDto>(tacheReadDto);

				await Controller.Update(tacheUpdateDto);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de modifier la tâche " + id + "  : \n" + ex.Message);
			}
		}

		/// <summary>
		/// Récupère le nom du locataire grâce à son id
		/// </summary>
		/// <param name="id">Id du locataire</param>
		/// <returns>Le nom du locataire</returns>
		public async Task<string> NomLocataireCourant(int id)
		{
			return (await new ControllerLocataires().GetById(id)).Nom;
		}
	}
}
