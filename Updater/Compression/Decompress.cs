using System.IO.Compression;

namespace Updater.Compression
{
	public class Decompress
	{
		public string Source { get; set; }
		public string Destination { get; set; }

		/**
		 * <summary>Décompresse un fichier</summary>
		 */
		public void Extract()
		{
			ZipFile.ExtractToDirectory(Source, Destination, true);
		}
	}
}
