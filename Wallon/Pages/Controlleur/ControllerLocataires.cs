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

		public Locataire Existe(string nom)
		{
			List<Locataire> locataires = new RepositoryLocataires().Lire("id");

			foreach (Locataire locataire in locataires)
				if (locataire.Nom == nom)
					return locataire;

			return null;
		}

		public bool Authentifie(string nom, string password)
		{
			Locataire locataire = Existe(nom);
			if (locataire == null) return false;

			return locataire.Password == password;
		}

		public Locataire GetById(int id)
		{
			return new RepositoryLocataires().LireId(id);
		}
	}
}
