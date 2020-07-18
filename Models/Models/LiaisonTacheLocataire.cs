namespace Models.Models
{
	public class LiaisonTacheLocataire
	{
		public int Id { get; set; }

		public int LocataireId { get; set; } // foreign key
		public Locataire Locataire { get; set; } // contenu lié à l'objet


		public int TacheId { get; set; } // foreign key
		public Tache Tache { get; set; } // contenu lié à l'objet
	}
}
