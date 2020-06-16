using System;
using System.Collections.Generic;

namespace Couche_Classe
{
	public class Taches : Base
	{
		public Taches()
		{
		}

		public Taches(string nom, DateTime datteFin, bool actif, int locataireCourant, int cycle)
		{
			Nom = nom;
			DatteFin = datteFin;
			Active = actif;
			LocataireCourant = locataireCourant;
			Cycle = cycle;
		}

		public Taches(int id, string nom, DateTime datteFin, bool actif, int locataireCourant, int cycle) :
			this(nom, datteFin, actif, locataireCourant, cycle)
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
				_champs.Add(("locataireCourant", typeof(int)));
				_champs.Add(("cycle", typeof(int)));
			}

			return _champs;
		}

		public int Id { get; set; }

		public string Nom { get; set; }
		public DateTime DatteFin { get; set; }
		public bool Active { get; set; }
		public int LocataireCourant { get; set; }
		public int Cycle { get; set; }
	}
}
