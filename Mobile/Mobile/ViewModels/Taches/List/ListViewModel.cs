using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Models.Dtos.Taches;
using RestApiClient.Controllers;

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
	}
}
