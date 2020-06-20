using Controls;
using Wallon.Pages.Controllers.Utilisateurs;

namespace Wallon.Pages.Vue.Utilisateurs
{
	public partial class Profil : ThemePanel
	{
		private readonly ControllerProfil _controllerProfil;

		public Profil()
		{
			InitializeComponent();

			_controllerProfil = new ControllerProfil();

			SetTitre(_controllerProfil.TitrePage());

			SetColors();

			flatTextBoxPassword.IsPassword = true;

			_controllerProfil.RempliChamps(flatTextBoxNom, flatTextBoxPassword);
		}

		private void flatButtonUpdate_Click(object sender, System.EventArgs e)
		{
			_controllerProfil.Update(flatTextBoxNom.Text, flatTextBoxPassword.Text); // modifie les informations de l'utilisateur
			SetTitre(_controllerProfil.TitrePage()); // remet à jour le titre de la page si le nom a changé

			// informe l'utilisateur que la modification s'est bien passée
			alerte.ThemeValid();
			alerte.Show("Votre profil a bien été mis à jour");
		}
	}
}
