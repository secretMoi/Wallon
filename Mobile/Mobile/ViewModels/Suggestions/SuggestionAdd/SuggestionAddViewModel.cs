using System.Threading.Tasks;
using Mobile.Controllers.Suggestion;

namespace Mobile.ViewModels.Suggestions.SuggestionAdd
{
	public class SuggestionAddViewModel : BaseViewModel
	{
		private readonly ISuggestionController _suggestionController;

		private SuggestionAddData _suggestionData;

		public SuggestionAddData SuggestionData
		{
			get => _suggestionData;
			set => SetProperty(ref _suggestionData, value);
		}

		public SuggestionAddViewModel(ISuggestionController suggestionController)
		{
			SuggestionData = new SuggestionAddData();
			Title = "Proposer une suggestion";

			_suggestionController = suggestionController;
		}

		public async Task<string> SendSuggestion()
		{
			throw new System.NotImplementedException();
		}
	}
}
