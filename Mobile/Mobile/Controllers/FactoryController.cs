using Mobile.Controllers.Liaison;
using Mobile.Controllers.Locataire;
using Mobile.Controllers.Tache;
using RestApiClient.Controllers;
using RestApiClient.Mocks;

namespace Mobile.Controllers
{
	public class FactoryController
	{
		public static ILocataireController CreateLocataire()
		{
			return LocataireController.Instance;
		}

		public static ITacheController CreateTache()
		{
			return TacheController.Instance(new TachesController());
		}

		public static ITacheController CreateMockTache()
		{
			return TacheController.Instance(new TacheApiMock());
		}

		public static ILiaisonController CreateLiaison()
		{
			return LiaisonController.Instance;
		}
	}
}
