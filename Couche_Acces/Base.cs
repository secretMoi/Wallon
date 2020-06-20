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

		/// <summary>
		/// Ajoute un seul paramètre à une requête SQL
		/// </summary>
		/// <param name="name">Nom du paramètre dans la procédure stockée</param>
		/// <param name="value">Valeur du paramètre</param>
		protected void AddParameter(string name, object value)
		{
			Commande.Parameters.AddWithValue("@" + name, (dynamic) value);
		}

		/// <summary>
		/// Ajoute une liste de paramètres à une requête SQL SANS l'id
		/// </summary>
		/// <param name="values">Tableau dynamique contenant les paramètres</param>
		protected void AddParameters(params object[] values)
		{
			if(values.Length != _classesBase.GetChamps().Count - 1)
				throw new Exception("Nombre de paramètres inexact");

			for (int i = 0; i < values.Length; i++)
				AddParameter(_classesBase.GetChamps()[i + 1].Item1, values[i]);
		}

		/// <summary>
		/// Ajoute une liste de paramètres à une requête SQL comprenant l'id
		/// </summary>
		/// <param name="values">Tableau dynamique contenant les paramètres</param>
		protected void AddParametersWithId(params object[] values)
		{
			if (values.Length != _classesBase.GetChamps().Count)
				throw new Exception("Nombre de paramètres inexact");

			for (int i = 0; i < values.Length; i++)
				AddParameter(_classesBase.GetChamps()[i].Item1, values[i]);
		}

		protected string LireChamp(SqlDataReader sqlDataReader, string champ)
		{
			return sqlDataReader[champ].ToString();
		}

		/// <summary>
		/// Ajoute la table de la classe enfant aux paramètres de la procédure stockée
		/// </summary>
		protected void AddTableAsParam()
		{
			AddParameter("Table", Table);
		}
		#endregion

		/// <summary>
		/// Permet d'ajouter un enregistrement
		/// </summary>
		/// <param name="arguments">Liste des valeurs que va prendre l'enregistrement</param>
		/// <returns>Id du nouvel enregistrement</returns>
		public int Ajouter(params object[] arguments)
		{
			CreerCommande(Table + "Ajouter");

			Commande.Parameters.Add("id", SqlDbType.Int);
			Direction("id", ParameterDirection.Output);

			AddParameters(arguments);

			Commande.Connection.Open();

			Commande.ExecuteNonQuery();

			int num = int.Parse(LireParametre("id"));

			Commande.Connection.Close();

			return num;
		}

		/// <summary>
		/// Permet de modifier un enregistrement grâce à son id
		/// </summary>
		/// <param name="arguments">Liste des nouvelles valeurs que va prendre l'enregistrement</param>
		public int Modifier(params object[] arguments)
		{
			CreerCommande(Table + "Modifier");

			AddParametersWithId(arguments);

			Commande.Connection.Open();

			Commande.ExecuteNonQuery();

			Commande.Connection.Close();

			return 0;
		}

		/// <summary>
		/// Permet de supprimer un enregistrement grâce à son id
		/// </summary>
		/// <param name="id">Id de l'enregistrement à supprimer</param>
		public int Supprimer(int id)
		{
			CreerCommande(Table + "Supprimer");

			AddTableAsParam();

			AddParameter("id", id);

			Commande.Connection.Open();
			int num = Commande.ExecuteNonQuery();

			Commande.Connection.Close();

			return num;
		}

		/// <summary>
		/// Permet de récupérer tous les enregistrements d'une table
		/// </summary>
		/// <param name="index">Détermine l'ordre de tri</param>
		/// <returns>Une liste des enregistrements trouvés</returns>
		public List<Couche_Classe.Base> Lire(string index)
		{
			CreerCommande("Lire");

			AddTableAsParam();

			Commande.Parameters.AddWithValue("@Index", index);
			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();

			List<Couche_Classe.Base> liste = AssigneChamp(sqlDataReader);

			sqlDataReader.Close();
			Commande.Connection.Close();

			return liste;
		}

		/// <summary>
		/// Permet de récupérer un enregistrement grâce à son id
		/// </summary>
		/// <param name="id">L'id de l'élément à recupérer</param>
		/// <returns>L'enregistrement trouvé</returns>
		public Couche_Classe.Base LireId(int id)
		{
			CreerCommande("LireId");

			AddTableAsParam();

			Commande.Parameters.AddWithValue("@id", id);
			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();

			Couche_Classe.Base element = AssigneChamp(sqlDataReader)[0];

			sqlDataReader.Close();
			Commande.Connection.Close();

			return element;
		}

		/// <summary>
		/// Construit la requête SQL pour un SELECT
		/// </summary>
		/// <returns>Une liste des enregistrements trouvés</returns>
		protected List<Couche_Classe.Base> AssigneChamp(SqlDataReader sqlDataReader)
		{
			Type type = _classesBase.GetType(); // récupère le type de l'objet

			List<Couche_Classe.Base> liste = new List<Couche_Classe.Base>(); // crée la liste à retourner

			while (sqlDataReader.Read()) // parcourt toutes les données SQL reçues
			{
				object[] arguments = GenereArguments(sqlDataReader); // prépare les arguments en vue d'hydrater l'objet

				object classe = Activator.CreateInstance(type, arguments); // instancie l'objet dans son type et l'hydrate

				liste.Add(classe as Couche_Classe.Base); // ajoute l'objet à la liste de retour
			}

			return liste;
		}

		/// <summary>
		/// Génère les champs automatiquement pour les requêtes SQL de lecture
		/// </summary>
		/// <returns>La liste des valeurs des champs créés dans le type adéquat</returns>
		/// <remarks>La chaîne de connexion est récupérée en argument</remarks>
		protected object[] GenereArguments(SqlDataReader sqlDataReader)
		{
			object[] arguments = new object[_classesBase.GetChamps().Count]; // tableau pour contenir la valeur des champs

			(string, Type) champ;
			string valeur;

			// pour chaque champ, on teste son type et on fait le cast adéquat
			for (int i = 0; i < _classesBase.GetChamps().Count; i++)
			{
				champ = _classesBase.GetChamps()[i];
				valeur = LireChamp(sqlDataReader, champ.Item1);

				if (champ.Item2 == typeof(string)) // si le champ est de type string
					arguments[i] = LireChamp(sqlDataReader, champ.Item1);
				else if (champ.Item2 == typeof(int)) // si le champ est un simple int
				{
					try
					{
						arguments[i] = int.Parse(LireChamp(sqlDataReader, champ.Item1));
					}
					catch
					{
						throw new Exception("Impossible de convertir la valeur " + valeur + " en nombre");
					}
				}
				else if (champ.Item2 == typeof(bool)) // si le champ est un booléen
				{
					if (valeur == "False")
						arguments[i] = false;
					else if (valeur == "True")
						arguments[i] = true;
					else
						throw new Exception("Le booléen dans la BDD n'est pas valide");
				}
				else if (champ.Item2 == typeof(DateTime)) // si le champ est un DateTime
					arguments[i] = Convert.ToDateTime(valeur);

				else
					throw new Exception(
						"Type de paramètre inconnu venant de la BDD pour la valeur " + valeur +
						" du type " + champ.Item2 +
						" de la colonne " + champ.Item1 +
						" de la table " + _table
					);
			}

			return arguments;
		}

		protected string Table
		{
			get => _table;
			set => _table = value;
		}
	}
}
