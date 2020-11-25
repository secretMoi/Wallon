using System.Collections.Generic;
using Models.Models;

namespace RestServer.Data.Suggestions
{
	public interface ISuggestionRepo
	{
		WallonsContext Context { get; }
		bool SaveChanges();
		IEnumerable<Suggestion> GetAll();
		Suggestion GetById(int id);
		void Create(Suggestion model);
		void Update(Suggestion tache);
		void Delete(Suggestion model);
	}
}