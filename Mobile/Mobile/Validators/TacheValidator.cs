using System;
using FluentValidation;
using Models.Dtos.Taches;

namespace Mobile.Validators
{
	public class TacheValidator : AbstractValidator<TacheReadDto>
	{
		public TacheValidator()
		{
			RuleFor(tache => tache.Nom)
				.Cascade(CascadeMode.Stop)
				.NotEmpty().WithMessage("Le {PropertyName} est vide")
				.MinimumLength(1)
				.WithMessage("Le {PropertyName} doit contenir au moins 1 caractère, {TotalLength} founi")
				.MaximumLength(50)
				.WithMessage("Le {PropertyName} ne peut pas contenir plus de 50 caractères, {TotalLength} founis");

			RuleFor(tache => tache.DateFin)
				.Cascade(CascadeMode.Stop)
				.NotEmpty().WithMessage("La datte de fin ne peut pas être nulle")
				.Must(ValidDatteFin).WithMessage("La datte de fin doit être supérieure au " + DateTime.Now.ToShortDateString());

			RuleFor(tache => tache.Cycle)
				.Cascade(CascadeMode.Stop)
				.GreaterThanOrEqualTo(0).WithMessage("Le {PropertyName} ne peut pas être négatif");

			RuleFor(tache => tache.LocataireId)
				.Cascade(CascadeMode.Stop)
				.GreaterThan(0).WithMessage("Le locataire courant est invalide");
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
