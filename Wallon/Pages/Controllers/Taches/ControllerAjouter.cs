using System;
using System.Collections.Generic;
using System.Linq;
using Controls;
using Wallon.Core;
using Wallon.Fenetres;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerAjouter
	{
		private readonly RepositoryTaches _taches;
		private readonly FlatList _flatList;

		public ControllerAjouter(FlatList flatList)
		{
			_taches = new RepositoryTaches();

			_taches.Ajouter(new Couche_Classe.Taches(

				"test", DateTime.Now, true, 8, 7
			));

			_flatList = flatList;
		}

		public List<string> ListeLocataires()
		{
			return new RepositoryLocataires().Lire("id").Select(locataire => locataire.Nom).ToList();
		}

		public void Ajouter(string name, string datteDebut, string cycle, List<string> selectedItems)
		{
			if (!Formulaire.IsValid(name, datteDebut, cycle))
			{
				Dialog.Show("Le formualire n'est pas correctement rempli");
				return;
			}


		}
	}
}
