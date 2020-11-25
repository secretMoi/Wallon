using System.Collections.Generic;
using Models.Dtos.Locataires;

namespace Models.Mocks
{
	public class LocataireMock : IDtoMock<LocataireReadDto>
	{
		private readonly IList<LocataireReadDto> _mock = new List<LocataireReadDto>();

		public IList<LocataireReadDto> Data => _mock;

		public LocataireMock()
		{
			_mock.Add(
				new LocataireReadDto()
				{
					Id = 1,
					Actif = true,
					Nom = "Quentin",
					Password = new byte[]
					{
						21, 55, 128
					}
				}
			);
			_mock.Add(
				new LocataireReadDto()
				{
					Id = 1000,
					Actif = false,
					Nom = "Goku",
					Password = new byte[]
					{
						21, 55, 128
					}
				}
			);
		}
	}
}
