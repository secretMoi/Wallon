using System.Threading.Tasks;
using Updater.Compression;

namespace Updater
{
	public class Run
	{
		private const string TempDirectory = "Temp";
		private const string File = "test.zip";
		private const string HashFile = "hash.txt";
		private const string UrlSource = "http://aorus.aorus.ovh/wallon";

		public async Task<string> Execute()
		{
			LocalVersion localVersion = new LocalVersion
			{
				TempDirectory = TempDirectory
			};
			ServerVersion serverVersion = new ServerVersion
			{
				UrlSource = UrlSource,
				TempDirectory = TempDirectory
			};

			string result;
			localVersion.InitDirectory();

			string localHash = await localVersion.GetHash(File, HashFile); // récupère l'ancien hash
			string serverHash = await serverVersion.GetHash(HashFile); // récupère le hash sur le serveur

			if (serverHash == localHash) // si les hash correspondent
				return "Already updated"; // l'app locale correspond au serveur

			result = await serverVersion.Download(File); // télécharge l'archive du nouveau prog sur le serveur
			if (result != null)
				return result;

			Decompress();

			return "Update success";
		}

		/**
		 * <summary>Décompresse un fichier</summary>
		 */
		private void Decompress()
		{
			// décompresse le zip
			Decompress decompress = new Decompress()
			{
				Source = $"{TempDirectory}/{File}",
				Destination = TempDirectory
			};

			decompress.Extract();
		}
	}
}
