using System.ComponentModel;

namespace Models.Models
{
	public class Locataire
	{
		public int Id { get; set; }

		public string Nom { get; set; }

		public byte[] Password { get; set; }

		public bool? Actif { get; set; }
	}
}
