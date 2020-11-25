namespace Models.Dtos.Locataires
{
	public class LocataireReadDto : IRead, ILocataire
	{
		public int Id { get; set; }

		public string Nom { get; set; }

		public byte[] Password { get; set; }

		public bool Actif { get; set; }
	}
}
