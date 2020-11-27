using System.Collections.ObjectModel;
using Models.Dtos.Suggestions;

namespace Mobile.ViewModels.Suggestions.List
{
	public class SuggestionListData : BaseViewModel
	{
		public ObservableCollection<SuggestionReadDto> List { get; set; }

		public SuggestionListData()
		{
			List = new ObservableCollection<SuggestionReadDto>();
		}
	}
}