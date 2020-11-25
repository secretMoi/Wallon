using Models.Mocks;
using RestApiClient.Interfaces;

namespace RestApiClient.Mocks
{
	public class LocataireApiApiMock : BaseApiMock, ILocatairesApiController
	{
		private readonly LocataireMock _mock = new LocataireMock();
	}
}
