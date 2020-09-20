using System.IO;
using System.Threading.Tasks;
using Updater.Downloads;

namespace Updater
{
	public class ServerVersion
	{
		public string UrlSource { get; set; }
		public string TempDirectory { get; set; }

		public async Task<string> GetHash(string filename)
		{
			string result = await Download(filename); // récupère la code hash sur le 
			if (result != null)
				return result;

			return await File.ReadAllTextAsync($"{TempDirectory}/{filename}");
		}

		/**
		 * <summary>télécharge un fichier</summary>
		 * <param name="file">Url du fichier à télécharger</param>
		 * <returns>Null si tout s'est bien passé, le message de l'erreur sinon</returns>
		 */
		public async Task<string> Download(string file)
		{
			// initialise ce qu'on télécharge et où on le met
			Transferer transferer = new Transferer(new Http())
			{
				Source = $"{UrlSource}/{file}",
				Destination = $"{TempDirectory}/{file}"
			};

			// vérifie que le fichier existe sur le serveur
			bool result = await transferer.Exists();
			if (result == false)
				return $"File {file} not found on server";

			if(File.Exists(transferer.Destination))
				File.Delete(transferer.Destination);

			transferer.Download(); // télécharge le fichier
			transferer.WaitTasksForEnding(); // on attend que le téléchargement soit terminé

			return null;
		}
	}
}
