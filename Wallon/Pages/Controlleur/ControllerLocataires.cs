using System.Collections.Generic;
using Couche_Classe;
using Wallon.Pages.Repository;

namespace Wallon.Pages.Controlleur
{
	public class ControllerLocataires
	{
		public ControllerLocataires()
		{
			
		}

		public bool LocataireExiste(string nom)
		{
			List<Locataire> locataires = new RepositoryLocataires().Lire("id");

			foreach (Locataire locataire in locataires)
				if (locataire.Nom == nom)
					return true;

			return false;
		}

		public Locataire GetById(int id)
		{
			return new RepositoryLocataires().LireId(id);
		}
    }
}
