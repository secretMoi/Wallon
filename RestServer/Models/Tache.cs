using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestServer.Models
{
	public class Tache
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(256)]
		[Column(TypeName = "varchar(256)")]
		public string Nom { get; set; }

		[Required]
		public DateTime DatteFin { get; set; }

		[Required]
		[DefaultValue(true)]
		public bool Active { get; set; }

		[Required]
		public int LocataireId { get; set; } // foreign key
		public Locataire LocataireCourant { get; set; } // contenu de status lié à l'objet

		[Required]
		public int Cycle { get; set; }
	}
}
