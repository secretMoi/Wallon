using System;
using Controls;

namespace Wallon.Pages.Vue
{
	public partial class Accueil : ThemePanel
	{
		public Accueil()
		{
			InitializeComponent();

			SetTitre("Accueil");

			if(!Settings.Auth)
				LoadPage("Connexion");
		}

		private void buttonVendre_Click(object sender, EventArgs e)
		{
			LoadPage("Clients.Commander");
		}

		private void buttonAcheter_Click(object sender, EventArgs e)
		{
			LoadPage("Fournisseurs.Reapprovisionner");
		}

		private void buttonStock_Click(object sender, EventArgs e)
		{
			LoadPage("Stock.Consulter");
		}
	}
}
