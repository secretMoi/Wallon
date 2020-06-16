using System;
using System.Collections.Generic;

namespace Couche_Classe
{
	public class LiaisonTachesLocataires : Base
	{
		public LiaisonTachesLocataires()
		{
		}

		public LiaisonTachesLocataires(int locataire, int tache)
		{
			Locataire = locataire;
			Tache = tache;
		}

		public LiaisonTachesLocataires(int id, int locataire, int tache) : this(locataire, tache)
		{
			Id = id;
		}

		public override List<(string, Type)> GetChamps()
		{
			if (_champs.Count == 0)
			{
				_champs.Add(("id", typeof(int)));
				_champs.Add(("idLocataire", typeof(int)));
				_champs.Add(("idTache", typeof(int)));
			}

			return _champs;
		}

		public int Id { get; set; }

		public int Locataire { get; set; }
		public int Tache { get; set; }
	}
}
