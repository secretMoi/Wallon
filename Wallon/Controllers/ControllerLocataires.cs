using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Couche_Classe;
using Wallon.Core;
using Wallon.Repository;

namespace Wallon.Controllers
{
	public class ControllerLocataires
	{
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

		public Locataire Existe(string nom)
		{
			List<Locataire> locataires = new RepositoryLocataires().Lire("id");

			foreach (Locataire locataire in locataires)
				if (locataire.Nom == nom)
					return locataire;

			return null;
		}

		public bool Authentifie(string nom, string password)
		{
			Locataire locataire = Existe(nom);
			if (locataire == null) return false;

			return Cryptage.Uncrypt(locataire.Password) == password;
		}

		public Locataire GetById(int id)
		{
			return new RepositoryLocataires().LireId(id);
		}

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
