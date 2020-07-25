namespace Models.Models
{
	public class LiaisonTacheLocataire
	{
		public int Id { get; set; }

		public bool? Active { get; set; }

		public int LocataireId { get; set; } // foreign key
		public virtual Locataire Locataire { get; set; } // contenu lié à l'objet


		public int TacheId { get; set; } // foreign key
		public virtual Tache Tache { get; set; } // contenu lié à l'objet
	}
}
