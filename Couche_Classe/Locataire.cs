namespace Couche_Classe
{
	public class Locataire
	{
		public Locataire()
		{
		}

		public Locataire(string nom, string password)
		{
			Nom = nom;
			Password = password;
		}

		public Locataire(int id, string nom, string password)
			: this(nom, password)
		{
			Id = id;
		}

		public int Id { get; set; }

		public string Nom { get; set; }
		public string Password { get; set; }
	}
}
