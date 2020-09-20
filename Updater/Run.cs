using System.Threading.Tasks;
using Updater.Compression;
using Updater.Folders;

namespace Updater
{
	public class Run
	{
		private const string TempDirectory = "Temp";
		private const string File = "test.zip";
		private const string HashFile = "hash.txt";
		private const string UrlSource = "http://aorus.aorus.ovh/wallon";
		private const string InstallPath = @"C:\Users\Quentin\source\repos\secretMoi\Wallon\Wallon\bin\Debug\";
		private const string InstallExe = "Wallon.exe";

		public async Task<string> Execute()
		{
			// lance le programme
			string result = new Starter().Run(InstallPath, InstallExe);
			if (result != "0")
				return result;

			LocalVersion localVersion = new LocalVersion
			{
				TempDirectory = TempDirectory
			};
			ServerVersion serverVersion = new ServerVersion
			{
				UrlSource = UrlSource,
				TempDirectory = TempDirectory
			};

			// initialise les dossiers locaux
			localVersion.InitDirectory();

			string localHash = await localVersion.GetHash(File, HashFile); // récupère l'ancien hash
			string serverHash = await serverVersion.GetHash(HashFile); // récupère le hash sur le serveur

			if (serverHash == localHash) // si les hash correspondent
				return "Already updated"; // l'app locale correspond au serveur

			result = await serverVersion.Download(File); // télécharge l'archive du nouveau prog sur le serveur
			if (result != null)
				return result;

			Decompress(); // décompresse le zip

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
