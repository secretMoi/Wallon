using System.Data;
using Couche_Classe;

namespace Couche_Acces
{
	public class Acces_Locataire : Base
	{
		public Acces_Locataire(string sChaineConnexion)
		  : base(sChaineConnexion)
		{
			Table = "Locataires";

			_classesBase = new Locataire();
		}

		public int Ajouter(string nom, string password)
		{
			CreerCommande("LocataireAjouter");

			Commande.Parameters.Add("id", SqlDbType.Int);
			Direction("id", ParameterDirection.Output);

			AddParameters(nom, password);

			Commande.Connection.Open();

			Commande.ExecuteNonQuery();
			
			int num = int.Parse(LireParametre("id"));

			Commande.Connection.Close();

			return num;
		}

		public int Modifier(int id, string nom, string password)
		{
			CreerCommande("LocataireModifier");
			int num = 0;

			AddParametersWithId(id, nom, password);

			Commande.Connection.Open();

			Commande.ExecuteNonQuery();

			Commande.Connection.Close();

			return num;
		}

		public int Supprimer(int id)
		{
			CreerCommande("Supprimer");

			//Commande.Parameters.AddWithValue("@id", id);
			AddParameter("id", id);

			Commande.Connection.Open();
			int num = Commande.ExecuteNonQuery();

			Commande.Connection.Close();

			return num;
		}
	}
}
