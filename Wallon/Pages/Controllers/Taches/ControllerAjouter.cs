using System;
using System.Collections.Generic;
using System.Linq;
using Controls;
using Couche_Classe;
using Wallon.Core;
using Wallon.Fenetres;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerAjouter
	{
		private readonly RepositoryTaches _taches;
		private readonly FlatList _flatList;
		private readonly List<(int, int)> _associeIdListAndLocataires; // id1 ordre, id2 id réel bdd

		public ControllerAjouter(FlatList flatList)
		{
			_flatList = flatList;
			_taches = new RepositoryTaches();
			_associeIdListAndLocataires = new List<(int, int)>();

			_taches.Ajouter(new Couche_Classe.Taches(

				"test", DateTime.Now, true, 8, 7
			));
		}

		public List<string> ListeLocataires()
		{
			List<Locataire> locataires = new RepositoryLocataires().Lire("id");
			List<string> noms = new List<string>();
			//List<string> locataires = new RepositoryLocataires().Lire("id").Select(locataire => locataire.Nom).ToList();

			for (int i = 0; i < locataires.Count; i++)
			{
				_associeIdListAndLocataires.Add((
					i,
					locataires[i].Id
					));

				noms.Add(locataires[i].Nom);
			}

			return noms;
		}

		public void Ajouter(string name, string datte, string cycleInput, List<int> selectedId)
		{
			if (!Formulaire.IsValid(name, datte, cycleInput) || selectedId.Count <1)
			{
				Dialog.Show("Le formulaire n'est pas correctement rempli");
				return;
			}

			DateTime datteDebut;
			try
			{
				datteDebut = Convert.ToDateTime(datte);
			}
			catch
			{
				Dialog.Show("La datte " + datte + " n'est pas valide");
				return;
			}

			if (!int.TryParse(cycleInput, out int cycle))
			{
				Dialog.Show("Le cycle " + cycleInput + " n'est pas valide");
				return;
			}
			
			// Ajout la tache dans la bdd
			Couche_Classe.Taches tache = new Couche_Classe.Taches(
				name,
				datteDebut,
				true,
				_associeIdListAndLocataires[selectedId[0]].Item2,
				cycle
			);
			int idTache = _taches.Ajouter(tache);

			// Ajout les locataires à la tâche
			/*foreach ((int, int) locataire in _associeIdListAndLocataires)
				new RepositoryLiaisonTachesLocataires().Ajouter(locataire, idTache);*/

			/*for (int i = 0; i < selectedId.Count; i++)
			{
				new RepositoryLiaisonTachesLocataires().Ajouter(
					_associeIdListAndLocataires[i].Item2,
					idTache
				);
			}*/

			foreach (int idSelected in selectedId)
				new RepositoryLiaisonTachesLocataires().Ajouter(
					_associeIdListAndLocataires[idSelected].Item2,
					idTache
				);

			Dialog.Show("La tâche " + name + " a bien été ajoutée");
		}
	}
}
