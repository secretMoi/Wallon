using System.Threading.Tasks;

namespace Updater.Downloads
{
	public interface IDownload
	{
		public string Source { get; set; }
		public string Destination { get; set; }

		public Task Download();
	}
}
