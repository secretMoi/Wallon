using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Suggestions;

namespace Mobile.Controllers.Suggestion
{
	public interface ISuggestionController
	{
		static ISuggestionController Instance { get; }
		Task<SuggestionReadDto> PostAsync(SuggestionCreateDto suggestion);
		Task<IList<SuggestionReadDto>> GetAllAsync();
		Task<bool> DeleteAsync(int suggestionId);
		Task<SuggestionReadDto> GetByIdAsync(int idSuggestion);
	}
}