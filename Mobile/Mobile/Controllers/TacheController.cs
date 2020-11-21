using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using RestApiClient.Controllers;

namespace Mobile.Controllers
{
	public class TacheController
	{
		private readonly TachesController _taches = new TachesController();
		private readonly LiaisonsController _liaisons = new LiaisonsController();

		/**
		 * <summary>Trouve le prochain locataire dans l'ordre des locataires</summary>
		 * <param name="idTache">Id de la tâche concernée</param>
		 * <param name="idLocataire">Id du locataire courant</param>
		 * <returns>Les données du locataire trouvé</returns>
		 */
		public async Task<LocataireReadDto> TrouveLocataireSuivant(int idTache, int idLocataire)
		{
			List<LocataireReadDto> liaison = (await _liaisons.ListeLocataires(idTache)).ToList(); // liste des locataires participant à la tâche

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

		public async Task LocataireSuivant(int id, int idLocataire)
		{
			try
			{
				TacheReadDto tacheReadDto = await _taches.GetById<TacheReadDto>(id);

				tacheReadDto.DateFin = tacheReadDto.DateFin.AddDays(tacheReadDto.Cycle); // met à jour la datte de fin
				tacheReadDto.LocataireId = idLocataire; // met à jour le locataire courant

				//Initialize the mapper
				MapperConfiguration config = new MapperConfiguration(cfg =>
					cfg.CreateMap<TacheReadDto, TacheUpdateDto>()
				);
				Mapper mapper = new Mapper(config);
				TacheUpdateDto tacheUpdateDto = mapper.Map<TacheUpdateDto>(tacheReadDto);

				await _taches.Update(tacheUpdateDto);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de modifier la tâche avec l'id " + id + "  : \n" + ex.Message);
			}
		}
	}
}
