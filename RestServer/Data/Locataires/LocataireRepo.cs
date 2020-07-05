using System;
using System.Collections.Generic;
using System.Linq;
using RestServer.Models;

namespace RestServer.Data.Locataires
{
	public class LocataireRepo : ILocataireRepo
	{
		private readonly WallonsContext _context;

		public WallonsContext Context => _context;

		public LocataireRepo(WallonsContext context)
		{
			_context = context;
		}

		public bool SaveChanges()
		{
			// permet d'appliquer les modifications à la db
			return _context.SaveChanges() >= 0;
		}

		public IEnumerable<Locataire> GetAll()
		{
			return _context.Locataires.ToList(); // retourne la liste des commandes
		}

		public Locataire GetById(int id)
		{
			// retourne le premier dont l'id correspond
			return _context.Locataires.FirstOrDefault(p => p.Id == id);
		}

		public void Create(Locataire locataire)
		{
			if (locataire == null)
				throw new ArgumentNullException(nameof(locataire));

			_context.Locataires.Add(locataire);
		}

		public void Update(Locataire locataire)
		{
			//Nothing, handled by context
		}

		public void Delete(Locataire locataire)
		{
			if (locataire == null)
				throw new ArgumentNullException(nameof(locataire));

			_context.Locataires.Remove(locataire);
		}
	}
}
