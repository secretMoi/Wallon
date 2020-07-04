using System;
using System.IO;
using System.Security.Cryptography;
using Couche_Classe;
using Wallon.Controllers;
using Wallon.Pages.Controllers;

namespace Wallon.Pages.Vue
{
	public partial class Connexion : ThemePanel
	{
		private readonly ControllerLocataires _controllerLocataires;
		private readonly ControllerConnection _controllerConnection;

		public Connexion()
		{
			InitializeComponent();

			_controllerLocataires = new ControllerLocataires();
			_controllerConnection = new ControllerConnection();

			if (_controllerConnection.AuthInCacheValid(_controllerLocataires))
			{
				_controllerConnection.Auth(_controllerLocataires);
				LoadPage("Accueil");
			}

			SetTitre("Connexion");

			SetColors();

			flatTextBoxPassword.IsPassword = true;

			/*using (Aes myAes = Aes.Create())
			{

				// Encrypt the string to an array of bytes.
				byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

				using (StreamWriter file = new StreamWriter(@"debug.txt", true))
				{
					file.WriteLine(myAes.Key);
					file.WriteLine(myAes.IV);
					myAes.
				}

				// Decrypt the bytes to a string.
				string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

				//Display the original data and the decrypted data.
				Console.WriteLine("Original:   {0}", original);
				Console.WriteLine("Round Trip: {0}", roundtrip);
			}*/

			//Dialog.Show(new RepositoryLocataires().);

			/*_controllerLocataires.Ajouter(new Locataire("Quentin", "test"));
			_controllerLocataires.Ajouter(new Locataire("Laura", "mdp"));
			_controllerLocataires.Ajouter(new Locataire("Andy", "mdp"));*/
		}

		private void flatButtonConnexion_Click(object sender, EventArgs e)
		{
			// récupère les text des champs
			string nom = flatTextName.Text;
			string password = flatTextBoxPassword.Text;

			if (_controllerLocataires.Authentifie(nom, password)) // si les identifiants entrés sont bons
			{
				_controllerConnection.Save(nom, password); // enregistre la session dans le fichier local
				_controllerConnection.Auth(_controllerLocataires); // authentifie dans le programme

				LoadPage("Accueil"); // redirige vers la page d'accueil
			}
			else
				alerte.Show("Identifiants invalides");
		}
	}
}
