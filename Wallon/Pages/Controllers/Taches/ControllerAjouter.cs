﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlatControls.Controls;
using FluentValidation.Results;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using Wallon.Controllers.BaseConsulter;
using Wallon.Controllers.Validators;
using Wallon.Core;
using Wallon.Fenetres;
using Wallon.Pages.Vue.Taches;
using Wallon.Profiles;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerAjouter
	{
		private readonly RepositoryLocataires _repositoryLocataires = RepositoryLocataires.Instance;
		private readonly RepositoryTaches _repositoryTaches = RepositoryTaches.Instance;
		private readonly RepositoryLiaisonTachesLocataires _liaison = RepositoryLiaisonTachesLocataires.Instance;
		private readonly Ajouter _page;

		public ControllerAjouter(Ajouter page)
		{
			_page = page;
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
		public async Task FillDgv()
		{
			IList<LocataireReadDto> locataires = await _repositoryLocataires.Lire(); // récupère les données dans la bdd

			foreach (LocataireReadDto locataire in locataires) // les lie à la dgv
				_page.FillDgv(
					locataire.Id,
					locataire.Nom,
					"Non"
				);
		}

		/// <summary>
		/// Modifie le champ inclu dans la dgv lors de la modification
		/// </summary>
		public async void UpdateDgv(object sender, EventArgs e)
		{
			IList<int> locatairesInclus = (await _liaison.ListeLocataires((int) IdTache))
				.ToList()
				.Select(locataire => locataire.Id)
				.ToList(); // récupère la liste des locataires inclus dans la tâche

			for (int i = 0; i < _page.UseGridView.Table.Rows.Count; i++) // parcours la dgv
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
		public async void Envoyer(string name, string datte, string cycleInput)
		{
			DateTime datteDebut = default;
			int cycle = 0;
			List<int> idLocataires = new List<int>();
			if (!ValidateInput(name, datte, cycleInput, ref datteDebut, ref cycle, idLocataires)) return;

			if(IdTache == null) // mode ajout
				await Ajouter(name, datteDebut.AddDays(cycle), cycle, idLocataires);
			else // mode update
			{
				await Supprimer();
				await Ajouter(name, datteDebut.AddDays(cycle), cycle, idLocataires);
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

		private async Task Ajouter(string name, DateTime datteDebut, int cycle, List<int> idLocataires)
		{
			// Crée la tâche
			TacheReadDto tache = new TacheReadDto()
			{
				Nom = name,
				DateFin = datteDebut,
				Active = true,
				LocataireId = idLocataires[0],
				Cycle = cycle
			};

			// validation des données
			ValidationResult result = new TacheValidator().Validate(tache);
			if (!result.IsValid)
			{
				Dialog.Show($"{result.Errors[0].PropertyName} : {result.Errors[0].ErrorMessage}");
				return;
			}

			TacheCreateDto tacheCreateDto = TachesProfile.ReadToCreate().Map<TacheCreateDto>(tache);

			// Ajout de la tâche à la bdd
			int idTache = (await _repositoryTaches.Ajouter(tacheCreateDto)).Id;

			// Ajout les locataires à la tâche dans la bdd (table liaison)
			foreach (int idSelected in idLocataires)
				await _liaison.Ajouter(
					idSelected,
					idTache
				);

			Dialog.Show("La tâche " + name + " a bien été ajoutée");
		}

		private async Task Supprimer()
		{
			/*IList<LocataireReadDto> liaisonsASupprimer = await _liaison.ListeLocataires((int) IdTache);
			foreach (LocataireReadDto liaison in liaisonsASupprimer)*/
				await _liaison.DeleteLiaisonsFromTache((int)IdTache);

			await _repositoryTaches.Supprimer((int) IdTache);
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
		public async Task<TacheReadDto> GetTache()
		{
			return await _repositoryTaches.LireId((int) IdTache);
		}

		/// <summary>
		/// Trouve le locataire grâce à son id
		/// </summary>
		/// <param name="idLocataire">Id du locataire à récupérer</param>
		/// <returns>Le nom du locataire</returns>
		public async Task<string> FillFieldLocataireCourant(int idLocataire)
		{
			return (await _repositoryLocataires.LireId(idLocataire)).Nom;
		}


		/// <summary>
		/// Récupère la liste des locataires associés à une tâche
		/// </summary>
		/// <returns>Tableau des noms des locataires</returns>
		/*public string[] FillListLocataireCourant()
		{
			ListPage<int> listeIdLocataires = _liaison.ListeLocataires((int) IdTache);

			ListPage<Locataire> listeLocataires = new ListPage<Locataire>(listeIdLocataires.Count);

			foreach (int idLocataire in listeIdLocataires)
				listeLocataires.Add(new ControllerLocataires().GetById(idLocataire));

			return listeLocataires.Select(x => x.Nom).ToArray();
		}*/

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
