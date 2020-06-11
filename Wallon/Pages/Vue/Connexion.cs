using System.Linq;
using Controls;
using Wallon.Controllers;
using Wallon.Pages.Controlleur;

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
				_controllerConnection.Auth();
				LoadPage("Accueil");
			}

			SetTitre("Connexion");

			SetColors();
		}

		private void SetColors()
		{
			// change la couleur de tous les flatLabel
			foreach (FlatLabel label in Controls.OfType<FlatLabel>())
				label.ForeColor = Theme.BackDark;
		}

		private void flatButtonConnexion_Click(object sender, System.EventArgs e)
		{
			string nom = flatTextName.Text;
			string password = flatTextBoxPassword.Text;

			if (_controllerLocataires.Authentifie(nom, password))
			{
				_controllerConnection.Save(nom, password);
				_controllerConnection.Auth();

				LoadPage("Accueil");
			}
			else
				alerte.Show("Identifiants invalides");
		}
	}
}
