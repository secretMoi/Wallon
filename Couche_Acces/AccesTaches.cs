using Couche_Classe;

namespace Couche_Acces
{
	public class AccesTaches : Base
	{
		public AccesTaches(string sChaineConnexion) : base(sChaineConnexion)
		{
			Table = "Taches";

			_classesBase = new Taches();
		}
	}
}
