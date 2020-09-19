using System.IO;
using System.Security.Cryptography;

namespace Updater.Hash
{
	public class Hasher
	{
		private readonly MD5 _hasher = MD5.Create();
		public string FileName { get; set; }

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
