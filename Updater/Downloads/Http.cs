using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Updater.Downloads
{
	public class Http : IDownload
	{
		public string Source { get; set; }
		public string Destination { get; set; }

		public async Task Download()
		{
			using (WebClient client = new WebClient())
			{
				await client.DownloadFileTaskAsync(new Uri(Source), Destination);
			}
		}
	}
}
