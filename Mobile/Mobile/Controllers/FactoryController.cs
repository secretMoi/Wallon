using Mobile.Controllers.Liaison;
using Mobile.Controllers.Locataire;
using Mobile.Controllers.Suggestion;
using Mobile.Controllers.Tache;
using RestApiClient.Controllers;
using RestApiClient.Mocks;

namespace Mobile.Controllers
{
	public class FactoryController
	{
		public static ILocataireController CreateLocataire()
		{
			return LocataireController.Instance(new LocatairesApiController());
		}

		public static ILocataireController CreateMockLocataire()
		{
			return LocataireController.Instance(new LocataireApiApiMock());
		}

		public static ITacheController CreateTache()
		{
			return TacheController.Instance(new TachesApiController());
		}

		public static ITacheController CreateMockTache()
		{
			return TacheController.Instance(new TacheApiMock());
		}

		public static ILiaisonController CreateLiaison()
		{
			return LiaisonController.Instance;
		}

		public static ISuggestionController CreateSuggestion()
		{
			return SuggestionController.Instance(new SuggestionsApiController());
		}
	}
}
