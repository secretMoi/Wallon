using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
			foreach (FlatLabel label in this.Controls.OfType<FlatLabel>())
				label.ForeColor = Theme.BackDark;
		}
	}
}
