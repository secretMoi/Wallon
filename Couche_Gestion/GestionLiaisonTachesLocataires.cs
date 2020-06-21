using System.Collections.Generic;
using Couche_Acces;
using Couche_Classe;

namespace Couche_Gestion
{
	public class GestionLiaisonTachesLocataires : Base
	{
		public GestionLiaisonTachesLocataires()
		{

		}

		public GestionLiaisonTachesLocataires(string sChaineConnexion) : base(sChaineConnexion)
		{
		}

		public int Ajouter(LiaisonTachesLocataires liaison)
		{
			return new AccesLiaisonTachesLocataires(ChaineConnexion).Ajouter(liaison.Locataire, liaison.Tache);
		}

		public int Modifier(int id, int locataire, int tache)
		{
			return new AccesLiaisonTachesLocataires(ChaineConnexion).Modifier(id, locataire, tache);
		}

		public List<LiaisonTachesLocataires> Lire(string index)
		{
			return new AccesLiaisonTachesLocataires(ChaineConnexion).Lire(index).ConvertAll(x => (LiaisonTachesLocataires)x);
		}

		public LiaisonTachesLocataires LireId(int id)
		{
			return new AccesLiaisonTachesLocataires(ChaineConnexion).LireId(id) as LiaisonTachesLocataires;
		}

		public int Supprimer(int id)
		{
			return new AccesLiaisonTachesLocataires(ChaineConnexion).Supprimer(id);
		}

		public List<int> LireTachesLocataire(int idLocataire)
		{
			return new AccesLiaisonTachesLocataires(ChaineConnexion).LireTachesLocataire(idLocataire);
		}

		public List<int> ListeLocataires(int idTache)
		{
			return new AccesLiaisonTachesLocataires(ChaineConnexion).ListeLocataires(idTache);
		}
	}
}
