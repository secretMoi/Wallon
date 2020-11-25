using System;
using RestApiClient.Interfaces;

namespace Mobile.Controllers.Suggestion
{
	public class SuggestionController : ISuggestionController
	{
		private ISuggestionsApiController _suggestionsApi;

		private static readonly Lazy<ISuggestionController> Lazy = new Lazy<ISuggestionController>(() => new SuggestionController());

		public static ISuggestionController Instance(ISuggestionsApiController suggestionController)
		{
			((SuggestionController)Lazy.Value)._suggestionsApi = suggestionController;
			return Lazy.Value;
		}

		private SuggestionController()
		{

		}
	}
}
