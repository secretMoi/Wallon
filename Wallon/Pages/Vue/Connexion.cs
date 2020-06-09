using System.Linq;
using Controls;

namespace Wallon.Pages.Vue
{
	public partial class Connexion : ThemePanel
	{
		public Connexion()
		{
			InitializeComponent();

			SetTitre("Connexion");

			SetColors();
		}

		private void SetColors()
		{
			// change la couleur de tous les flatLabel
			foreach (FlatLabel label in Controls.OfType<FlatLabel>())
				label.ForeColor = Theme.BackDark;
		}
	}
}
