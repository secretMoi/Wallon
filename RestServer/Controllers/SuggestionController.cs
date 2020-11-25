using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.Suggestions;
using Models.Models;
using RestServer.Data.Locataires;
using RestServer.Data.Suggestions;

namespace RestServer.Controllers
{
	[Route("api/suggestions")] // route par défaut du controller
	[ApiController] // indique que cette classe est un controller api
	public class SuggestionController : ControllerBase
	{
		private readonly ISuggestionRepo _repository; // repo sur lequel le controller va travailler
		private readonly IMapper _mapper;
		private ILocataireRepo _locataireRepo;

		public SuggestionController(ISuggestionRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		private LocataireRepo InstanceLocataire
		{
			get
			{
				if (_locataireRepo == null)
					_locataireRepo = new LocataireRepo(_repository.Context);

				return (LocataireRepo)_locataireRepo;
			}
		}

		// GET api/suggestions
		/// <summary>
		/// Récupère tous les enregistrements des suggestions sous format JSON
		/// </summary>
		/// <returns>Renvoie une liste des suggestions encapsulée dans le status 200 OK</returns>
		[HttpGet] // indique que cette méthode répond à une requete http
		public ActionResult<IEnumerable<SuggestionReadDto>> GetAll()
		{
			IEnumerable<Suggestion> model = _repository.GetAll();

			return Ok(_mapper.Map<IEnumerable<SuggestionReadDto>>(model)); // méthode Ok définie dans controllerBase
		}

		// GET api/suggestions/5
		// GET api/suggestions/{id}
		/// <summary>
		/// Récupère une suggestion via son id sous format JSON
		/// </summary>
		/// <param name="id">Id de la suggestion</param>
		/// <returns>Renvoie une suggestion encapsulée dans le status 200 OK<br />
		/// Renvoie le status NotFound 404 si la suggestion n'est pas trouvée</returns>
		[HttpGet("{id:int}", Name = "GetSuggestionById")] // indique que cette méthode répond à une requete http
		public ActionResult<SuggestionReadDto> GetTacheById(int id)
		{
			Suggestion model = _repository.GetById(id);

			if (model != null)
				return Ok(_mapper.Map<SuggestionReadDto>(model)); // map commandItem en CommandReadDto pour renvoyer les données formattées au client

			return NotFound(); // si pas trouvé renvoie 404 not found
		}

		// POST api/taches
		/// <summary>
		/// Enregistre une suggestion en JSON dans la bdd
		/// </summary>
		/// <param name="suggestionCreateDto">Données de la suggestion à enregistrer</param>
		/// <returns>Renvoie la suggestion tout juste créée et encapsulée dans le status 200 OK</returns>
		[HttpPost]
		public ActionResult<SuggestionReadDto> Create(SuggestionCreateDto suggestionCreateDto)
		{
			Suggestion model = _mapper.Map<Suggestion>(suggestionCreateDto); // trouve le model à utiliser
			_repository.Create(model); // crée la command en ram
			_repository.SaveChanges(); // sauvegarde les changements dans la bdd

			SuggestionReadDto suggestionReadDto = _mapper.Map<SuggestionReadDto>(model);
			if (suggestionReadDto.LocataireId != null)
				suggestionReadDto.Locataire = InstanceLocataire.GetById((int) suggestionReadDto.LocataireId);
			else
				return BadRequest();

			return Ok(suggestionReadDto);
		}

		// PUT api/suggestions/{id}
		/// <summary>
		/// Modifie toutes les données d'une suggestion selon son id
		/// </summary>
		/// <param name="id">Id de la suggestion</param>
		/// <param name="suggestionUpdateDto">Données de la suggestion à enregistrer</param>
		/// <returns>Renvoie le status 204 NoContent <br />
		/// Renvoie le status 404 NotFound si l'id de la suggestion n'existe pas
		/// </returns>
		[HttpPut("{id:int}")]
		public ActionResult Update(int id, SuggestionUpdateDto suggestionUpdateDto)
		{
			Suggestion model = _repository.GetById(id); // cherche l'objet dans la bdd
			if (model == null)
				return NotFound(); // si il n'existe pas on quitte et envoie 404

			_mapper.Map(suggestionUpdateDto, model); // met commandUpdateDto dans commandModelFromRepo

			_repository.Update(model); // update l'objet

			_repository.SaveChanges(); // sauvegarde l'état de l'objet dans la bdd

			return NoContent();
		}

		// DELETE api/suggestions/{id}
		/// <summary>
		/// Supprime une suggestion via son id
		/// </summary>
		/// <param name="id">Id de la suggestion à supprimer</param>
		/// <returns>Renvoie 204 NoContent si supprimé, 404 NotFound si l'id de la suggestion n'existe pas dans la bdd</returns>
		[HttpDelete("{id:int}")]
		public ActionResult Delete(int id)
		{
			Suggestion model = _repository.GetById(id); // cherche l'objet dans la bdd
			if (model == null)
				return NotFound(); // si il n'existe pas on quitte et envoie 404

			_repository.Delete(model); // supprime l'id dans l'objet
			_repository.SaveChanges(); // sauvegarde dans la bdd

			return NoContent();
		}
	}
}
