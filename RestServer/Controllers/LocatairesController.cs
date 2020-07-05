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
		[HttpGet] // indique que cette méthode répond à une requete http
		public ActionResult<IEnumerable<LocataireReadDto>> GetAll()
		{
			IEnumerable<Locataire> locataires = _repository.GetAll();

			// mapper, mets l'objet commandItems dans CommandReadDto
			return Ok(_mapper.Map<IEnumerable<LocataireReadDto>>(locataires)); // méthode Ok définie dans controllerBase
		}

		// GET api/commands/5
		// GET api/commands/{id}
		[HttpGet("{id}", Name = "GetLocataireById")] // indique que cette méthode répond à une requete http
		public ActionResult<LocataireReadDto> GetLocataireById(int id)
		{
			Locataire locataire = _repository.GetById(id);

			if (locataire != null)
				return Ok(_mapper.Map<LocataireReadDto>(locataire)); // map commandItem en CommandReadDto pour renvoyer les données formattées au client

			return NotFound(); // si pas trouvé renvoie 404 not found
		}

		// POST api/commands
		[HttpPost]
		public ActionResult<LocataireReadDto> Create(LocataireCreateDto commandCreateDto)
		{
			Locataire locataireModel = _mapper.Map<Locataire>(commandCreateDto); // trouve le model à utiliser
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
