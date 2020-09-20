using System.Net;

namespace Packager.Transfers
{
	public class Ftp : IUpload, IAuth
	{
		public string Source { get; set; }
		public string Destination { get; set; }

		public string User { get; set; }
		public string Password { get; set; }

		public string Upload()
		{
			WebClient client = new WebClient
			{
				Credentials = new NetworkCredential(User, Password)
			};

			return client.UploadFile(Destination, Source).ToString();
		}
	}
}
