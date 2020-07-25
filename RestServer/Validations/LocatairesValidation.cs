using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace RestServer.Validations
{
	public class LocatairesValidation : IEntityTypeConfiguration<Locataire>
	{
		public void Configure(EntityTypeBuilder<Locataire> modelBuilder)
		{
			modelBuilder.HasKey(locataire => locataire.Id);

			modelBuilder.Property(locataire => locataire.Nom)
				.IsRequired(true);

			modelBuilder.Property(locataire => locataire.Password)
				.IsRequired(true);

			modelBuilder.Property(locataire => locataire.Actif)
				.HasDefaultValue(true);
		}

		/*public override void Map(EntityTypeBuilder<Locataire> modelBuilder)
		{
			modelBuilder.HasKey(locataire => locataire.Id);

			modelBuilder.Property(locataire => locataire.Nom)
				.IsRequired(true);

			modelBuilder.Property(locataire => locataire.Password)
				.IsRequired(true);

			modelBuilder.Property(locataire => locataire.Actif)
				.HasDefaultValue(true);
		}*/
	}
}
