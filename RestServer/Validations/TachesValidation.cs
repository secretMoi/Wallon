using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace RestServer.Validations
{
	public class TachesValidation : IEntityTypeConfiguration<Tache>
	{
		public void Configure(EntityTypeBuilder<Tache> modelBuilder)
		{
			modelBuilder.HasKey(tache => tache.Id);

			modelBuilder.Property(tache => tache.Nom)
				.IsRequired(true);

			modelBuilder.Property(tache => tache.Active)
				.HasDefaultValue(true);

			modelBuilder.Property(tache => tache.Cycle)
				.IsRequired(true);

		}
		/*public override void Map(EntityTypeBuilder<Tache> modelBuilder)
		{
			modelBuilder.HasKey(tache => tache.Id);

			modelBuilder.Property(tache => tache.Nom)
				.IsRequired(true);

			modelBuilder.Property(tache => tache.Active)
				.HasDefaultValue(true);

			modelBuilder.Property(tache => tache.Cycle)
				.IsRequired(true);
		}*/
	}
}
