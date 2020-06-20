using System;
using System.Windows.Forms;
using FlatControls.Controls.Buttons;
using FlatControls.Core;

namespace Wallon.Fenetres
{
	public partial class Dialog : Form
	{
		private readonly Couple _tailleBouton = new Couple(150, 50);
		private static DialogResult resultat;
		private static TypeFenetre type;

		private enum TypeFenetre
		{
			Ok, YesNo
		}

		private Dialog(string texte, string titre = null)
		{
			InitializeComponent();

			if (titre != null)
				Text = titre;
			flatLabel1.Text = texte;

			switch (type)
			{
				case TypeFenetre.Ok:
					CreerOkButton();
					break;
				case TypeFenetre.YesNo:
					CreerOuiNonBoutons();
					break;
				default:
					Close();
					break;
			}
		}

		public static void Show(string texte, string titre = null)
		{
			type = TypeFenetre.Ok;

			// using assure que les ressources seront libérées à la fermeture de la fenêtre
			using (Dialog form = new Dialog(texte, titre))
			{
				form.ShowDialog();
			}
		}

		public static DialogResult ShowYesNo(string texte, string titre = null)
		{
			type = TypeFenetre.YesNo;

			// using assure que les ressources seront libérées à la fermeture de la fenêtre
			using (Dialog form = new Dialog(texte, titre))
			{
				form.ShowDialog();
			}

			return resultat;
		}

		private void CreerOuiNonBoutons()
		{
			Couple position = new Couple(
				ClientSize.Width / 4 - _tailleBouton.Xi / 2,
				ClientSize.Height - _tailleBouton.Yi - 15
			);

			FlatButton bouton = CreerBouton(position, @"Oui");

			bouton.Click += (sender, args) =>
			{
				resultat = DialogResult.Yes;
				Action_Fermeture(sender, args);
			};

			position = new Couple(
				ClientSize.Width * 3 / 4 - _tailleBouton.Xi / 2,
				ClientSize.Height - _tailleBouton.Yi - 15
			);
			bouton = CreerBouton(position, @"Non");

			bouton.Click += (sender, args) =>
			{
				resultat = DialogResult.No;
				Action_Fermeture(sender, args);
			};
		}

		private void CreerOkButton()
		{
			Couple position = new Couple(
				(ClientSize.Width - _tailleBouton.Xi) / 2,
				ClientSize.Height - _tailleBouton.Yi - 15
			);

			FlatButton boutonOk = CreerBouton(position, @"OK");

			boutonOk.Click += Action_Fermeture;
		}

		private FlatButton CreerBouton(Couple position, string texte)
		{
			FlatButton bouton = new FlatButton
			{
				Location = position.ToPoint(),
				Size = _tailleBouton.ToSize(),
				Text = texte
			};

			Controls.Add(bouton);

			return bouton;
		}

		public sealed override string Text
		{
			get { return base.Text; }
			set { base.Text = value; }
		}

		private void Action_Fermeture(object sender, EventArgs eventArgs)
		{
			Close();
		}

		// permet de déplacer la fenêtre
		private void panelHeader_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				// Release the mouse capture started by the mouse down.
				panelHeader.Capture = false;
				flatLabel1.Capture = false;

				// Create and send a WM_NCLBUTTONDOWN message.
				const int wmNclbuttondown = 0x00A1;
				const int htcaption = 2;
				Message msg =
					Message.Create(Handle, wmNclbuttondown,
						new IntPtr(htcaption), IntPtr.Zero);
				DefWndProc(ref msg);
			}
		}

		// dessine une bordure pour la distinguer du fond
		private void Dialog_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, FlatControls.Controls.Theme.BackDark, ButtonBorderStyle.Solid);
		}
	}
}
