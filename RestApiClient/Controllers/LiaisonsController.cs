using System.Collections.Generic;

namespace RestApiClient.Controllers
{
	public class LiaisonsController : BaseController
	{
		public LiaisonsController()
		{
			Url = "liaisons";

			FillBaseMethods(
				BaseMethod.GetId,
				BaseMethod.Post,
				BaseMethod.Delete
			);

			/*BaseMethods.AddRange(new List<BaseMethod>
			{
				BaseMethod.GetId,
				BaseMethod.Post,
				BaseMethod.Delete
			});*/
		}
	}
}
