using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Suggestions;
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

		public Task<SuggestionReadDto> PostAsync(SuggestionCreateDto suggestion)
		{
			return _suggestionsApi.Post<SuggestionCreateDto, SuggestionReadDto>(suggestion);
		}

		public Task<IList<SuggestionReadDto>> GetAllAsync()
		{
			return _suggestionsApi.GetAll<SuggestionReadDto>();
		}

		public Task<bool> DeleteAsync(int suggestionId)
		{
			return _suggestionsApi.Delete(suggestionId);
		}

		public Task<SuggestionReadDto> GetByIdAsync(int idSuggestion)
		{
			return _suggestionsApi.GetById<SuggestionReadDto>(idSuggestion);
		}
	}
}
