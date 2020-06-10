using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Couche_Classe;

namespace Couche_Acces
{
	public class Acces_Locataire : Base
	{
		public Acces_Locataire(string sChaineConnexion)
		  : base(sChaineConnexion)
		{
			Table = "Locataires";

			_champs.Add(("id", typeof(int)));
			_champs.Add(("nom", typeof(string)));
			_champs.Add(("password", typeof(string)));
		}

		public int Ajouter(string nom, string password)
		{
			CreerCommande("Ajouter");

			/*Commande.Parameters.Add("id", SqlDbType.Int);
			Direction("id", ParameterDirection.Output);*/

			AddParameters(nom, password);

			Commande.Connection.Open();

			Commande.ExecuteNonQuery();
			

			//int num = int.Parse(LireParametre("id"));
			int num = 0;

			Commande.Connection.Close();

			return num;
		}

		public int Modifier(int id, string nom, string password)
		{
			CreerCommande("Modifier");
			int num = 0;

			AddParameters(true, id, nom, password);

			Commande.Connection.Open();

			Commande.ExecuteNonQuery();

			Commande.Connection.Close();

			return num;
		}

		public List<Locataire> Lire(string index)
		{
			CreerCommande("Lire");

			Commande.Parameters.AddWithValue("@Index", index);
			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();
			List<Locataire> cClientsList = new List<Locataire>();

			while (sqlDataReader.Read())
				cClientsList.Add(new Locataire
				{
					Id = int.Parse(LireChamp(sqlDataReader, "id")),
					Nom = LireChamp(sqlDataReader, "nom"),
					Password = LireChamp(sqlDataReader, "password")
				});

			sqlDataReader.Close();
			Commande.Connection.Close();

			return cClientsList;
		}

		public Locataire LireId(int id)
		{
			CreerCommande("LireId");

			Commande.Parameters.AddWithValue("@id", id);
			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();
			Locataire cClients = new Locataire();

			while (sqlDataReader.Read())
			{
				cClients.Id = int.Parse(LireChamp(sqlDataReader, "id"));
				cClients.Nom = LireChamp(sqlDataReader, "nom");
				cClients.Password = LireChamp(sqlDataReader, "password");
			}

			sqlDataReader.Close();
			Commande.Connection.Close();

			return cClients;
		}

		public int Supprimer(int id)
		{
			CreerCommande("SupprimerClients");

			//Commande.Parameters.AddWithValue("@id", id);
			AddParameter("id", id);

			Commande.Connection.Open();
			int num = Commande.ExecuteNonQuery();

			Commande.Connection.Close();

			return num;
		}
	}
}
