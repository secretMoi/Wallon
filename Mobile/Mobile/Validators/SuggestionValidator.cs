using FluentValidation;
using Models.Dtos.Suggestions;

namespace Mobile.Validators
{
	public class SuggestionValidator : AbstractValidator<SuggestionReadDto>
	{
		public SuggestionValidator()
		{
			RuleFor(suggestion => suggestion.LocataireId)
				.Cascade(CascadeMode.Stop)
				.NotNull().WithMessage("L'id du locataire ne peut pas être null")
				.GreaterThan(0).WithMessage("L'id du locataire doit être supérieur à 0");
		}
	}
}
