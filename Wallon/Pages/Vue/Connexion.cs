using Wallon.Controllers;
using Wallon.Fenetres;
using Wallon.Pages.Controllers;
using Wallon.Repository;

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

			//Dialog.Show(new RepositoryLocataires().);

			//_controllerLocataires.Ajouter(new Locataire("Quentin", "test"));
		}

		private void flatButtonConnexion_Click(object sender, System.EventArgs e)
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
