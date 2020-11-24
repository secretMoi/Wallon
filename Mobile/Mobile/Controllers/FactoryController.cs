using Mobile.Controllers.Liaison;
using Mobile.Controllers.Locataire;
using Mobile.Controllers.Tache;

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
			return TacheController.Instance;
		}

		public static ITacheController CreateMockTache()
		{
			return new MockTacheController();
		}

		public static ILiaisonController CreateLiaison()
		{
			return LiaisonController.Instance;
		}
	}
}
