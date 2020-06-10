using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Couche_Classe;

namespace Couche_Acces
{
	public class Base
	{
		#region Données membres
		protected SqlCommand _commande;
		protected string _table;

		protected Couche_Classe.Base _classesBase;
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
		/// <param name="bTypeRequete">Type de requête (Vrai=stockée, Faux=Texte)</param>
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
		/// <param name="bTypeRequete">Type de requête (Vrai=stockée, Faux=Texte)</param>
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
			if(values.Length != _classesBase.GetChamps().Count - 1)
				throw new Exception("Nombre de paramètres inexact");

			for (int i = 0; i < values.Length; i++)
			{
				AddParameter(_classesBase.GetChamps()[i + 1].Item1, values[i]);
			}
		}

		protected void AddParametersWithId(params object[] values)
		{
			if (values.Length != _classesBase.GetChamps().Count)
				throw new Exception("Nombre de paramètres inexact");

			for (int i = 0; i < values.Length; i++)
			{
				AddParameter(_classesBase.GetChamps()[i].Item1, values[i]);
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

		public List<Couche_Classe.Base> Lire(string index)
		{
			CreerCommande("Lire");

			AddTableAsParam();

			Commande.Parameters.AddWithValue("@Index", index);
			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();


			//IList liste = CreateList(_classesBase.GetType());

			List<Couche_Classe.Base> liste = AssigneChamp(sqlDataReader);

			/*while (sqlDataReader.Read())
				liste.Add(new Locataire
				{
					Id = int.Parse(LireChamp(sqlDataReader, "id")),
					Nom = LireChamp(sqlDataReader, "nom"),
					Password = LireChamp(sqlDataReader, "password")
				});*/

			sqlDataReader.Close();
			Commande.Connection.Close();

			return liste;
		}

		protected List<Couche_Classe.Base> AssigneChamp(SqlDataReader sqlDataReader)
		{
			// get type information
			Type type = _classesBase.GetType();

			List<Couche_Classe.Base> liste = new List<Couche_Classe.Base>();

			while (sqlDataReader.Read())
			{
				// invoke the first public constructor with no parameters.
				object classe = Activator.CreateInstance(type,
					int.Parse(LireChamp(sqlDataReader, "id")),
					LireChamp(sqlDataReader, "nom"),
					LireChamp(sqlDataReader, "password")
				);

				liste.Add(classe as Couche_Classe.Base);
			}

			return liste;
		}

		//private object[] 

		/*public IList CreateList(Type myType)
		{
			Type genericListType = typeof(List<>).MakeGenericType(myType);

			return (IList)Activator.CreateInstance(genericListType);
		}*/

		protected string Table
		{
			get => _table;
			set => _table = value;
		}
	}
}
