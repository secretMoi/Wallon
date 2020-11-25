using RestApiClient.Interfaces;

namespace Mobile.Controllers.Suggestion
{
	public interface ISuggestionController
	{
		static ISuggestionController Instance { get; }
	}
}