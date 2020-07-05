using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestServer.Data.Locataires;
using RestServer.Data.Taches;
using RestServer.Dtos.Taches;
using RestServer.Models;

namespace RestServer.Controllers
{
	// controllerbase, classe de base de aspnetcore qui supporte uniquement model et controller
	// controller, classe de base de aspnetcore qui supporte model et controller + vue
	// on a pas de vue ici

	//[Route("api/[controller]")] // => /api/commands (nom de la classe sans controller)
	[Route("api/taches")] // permet de renommer la classe sans que les clients ne soient impactés
	[ApiController] // indique que cette classe est un controller api
	public class TachesController : ControllerBase
	{
		private readonly ITacheRepo _repository; // repo sur lequel le controller va travailler
		private readonly IMapper _mapper;

		public TachesController(ITacheRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
			//_mapper = new LocatairesProfile();
		}

		// GET api/commands
		[HttpGet] // indique que cette méthode répond à une requete http
		public ActionResult<IEnumerable<TacheReadDto>> GetAll()
		{
			IEnumerable<Tache> taches = _repository.GetAll();

			// mapper, mets l'objet commandItems dans CommandReadDto
			return Ok(_mapper.Map<IEnumerable<TacheReadDto>>(taches)); // méthode Ok définie dans controllerBase
		}

		// GET api/commands/5
		// GET api/commands/{id}
		[HttpGet("{id}", Name = "GetTacheById")] // indique que cette méthode répond à une requete http
		public ActionResult<TacheReadDto> GetTacheById(int id)
		{
			Tache tache = _repository.GetById(id);

			if (tache != null)
				return Ok(_mapper.Map<TacheReadDto>(tache)); // map commandItem en CommandReadDto pour renvoyer les données formattées au client

			return NotFound(); // si pas trouvé renvoie 404 not found
		}

		// POST api/commands
		[HttpPost]
		public ActionResult<TacheReadDto> Create(TacheCreateDto tacheCreateDto)
		{
			Tache tache = _mapper.Map<Tache>(tacheCreateDto); // trouve le model à utiliser
			_repository.Create(tache); // crée la command en ram
			_repository.SaveChanges(); // sauvegarde les changements dans la bdd

			// mapper, mets l'objet commandModel dans CommandReadDto
			TacheReadDto tacheReadDto = _mapper.Map<TacheReadDto>(tache);
			tacheReadDto.LocataireCourant = new LocataireRepo(_repository.Context).GetById(tacheReadDto.LocataireId);


			// renvoie l'uri permettant d'accéder à l'élément créé
			// fonction gérant la route à appeler (GET api/commands/{id})
			// paramètre à passer à la route (l'id créé)
			// classe pour formatter les données
			//return CreatedAtRoute(nameof(GetById), new { Id = commandReadDto.Id }, commandReadDto);
			return Ok(tacheReadDto);
		}

		// PUT api/commands/{id}
		[HttpPut("{id}")]
		public ActionResult Update(int id, TacheUpdateDto tacheUpdateDto)
		{
			Tache tache = _repository.GetById(id); // cherche l'objet dans la bdd
			if (tache == null)
				return NotFound(); // si il n'existe pas on quitte et envoie 404
			// met commandUpdateDto dans commandModelFromRepo
			_mapper.Map(tacheUpdateDto, tache);

			_repository.Update(tache); // update l'objet

			_repository.SaveChanges(); // sauvegarde l'état de l'objet dans la bdd

			return NoContent();
		}
	}
}
