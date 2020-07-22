using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couche_Classe;
using Couche_Gestion;
using Models.Dtos.Locataires;
using RestApiClient.Controllers;

namespace Wallon.Repository
{
	public class RepositoryLocataires
	{
		private readonly Gestion_Locataire _gestion;
		private static LocatairesController _locatairesController;

		private LocatairesController Controller
		{
			get
			{
				if (_locatairesController == null)
					_locatairesController = new LocatairesController();

				return _locatairesController;
			}
			
		}

		public RepositoryLocataires()
		{
			_gestion = new Gestion_Locataire(Settings.Connection);
		}

		public List<Locataire> Lire(string index)
		{
			try
			{
				return _gestion.Lire(index);
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

		public int Supprimer(int index)
		{
			try
			{
				return _gestion.Supprimer(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de supprimer le locataire avec l'id " + index + "  : \n" + ex.Message);
			}
		}

		public int Ajouter(Locataire locataire)
		{
			try
			{
				return _gestion.Ajouter(
					locataire.Nom,
					locataire.Password
				);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible d'ajouter le locataire " + locataire.Nom + "  : \n" + ex.Message);
			}
		}

		public int Modifier(Locataire locataire)
		{
			try
			{
				return _gestion.Modifier(locataire.Id, locataire.Nom, locataire.Password);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de modifier le locataire " + locataire.Nom + "  : \n" + ex.Message);
			}
		}
		public int Modifier(int id, string nom, byte[] password)
		{
			return Modifier(new Locataire(id, nom, password));
		}
	}
}
