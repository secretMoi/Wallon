using System.IO;
using System.Threading.Tasks;
using Updater.Hash;

namespace Updater
{
	public class LocalVersion
	{
		public string TempDirectory { get; set; }

		public async Task<string> GetHash(string code, string localHash)
		{
			if(File.Exists($"{TempDirectory}/{localHash}")) // si le fichier de hash existe déjà
				return await File.ReadAllTextAsync($"{TempDirectory}/{localHash}"); // on le lit

			if (File.Exists($"{TempDirectory}/{localHash}")) // si le fichier de code existe déjà
				return Hash(code); // sinon on hash le zip

			return ""; // si rien n'existe
		}

		/**
		 * <summary>Retourne le hash en texte</summary>
		 * <param name="file">Fichier à hasher</param>
		 * <returns>Le hash sous forme de string</returns>
		 */
		private string Hash(string file)
		{
			// récupère hash le fichier téléchargé
			Hasher hasher = new Hasher
			{
				FileName = $"{TempDirectory}/{file}"
			};

			return hasher.HashFile();
		}

		/**
		 * <summary>Nettoie le dossier d'extraction pour éviter des conflits</summary>
		 */
		public void InitDirectory()
		{
			if (!Directory.Exists(TempDirectory))
				Directory.CreateDirectory(TempDirectory); // crée le répertoire pour extraire le nouveau code
		}
	}
}
