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

		public int Ajouter(Taches tache)
		{
			string activeBdd;

			if (tache.Active)
				activeBdd = "1";
			else
				activeBdd = "0";

			return new AccesTaches(ChaineConnexion).Ajouter(
				tache.Nom,
				tache.DatteFin,
				activeBdd,
				tache.LocataireCourant,
				tache.Cycle
			);
		}

		public List<Taches> Lire(string index)
		{
			return new AccesTaches(ChaineConnexion).Lire(index).ConvertAll(x => (Taches)x);
		}
	}
}
