using System.Collections.Generic;
using Couche_Acces;
using Couche_Classe;

namespace Couche_Gestion
{
	public class Gestion_Locataire : Base
	{
		public Gestion_Locataire()
		{
		}

		public Gestion_Locataire(string sChaineConnexion)
			: base(sChaineConnexion)
		{
		}

		public int Ajouter(string nom, string password)
		{
			return new Acces_Locataire(ChaineConnexion).Ajouter(nom, password);
		}

		public int Modifier(int id, string nom, string password)
		{
			return new Acces_Locataire(ChaineConnexion).Modifier(id, nom, password);
		}

		public List<Locataire> Lire(string index)
		{
			return new Acces_Locataire(ChaineConnexion).Lire(index).ConvertAll(x => (Locataire)x);
		}

		public Locataire LireId(int id)
		{
			return new Acces_Locataire(ChaineConnexion).LireId(id);
		}

		public int Supprimer(int id)
		{
			return new Acces_Locataire(ChaineConnexion).Supprimer(id);
		}
	}
}
