using Couche_Classe;
using Wallon.Core;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerAjouter
	{
		private readonly RepositoryLocataires _repositoryLocataires;

		public ControllerAjouter()
		{
			_repositoryLocataires = new RepositoryLocataires();
		}

		public void Add(string name, string password)
		{
			_repositoryLocataires.Ajouter(new Locataire(
				name,
				Cryptage.Crypt(password)
			));
		}
	}
}
