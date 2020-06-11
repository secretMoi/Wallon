using System;
using System.Collections.Generic;
using Couche_Classe;
using Couche_Gestion;

namespace Wallon.Pages.Repository
{
	public class RepositoryLocataires
	{
		private readonly Gestion_Locataire _gestion;

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

		public Locataire LireId(int index)
		{
			try
			{
				return _gestion.LireId(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire le locataire " + index + "  : \n" + ex.Message);
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
				return _gestion.Ajouter(locataire.Nom, locataire.Password);
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
	}
}
