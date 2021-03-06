﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Controllers.Liaison;
using Mobile.Controllers.Locataire;
using Mobile.Controllers.Tache;
using Mobile.Core;
using Mobile.Validators;
using Mobile.ViewModels.Taches.Detail;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Taches;

namespace Mobile.ViewModels.Taches.Add
{
	public class AddTacheViewModel : BaseViewModel
	{
		private DetailData _detailData = new DetailData();
		private readonly ITacheController _taches;
		private readonly ILocataireController _locataires;
		private readonly ILiaisonController _liaisons;

		private readonly IList<int> _reoderedLocataires = new List<int>();

		public AddTacheViewModel(ITacheController tacheController, ILocataireController locataireController, ILiaisonController liaisonController)
		{
			Title = "Création d'une tâche";
			Tache.Tache = new TacheReadDto
			{
				DateFin = DateTime.Now
			};
			Tache.Locataires = new ObservableCollection<DetailData.LocatairesInclus>();

			Tache.CheckedLocataires = new ObservableCollection<DetailData.LocatairesInclus>();

			_taches = tacheController;
			_locataires = locataireController;
			_liaisons = liaisonController;
		}

		public DetailData Tache
		{
			get => _detailData;
			set => SetProperty(ref _detailData, value);
		}

		public async Task Load()
		{
			if(Tache.Locataires.Count == 0)
				await LoadLocataires();
		}

		/**
		 * <summary>Charge les locataires depuis la bdd et peuple la liste de locataires</summary>
		 */
		private async Task LoadLocataires()
		{
			// liste de tous les locataires
			var locataires = await _locataires.GetAllAsync();

			// parcours la liste des locataires
			foreach (var locataire in locataires)
			{
				// ajoute le locataire dans la liste data
				Tache.Locataires.Add(new DetailData.LocatairesInclus
				{
					Locataire = locataire,
					Inclu = false
				});
			}

			HydrateListeDeTri();

			HydrateCheckedLocataires();

			// Hydrate la liste cachée de tri
			void HydrateListeDeTri()
			{
				foreach (var locataire in Tache.Locataires)
				{
					_reoderedLocataires.Add(Tache.Locataires.IndexOf(locataire));
				}
			}
		}

		/**
		 * <summary>Hydrate la liste des locataires checkés</summary>
		 */
		public void HydrateCheckedLocataires()
		{
			Tache.CheckedLocataires.Clear();

			foreach (var locataire in Tache.Locataires)
			{
				if (locataire.Inclu)
				{
					Tache.CheckedLocataires.Add(new DetailData.LocatairesInclus
						{
							Locataire = locataire.Locataire
						}
					);
				}
			}
		}

		/**
		 * <summary>Réarrange la liste des id des items locataires</summary>
		 * <param name="oldIndex">Id de la position précédente</param>
		 * <param name="newIndex">Id de la nouvelle position</param>
		 */
		public void DropedItem(int oldIndex, int newIndex)
		{
			SwapElementInList(oldIndex, newIndex, _reoderedLocataires);
		}

		/**
		 * <summary>Réarrange la liste des id des items locataires</summary>
		 * <param name="oldIndex">Id de la position précédente</param>
		 * <param name="newIndex">Id de la nouvelle position</param>
		 * <param name="list">Liste dans laquelle swaper les éléments</param>
		 */
		private void SwapElementInList<T>(int oldIndex, int newIndex, IList<T> list)
		{
			var tmp = list[oldIndex];
			list[oldIndex] = list[newIndex];
			list[newIndex] = tmp;
		}

		/**
		 * <summary>Effectue les actions pour ajouter la tâche dans la bdd</summary>
		 * <returns>Retourne une string expliquant ce qu'il s'est passé</returns>
		 */
		public async Task<string> OnSendClicked()
		{
			Tache.Tache.LocataireId = Tache.SelectedLocataire.Locataire.Id;

			// validation des données
			var result = await new TacheValidator().ValidateAsync(Tache.Tache);
			if (!result.IsValid)
				return $"{result.Errors[0].ErrorMessage}";

			// converti le dto de lecture en create
			var tacheCreate = Mapping.Map(Tache.Tache, new TacheCreateDto());

			// ajoute la tâche
			var createdTache = await _taches.PostAsync(tacheCreate);

			// ajout des liaisons
			foreach (var orderedLocataire in _reoderedLocataires)
			{
				if (!Tache.Locataires[orderedLocataire].Inclu) continue;

				var liaison = new LiaisonCreateDto
				{
					LocataireId = Tache.Locataires[orderedLocataire].Locataire.Id,
					TacheId = createdTache.Id
				};

				await _liaisons.PostAsync(liaison);
			}

			return $"La tâche {Tache.Tache.Nom} a bien été ajoutée";
		}
	}
}
