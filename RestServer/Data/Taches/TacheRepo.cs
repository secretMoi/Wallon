using System;
using System.Collections.Generic;
using System.Linq;
using Models.Models;

namespace RestServer.Data.Taches
{
	public class TacheRepo : ITacheRepo
	{
		private readonly WallonsContext _context;
		public WallonsContext Context => _context;

		public TacheRepo(WallonsContext context)
		{
			_context = context;
		}

		public bool SaveChanges()
		{
			// permet d'appliquer les modifications à la db
			return _context.SaveChanges() >= 0;
		}

		public IEnumerable<Tache> GetAll()
		{
			return _context.Taches.ToList(); // retourne la liste des commandes
		}

		public Tache GetById(int id)
		{
			// retourne le premier dont l'id correspond
			return _context.Taches.FirstOrDefault(p => p.Id == id);
		}

		public void Create(Tache tache)
		{
			if (tache == null)
				throw new ArgumentNullException(nameof(tache));

			_context.Taches.Add(tache);
		}

		public void Update(Tache tache)
		{
			//Nothing, handled by context
		}

		public void Delete(Tache tache)
		{
			if (tache == null)
				throw new ArgumentNullException(nameof(tache));

			_context.Taches.Remove(tache);
		}
	}
}
