using System.IO;
using System.IO.Compression;

namespace Packager
{
	public class Compress
	{
		/**
		 * <summary>Compress un répertoire dans une archive</summary>
		 * <param name="source">Chemin du répertoire à compresser</param>
		 * <param name="destination">Chemin de l'archive à créer</param>
		 */
		public static void Zip(string source, string destination)
		{
			string path = Path.GetDirectoryName(source);

			if (!Directory.Exists(path)) // crée le dossier de destination si il n'existe pas
				Directory.CreateDirectory(path);

			if(File.Exists(destination)) // supprime l'ancienne archive
				File.Delete(destination);

			ZipFile.CreateFromDirectory(source, destination);
		}
	}
}
