using System.Collections.Generic;
using Models.Dtos.LiaisonsTachesLocataires;

namespace Models.Mocks
{
	public class LiaisonMock : IDtoMock<LiaisonReadDto>
	{
		public IList<LiaisonReadDto> Data { get; }
	}
}
