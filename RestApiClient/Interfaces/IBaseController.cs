using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Dtos;

namespace RestApiClient.Interfaces
{
	public interface IBaseController
	{
		Task<T> GetById<T>(int id) where T : class, IRead;
		Task<IList<T>> GetAll<T>() where T : class, IRead;
		Task Update<T>(T data) where T : IUpdate;
		Task<TU> Post<T, TU>(T input) where TU : IRead;
		Task Delete(int id);
	}
}