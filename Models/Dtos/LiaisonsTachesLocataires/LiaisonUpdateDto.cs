namespace Models.Dtos.LiaisonsTachesLocataires
{
	public class LiaisonUpdateDto : IUpdate, ILiaison
	{
		public int Id { get; set; }
		public int LocataireId { get; set; }
		public int TacheId { get; set; }
	}
}
