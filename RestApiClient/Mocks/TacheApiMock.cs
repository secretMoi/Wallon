using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Taches;
using RestApiClient.Interfaces;

namespace RestApiClient.Mocks
{
	public class TacheApiMock : BaseApiMock, ITachesController
	{
		public Task<IList<TacheReadDto>> GetTachesFromLocataire(int idLocataire)
		{
			throw new NotImplementedException();
		}
	}
}
