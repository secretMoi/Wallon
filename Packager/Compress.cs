using System.IO;
using System.IO.Compression;

namespace Packager
{
	public class Compress
	{
		public static string Zip(string source, string destination)
		{
			string path = Path.GetDirectoryName(source);

			if (!Directory.Exists(path)) // crée le dossier de destination si il n'existe pas
				Directory.CreateDirectory(path);

			if(File.Exists(destination)) // supprime l'ancienne archive
				File.Delete(destination);

			ZipFile.CreateFromDirectory(source, destination);

			return destination;
		}
	}
}
