using System;
using System.Linq;
using Controls;
using Wallon.Fenetres;
using Wallon.Pages.Controlleur;

namespace Wallon.Pages.Vue
{
	public partial class Connexion : ThemePanel
	{
		private readonly ControllerLocataires _controllerLocataires;

		public Connexion()
		{
			InitializeComponent();

			_controllerLocataires = new ControllerLocataires();

			SetTitre("Connexion");

			SetColors();

			alerte.Text = "coucou";

			alerte.HeightMax = 45;
				
			alerte.Enable = true;

			alerte.AddClick(test);
		}

		private void test(object sender, EventArgs e)
		{
			Dialog.Show("coucou");
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

			if(_controllerLocataires.Authentifie(nom, password))
				LoadPage("Accueil");
			else
			{
				Dialog.Show("Identifiants invalides");
			}
		}
	}
}
