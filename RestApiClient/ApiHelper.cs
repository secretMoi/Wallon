using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RestApiClient
{
	public class ApiHelper
	{
		public static HttpClient ApiClient { get; set; } // static => ouvre 1x pour toute l'application (optimisation tcp)

		public static void InitializeClient()
		{
			// trust any certificate
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.ServerCertificateValidationCallback +=
				(sender, cert, chain, sslPolicyErrors) => { return true; };

			ApiClient = new HttpClient();

			// set une addresse de base (ex : http://xkcd.com/ , qui permet de manipuler plusieurs liens api de ce site)
			ApiClient.BaseAddress = new Uri("http://localhost:5000/api/");

			ApiClient.DefaultRequestHeaders.Accept.Clear(); // nettoie les headers

			// crée un header qui demande du json
			ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}
