using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Mobile.Controllers.Liaison;
using Mobile.Controllers.Locataire;
using Mobile.Controllers.Tache;
using Mobile.Core;
using Mobile.Core.Logger;
using Mobile.Validators;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Taches;
using Xamarin.Forms;

namespace Mobile.ViewModels.Taches.Detail
{
	[QueryProperty(nameof(TacheId), nameof(TacheId))]
	public class DetailViewModel : BaseViewModel
	{
		private DetailData _detailData = new DetailData();
		private string _itemId;

		private readonly ITacheController _taches;
		private readonly ILocataireController _locataires;
		private readonly ILiaisonController _liaisons;

		private readonly IList<int> _reoderedLocataires = new List<int>();

		public DetailViewModel(ITacheController tacheController, ILocataireController locataireController, ILiaisonController liaisonController)
		{
			Title = "Modification d'une tâche";
			Tache.Locataires = new ObservableCollection<DetailData.LocatairesInclus>();

			Tache.CheckedLocataires = new ObservableCollection<DetailData.LocatairesInclus>();

			_taches = tacheController;
			_locataires = locataireController;
			_liaisons = liaisonController;
		}

		/**
		 * <summary>Effectue les actions pour modifier la tâche dans la bdd</summary>
		 * <returns>Retourne une string expliquant ce qu'il s'est passé</returns>
		 */
		public async Task<string> OnSendClicked()
		{
			Tache.Tache.LocataireId = Tache.SelectedLocataire.Locataire.Id;

			// validation des données
			var result = await new TacheValidator().ValidateAsync(Tache.Tache);
			if (!result.IsValid)
				return $"{result.Errors[0].ErrorMessage}";

			// converti le dto de lecture en update
			var tacheUpdate = Mapping.Map(Tache.Tache, new TacheUpdateDto());

			// modifie la tâche
			await _taches.UpdateAsync(tacheUpdate);

			// modifie les liaisons
			await _liaisons.DeleteLiaisonsFromTacheAsync(tacheUpdate.Id);

			foreach (var orderedLocataire in _reoderedLocataires)
			{
				if (!Tache.Locataires[orderedLocataire].Inclu) continue;

				var liaison = new LiaisonCreateDto
				{
					LocataireId = Tache.Locataires[orderedLocataire].Locataire.Id,
					TacheId = tacheUpdate.Id
				};

				await _liaisons.PostAsync(liaison);
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
				Tache.Tache = await _taches.GetByIdAsync(idTache);
				Title = "Modification de la tâche " + Tache.Tache.Nom;

				await LoadLocataires(idTache);

				Tache.SelectedLocataire =
					Tache.CheckedLocataires.FirstOrDefault(item => item.Locataire.Id == Tache.Tache.LocataireId);
			}
			catch (Exception e)
			{
				App.Container.GetService<ILogger>().LogError("Impossible de charger la tâche avec l'id : " + itemId + e.Message);
			}

			IsBusy = false;
		}

		/**
		 * <summary>Charge les locataires depuis la bdd et peuple la liste de locataires</summary>
		 */
		private async Task LoadLocataires(int idTache)
		{
			// liste de tous les locataires
			var locataires = await _locataires.GetAllAsync();

			// liste des locataires dans la tâche
			var liaisons = await _liaisons.ListeLocatairesAsync(idTache);

			// parcours la liste des locataires
			foreach (var locataire in locataires)
			{
				// ajoute le locataire dans la liste data
				Tache.Locataires.Add(new DetailData.LocatairesInclus
				{
					Locataire = locataire,
					Inclu = liaisons.FirstOrDefault(item => item.Id == locataire.Id) != null
				});
			}

			OrderLocataires();

			HydrateListeDeTri();

			HydrateCheckedLocataires();

			// Trie les locataires
			void OrderLocataires()
			{
				int index = 0;
				foreach (var locataire in liaisons)
				{
					int oldIndex = Tache.Locataires.IndexOf(
						Tache.Locataires.First(item => item.Locataire.Id == locataire.Id)
					);

					int newIndex = index;

					SwapElementInList(oldIndex, newIndex, Tache.Locataires);

					index++;
				}
			}

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
	}
}
