using Couche_Classe;

namespace Couche_Acces
{
	public class Acces_Locataire : Base
	{
		public Acces_Locataire(string sChaineConnexion) : base(sChaineConnexion)
		{
			Table = "Locataires";

			_classesBase = new Locataire();
		}
	}
}
