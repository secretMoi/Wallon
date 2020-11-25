using Models.Models;

namespace Models.Dtos.Suggestions
{
	public class SuggestionUpdateDto : IUpdate, ISuggestion
	{
		public int Id { get; set; }

		public string Nom { get; set; }

		public string Description { get; set; }

		public int? LocataireId { get; set; } // foreign key

		public virtual Locataire Locataire { get; set; } // contenu de status lié à l'objet

		public bool? Active { get; set; }
	}
}
