using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestServer.Data.LiaisonsTachesLocataires;
using RestServer.Data.Locataires;
using RestServer.Data.Taches;
using Models.Dtos.Taches;
using Models.Models;

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
		private ILocataireRepo _locataireRepo;

		public TachesController(ITacheRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
			//_mapper = new LocatairesProfile();
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

		// GET api/taches
		/// <summary>
		/// Récupère tous les enregistrements des taches sous format JSON
		/// </summary>
		/// <returns>Renvoie une liste des taches encapsulées dans le status 200 OK</returns>
		[HttpGet] // indique que cette méthode répond à une requete http
		public ActionResult<IEnumerable<TacheReadDto>> GetAll()
		{
			IEnumerable<Tache> taches = _repository.GetAll();

			return Ok(_mapper.Map<IEnumerable<TacheReadDto>>(taches)); // méthode Ok définie dans controllerBase
		}

		// GET api/taches/5
		// GET api/taches/{id}
		/// <summary>
		/// Récupère une tâche via son id sous format JSON
		/// </summary>
		/// <param name="id">Id de la tâche</param>
		/// <returns>Renvoie une tâche encapsulée dans le status 200 OK<br />
		/// Renvoie le status NotFound 404 si la tâche n'est pas trouvée</returns>
		[HttpGet("{id:int}", Name = "GetTacheById")] // indique que cette méthode répond à une requete http
		public ActionResult<TacheReadDto> GetTacheById(int id)
		{
			Tache tache = _repository.GetById(id);

			if (tache != null)
				return Ok(_mapper.Map<TacheReadDto>(tache)); // map commandItem en CommandReadDto pour renvoyer les données formattées au client

			return NotFound(); // si pas trouvé renvoie 404 not found
		}

		// GET api/taches/duLocataire/5
		// GET api/taches/duLocataire/{id}
		/// <summary>
		/// Récupère la liste des tâches du locataire selon son ID
		/// </summary>
		/// <param name="id">Id du locataire</param>
		/// <returns>Renvoie une liste de tâches encapsulée dans le status 200 OK<br />
		/// Renvoie le status NotFound 404 si le locataire n'est pas trouvé</returns>
		[HttpGet("duLocataire/{id:int}", Name = "GetTachesDuLocataire")] // indique que cette méthode répond à une requete http
		public async Task<ActionResult<IEnumerable<TacheReadDto>>> GetTachesDuLocataire(int id)
		{
			Locataire locataire = InstanceLocataire.GetById(id);

			if (locataire == null)
				return NotFound($"Locataire {id} introuvable"); // si pas trouvé renvoie 404 not found

			// récupère toutes les tâches où le locataire est inscrit
			IList<LiaisonTacheLocataire> liaisons = await
				new LiaisonTacheLocataireRepo(_repository.Context).GetTachesFromLocataire(id) 
					as IList<LiaisonTacheLocataire>;

			if (liaisons == null) // si le locataire n'existe pas
				return Content("Liste de liaisons nulle");

			IList<TacheReadDto> tachesReadDtos = new List<TacheReadDto>(liaisons.Count);

			foreach (LiaisonTacheLocataire liaison in liaisons)
			{
				var tacheReadDto = new TacheReadDto();
				_mapper.Map(liaison.Tache, tacheReadDto);

				if(tacheReadDto.LocataireId == id) // si le locataire actuel est celui renseigné en paramètre
					tachesReadDtos.Add(tacheReadDto);
			}

			return Ok(tachesReadDtos);
		}

		// POST api/taches
		/// <summary>
		/// Enregistre une tâche en JSON dans la bdd
		/// </summary>
		/// <param name="tacheCreateDto">Données de la tâche à enregistrer</param>
		/// <returns>Renvoie la tâche tout juste créée et encapsulée dans le status 200 OK</returns>
		[HttpPost]
		public ActionResult<TacheReadDto> Create(TacheCreateDto tacheCreateDto)
		{
			Tache tache = _mapper.Map<Tache>(tacheCreateDto); // trouve le model à utiliser
			_repository.Create(tache); // crée la command en ram
			_repository.SaveChanges(); // sauvegarde les changements dans la bdd

			TacheReadDto tacheReadDto = _mapper.Map<TacheReadDto>(tache);
			tacheReadDto.Locataire = InstanceLocataire.GetById(tacheReadDto.LocataireId);

			//return CreatedAtRoute(nameof(GetById), new { Id = commandReadDto.Id }, commandReadDto);
			return Ok(tacheReadDto);
		}

		// PUT api/taches/{id}
		/// <summary>
		/// Modifie toutes les données d'une tâche selon son id
		/// </summary>
		/// <param name="id">Id de la tâche</param>
		/// <param name="tacheUpdateDto">Données de la tâche à enregistrer</param>
		/// <returns>Renvoie le status 204 NoContent <br />
		/// Renvoie le status 404 NotFound si l'id de la tâche n'existe pas
		/// </returns>
		[HttpPut("{id:int}")]
		public ActionResult Update(int id, TacheUpdateDto tacheUpdateDto)
		{
			Tache tache = _repository.GetById(id); // cherche l'objet dans la bdd
			if (tache == null)
				return NotFound(); // si il n'existe pas on quitte et envoie 404
			
			_mapper.Map(tacheUpdateDto, tache); // met commandUpdateDto dans commandModelFromRepo

			_repository.Update(tache); // update l'objet

			_repository.SaveChanges(); // sauvegarde l'état de l'objet dans la bdd

			return NoContent();
		}

		// DELETE api/commands/{id}
		/// <summary>
		/// Supprime une tache via son id
		/// </summary>
		/// <param name="id">Id de la tâche à supprimer</param>
		/// <returns>Renvoie 204 NoContent si supprimé, 404 NotFound si l'id de la tâche n'existe pas dans la bdd</returns>
		[HttpDelete("{id:int}")]
		public ActionResult DeleteCommand(int id)
		{
			Tache tache = _repository.GetById(id); // cherche l'objet dans la bdd
			if (tache == null)
				return NotFound(); // si il n'existe pas on quitte et envoie 404

			_repository.Delete(tache); // supprime l'id dans l'objet
			_repository.SaveChanges(); // sauvegarde dans la bdd

			return NoContent();
		}
	}
}
