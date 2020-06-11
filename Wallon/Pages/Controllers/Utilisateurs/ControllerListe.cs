using System.Collections.Generic;
using Core;
using Couche_Classe;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerListe
	{
		private readonly RepositoryLocataires _locataire;

		public ControllerListe()
		{
			_locataire = new RepositoryLocataires();
		}

		public string[] ListeColonnes()
		{
			/*List<(string, Type)> locataire = new Locataire().GetChamps();
			string[] listeColonnes = new string[locataire.Count];

			for (int i = 0; i < locataire.Count; i++)
				listeColonnes[i] = locataire[i].Item1;*/

			return new []{"Nom"};
		}

		public void GetData(UseGridView useGridView)
		{
			List<Locataire> locataires = _locataire.Lire("id");

			foreach (Locataire locataire in locataires)
			{

				useGridView.Add(
					locataire.Nom
				);
			}
		}
	}
}
