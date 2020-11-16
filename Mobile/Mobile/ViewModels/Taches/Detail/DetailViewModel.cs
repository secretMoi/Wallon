using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
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

		public DetailViewModel()
		{
			Title = "Création d'une tâche";
			Tache.Locataires = new ObservableCollection<LocataireReadDto>();
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

		private async Task LoadLocataires()
		{
			var locataires = await _locataires.GetAll<LocataireReadDto>();
			
			foreach (var locataire in locataires)
			{
				Tache.Locataires.Add(locataire);
			}
		}
	}
}
