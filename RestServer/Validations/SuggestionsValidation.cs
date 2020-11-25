using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace RestServer.Validations
{
	public class SuggestionsValidation : IEntityTypeConfiguration<Suggestion>
	{
		public void Configure(EntityTypeBuilder<Suggestion> modelBuilder)
		{
			modelBuilder.HasKey(suggestion => suggestion.Id);

			modelBuilder.Property(suggestion => suggestion.Nom)
				.IsRequired(true);

			modelBuilder.Property(suggestion => suggestion.Active)
				.HasDefaultValue(true);
		}
	}
}
