using System;
using System.Collections.Generic;
using System.Text;

namespace Couche_Classe
{
	public class Locataire : Base
	{
		public Locataire()
		{
		}

		public Locataire(string nom, byte[] password)
		{
			Nom = nom;
			Password = password;
		}

		public Locataire(string nom, string password)
		{
			Nom = nom;
			Password = Encoding.ASCII.GetBytes(password);
		}

		public Locataire(int id, string nom, byte[] password)
			: this(nom, password)
		{
			Id = id;
		}

		public void Hydrate(params object[] arguments)
		{

		}

		public override List<(string, Type)> GetChamps()
		{
			if (_champs.Count == 0)
			{
				_champs.Add(("id", typeof(int)));
				_champs.Add(("nom", typeof(string)));
				_champs.Add(("password", typeof(byte[])));
			}

			return _champs;
		}

		public int Id { get; set; }

		public string Nom { get; set; }
		public byte[] Password { get; set; }
	}
}
