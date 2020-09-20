using System.Collections.Generic;
using System.IO;

namespace Packager
{
	public class Selecter
	{
		private readonly List<string> _extensionsExcludedExtensionsExcluded = new List<string>();

		public List<string> ExtensionsExcluded => _extensionsExcludedExtensionsExcluded;

		public void RemoveExtensions(params string[] extensions)
		{
			foreach (string extension in extensions)
				_extensionsExcludedExtensionsExcluded.Add("." + extension);
		}

		public void CopyFiles(string source, string destination)
		{
			foreach (var sourceFilePath in Directory.GetFiles(source)) // parcourt le répertoire
			{
				string fileName = Path.GetFileName(sourceFilePath); // récupère le nom du fichier
				string destinationFilePath = Path.Combine(destination, fileName); // prépare le chemin de destination
				string extension = Path.GetExtension(fileName); // récupère l'extension
				
				if (!Directory.Exists(destinationFilePath))
					Directory.CreateDirectory(destination);

				if(!ExtensionsExcluded.Contains(extension)) // si l'extension est autorisée
					File.Copy(sourceFilePath, destinationFilePath, true); // copie le fichier
			}

			string[] folders = Directory.GetDirectories(source);
			foreach (string folder in folders)
			{
				string name = Path.GetFileName(folder);
				string dest = Path.Combine(destination, name);
				CopyFiles(folder, dest);
			}
		}

		public static void CopyFolder(string sourceFolder, string destFolder)
		{
			if (!Directory.Exists(destFolder))
				Directory.CreateDirectory(destFolder);

			string[] files = Directory.GetFiles(sourceFolder);

			foreach (string file in files)
			{
				string name = Path.GetFileName(file);
				string dest = Path.Combine(destFolder, name);
				File.Copy(file, dest);
			}

			string[] folders = Directory.GetDirectories(sourceFolder);
			foreach (string folder in folders)
			{
				string name = Path.GetFileName(folder);
				string dest = Path.Combine(destFolder, name);
				CopyFolder(folder, dest);
			}
		}
	}
}
