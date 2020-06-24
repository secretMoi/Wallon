using System;
using Couche_Classe;
using FluentValidation;

namespace Wallon.Controllers.Validators
{
	public class TacheValidator : AbstractValidator<Taches>
	{
		public TacheValidator()
		{
			RuleFor(tache => tache.Nom)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("Le {PropertyName} est vide")
				.MinimumLength(1)
				.WithMessage("Le {PropertyName} doit contenir au moins 1 caractère, {TotalLength} founi")
				.MaximumLength(50)
				.WithMessage("Le {PropertyName} ne peut pas contenir plus de 50 caractères, {TotalLength} founis");

			RuleFor(tache => tache.DatteFin)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("La datte de fin ne peut pas être nulle")
				.Must(ValidDatteFin).WithMessage("La datte de fin doit être supérieure au " + DateTime.Now.ToShortDateString());

			RuleFor(tache => tache.Cycle)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.GreaterThanOrEqualTo(0).WithMessage("Le {PropertyName} ne peut pas être négatif");
		}

		/// <summary>
		/// Vérifie que la valeur de la datte soit valide
		/// </summary>
		/// <returns>true si la datte est valide, false sinon</returns>
		protected bool ValidDatteFin(DateTime arg)
		{
			DateTime today = DateTime.Now.Date;

			return arg >= today;
		}
	}
}
