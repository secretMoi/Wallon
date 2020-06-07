using System;

namespace QMag.Core
{
	class Money
	{
		private decimal _montant;

		public Money(decimal montant = Decimal.Zero)
		{
			_montant = Round(montant);
		}

		public override string ToString()
		{
			return _montant + " €";
		}

		public static string Display(decimal montant)
		{
			return Round(montant) + " €";
		}

		public static decimal Round(decimal montant)
		{
			return decimal.Round(montant, 2);
		}

		public static string CleanDevise(string montant)
		{
			return montant.Split(' ')[0];
		}

		public decimal Montant
		{
			get => _montant;
			set => _montant = value;
		}
	}
}
