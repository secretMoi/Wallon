using System.IO;
using Packager.Hash;
using Packager.Transfers;

namespace Packager
{
	public class Run
	{
		private const string Server = "ftp://192.168.1.124/"; // serveur où stocker la release

		private const string ProjectPath = "../../../../Wallon/bin/Debug"; // chemin du fichier à packager
		private const string TempPath = "../../../../Wallon/bin/Temp/Source"; // chemin du dossier temporaire du code pour créer l'archive

		private const string ArchiveName = "test.zip"; // nom de l'archive
		private const string ArchivePath = "../../../../Wallon/bin/Temp/" + ArchiveName; // chemin de l'archive

		private const string HashName = "hash.txt"; // nom du fichier de hash
		private const string HashPath = "../../../../Wallon/bin/Temp/"; // chemin du fichier de hash

		public Run()
		{
			SelectFiles();

			Compresser();

			Hash(ArchivePath);

			Upload(
				ArchivePath,
				Path.Combine(Server, ArchiveName)
			); // upload l'archive de la release

			Upload(
				Path.Combine(HashPath, HashName),
				Path.Combine(Server, HashName)
			); // upload le fichier hash de la release

			//todo persist files (config.ini)
			//todo set config dans le programme principal
		}

		/**
		 * <summary>Sélectionne les fichiers à mettre dans l'archive</summary>
		 */
		private void SelectFiles()
		{
			Selecter selecter = new Selecter();
			selecter.RemoveExtensions("pdb", "zip"); // exclu les fichiers avec ces extensions
			selecter.CopyFiles(ProjectPath, TempPath); // copie le contenu de ProjectPath dans TempPath
		}

		/**
		 * <summary>Compresse les fichiers dans une nouvelle archive</summary>
		 */
		private void Compresser()
		{
			Compress.Zip(TempPath, ArchivePath); // compresse le contenu de TempPath dans l'archive ArchivePath
		}

		/**
		 * <summary>Upload un fichier</summary>
		 * <param name="sourcePath">Chemin du fichier à uploader</param>
		 * <param name="destinationPath">Chemin du fichier à créer sur le serveur distant</param>
		 */
		private void Upload(string sourcePath, string destinationPath)
		{
			// initialise le protocole
			IAuth upload = new Ftp()
			{
				User = "",
				Password = "",
				Source = sourcePath,
				Destination = destinationPath
			};

			upload.Upload(); // upload le fichier
		}

		/**
		 * <summary>Hash un fichier</summary>
		 * <param name="fileToHash">Fichier à hasher</param>
		 */
		private void Hash(string fileToHash)
		{
			// initialise le hasher
			Hasher hasher = new Hasher
			{
				FileName = fileToHash
			};

			hasher.HashFile(); // hash le fichier

			hasher.SaveHash(Path.Combine(HashPath, HashName)); // sauvegarde le hash dans un fichier
		}
	}
}
