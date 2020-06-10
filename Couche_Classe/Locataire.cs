using System;
using System.Collections.Generic;

namespace Couche_Classe
{
	public class Locataire : Base
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

		public void Hydrate(params object[] arguments)
		{

		}

		public override List<(string, Type)> GetChamps()
		{
			if (_champs.Count == 0)
			{
				_champs.Add(("id", typeof(int)));
				_champs.Add(("nom", typeof(string)));
				_champs.Add(("password", typeof(string)));
			}

			return _champs;
		}

		public int Id { get; set; }

		public string Nom { get; set; }
		public string Password { get; set; }
	}
}
