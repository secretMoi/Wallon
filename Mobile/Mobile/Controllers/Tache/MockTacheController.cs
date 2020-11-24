using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;

namespace Mobile.Controllers.Tache
{
	public class MockTacheController : ITacheController
	{
		public Task<LocataireReadDto> TrouveLocataireSuivant(int idTache, int idLocataire)
		{
			throw new NotImplementedException();
		}

		public Task LocataireSuivant(int id, int idLocataire)
		{
			throw new NotImplementedException();
		}

		public Task<TacheReadDto> PostAsync(TacheCreateDto tache)
		{
			throw new NotImplementedException();
		}

		public Task<IList<TacheReadDto>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<TacheReadDto> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(TacheUpdateDto tache)
		{
			throw new NotImplementedException();
		}

		public Task<IList<TacheReadDto>> GetTachesFromLocataireAsync(int idLocataire)
		{
			throw new NotImplementedException();
			//return Task.Run(() =>
			//	{

			//	}
			//);
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
