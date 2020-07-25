using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace RestServer.Validations
{
	public class LiaisonsValidation : IEntityTypeConfiguration<LiaisonTacheLocataire>
	{
		public void Configure(EntityTypeBuilder<LiaisonTacheLocataire> modelBuilder)
		{
			modelBuilder.HasKey(tache => tache.Id);

			modelBuilder.Property(tache => tache.Active)
				.HasDefaultValue(true);
		}


		/*public override void Map(EntityTypeBuilder<LiaisonTacheLocataire> modelBuilder)
		{
			modelBuilder.HasKey(tache => tache.Id);

			modelBuilder.Property(tache => tache.Active)
				.HasDefaultValue(true);
		}*/
	}
}
