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
		}
	}
}
