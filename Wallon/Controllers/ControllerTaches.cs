using System;
using System.Collections.Generic;
using Wallon.Repository;

namespace Wallon.Controllers
{
	public class ControllerTaches
	{
		public ControllerTaches()
		{

		}

		public int LocataireSuivant(int idTache)
		{
			List<int> liaison = new RepositoryLiaisonTachesLocataires().LireTache(idTache);

			int indexActuel = liaison.IndexOf(Settings.IdLocataire);
			if(indexActuel == -1)
				throw new Exception("Le locataire " + indexActuel + " n'est pas dans la tâche " + idTache);

			return ProchainLocataire(indexActuel, liaison);
		}

		private int ProchainLocataire(int indexActuel, List<int> listeLocataires)
		{
			if (indexActuel + 1 < listeLocataires.Count)
				return listeLocataires[indexActuel + 1];

			return listeLocataires[0];
		}
	}
}
