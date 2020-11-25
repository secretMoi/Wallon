using RestApiClient.Interfaces;

namespace RestApiClient.Controllers
{
	public class SuggestionsApiController : BaseController, ISuggestionsApiController
	{
		public SuggestionsApiController()
		{
			Url = "suggestions";

			FillBaseMethods(
				BaseMethod.GetAll,
				BaseMethod.GetId,
				BaseMethod.Post,
				BaseMethod.Update
			);
		}
	}
}
