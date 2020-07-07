using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestServer.Data.LiaisonsTachesLocataires;
using RestServer.Data.Locataires;
using RestServer.Data.Taches;
using RestServer.Dtos.LiaisonsTachesLocataires;
using RestServer.Models;

namespace RestServer.Controllers
{
	// controllerbase, classe de base de aspnetcore qui supporte uniquement model et controller
	// controller, classe de base de aspnetcore qui supporte model et controller + vue
	// on a pas de vue ici

	//[Route("api/[controller]")] // => /api/commands (nom de la classe sans controller)
	[Route("api/liaisons")] // permet de renommer la classe sans que les clients ne soient impactés
	[ApiController] // indique que cette classe est un controller api
	public class LiaisonsController : ControllerBase
	{
		private readonly ILiaisonTacheLocataireRepo _repository; // repo sur lequel le controller va travailler
		private readonly IMapper _mapper;

		public LiaisonsController(ILiaisonTacheLocataireRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
			//_mapper = new LocatairesProfile();
		}

		// POST api/commands
		/// <summary>
		/// Enregistre une tâche en JSON dans la bdd
		/// </summary>
		/// <param name="liaisonCreateDto">Données de la tâche à enregistrer</param>
		/// <returns>Renvoie la tâche tout juste créée et encapsulée dans le status 200 OK</returns>
		[HttpPost]
		public ActionResult<LiaisonReadDto> Create(LiaisonCreateDto liaisonCreateDto)
		{
			LiaisonTacheLocataire liaison = _mapper.Map<LiaisonTacheLocataire>(liaisonCreateDto); // trouve le model à utiliser
			_repository.Create(liaison); // crée la command en ram
			_repository.SaveChanges(); // sauvegarde les changements dans la bdd

			LiaisonReadDto liaisonReadDto = _mapper.Map<LiaisonReadDto>(liaison);
			liaisonReadDto.Locataire = new LocataireRepo(_repository.Context).GetById(liaisonReadDto.LocataireId);
			liaisonReadDto.Tache = new TacheRepo(_repository.Context).GetById(liaisonReadDto.TacheId);

			//return CreatedAtRoute(nameof(GetById), new { Id = commandReadDto.Id }, commandReadDto);
			return Ok(liaisonReadDto);
		}
	}
}
