using System.IO;
using System.Security.Cryptography;

namespace Packager.Hash
{
	public class Hasher : IHash
	{
		private readonly MD5 _hasher = MD5.Create();
		public string FileName { get; set; }
		public string Hashed { get; private set; }

		/**
		 * <summary>Hash un fichier</summary>
		 * <returns>Le hash du fichier</returns>
		 */
		public string HashFile()
		{
			using (FileStream stream = File.OpenRead(FileName))
			{
				Hashed = BytesToString(_hasher.ComputeHash(stream));
				return Hashed;
			}
		}

		/**
		 * <summary>Enregistre le hash d'un fichier pré calculé dans un fichier</summary>
		 * <param name="pathToSave">Fichier de destination dans lequel sauvegarder le hash</param>
		 */
		public void SaveHash(string pathToSave)
		{
			if(Hashed == null)
				return;

			if(File.Exists(pathToSave))
				File.Delete(pathToSave);

			using (StreamWriter sw = File.CreateText(pathToSave))
			{
				sw.WriteLine(Hashed);
			}
		}

		/**
		 * <summary>Retourne le hash en texte</summary>
		 * <param name="bytes">Octets du hash</param>
		 * <returns>Le hash sous forme de string</returns>
		 */
		public static string BytesToString(byte[] bytes)
		{
			string result = "";
			foreach (byte b in bytes) result += b.ToString("x2");
			return result;
		}
	}
}
