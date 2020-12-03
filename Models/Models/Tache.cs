using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
	public class Tache
	{
		public int Id { get; set; }
		public string Nom { get; set; }
		public string Description { get; set; }
		public DateTime DateFin { get; set; }
		public bool? Active { get; set; }
		public int? LocataireId { get; set; } // foreign key

		[ForeignKey("LocataireId")]
		public virtual Locataire Locataire { get; set; } // contenu de status lié à l'objet
		public int Cycle { get; set; }
	}
}
