using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
	public class Suggestion
	{
		public int Id { get; set; }

		public string Nom { get; set; }

		public string Description { get; set; }

		public int? LocataireId { get; set; } // foreign key

		[ForeignKey("LocataireId")]
		public virtual Locataire Locataire { get; set; } // contenu de status lié à l'objet
	}
}
