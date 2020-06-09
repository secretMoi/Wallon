namespace Couche_Gestion
{
	public class Base
	{
		#region Données membres
		string _chaineConnexion;
		#endregion

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

		#region Accesseur
		public string ChaineConnexion
		{
			get => _chaineConnexion;
			set => _chaineConnexion = value;
		}
		#endregion
	}
}
