using System.Collections.Generic;
using Couche_Classe;
using Wallon.Core;
using Wallon.Repository;

namespace Wallon.Controllers
{
	public class ControllerLocataires
	{
		private int _idValid;

		public ControllerLocataires()
		{ 
			/*Ajouter(
				new Locataire("q", "s")
			);*/
		}

		public int Ajouter(Locataire locataire)
		{
			locataire.Password = Cryptage.Crypt(locataire.Password);

			return new RepositoryLocataires().Ajouter(locataire);
		}

		/// <summary>
		/// Vérifie que le nom du locataire passé en paramètres existe dans la bdd
		/// </summary>
		/// <param name="nom">Le nom du locataire</param>
		/// <returns>true si le locataire se trouve dans la bdd, false sinon</returns>
		public Locataire Existe(string nom)
		{
			List<Locataire> locataires = new RepositoryLocataires().Lire("id");

			foreach (Locataire locataire in locataires)
				if (locataire.Nom == nom)
					return locataire;

			return null;
		}

		/// <summary>
		/// Permet de savoir si les logs correspondent à ceux dans la base de données
		/// </summary>
		/// <param name="nom">Le nom du locataire</param>
		/// <param name="password">Le mot de passe du locataire</param>
		/// <returns>true si le nom et le mot de passe correspondent, false sinon</returns>
		public bool Authentifie(string nom, string password)
		{
			Locataire locataire = Existe(nom);
			if (locataire == null) return false;

			_idValid = locataire.Id;

			return Cryptage.Uncrypt(locataire.Password) == password;
		}

		public Locataire GetById(int id)
		{
			return new RepositoryLocataires().LireId(id);
		}

		public int IdValid => _idValid;

		/*public static string CryptPassword(string password)
		{
			string hash = null;

			using (SHA256 sha256Hash = SHA256.Create())
			{
				byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
				byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
				//hash = Encoding.UTF8.GetString(hashBytes);
				hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
			}

			return hash;
		}

		/*public static byte[] Hash(string inputString)
		{
			using (HashAlgorithm algorithm = SHA256.Create())
				return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
		}

		public static string HashString(string inputString)
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in Hash(inputString))
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}*/
	}
}
