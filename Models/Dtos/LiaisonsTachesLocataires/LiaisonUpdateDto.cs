namespace Models.Dtos.LiaisonsTachesLocataires
{
	public class LiaisonUpdateDto : IUpdate
	{
		public int Id { get; set; }
		public int LocataireId { get; set; }
		public int TacheId { get; set; }
	}
}
