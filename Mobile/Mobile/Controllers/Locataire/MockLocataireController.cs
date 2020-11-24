using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;
using Models.Mocks;

namespace Mobile.Controllers.Locataire
{
	public class MockLocataireController : ILocataireController
	{
		private readonly LocataireMock _mock = new LocataireMock();

		public Task<IList<LocataireReadDto>> GetAllAsync()
		{
			return Task.Run(() => _mock.Data);
		}
	}
}
