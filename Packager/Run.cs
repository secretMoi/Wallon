using System.IO;
using Packager.Hash;
using Packager.Models;
using Packager.Transfers;

namespace Packager
{
	public class Run
	{
		//private const string Server = "ftp://192.168.1.124/"; // serveur où stocker la release

		private const string ProjectPath = "../../../../Wallon/bin/Debug"; // chemin du fichier à packager
		/*private const string TempPath = "../../../../Wallon/bin/Temp/Source"; // chemin du dossier temporaire du code pour créer l'archive

		private const string ArchiveName = "test.zip"; // nom de l'archive
		private const string ArchivePath = "../../../../Wallon/bin/Temp/" + ArchiveName; // chemin de l'archive

		private const string HashName = "hash.txt"; // nom du fichier de hash
		private const string HashPath = "../../../../Wallon/bin/Temp/"; // chemin du fichier de hash*/

		private readonly Config _config;

		public Run(string configPath)
		{
			_config = LoadConfig(configPath);

			SelectFiles(_config.ProjectPath, _config.TempPath);

			Compresser(_config.TempPath, _config.Archive.Path, _config.Archive.Name);

			Hash(_config.Archive.Path, _config.Archive.Name, _config.Hash.Path, _config.Hash.Name);

			// upload l'archive de la release
			Upload(
				Path.Combine(_config.Archive.Path, _config.Archive.Name),
				Path.Combine(_config.Server, _config.Archive.Name)
			);

			// upload le fichier hash de la release
			Upload(
				Path.Combine(_config.Hash.Path, _config.Hash.Name),
				Path.Combine(_config.Server, _config.Hash.Name)
			);

			//todo persist files (config.ini)
		}

		/**
		 * <summary>Charge le fichier de configuration du packager</summary>
		 * <param name="configPath">Chemin du fichier de config à charger</param>
		 * <returns>Le modèle de configuration hydraté</returns>
		 */
		private Config LoadConfig(string configPath)
		{
			return Configuration.LoadConfig<Config>(Path.Combine(ProjectPath, "packager.json"));
		}

		/**
		 * <summary>Sélectionne les fichiers à mettre dans l'archive</summary>
		 * <param name="projectPath">Répertoire du projet à packager</param>
		 * <param name="tempPath">Répertoire temporaire où travailler</param>
		 */
		private void SelectFiles(string projectPath, string tempPath)
		{
			Selecter selecter = new Selecter();
			selecter.RemoveExtensions("pdb", "zip"); // exclu les fichiers avec ces extensions
			selecter.CopyFiles(projectPath, tempPath); // copie le contenu de ProjectPath dans TempPath
		}

		/**
		 * <summary>Compresse les fichiers dans une nouvelle archive</summary>
		 * <param name="tempPath">Répertoire temporaire où travailler</param>
		 * <param name="archivePath">Répertoire de l'archive à générer</param>
		 * <param name="archiveName">Nom de l'archive à générer</param>
		 */
		private void Compresser(string tempPath, string archivePath, string archiveName)
		{
			Compress.Zip(tempPath, Path.Combine(archivePath, archiveName)); // compresse le contenu de TempPath dans l'archive ArchivePath
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
		 * <param name="archivePath">Répertoire de l'archive à hasher</param>
		 * <param name="archiveName">Nom de l'archive à hasher</param>
		 * <param name="hashPath">Répertoire du hash à générer</param>
		 * <param name="hashName">Nom du hash à générer</param>
		 */
		private void Hash(string archivePath, string archiveName, string hashPath, string hashName)
		{
			// initialise le hasher
			Hasher hasher = new Hasher
			{
				FileName = Path.Combine(archivePath, archiveName)
			};

			hasher.HashFile(); // hash le fichier

			hasher.SaveHash(Path.Combine(hashPath, hashName)); // sauvegarde le hash dans un fichier
		}
	}
}
