using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Dtos.Taches;
using Models.Mocks;
using RestApiClient.Interfaces;

namespace RestApiClient.Mocks
{
	public class TacheApiMock : BaseApiMock, ITachesController
	{
		/*public TacheApiMock()
		{
			Dto = typeof(TacheReadDto);
		}*/

		public Task<IList<TacheReadDto>> GetTachesFromLocataire(int idLocataire)
		{
			return Task.Run(() =>
				{
					var list = new TacheMock().Data.Where(x => x.LocataireId == idLocataire);
					return CastListToIList(list.ToList());
				}
			);
		}
	}
}
