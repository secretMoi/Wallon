using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestServer.Data.Locataires;
using RestServer.Dtos.Locataires;
using RestServer.Models;

namespace RestServer.Controllers
{
	// controllerbase, classe de base de aspnetcore qui supporte uniquement model et controller
	// controller, classe de base de aspnetcore qui supporte model et controller + vue
	// on a pas de vue ici

	//[Route("api/[controller]")] // => /api/commands (nom de la classe sans controller)
	[Route("api/locataires")] // permet de renommer la classe sans que les clients ne soient impactés
	[ApiController] // indique que cette classe est un controller api
	public class LocatairesController : ControllerBase
	{
		private readonly ILocataireRepo _repository; // repo sur lequel le controller va travailler
		private readonly IMapper _mapper;

		public LocatairesController(ILocataireRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
			//_mapper = new LocatairesProfile();
		}

		// GET api/commands
		/// <summary>
		/// Récupère tous les enregistrements des locataires sous format JSON
		/// </summary>
		/// <returns>Renvoie une liste des locataires encapsulés dans le status 200 OK</returns>
		[HttpGet] // indique que cette méthode répond à une requete http
		public ActionResult<IEnumerable<LocataireReadDto>> GetAll()
		{
			IEnumerable<Locataire> locataires = _repository.GetAll();

			// mapper, mets l'objet commandItems dans CommandReadDto
			return Ok(_mapper.Map<IEnumerable<LocataireReadDto>>(locataires)); // méthode Ok définie dans controllerBase
		}

		// GET api/commands/5
		// GET api/commands/{id}
		/// <summary>
		/// Récupère un locataire via son id sous format JSON
		/// </summary>
		/// <param name="id">Id du locataire</param>
		/// <returns>Renvoie un locataire encapsulé dans le status 200 OK<br />
		/// Renvoie le status NotFound 404 si le locataire n'est pas trouvé</returns>
		[HttpGet("{id}", Name = "GetLocataireById")] // indique que cette méthode répond à une requete http
		public ActionResult<LocataireReadDto> GetLocataireById(int id)
		{
			Locataire locataire = _repository.GetById(id);

			if (locataire != null)
				return Ok(_mapper.Map<LocataireReadDto>(locataire)); // map commandItem en CommandReadDto pour renvoyer les données formattées au client

			return NotFound(); // si pas trouvé renvoie 404 not found
		}

		// POST api/commands
		/// <summary>
		/// Enregistre un locataire en JSON dans la bdd
		/// </summary>
		/// <param name="locataireCreateDto">Données du locataire à enregistrer</param>
		/// <returns>Renvoie le locataire tout juste créé encapsulé dans le status 200 OK</returns>
		[HttpPost]
		public ActionResult<LocataireReadDto> Create(LocataireCreateDto locataireCreateDto)
		{
			Locataire locataireModel = _mapper.Map<Locataire>(locataireCreateDto); // trouve le model à utiliser
			_repository.Create(locataireModel); // crée la command en ram
			_repository.SaveChanges(); // sauvegarde les changements dans la bdd

			// mapper, mets l'objet commandModel dans CommandReadDto
			LocataireReadDto readDto = _mapper.Map<LocataireReadDto>(locataireModel);

			// renvoie l'uri permettant d'accéder à l'élément créé
			// fonction gérant la route à appeler (GET api/commands/{id})
			// paramètre à passer à la route (l'id créé)
			// classe pour formatter les données
			//return CreatedAtRoute(nameof(GetById), new { Id = commandReadDto.Id }, commandReadDto);
			return Ok(readDto);
		}

		// PUT api/commands/{id}
		/// <summary>
		/// Modifie toutes les données d'un locataire selon son id
		/// </summary>
		/// <param name="id">Id du locataire</param>
		/// <param name="locataireUpdateDto">Données du locataire à enregistrer</param>
		/// <returns>Renvoie le status 204 NoContent</returns>
		[HttpPut("{id}")]
		public ActionResult Update(int id, LocataireUpdateDto locataireUpdateDto)
		{
			Locataire locataireModel = _repository.GetById(id); // cherche l'objet dans la bdd
			if (locataireModel == null)
				return NotFound(); // si il n'existe pas on quitte et envoie 404
			// met commandUpdateDto dans commandModelFromRepo
			_mapper.Map(locataireUpdateDto, locataireModel);

			_repository.Update(locataireModel); // update l'objet

			_repository.SaveChanges(); // sauvegarde l'état de l'objet dans la bdd

			return NoContent();
		}
	}
}
