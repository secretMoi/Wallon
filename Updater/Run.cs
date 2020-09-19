using System;
using System.IO;
using System.Threading.Tasks;
using Updater.Compression;
using Updater.Downloads;
using Updater.Hash;

namespace Updater
{
	public class Run
	{
		private string _directory = "Deploy";
		private string _file = "test.zip";
		private string _hashFile = "hash.txt";
		private string _urlSource = "http://192.168.1.124";

		public async Task<string> Execute()
		{
			string result = null;
			InitDirectory();

			result = await Download(_file); // télécharge l'archive du nouveau prog sur le serveur
			if (result != null)
				return result;

			result = await Download(_hashFile); // récupère la code hash sur le 
			if (result != null)
				return result;

			string serverHash = Hash(_file);
			string localHash = await File.ReadAllTextAsync($"{_directory}/{_hashFile}");

			if (serverHash != localHash)
				return $"Hashes differents. Server : {serverHash} Local : {localHash}";

			Decompress();

			return "Update success";
		}

		private void InitDirectory()
		{
			// supprime les fichiers existants déjà
			if (Directory.Exists(_directory))
				Directory.Delete(_directory, true);

			Directory.CreateDirectory(_directory); // crée le répertoire pour extraire le nouveau code
		}

		private async Task<string> Download(string file)
		{
			// initialise ce qu'on télécharge et où on le met
			Transferer transferer = new Transferer(new Http())
			{
				Source = $"{_urlSource}/{file}",
				Destination = $"{_directory}/{file}"
			};

			bool result = await transferer.Exists();
			if (result == false)
				return $"File {file} not found on server"; 

			transferer.Download(); // télécharge le nouveau code
			transferer.WaitTasksForEnding(); // on attend que le téléchargement soit terminé

			return null;
		}

		private string Hash(string file)
		{
			// récupère hash le fichier téléchargé
			Hasher hasher = new Hasher()
			{
				FileName = $"{_directory}/{file}"
			};

			Console.WriteLine(hasher.HashFile());

			return hasher.HashFile();
		}

		private void Decompress()
		{
			// décompresse le zip
			Decompress decompress = new Decompress()
			{
				Source = $"{_directory}/{_file}",
				Destination = _directory
			};
			decompress.Extract();
		}
	}
}
