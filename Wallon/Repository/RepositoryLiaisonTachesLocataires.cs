using System;
using System.Collections.Generic;
using Couche_Classe;
using Couche_Gestion;

namespace Wallon.Repository
{
	public class RepositoryLiaisonTachesLocataires
	{
		private readonly GestionLiaisonTachesLocataires _gestion;

		public RepositoryLiaisonTachesLocataires()
		{
			_gestion = new GestionLiaisonTachesLocataires(Settings.Connection);
		}

		public List<LiaisonTachesLocataires> Lire(string index)
		{
			try
			{
				return _gestion.Lire(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la liaison : \n" + ex.Message);
			}
		}

		public List<int> LireTache(int idTache)
		{
			try
			{
				return _gestion.LireTache(idTache);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la liaison : \n" + ex.Message);
			}
		}

		public int Ajouter(LiaisonTachesLocataires liaison)
		{
			try
			{
				return _gestion.Ajouter(liaison);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible d'ajouter la liason : \n" + ex.Message);
			}
		}

		public int Ajouter(int locataire, int tache)
		{
			return Ajouter(new LiaisonTachesLocataires(locataire, tache));
		}
	}
}
