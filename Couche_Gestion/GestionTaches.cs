using System;
using System.Collections.Generic;
using Couche_Acces;
using Couche_Classe;

namespace Couche_Gestion
{
	public class GestionTaches : Base
	{
		public GestionTaches()
		{
		}

		public GestionTaches(string sChaineConnexion) : base(sChaineConnexion)
		{
		}

		public int Ajouter(string nom, DateTime datteFin, bool active, int locataireCourant)
		{
			string activeBdd;

			if (active)
				activeBdd = "1";
			else
				activeBdd = "0";

			return new AccesTaches(ChaineConnexion).Ajouter(nom, datteFin, activeBdd, locataireCourant);
		}

		public List<Taches> Lire(string index)
		{
			return new AccesTaches(ChaineConnexion).Lire(index).ConvertAll(x => (Taches)x);
		}
	}
}
