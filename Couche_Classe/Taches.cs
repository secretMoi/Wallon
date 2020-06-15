using System;
using System.Collections.Generic;

namespace Couche_Classe
{
	public class Taches : Base
	{
		public Taches()
		{
		}

		public Taches(string nom, DateTime datteFin, bool actif)
		{
			Nom = nom;
			DatteFin = datteFin;
			Active = actif;
		}

		public Taches(int id, string nom, DateTime datteFin, bool actif) : this(nom, datteFin, actif)
		{
			Id = id;
		}

		public override List<(string, Type)> GetChamps()
		{
			if (_champs.Count == 0)
			{
				_champs.Add(("id", typeof(int)));
				_champs.Add(("nom", typeof(string)));
				_champs.Add(("datteFin", typeof(DateTime)));
				_champs.Add(("active", typeof(bool)));
			}

			return _champs;
		}

		public int Id { get; set; }

		public string Nom { get; set; }
		public DateTime DatteFin { get; set; }
		public bool Active { get; set; }
	}
}
