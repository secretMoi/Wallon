using System.IO;
using System.Threading.Tasks;
using Updater.Compression;

namespace Updater
{
	public class Run
	{
		private const string TempDirectory = "Temp"; // dossier temporaire pour décompresser l'archive
		private const string File = "test.zip"; // fichier release à télécharger
		private const string HashFile = "hash.txt"; // fichier de hash à télécharger
		private const string UrlSource = "http://aorus.aorus.ovh/wallon"; // serveur pour récupérer les releases
		private const string InstallPath = @"C:\Users\Quentin\source\repos\secretMoi\Wallon\Wallon\bin\Debug\"; // chemin où lancer le programme intallé
		private const string InstallExe = "Wallon.exe"; // nom du programme à lancer

		public async Task<string> Execute()
		{
			string result;

			// lance le programme
			if (System.IO.File.Exists(Path.Combine(InstallPath, InstallExe)))
				new Starter().Run(InstallPath, InstallExe);

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
