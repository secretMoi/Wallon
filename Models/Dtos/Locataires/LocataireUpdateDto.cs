namespace Models.Dtos.Locataires
{
	public class LocataireUpdateDto
	{
		public string Nom { get; set; }

		public byte[] Password { get; set; }

		public bool Actif { get; set; }
	}
}
