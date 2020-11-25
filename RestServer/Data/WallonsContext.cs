using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace RestServer.Data
{
	public class WallonsContext : DbContext
	{
		public WallonsContext(DbContextOptions<WallonsContext> options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			/*modelBuilder.AddConfiguration(new LocatairesValidation());
			modelBuilder.AddConfiguration(new TachesValidation());
			modelBuilder.AddConfiguration(new LiaisonsValidation());*/
		}

		// liste des tables
		public DbSet<Locataire> Locataires { get; set; } // map entity framework avec nos modèles
		public DbSet<Tache> Taches { get; set; } // map entity framework avec nos modèles
		public DbSet<LiaisonTacheLocataire> LiaisonTachesLocataires { get; set; } // map entity framework avec nos modèles
		public DbSet<Suggestion> Suggestions { get; set; } // map entity framework avec nos modèles
	}
}
