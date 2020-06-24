using System;
using Wallon.Pages.Controllers.Utilisateurs;

namespace Wallon.Pages.Vue.Utilisateurs
{
	public partial class Ajouter : ThemePanel
	{
		private readonly ControllerAjouter _controllerAjouter;

		public Ajouter()
		{
			InitializeComponent();

			_controllerAjouter = new ControllerAjouter();

			SetTitre("Ajouter un nouveau locataire");

			SetColors();

			flatTextBoxPassword.IsPassword = true;
		}

		private void flatButtonAjouter_Click(object sender, EventArgs e)
		{
			_controllerAjouter.Add(flatTextName.Text, flatTextBoxPassword.Text);

			alerte.ThemeValid();
			alerte.Show($"Locataire {flatTextName.Text} ajouté.");
		}
	}
}
