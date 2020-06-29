namespace Couche_Gestion
{
	public class Base
	{
		#region Constructeurs
		public Base()
		{
			ChaineConnexion = "";
		}

		public Base(string sChaineConnexion)
		{
			ChaineConnexion = sChaineConnexion;
		}
		#endregion

		public bool TestConnection()
		{
			return new Couche_Acces.Base(ChaineConnexion).TestConnection();
		}

		public void Supprimer(int id)
		{
			new Couche_Acces.Base(ChaineConnexion).Supprimer(id);
		}

		#region Accesseur
		public string ChaineConnexion { get; set; }

		#endregion
	}
}
