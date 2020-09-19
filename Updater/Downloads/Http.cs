using System;
using System.Net;
using System.Threading.Tasks;

namespace Updater.Downloads
{
	public class Http : IDownload
	{
		public string Source { get; set; }
		public string Destination { get; set; }

		/**
		 * <summary>Télécharge un fichier</summary>
		 */
		public async Task Download()
		{
			using (WebClient client = new WebClient())
			{
				await client.DownloadFileTaskAsync(new Uri(Source), Destination);
			}
		}

		/**
		 * <summary>Retourne le hash en texte</summary>
		 * <returns>true si le fichier existe, false sinon</returns>
		 */
		public async Task<bool> Exists()
		{
			try
			{
				HttpWebRequest request = WebRequest.CreateHttp(Source);
				request.Method = "HEAD"; // comme un GET mais sans le contenu, juste les headers

				using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse) // attends la réponse du serveur
				{
					if (response == null)
						return false;

					return response.StatusCode == HttpStatusCode.OK; // si le header est OK(200)
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
