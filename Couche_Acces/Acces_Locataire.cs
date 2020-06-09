using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Couche_Classe;

namespace Couche_Acces
{
	public class Acces_Locataire : Base
	{
		public Acces_Locataire(string sChaineConnexion)
		  : base(sChaineConnexion)
		{
		}

		public int Ajouter(string nom, string password)
		{
			CreerCommande("LocataireAjouter");

			Commande.Parameters.Add("id", SqlDbType.Int);
			Direction("id", ParameterDirection.Output);

			Commande.Parameters.AddWithValue("@nom", nom);
			Commande.Parameters.AddWithValue("@password", password);

			Commande.Connection.Open();
			Commande.ExecuteNonQuery();

			int num = int.Parse(LireParametre("id"));

			Commande.Connection.Close();

			return num;
		}

		public int Modifier(int id, string nom, string password)
		{
			CreerCommande("ModifierClients");
			int num = 0;

			Commande.Parameters.AddWithValue("@id", id);
			Commande.Parameters.AddWithValue("@nom", nom);
			Commande.Parameters.AddWithValue("@password", password);
			Commande.Connection.Open();

			Commande.ExecuteNonQuery();

			Commande.Connection.Close();

			return num;
		}

		public List<Locataire> Lire(string Index)
		{
			CreerCommande("SelectionnerClients");

			Commande.Parameters.AddWithValue("@Index", Index);
			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();
			List<Locataire> cClientsList = new List<Locataire>();

			while (sqlDataReader.Read())
				cClientsList.Add(new Locataire
				{
					Id = int.Parse(sqlDataReader["id"].ToString()),
					Nom = sqlDataReader["nom"].ToString(),
					Password = sqlDataReader["password"].ToString()
				});

			sqlDataReader.Close();
			Commande.Connection.Close();

			return cClientsList;
		}

		public Locataire Lire_ID(int id)
		{
			CreerCommande("SelectionnerClients_ID");

			Commande.Parameters.AddWithValue("@id", id);
			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();
			Locataire cClients = new Locataire();

			while (sqlDataReader.Read())
			{
				cClients.Id = int.Parse(sqlDataReader[nameof(id)].ToString());
				cClients.Nom = sqlDataReader["nom"].ToString();
				cClients.Password = sqlDataReader["password"].ToString();
			}

			sqlDataReader.Close();
			Commande.Connection.Close();

			return cClients;
		}

		public int Supprimer(int id)
		{
			CreerCommande("SupprimerClients");

			Commande.Parameters.AddWithValue("@id", id);

			Commande.Connection.Open();
			int num = Commande.ExecuteNonQuery();

			Commande.Connection.Close();

			return num;
		}
	}
}
