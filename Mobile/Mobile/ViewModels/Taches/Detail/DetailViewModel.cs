using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mobile.Core;
using Mobile.Validators;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
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

		/**
		 * <summary>Effectue les actions pour modifier la tâche dans la bdd</summary>
		 * <returns>Retourne une string expliquant ce qu'il s'est passé</returns>
		 */
		public async Task<string> OnSendClicked()
		{
			// validation des données
			var result = new TacheValidator().Validate(Tache.Tache);
			if (!result.IsValid)
				return $"{result.Errors[0].ErrorMessage}";

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
				int idTache = Convert.ToInt32(itemId);
				Tache.Tache = await _taches.GetById<TacheReadDto>(idTache);
				Title = "Modification de la tâche " + Tache.Tache.Nom;

				await LoadLocataires(idTache);
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
		private async Task LoadLocataires(int idTache)
		{
			// liste de tous les locataires
			var locataires = await _locataires.GetAll<LocataireReadDto>();

			// liste des locataires dans la tâche
			var liaisons = await _liaisons.ListeLocataires(idTache);

			//todo trier les locataires par ordre de la tâche
			//todo check box dans les locataires pour les activer ou non dans la tâche ou par groupe

			foreach (var locataire in locataires)
			{
				Tache.Locataires.Add(locataire);

				// si le locataire est inclu dans la tâche
				if (liaisons.FirstOrDefault(item => item.Id == locataire.Id) != null)
				{
					Tache.LocataireIncluded.Add(new DetailData.LocataireInclu
					{
						IdLocataire = locataire.Id,
						Inclu = true
					});
				}
				else
				{
					Tache.LocataireIncluded.Add(new DetailData.LocataireInclu
					{
						IdLocataire = locataire.Id,
						Inclu = false
					});

				}

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
