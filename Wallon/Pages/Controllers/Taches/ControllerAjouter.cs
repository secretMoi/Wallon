using System;
using System.Collections.Generic;
using Couche_Classe;
using FluentValidation.Results;
using Wallon.Controllers.Validators;
using Wallon.Core;
using Wallon.Fenetres;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerAjouter
	{
		private readonly RepositoryTaches _taches;
		private readonly List<(int, int)> _associeIdListAndLocataires; // id1 ordre, id2 id réel bdd

		public ControllerAjouter()
		{
			_taches = new RepositoryTaches();
			_associeIdListAndLocataires = new List<(int, int)>();
		}

		/// <summary>
		/// Génère une liste complète des noms de locataires, associe l'id d'ordre de la flatlist avec l'id des locataires
		/// </summary>
		/// <returns>Liste des noms des locataires</returns>
		public List<string> ListeLocataires()
		{
			List<Locataire> locataires = new RepositoryLocataires().Lire("id");
			List<string> noms = new List<string>();

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

		/// <summary>
		/// Permet d'ajouter une tâche et sa liaison
		/// </summary>
		/// <param name="name">Nom de la tâche</param>
		/// <param name="datte">Datte de début de la tâche</param>
		/// <param name="cycleInput">Cycle en jours pour répéter la tâche</param>
		/// <param name="selectedId">Liste des id de la FlatList sélectionnés</param>
		public void Ajouter(string name, string datte, string cycleInput, List<int> selectedId)
		{
			if (!Formulaire.IsValid(name, datte, cycleInput) || selectedId.Count < 1)
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

			// Crée la tâche
			Couche_Classe.Taches tache = new Couche_Classe.Taches(
				name,
				datteDebut,
				true,
				_associeIdListAndLocataires[selectedId[0]].Item2,
				cycle
			);

			// validation des données
			ValidationResult result = new TacheValidator().Validate(tache);
			if (!result.IsValid)
			{
				Dialog.Show($"{result.Errors[0].PropertyName} : {result.Errors[0].ErrorMessage}");
				return;
			}

			// Ajout de la tâche à la bdd
			int idTache = _taches.Ajouter(tache);

			// Ajout les locataires à la tâche dans la bdd (table liaison)
			foreach (int idSelected in selectedId)
				new RepositoryLiaisonTachesLocataires().Ajouter(
					_associeIdListAndLocataires[idSelected].Item2,
					idTache
				);

			Dialog.Show("La tâche " + name + " a bien été ajoutée");
		}

		public string FillFieldDate()
		{
			return DateTime.Now.ToShortDateString();
		}
	}
}
