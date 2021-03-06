﻿using System;
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
		// singleton lazy et thread-safe
		private static readonly Lazy<RepositoryTaches> Lazy = new Lazy<RepositoryTaches>(() => new RepositoryTaches());

		public static RepositoryTaches Instance => Lazy.Value;

		private RepositoryTaches()
		{
		}

		private static TachesApiController _apiClientApiController;

		private TachesApiController ApiController
		{
			get
			{
				if (_apiClientApiController == null)
					_apiClientApiController = new TachesApiController();

				return _apiClientApiController;
			}
		}

		public async Task<IList<TacheReadDto>> Lire()
		{
			try
			{
				return await ApiController.GetAll<TacheReadDto>();
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire les tâches : \n" + ex.Message);
			}
		}

		public async Task<IList<TacheReadDto>> LireAsync()
		{
			return await Task.Run(Lire);
		}

		public async Task<TacheReadDto> LireId(int id)
		{
			try
			{
				return await ApiController.GetById<TacheReadDto>(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la tâche " + id + "  : \n" + ex.Message);
			}
		}

		public async Task Modifier(TacheUpdateDto tacheUpdateDto)
		{
			try
			{
				await ApiController.Update(tacheUpdateDto);
			}
			catch (Exception ex)
			{
				throw new Exception($"Impossible de mettre à jour la tâche : {tacheUpdateDto.Id} \n" + ex.Message);
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
				return await ApiController.GetTachesFromLocataire(idLocataireCourant);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire les tâches du locataire " + idLocataireCourant + "  : \n" + ex.Message);
			}
		}

		public async Task<TacheReadDto> Ajouter(TacheCreateDto tache)
		{
			try
			{
				return await ApiController.Post<TacheCreateDto, TacheReadDto>(tache);
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
				TacheReadDto tacheReadDto = await ApiController.GetById<TacheReadDto>(id);

				tacheReadDto.DateFin = tacheReadDto.DateFin.AddDays(tacheReadDto.Cycle); // met à jour la datte de fin
				tacheReadDto.LocataireId = idLocataire; // met à jour le locataire courant

				//Initialize the mapper
				MapperConfiguration config = new MapperConfiguration(cfg =>
					cfg.CreateMap<TacheReadDto, TacheUpdateDto>()
				);
				Mapper mapper = new Mapper(config);
				TacheUpdateDto tacheUpdateDto = mapper.Map<TacheUpdateDto>(tacheReadDto);

				await ApiController.Update(tacheUpdateDto);
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
