using RestApiClient.Interfaces;

namespace RestApiClient.Controllers
{
	public class LocatairesApiController : BaseController, ILocatairesApiController
	{
		public LocatairesApiController()
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
