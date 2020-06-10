using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Couche_Acces
{
	public class Base
	{
		#region Données membres
		protected SqlCommand _commande;
		protected String _table;
		protected List<(string, Type)> _champs = new List<(string, Type)>();
		#endregion

		#region Constructeurs (étendus)
		/// <summary>
		/// Constructeur par défaut
		/// </summary>
		/// <remarks>La chaîne de connexion est récupérée en argument</remarks>
		public Base(string sChaineConnexion)
		{
			_commande = new SqlCommand
			{
				Connection = new SqlConnection(sChaineConnexion)
			};
		}

		/// <summary>
		/// Méthode assignant une procédure stockée
		/// </summary>
		/// <param name="sCommande">Nom de la procédure stockée</param>
		public void CreerCommande(string sCommande)
		{
			_commande.CommandType = CommandType.StoredProcedure;
			_commande.CommandText = sCommande;

			AddTableAsParam();
		}
		/// <summary>
		/// Méthode assignant une procédure stockée ET une chaîne de connexion
		/// </summary>
		/// <param name="sCommande">Nom de la procédure stockée</param>
		/// <param name="sConnexion">Chaîne de connexion à utiliser</param>
		public void CreerCommande(string sCommande, string sConnexion)
		{
			_commande.Connection = new SqlConnection(sConnexion);
			_commande.CommandType = CommandType.StoredProcedure;
			_commande.CommandText = sCommande;
		}
		/// <summary>
		/// Méthode assignant une procédure stockée et le type de requête
		/// </summary>
		/// <param name="sCommande">Nom de la procédure stockée</param>
		/// <param name="bTypeProcedures">Type de requête (Vrai=stockée, Faux=Texte)</param>
		public void CreerCommande(string sCommande, bool bTypeRequete)
		{
			if (bTypeRequete) _commande.CommandType = CommandType.StoredProcedure;
			else _commande.CommandType = CommandType.Text;
			_commande.CommandText = sCommande;
		}
		/// <summary>
		/// Méthode assignant une procédure stockée, une chaîne de connexion et le type de requête
		/// </summary>
		/// <param name="sCommande">Nom de la procédure stockée</param>
		/// <param name="sConnexion">Chaîne de connexion à utiliser</param>
		/// <param name="bTypeProcedures">Type de requête (Vrai=stockée, Faux=Texte)</param>
		public void CreerCommande(string sCommande, bool bTypeRequete, string sConnexion)
		{
			_commande.Connection = new SqlConnection(sConnexion);
			if (bTypeRequete) _commande.CommandType = CommandType.StoredProcedure;
			else _commande.CommandType = CommandType.Text;
			_commande.CommandText = sCommande;
		}
		#endregion

		#region Accesseurs
		public SqlCommand Commande
		{
			get => _commande;
			set => _commande = value;
		}
		#endregion

		#region Utilitaires

		public void Direction(string sParam, ParameterDirection dParam)
		{
			Commande.Parameters[sParam].Direction = dParam;
		}

		public string LireParametre(string sParam)
		{
			return Commande.Parameters[sParam].Value.ToString();
		}

		protected void AddParameter(string name, object value)
		{
			Commande.Parameters.AddWithValue("@" + name, (dynamic) value);
		}

		protected void AddParameters(params object[] values)
		{
			if(values.Length != _champs.Count - 1)
				throw new Exception("Nombre de paramètres inexact");

			/*int idChamp = 0;

			if (withId == false)
				idChamp = 1;

			while (idChamp < values.Length)
			{
				AddParameter(_champs[idChamp].Item1, values[idChamp]);

				idChamp++;
			}*/

			for (int i = 0; i < values.Length; i++)
			{
				AddParameter(_champs[i + 1].Item1, values[i]);
				//Commande.Parameters.AddWithValue("@" + _champs[i].Item1, (dynamic)values[i]);
			}
		}

		protected string LireChamp(SqlDataReader sqlDataReader, string champ)
		{
			return sqlDataReader[champ].ToString();
		}

		protected void AddTableAsParam()
		{
			AddParameter("Table", Table);
		}
		#endregion

		protected string Table
		{
			get => _table;
			set => _table = value;
		}
	}
}
