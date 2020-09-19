using System;
using System.IO;
using System.Net;

namespace Updater.Downloads
{
	public class Ftp
	{
		public string Host { get; set; }
		public string Path { get; set; }
		public string Destination { get; set; }

		private WebClient _client;

		public string Username { get; set; }
		public string Password { get; set; }
		public Mode ConnectionMode { get; set; }
		
		public enum Mode
		{
			Active, Passive
		}

		public void Download()
		{
			using (WebClient request = new WebClient())
			{
				request.Credentials = new NetworkCredential("IUSR", "root");
				byte[] fileData = request.DownloadData(Host + "/" + Path);

				using (FileStream file = File.Create(Host + "/" + Path))
				{
					file.Write(fileData, 0, fileData.Length);
					file.Close();
				}

				Console.WriteLine("Download Complete");
			}

			/*_client = new WebClient
			{
				
				//Credentials = new NetworkCredential(Username, Password)
			};
			_client.DownloadFileAsync(new Uri(Host + Path), Destination);*/
		}
	}
}
