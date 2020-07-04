using System.Collections.Generic;
using RestServer.Models;

namespace RestServer.Data
{
	public interface IBaseRepo<T>
	{
		bool SaveChanges();
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Create(T command);
		void Update(T command);
		void Delete(T command);
	}
}