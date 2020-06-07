using System.Drawing;
using System.Windows.Forms;
using Controls;
using QMag.Controls;
using Wallon.Fenetres;

namespace QMag.Core.Pages
{
	public partial class BaseAjouter : ThemePanel
	{
		protected Formulaire _ajout;
		protected int _idModification;

		public BaseAjouter()
		{
			InitializeComponent();
		}

		protected bool ChampsRemplis()
		{
			bool result = true;

			foreach (Control flatTextBox in _ajout.Being(typeof(FlatTextBox)))
				if (flatTextBox.Text == "") // si un des champs est vide
					result = false;

			if (!result)
				Dialog.Show(@"Veuillez remplir tous les champs !");

			return result;
		}
	}
}
