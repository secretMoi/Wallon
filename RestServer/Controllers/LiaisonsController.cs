using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestServer.Data.LiaisonsTachesLocataires;
using RestServer.Data.Locataires;
using RestServer.Data.Taches;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Locataires;
using Models.Models;

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

		// GET api/commands/5
		// GET api/commands/{id}
		/// <summary>
		/// Récupère une liaison via son id sous format JSON
		/// </summary>
		/// <param name="id">Id de la liaison</param>
		/// <returns>Renvoie une liaison encapsulée dans le status 200 OK<br />
		/// Renvoie le status NotFound 404 si la liaison n'est pas trouvée</returns>
		[HttpGet("{id:int}", Name = "GetLiaisonById")] // indique que cette méthode répond à une requete http
		public ActionResult<LiaisonReadDto> GetLiaisonById(int id)
		{
			LiaisonTacheLocataire liaison = _repository.GetById(id);

			if (liaison == null)
				return NotFound(); // si pas trouvé renvoie 404 not found

			LiaisonReadDto liaisonReadDto = _mapper.Map<LiaisonReadDto>(liaison);
			liaisonReadDto.Locataire = new LocataireRepo(_repository.Context).GetById(liaisonReadDto.LocataireId);
			liaisonReadDto.Tache = new TacheRepo(_repository.Context).GetById(liaisonReadDto.TacheId);

			return Ok(liaisonReadDto); // map commandItem en CommandReadDto pour renvoyer les données formattées au client
		}


		// GET api/commands/fromTache/5
		// GET api/commands/fromTache/{idTache}
		/// <summary>
		/// Récupère les locataires enregistré dans une tâche transmise en paramètre
		/// </summary>
		/// <param name="idTache">Id de la tâche</param>
		/// <returns>Renvoie une liste de locataires encapsulée dans le status 200 OK</returns>
		[HttpGet("fromTache/{idTache:int}", Name = "FromTache")] // indique que cette méthode répond à une requete http
		public ActionResult<IEnumerable<LocataireReadDto>> FromTache(int idTache)
		{
			// todo potimiser req
			List<LiaisonTacheLocataire> liaisonReadDtos = _repository
				.GetAll()
				.ToList(); // récupère toutes les liaisons
			
			liaisonReadDtos = liaisonReadDtos.FindAll(l => l.TacheId == idTache); // ne garde que celles correspondantes au param

			IList<LocataireReadDto> locataires = new List<LocataireReadDto>();
			foreach (LiaisonTacheLocataire liaison in liaisonReadDtos)
				locataires.Add(_mapper.Map<LocataireReadDto>(liaison.Locataire));

			return Ok(locataires);
		}

		// POST api/commands
		/// <summary>
		/// Enregistre une liaison en JSON dans la bdd
		/// </summary>
		/// <param name="liaisonCreateDto">Données de la liaison à enregistrer</param>
		/// <returns>Renvoie la liaison tout juste créée et encapsulée dans le status 200 OK</returns>
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

		// DELETE api/commands/{id}
		/// <summary>
		/// Supprime une liaison de la bdd par son id
		/// </summary>
		/// <param name="id">Id de la liaison à supprimer</param>
		/// <returns>Renvoie 204 NoContent si supprimé, 404 NotFound si l'id de la liaison n'existe pas dans la bdd</returns>
		[HttpDelete("{id:int}")]
		public ActionResult DeleteCommand(int id)
		{
			LiaisonTacheLocataire liaisonTacheLocataire = _repository.GetById(id); // cherche l'objet dans la bdd
			if (liaisonTacheLocataire == null)
				return NotFound(); // si il n'existe pas on quitte et envoie 404

			_repository.Delete(liaisonTacheLocataire); // supprime l'id dans l'objet
			_repository.SaveChanges(); // sauvegarde dans la bdd

			return NoContent();
		}
	}
}
