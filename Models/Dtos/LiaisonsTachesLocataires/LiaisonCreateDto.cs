namespace Models.Dtos.LiaisonsTachesLocataires
{
	public class LiaisonCreateDto : ILiaison
	{
		public int LocataireId { get; set; }
		public int TacheId { get; set; }
	}
}
