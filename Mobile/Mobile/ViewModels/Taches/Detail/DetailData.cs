using System.Collections.ObjectModel;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;

namespace Mobile.ViewModels.Taches.Detail
{
	public class DetailData : BaseViewModel
	{
		private TacheReadDto _tache;

		public ObservableCollection<LocataireReadDto> Locataires { get; set; } // données bindée dans la dgv du Fournisseur sélectionné

		public TacheReadDto Tache
		{
			get => _tache;
			set => SetProperty(ref _tache, value);
		}
	}
}
