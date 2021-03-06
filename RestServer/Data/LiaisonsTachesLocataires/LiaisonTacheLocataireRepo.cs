﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace RestServer.Data.LiaisonsTachesLocataires
{
	public class LiaisonTacheLocataireRepo : ILiaisonTacheLocataireRepo
	{
		private readonly WallonsContext _context;

		public WallonsContext Context => _context;

		public LiaisonTacheLocataireRepo(WallonsContext context)
		{
			_context = context;
		}

		public bool SaveChanges()
		{
			// permet d'appliquer les modifications à la db
			return _context.SaveChanges() >= 0;
		}

		public IEnumerable<LiaisonTacheLocataire> GetAll()
		{
			return _context.LiaisonTachesLocataires.ToList(); // retourne la liste des commandes
		}

		public async Task<ICollection<LiaisonTacheLocataire>> LiaisonsFromTache(int idTache)
		{
			return await _context.LiaisonTachesLocataires.Where(liaison => liaison.TacheId == idTache).ToListAsync();
		}

		public LiaisonTacheLocataire GetById(int id)
		{
			// retourne le premier dont l'id correspond
			return _context.LiaisonTachesLocataires.FirstOrDefault(p => p.Id == id);
		}

		public void Create(LiaisonTacheLocataire liaison)
		{
			if (liaison == null)
				throw new ArgumentNullException(nameof(liaison));

			_context.LiaisonTachesLocataires.Add(liaison);
		}

		public void Update(LiaisonTacheLocataire liaison)
		{
			//Nothing, handled by context
		}

		public void Delete(LiaisonTacheLocataire liaison)
		{
			if (liaison == null)
				throw new ArgumentNullException(nameof(liaison));

			_context.LiaisonTachesLocataires.Remove(liaison);
		}

		public async Task<IEnumerable<LiaisonTacheLocataire>> GetTachesFromLocataire(int idLocataire)
		{
			return await _context.LiaisonTachesLocataires
				.Where(liaison => liaison.LocataireId == idLocataire)
				.ToListAsync();
		}
	}
}
