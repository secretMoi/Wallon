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

		public int Modifier(Taches tache)
		{
			return new AccesTaches(ChaineConnexion).Modifier(
				tache.Id,
				tache.Nom,
				tache.DatteFin,
				tache.Active,
				tache.LocataireCourant,
				tache.Cycle
			);
		}

		public List<Taches> Lire(string index)
		{
			//return await Task.Run(() => new AccesTaches(ChaineConnexion).Lire(index).ConvertAll(x => (Taches)x));
			return new AccesTaches(ChaineConnexion).Lire(index).ConvertAll(x => (Taches)x);
		}

		public Taches LireId(int id)
		{
			return new AccesTaches(ChaineConnexion).LireId(id) as Taches;
		}

		public List<Taches> TachesCourantesDuLocataire(int idLocataire)
		{
			return new AccesTaches(ChaineConnexion).TachesCourantesDuLocataire(idLocataire).ConvertAll(x => (Taches)x);
		}
	}
}
