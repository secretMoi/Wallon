using System;

namespace Models.Dtos.Taches
{
	public class TacheCreateDto : ITache
	{
		public string Nom { get; set; }

		public string Description { get; set; }

		public DateTime DateFin { get; set; }

		public bool? Active { get; set; }

		public int? LocataireId { get; set; } // foreign key

		public int Cycle { get; set; }
	}
}
