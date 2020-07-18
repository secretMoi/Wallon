using System;

namespace Models.Dtos.Taches
{
	public class TacheUpdateDto
	{
		public string Nom { get; set; }

		public DateTime DatteFin { get; set; }

		public bool Active { get; set; }

		public int LocataireId { get; set; } // foreign key

		public int Cycle { get; set; }
	}
}
