using Models.Dtos.Taches;

namespace Mobile.ViewModels.Taches.Detail
{
	public class DetailData : BaseViewModel
	{
		private TacheReadDto _tache;

		public TacheReadDto Tache
		{
			get => _tache;
			set => SetProperty(ref _tache, value);
		}
	}
}
