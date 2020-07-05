using System.Collections.Generic;

namespace RestServer.Data
{
	public interface IBaseRepo<T>
	{
		WallonsContext Context { get; }
		bool SaveChanges();
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Create(T command);
		void Update(T command);
		void Delete(T command);
	}
}