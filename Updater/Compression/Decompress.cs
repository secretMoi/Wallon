using System.IO.Compression;

namespace Updater.Compression
{
	public class Decompress
	{
		public string Source { get; set; }
		public string Destination { get; set; }

		public void Extract()
		{
			ZipFile.ExtractToDirectory(Source, Destination);
		}
	}
}
