﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

		public List<int> LireTache(int idTache)
		{
			CreerCommande("LiaisonTachesLocatairesLireTache");

			Commande.Parameters.AddWithValue("@idTache", idTache);

			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();

			List<int> liste = new List<int>(); // crée la liste à retourner

			while (sqlDataReader.Read())
			{
				liste.Add(int.Parse(sqlDataReader["idLocataire"].ToString()));
			}
			
			sqlDataReader.Close();
			Commande.Connection.Close();

			return liste;
		}
	}
}
