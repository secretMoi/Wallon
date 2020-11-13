using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.ViewModels.Taches.Detail;
using Mobile.Views.Taches;
using Models.Dtos.Taches;
using RestApiClient.Controllers;
using Xamarin.Forms;

namespace Mobile.ViewModels.Taches.List
{
	public class ListViewModel : BaseViewModel
	{
		private ListData _listData = new ListData();
		private readonly TachesController _taches = new TachesController();

		public ObservableCollection<TacheReadDto> Taches { get; private set; }

		public ListData LogInData // élément sélectionné dans la dgv
		{
			get => _listData;
			set => SetProperty(ref _listData, value);
		}

		public ListViewModel()
		{
			Taches = new ObservableCollection<TacheReadDto>();
		}

		public async Task Hydrate()
		{
			var taches = await _taches.GetAll<TacheReadDto>();

			foreach (var tache in taches)
			{
				Taches.Add(tache);
			}
		}

		public async Task OnItemSelected(TacheReadDto tache)
		{
			if (tache == null)
				return;

			// This will push the ItemDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailViewModel.TacheId)}={tache.Id}");
		}
	}
}
