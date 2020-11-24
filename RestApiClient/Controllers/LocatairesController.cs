using RestApiClient.Interfaces;

namespace RestApiClient.Controllers
{
	public class LocatairesController : BaseController, ILocatairesController
	{
		public LocatairesController()
		{
			Url = "locataires";

			FillBaseMethods(
				BaseMethod.GetAll,
				BaseMethod.GetId,
				BaseMethod.Post,
				BaseMethod.Update
			);
		}
	}
}
