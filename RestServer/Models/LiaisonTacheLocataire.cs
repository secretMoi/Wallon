using System.ComponentModel.DataAnnotations;

namespace RestServer.Models
{
	public class LiaisonTacheLocataire
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int LocataireId { get; set; } // foreign key
		public Locataire Locataire { get; set; } // contenu lié à l'objet


		[Required]
		public int TacheId { get; set; } // foreign key
		public Tache Tache { get; set; } // contenu lié à l'objet
	}
}
