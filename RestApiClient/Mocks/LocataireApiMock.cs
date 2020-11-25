using Models.Mocks;
using RestApiClient.Interfaces;

namespace RestApiClient.Mocks
{
	public class LocataireApiMock : BaseApiMock, ILocatairesController
	{
		private readonly LocataireMock _mock = new LocataireMock();
	}
}
