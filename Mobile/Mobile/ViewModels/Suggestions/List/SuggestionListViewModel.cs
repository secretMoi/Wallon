using System.Threading.Tasks;
using Mobile.Controllers.Suggestion;

namespace Mobile.ViewModels.Suggestions.List
{
	public class SuggestionListViewModel : BaseViewModel
	{
		private readonly ISuggestionController _suggestionController;

		public SuggestionListData Suggestion { get; set; }
		
		public SuggestionListViewModel(ISuggestionController suggestionController)
		{
			Title = "Liste des suggestions";
			Suggestion = new SuggestionListData();
			
			_suggestionController = suggestionController;
		}

		public async Task LoadSuggestions()
		{
			if(Suggestion.List.Count != 0)
			{
				Suggestion.List.Clear();
			}

			var taches = await _suggestionController.GetAllAsync();

			foreach (var tache in taches)
			{
				Suggestion.List.Add(tache);
			}
		}
	}
}