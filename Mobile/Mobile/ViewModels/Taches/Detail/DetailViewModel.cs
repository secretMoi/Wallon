using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Models.Dtos.Taches;
using RestApiClient;
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

		public DetailViewModel()
		{
			Title = "Création d'une tâche";
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
			}
			catch (Exception e)
			{
				Debug.WriteLine("Impossible de charger la tâche avec l'id : " + itemId + e.Message);
			}

			IsBusy = false;
		}
	}
}
