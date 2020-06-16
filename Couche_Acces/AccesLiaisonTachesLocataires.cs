using Couche_Classe;

namespace Couche_Acces
{
	public class AccesLiaisonTachesLocataires : Base
	{
		public AccesLiaisonTachesLocataires(string sChaineConnexion) : base(sChaineConnexion)
		{
			Table = "LiaisonTachesLocataires";

			_classesBase = new LiaisonTachesLocataires();
		}
	}
}
