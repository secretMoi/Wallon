using RestServer.Models;

namespace RestServer.Dtos.LiaisonsTachesLocataires
{
	public class LiaisonReadDto
	{
		public int Id { get; set; }
		public int LocataireId { get; set; }
		public Locataire Locataire { get; set; }
		public int TacheId { get; set; }
		public Tache Tache { get; set; }
	}
}
