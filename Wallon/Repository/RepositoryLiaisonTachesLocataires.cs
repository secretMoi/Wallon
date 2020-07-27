using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couche_Classe;
using Couche_Gestion;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using RestApiClient.Controllers;

namespace Wallon.Repository
{
	public class RepositoryLiaisonTachesLocataires
	{
		// singleton lazy et thread-safe
		private static readonly Lazy<RepositoryLiaisonTachesLocataires> Lazy = new Lazy<RepositoryLiaisonTachesLocataires>(() => new RepositoryLiaisonTachesLocataires());

		public static RepositoryLiaisonTachesLocataires Instance => Lazy.Value;

		private RepositoryLiaisonTachesLocataires()
		{
		}

		private static LiaisonsController _apiClientController;

		private LiaisonsController Controller
		{
			get
			{
				if (_apiClientController == null)
					_apiClientController = new LiaisonsController();

				return _apiClientController;
			}
		}

		/*private readonly GestionLiaisonTachesLocataires _gestion;

		public RepositoryLiaisonTachesLocataires()
		{
			_gestion = new GestionLiaisonTachesLocataires(Settings.Connection);
		}*/

		/*public List<LiaisonTachesLocataires> Lire(string index)
		{
			try
			{
				return _gestion.Lire(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la liaison : \n" + ex.Message);
			}
		}*/

		public async Task Supprimer(int id)
		{
			try
			{
				await Controller.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception($"Impossible de supprimer l'id de liaison : {id} \n" + ex.Message);
			}
		}

		/*public List<int> LireTachesLocataire(int idLocataire)
		{
			try
			{
				return _gestion.LireTachesLocataire(idLocataire);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la liaison : \n" + ex.Message);
			}
		}*/

		public async Task<IList<LocataireReadDto>> ListeLocataires(int idTache)
		{
			try
			{
				return await Controller.ListeLocataires(idTache);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la liaison : \n" + ex.Message);
			}
		}

		public async Task<TacheReadDto> Ajouter(LiaisonCreateDto liaison)
		{
			try
			{
				return await Controller.Post<LiaisonCreateDto, TacheReadDto>(liaison);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible d'ajouter la liason : \n" + ex.Message);
			}
		}

		public async Task<TacheReadDto> Ajouter(int locataire, int tache)
		{
			LiaisonCreateDto liaison = new LiaisonCreateDto()
			{
				LocataireId = locataire,
				TacheId = tache
			};

			return await Ajouter(liaison);
		}
	}
}
