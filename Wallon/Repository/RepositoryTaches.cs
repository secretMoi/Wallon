using System;
using System.Collections.Generic;
using Couche_Classe;
using Couche_Gestion;

namespace Wallon.Repository
{
	public class RepositoryTaches
	{
		private readonly GestionTaches _gestion;

		public RepositoryTaches()
		{
			_gestion = new GestionTaches(Settings.Connection);
		}

		public List<Taches> Lire(string index)
		{
			try
			{
				return _gestion.Lire(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire les tâches : \n" + ex.Message);
			}
		}

		/*public Locataire LireId(int index)
		{
			try
			{
				return _gestion.LireId(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la tâche " + index + "  : \n" + ex.Message);
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
		}*/

		public int Ajouter(Taches tache)
		{
			try
			{
				return _gestion.Ajouter(tache);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible d'ajouter la tâche " + tache.Nom + "  : \n" + ex.Message);
			}
		}

		/*public int Modifier(Locataire locataire)
		{
			try
			{
				return _gestion.Modifier(locataire.Id, locataire.Nom, locataire.Password);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de modifier le locataire " + locataire.Nom + "  : \n" + ex.Message);
			}
		}*/

		public string NomLocataireCourant(int id)
		{
			return new RepositoryLocataires().LireId(id).Nom;
		}
	}
}
