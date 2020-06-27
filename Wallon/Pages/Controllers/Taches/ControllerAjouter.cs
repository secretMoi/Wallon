using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Couche_Classe;
using FlatControls.Controls;
using FluentValidation.Results;
using Wallon.Controllers;
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
		//private readonly List<(int, int)> _associeIdListAndLocataires; // id1 ordre, id2 id réel bdd
		private readonly Ajouter _page;

		public ControllerAjouter(Ajouter page)
		{
			_page = page;
			_taches = new RepositoryTaches();
			//_associeIdListAndLocataires = new List<(int, int)>();
		}

		/// <summary>
		/// Initialise les colonnes de la dgv
		/// </summary>
		public void InitColonnes()
		{
			_page.SetColonnes("Id", "Locataire", "Inclu");
			_page.FlatDataGridView.HideColonne("Id");
			_page.EnableColumn("valider", "supprimer", "up", "down");
			_page.AddColumnsFill(("Locataire", DataGridViewAutoSizeColumnMode.Fill));
		}

		/// <summary>
		/// Initialise les données de la dgv
		/// </summary>
		public void FillDgv()
		{
			List<Locataire> locataires = new RepositoryLocataires().Lire("id"); // récupère les données dans la bdd

			foreach (Locataire locataire in locataires) // les lie à la dgv
				_page._useGridView.Add(
					locataire.Id,
					locataire.Nom,
					"Non",
					_page.ImageValider,
					_page.ImageSupprimer,
					_page.ImageUp,
					_page.ImageDown
				);
		}

		/// <summary>
		/// Permet d'ajouter une tâche et sa liaison
		/// </summary>
		/// <param name="name">Nom de la tâche</param>
		/// <param name="datte">Datte de début de la tâche</param>
		/// <param name="cycleInput">Cycle en jours pour répéter la tâche</param>
		public void Ajouter(string name, string datte, string cycleInput)
		{
			if (!Formulaire.IsValid(name, datte, cycleInput))
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

			FlatDataGridView flatDataGridView = _page.FlatDataGridView;

			// récupère la liste des id des locataires inclus dans la dgv
			List<int> idLocataires = new List<int>();
			for (int i = 0; i < flatDataGridView.Rows.Count; i++)
			{
				if(flatDataGridView.Get(i, (int)flatDataGridView.GetColumnId("Inclu")) == "Oui" )
					idLocataires.Add(
						Convert.ToInt32(flatDataGridView.Get(i, (int) flatDataGridView.GetColumnId("Id")))
					);
			}

			if (idLocataires.Count == 0)
			{
				Dialog.Show("Aucun locataire sélectionné !");
				return;
			}

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
				new RepositoryLiaisonTachesLocataires().Ajouter(
					idSelected,
					idTache
				);

			Dialog.Show("La tâche " + name + " a bien été ajoutée");
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
		/// <param name="idTache">Id de la tâche à trouver</param>
		public Couche_Classe.Taches GetTache(int idTache)
		{
			return _taches.LireId(idTache);
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
		/// <param name="idTache">Id de la tâche</param>
		/// <returns>Tableau des noms des locataires</returns>
		public string[] FillListLocataireCourant(int idTache)
		{
			List<int> listeIdLocataires = new RepositoryLiaisonTachesLocataires().ListeLocataires(idTache);

			List<Locataire> listeLocataires = new List<Locataire>(listeIdLocataires.Count);

			foreach (int idLocataire in listeIdLocataires)
				listeLocataires.Add(new ControllerLocataires().GetById(idLocataire));

			return listeLocataires.Select(x => x.Nom).ToArray();
		}

		public void Clic(object sender, DataGridViewCellMouseEventArgs e)
		{
			int ligne = e.RowIndex;
			int colonne = e.ColumnIndex;

			FlatDataGridView flatDataGridView = _page.FlatDataGridView;

			if (colonne == flatDataGridView.GetColumnId("Valider")) // si la colonne cliquée correspond
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
