using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;
using RestApiClient.Controllers;

namespace Wallon.Repository
{
	public class RepositoryLocataires
	{
		// singleton lazy et thread-safe
		private static readonly Lazy<RepositoryLocataires> Lazy = new Lazy<RepositoryLocataires>(() => new RepositoryLocataires());

		public static RepositoryLocataires Instance => Lazy.Value;

		private RepositoryLocataires()
		{
		}

		private static LocatairesController _apiClientController;

		private LocatairesController Controller
		{
			get
			{
				if (_apiClientController == null)
					_apiClientController = new LocatairesController();

				return _apiClientController;
			}
		}

		public async Task<IList<LocataireReadDto>> Lire()
		{
			try
			{
				return await Controller.GetAll<LocataireReadDto>();
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire les locataires : \n" + ex.Message);
			}
		}

		public async Task<LocataireReadDto> LireId(int id)
		{
			try
			{
				return await Controller.GetById<LocataireReadDto>(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire le locataire " + id + "  : \n" + ex.Message);
			}
		}

		/*public int Supprimer(int index)
		{
			try
			{
				return _gestion.Supprimer(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de supprimer le locataire avec l'id " + index + "  : \n" + ex.Message);
			}
		}*/

		public async Task<LocataireReadDto> Ajouter(LocataireCreateDto locataire)
		{
			try
			{
				return await Controller.Post<LocataireCreateDto, LocataireReadDto>(locataire);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible d'ajouter le locataire " + locataire.Nom + "  : \n" + ex.Message);
			}
		}

		public async Task Modifier(LocataireUpdateDto locataire)
		{
			try
			{
				await Controller.Update(locataire);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de modifier le locataire " + locataire.Nom + "  : \n" + ex.Message);
			}
		}
	}
}
