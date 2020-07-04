using Microsoft.EntityFrameworkCore;
using RestServer.Models;

namespace RestServer.Data
{
	public class WallonsContext : DbContext
	{
		public WallonsContext(DbContextOptions<WallonsContext> options) : base(options)
		{
			
		}

		// liste des tables
		public DbSet<Locataire> Locataires { get; set; } // map entity framework avec nos modèles
		public DbSet<Tache> Taches { get; set; } // map entity framework avec nos modèles
		public DbSet<LiaisonTacheLocataire> LiaisonTachesLocataires { get; set; } // map entity framework avec nos modèles
	}
}
