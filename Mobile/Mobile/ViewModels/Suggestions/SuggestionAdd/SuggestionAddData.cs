using Models.Dtos.Suggestions;

namespace Mobile.ViewModels.Suggestions.SuggestionAdd
{
	public class SuggestionAddData : BaseViewModel
	{
		private SuggestionReadDto _suggestion;

		public SuggestionReadDto Suggestion
		{
			get => _suggestion;
			set => SetProperty(ref _suggestion, value);
		}
	}
}
