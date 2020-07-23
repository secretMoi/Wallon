using Couche_Classe;
using Models.Dtos.Locataires;
using Wallon.Core;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerAjouter
	{
		private readonly RepositoryLocataires _repositoryLocataires = RepositoryLocataires.Instance;

		public async void Add(string name, string password)
		{
			LocataireCreateDto locataireCreateDto = new LocataireCreateDto()
			{
				Nom = name,
				Password = Cryptage.Crypt(password)
			};

			await _repositoryLocataires.Ajouter(locataireCreateDto);
		}
	}
}
