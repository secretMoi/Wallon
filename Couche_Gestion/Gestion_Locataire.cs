using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			return new Acces_Locataire(this.ChaineConnexion).Ajouter(nom, password);
		}

		public int Modifier(int id, string nom, string password)
		{
			return new Acces_Locataire(this.ChaineConnexion).Modifier(id, nom, password);
		}

		public List<Locataire> Lire(string Index)
		{
			return new Acces_Locataire(this.ChaineConnexion).Lire(Index);
		}

		public Locataire Lire_ID(int id)
		{
			return new Acces_Locataire(this.ChaineConnexion).Lire_ID(id);
		}

		public int Supprimer(int id)
		{
			return new Acces_Locataire(this.ChaineConnexion).Supprimer(id);
		}
	}
}
