using System;
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

			SetTitre("Connexion");

			SetColors();

			flatTextBoxPassword.IsPassword = true;

			if (ControllerConnection.Disconnected)
			{
				alerte.ThemeValid();
				alerte.Show("Vous avez bien été déconnecté");
				ControllerConnection.Disconnected = false;
			}
		}

		private async void Connexion_Load(object sender, EventArgs e)
		{
			if (await _controllerConnection.AuthInCacheValid(_controllerLocataires))
			{
				_controllerConnection.Auth(_controllerLocataires);
				LoadPage("Accueil");
			}
		}

		private async void flatButtonConnexion_Click(object sender, EventArgs e)
		{
			// récupère les text des champs
			string nom = flatTextName.Text;
			string password = flatTextBoxPassword.Text;

			if (await _controllerLocataires.Authentifie(nom, password)) // si les identifiants entrés sont bons
			{
				_controllerConnection.Save(nom, password); // enregistre la session dans le fichier local
				_controllerConnection.Auth(_controllerLocataires); // authentifie dans le programme

				LoadPage("Accueil"); // redirige vers la page d'accueil
			}
			else
			{
				alerte.ThemeError();
				alerte.Show("Identifiants invalides");
			}
		}
	}
}
