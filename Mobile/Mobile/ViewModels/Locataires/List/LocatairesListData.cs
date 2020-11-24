using System.Collections.ObjectModel;
using Models.Dtos.Locataires;

namespace Mobile.ViewModels.Locataires.List
{
	public class LocatairesListData : BaseViewModel
	{
		public ObservableCollection<LocataireReadDto> List { get; set; }
	}
}
