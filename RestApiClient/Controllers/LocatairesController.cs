namespace RestApiClient.Controllers
{
	public class LocatairesController : BaseController
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
