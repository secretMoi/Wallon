using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using FluentValidation.Results;
using Mobile.Core;
using Mobile.Validators;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using Models.Models;
using RestApiClient.Controllers;
using Xamarin.Forms;

namespace Mobile.ViewModels.Taches.Detail
{
	[QueryProperty(nameof(TacheId), nameof(TacheId))]
	public class DetailViewModel : BaseViewModel
	{
		private DetailData _detailData = new DetailData();
		private string _itemId;

		private readonly TachesController _taches = new TachesController();
		private readonly LocatairesController _locataires = new LocatairesController();
		private readonly LiaisonsController _liaisons = new LiaisonsController();

		private readonly IList<int> _reoderedLocataires = new List<int>();

		public DetailViewModel()
		{
			Title = "Création d'une tâche";
			Tache.Locataires = new ObservableCollection<LocataireReadDto>();
		}

		public async Task<string> OnSendClicked()
		{
			// validation des données
			var result = new TacheValidator().Validate(Tache.Tache);
			if (!result.IsValid)
				return "Veuillez remplir correctement les champs !";

			// converti le dto de lecture en update
			var tacheUpdate = Mapping.Map(Tache.Tache, new TacheUpdateDto());

			// modifie la tâche
			await _taches.Update(tacheUpdate);

			// modifie les liaisons
			await _liaisons.DeleteLiaisonsFromTache(tacheUpdate.Id);

			foreach (var orderedLocataire in _reoderedLocataires)
			{
				var liaison = new LiaisonCreateDto
				{
					LocataireId = Tache.Locataires[orderedLocataire].Id,
					TacheId = tacheUpdate.Id
				};
				await _liaisons.Post<LiaisonCreateDto, LiaisonReadDto>(liaison);
			}

			return $"La tâche {Tache.Tache.Nom} a bien été modifiée";
		}

		public DetailData Tache
		{
			get => _detailData;
			set => SetProperty(ref _detailData, value);
		}

		public string TacheId
		{
			get => _itemId;
			set
			{
				_itemId = value;
				LoadItemId(value);
			}
		}

		/**
		 * <summary>Charge les données de la tâche de la bdd</summary>
		 * <param name="itemId">Id de la tâche à charger</param>
		 */
		public async void LoadItemId(string itemId)
		{
			IsBusy = true;
			try
			{
				Tache.Tache = await _taches.GetById<TacheReadDto>(Convert.ToInt32(itemId));
				Title = "Modification de la tâche " + Tache.Tache.Nom;

				await LoadLocataires();
			}
			catch (Exception e)
			{
				Debug.WriteLine("Impossible de charger la tâche avec l'id : " + itemId + e.Message);
			}

			IsBusy = false;
		}

		/**
		 * <summary>Charge les locataires depuis la bdd et peuple notre liste de locataires</summary>
		 */
		private async Task LoadLocataires()
		{
			var locataires = await _locataires.GetAll<LocataireReadDto>();
			
			foreach (var locataire in locataires)
			{
				Tache.Locataires.Add(locataire);
				_reoderedLocataires.Add(Tache.Locataires.Count - 1);
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
	}
}
