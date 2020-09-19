using System.IO;
using System.Security.Cryptography;

namespace Updater.Hash
{
	public class Hasher : IHash
	{
		private readonly MD5 _hasher = MD5.Create();
		public string FileName { get; set; }

		/**
		 * <summary>Hash un fichier</summary>
		 * <returns>Le hash du fichier</returns>
		 */
		public string HashFile()
		{
			using (FileStream stream = File.OpenRead(FileName))
			{
				return BytesToString(_hasher.ComputeHash(stream));
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
