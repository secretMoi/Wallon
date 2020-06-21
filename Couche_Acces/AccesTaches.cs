using System.Collections.Generic;
using System.Data.SqlClient;
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

		public List<Couche_Classe.Base> TachesCourantesDuLocataire(int idLocataire)
		{
			CreerCommande("TachesCourantesDuLocataire");

			Commande.Parameters.AddWithValue("@idLocataire", idLocataire);
			Commande.Connection.Open();

			SqlDataReader sqlDataReader = Commande.ExecuteReader();

			List<Couche_Classe.Base> liste = AssigneChamp(sqlDataReader);

			sqlDataReader.Close();
			Commande.Connection.Close();

			return liste;
		}
	}
}
