using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Couche_Classe;
using FlatControls.Controls;
using FluentValidation.Results;
using Wallon.Controllers;
using Wallon.Controllers.BaseConsulter;
using Wallon.Controllers.Validators;
using Wallon.Core;
using Wallon.Fenetres;
using Wallon.Pages.Vue.Taches;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerAjouter
	{
		private readonly RepositoryTaches _taches;
		private readonly RepositoryLiaisonTachesLocataires _liaison;
		private readonly Ajouter _page;

		public ControllerAjouter(Ajouter page)
		{
			_page = page;
			_taches = new RepositoryTaches();
			_liaison = new RepositoryLiaisonTachesLocataires();
		}

		public int? IdTache { get; set; }

		/// <summary>
		/// Initialise les colonnes de la dgv
		/// </summary>
		public void InitColonnes()
		{
			_page.SetColonnes("Id", "Locataire", "Inclu");
			_page.FlatDataGridView.HideColonne("Id");
			_page.EnableColumn(
				("Ajouter", ColonnesCliquables.Cliquable.Add),
				("Supprimer", ColonnesCliquables.Cliquable.Delete),
				("Monter", ColonnesCliquables.Cliquable.Up),
				("Descendre", ColonnesCliquables.Cliquable.Down)
			);
			_page.AddColumnsFill(("Locataire", DataGridViewAutoSizeColumnMode.Fill));
		}

		/// <summary>
		/// Initialise les données de la dgv
		/// </summary>
		public void FillDgv()
		{
			List<Locataire> locataires = new RepositoryLocataires().Lire("id"); // récupère les données dans la bdd

			foreach (Locataire locataire in locataires) // les lie à la dgv
				_page.FillDgv(
					locataire.Id,
					locataire.Nom,
					"Non"
				);
		}

		/// <summary>
		/// Modifie le champ inclu dans la dgv lors de la modification
		/// </summary>
		public void UpdateDgv(object sender, EventArgs e)
		{
			List<int> locatairesInclus = _liaison.ListeLocataires((int) IdTache); // récupère la liste des locataires inclus dans la tâche

			for (int i = 0; i < _page.FlatDataGridView.Rows.Count; i++) // parcours la dgv
			{
				// récupère l'id du locataire dans la colonne masquée Id
				int idLocaire = int.Parse(
					_page.FlatDataGridView.Get(
						i,
						"Id"
					));

				if (locatairesInclus.Contains(idLocaire)) // si un locataire de la tâche dans la bdd est dans la dgv
				{
					_page.FlatDataGridView.Set(i, "Inclu", "Oui"); // indique le ce locataire est inclu
					_page.FlatDataGridView.SwapRow(i, locatairesInclus.IndexOf(idLocaire)); // remet les locataires dans l'odre choisi
				}
			}
		}

		/// <summary>
		/// Permet d'ajouter une tâche et sa liaison
		/// </summary>
		/// <param name="name">Nom de la tâche</param>
		/// <param name="datte">Datte de début de la tâche</param>
		/// <param name="cycleInput">Cycle en jours pour répéter la tâche</param>
		public void Envoyer(string name, string datte, string cycleInput)
		{
			DateTime datteDebut = default;
			int cycle = 0;
			List<int> idLocataires = new List<int>();
			if (!ValidateInput(name, datte, cycleInput, ref datteDebut, ref cycle, idLocataires)) return;

			if(IdTache == null) // mode ajout
				Ajouter(name, datteDebut, cycle, idLocataires);
			else // mode update
			{
				Supprimer();
				Ajouter(name, datteDebut, cycle, idLocataires);
			}
		}

		private bool ValidateInput(string name, string datte, string cycleInput, ref DateTime datteDebut, ref int cycle, List<int> idLocataires)
		{
			if (!Formulaire.IsValid(name, datte, cycleInput))
			{
				Dialog.Show("Le formulaire n'est pas correctement rempli");
				return false;
			}

			try
			{
				datteDebut = Convert.ToDateTime(datte);
			}
			catch
			{
				Dialog.Show("La datte " + datte + " n'est pas valide");
				return false;
			}

			if (!int.TryParse(cycleInput, out cycle))
			{
				Dialog.Show("Le cycle " + cycleInput + " n'est pas valide");
				return false;
			}

			FlatDataGridView flatDataGridView = _page.FlatDataGridView;
			// récupère la liste des id des locataires inclus dans la dgv
			for (int i = 0; i < flatDataGridView.Rows.Count; i++)
			{
				if (flatDataGridView.Get(i, (int)flatDataGridView.GetColumnId("Inclu")) == "Oui")
					idLocataires.Add(
						Convert.ToInt32(flatDataGridView.Get(i, (int)flatDataGridView.GetColumnId("Id")))
					);
			}

			if (idLocataires.Count == 0)
			{
				Dialog.Show("Aucun locataire sélectionné !");
				return false;
			}

			return true;
		}

		private void Ajouter(string name, DateTime datteDebut, int cycle, List<int> idLocataires)
		{
			// Crée la tâche
			Couche_Classe.Taches tache = new Couche_Classe.Taches(
				name,
				datteDebut,
				true,
				idLocataires[0],
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
			foreach (int idSelected in idLocataires)
				_liaison.Ajouter(
					idSelected,
					idTache
				);

			Dialog.Show("La tâche " + name + " a bien été ajoutée");
		}

		private void Supprimer()
		{
			List<int> liaisonsASupprimer = _liaison.ListeLocataires((int) IdTache);
			foreach (int liaison in liaisonsASupprimer)
			{
				_liaison.Supprimer(liaison);
			}

			_taches.Supprimer((int) IdTache);
		}

		/// <summary>
		/// Trouve la date d'aujourd'hui
		/// </summary>
		/// <returns>Renvoie une chaine de caractère représentant uniquement la date d'aujourd'hui</returns>
		public string FillFieldDate()
		{
			return DateTime.Now.ToShortDateString();
		}

		/// <summary>
		/// Récupère une tâche grâce à son id dans la base de données
		/// </summary>
		public Couche_Classe.Taches GetTache()
		{
			return _taches.LireId((int) IdTache);
		}

		/// <summary>
		/// Trouve le locataire grâce à son id
		/// </summary>
		/// <param name="idLocataire">Id du locataire à récupérer</param>
		/// <returns>Le nom du locataire</returns>
		public string FillFieldLocataireCourant(int idLocataire)
		{
			return new ControllerLocataires().GetById(idLocataire).Nom;
		}


		/// <summary>
		/// Récupère la liste des locataires associés à une tâche
		/// </summary>
		/// <returns>Tableau des noms des locataires</returns>
		public string[] FillListLocataireCourant()
		{
			List<int> listeIdLocataires = _liaison.ListeLocataires((int) IdTache);

			List<Locataire> listeLocataires = new List<Locataire>(listeIdLocataires.Count);

			foreach (int idLocataire in listeIdLocataires)
				listeLocataires.Add(new ControllerLocataires().GetById(idLocataire));

			return listeLocataires.Select(x => x.Nom).ToArray();
		}

		/// <summary>
		/// Actions à effectuer lors du clic sur les colonnes cliquables
		/// </summary>
		public void Clic(object sender, DataGridViewCellMouseEventArgs e)
		{
			int ligne = e.RowIndex;
			int colonne = e.ColumnIndex;

			FlatDataGridView flatDataGridView = _page.FlatDataGridView;

			if (colonne == flatDataGridView.GetColumnId("Ajouter")) // si la colonne cliquée correspond
			{
				flatDataGridView.Set(ligne, (int) flatDataGridView.GetColumnId("Inclu"), "Oui");
			}
			if (colonne == flatDataGridView.GetColumnId("Supprimer")) // si la colonne cliquée correspond
			{
				flatDataGridView.Set(ligne, (int)flatDataGridView.GetColumnId("Inclu"), "Non");
			}
		}
	}
}
