using System.Collections.Generic;
using Wallon.Repository;

namespace Wallon.Controllers
{
	public class ControllerTaches
	{
		public ControllerTaches()
		{

		}

		public int LocataireSuivant(int locataireActuel)
		{
			List<int> liaison = new RepositoryLiaisonTachesLocataires().LireTache(locataireActuel);

			int indexActuel = liaison.IndexOf(locataireActuel); // todo throw si pas contenu (-1)

			int prochainLocataire = ProchainLocataire(indexActuel, liaison);

			return 0;
		}

		private int ProchainLocataire(int indexActuel, List<int> listeLocataires)
		{
			if (indexActuel + 1 < listeLocataires.Count)
				return listeLocataires[indexActuel + 1];

			return listeLocataires[0];
		}
	}
}
