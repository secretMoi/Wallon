namespace Models.Dtos.Locataires
{
	public class LocataireCreateDto : ILocataire
	{
		public string Nom { get; set; }

		public byte[] Password { get; set; }
	}
}
