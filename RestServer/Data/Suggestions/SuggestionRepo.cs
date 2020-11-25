using System;
using System.Collections.Generic;
using System.Linq;
using Models.Models;

namespace RestServer.Data.Suggestions
{
	public class SuggestionRepo : ISuggestionRepo
	{
		private readonly WallonsContext _context;
		public WallonsContext Context => _context;

		public SuggestionRepo(WallonsContext context)
		{
			_context = context;
		}

		public bool SaveChanges()
		{
			// permet d'appliquer les modifications à la db
			return _context.SaveChanges() >= 0;
		}

		public IEnumerable<Suggestion> GetAll()
		{
			return _context.Suggestions.ToList(); // retourne la liste des commandes
		}

		public Suggestion GetById(int id)
		{
			// retourne le premier dont l'id correspond
			return _context.Suggestions
				//.Include(t => t.Locataire) // utilisé pour fill le lazy loading si foreign key null
				.FirstOrDefault(p => p.Id == id);

		}

		public void Create(Suggestion model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			_context.Suggestions.Add(model);
		}

		public void Update(Suggestion tache)
		{
			//Nothing, handled by context
		}

		public void Delete(Suggestion model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			_context.Suggestions.Remove(model);
		}
	}
}
