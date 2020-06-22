using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FlatControls.Controls
{
	public partial class Alerte : UserControl
	{
		private bool _enabled;
		private int _heightMax = 40;

		public Alerte()
		{
			InitializeComponent();

			Display(false);

			ThemeError();
		}

		/// <summary>
		/// Applique un thème d'erreur à l'alerte
		/// </summary>
		public void ThemeError()
		{
			flatLabelText.ForeColor = Theme.Texte;
			BackColor = Theme.Error;
		}

		/// <summary>
		/// Applique de un thème de validation à l'alerte
		/// </summary>
		public void ThemeValid()
		{
			flatLabelText.ForeColor = Theme.Texte;
			BackColor = Theme.Valid;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (Size.Height <= _heightMax)
				Size = new Size(Size.Width, Size.Height + 1);

			else
				timer.Stop();
		}

		private void Display(bool state)
		{
			Visible = state;
			Size = new Size(Width, 0);
		}

		/// <summary>
		/// Active et affiche l'alerte
		/// </summary>
		/// <param name="text">Texte à afficher</param>
		public void Show(string text)
		{
			Enable = true;
			Text = text;
		}

		/// <summary>
		/// Ajoute une fonction de callback lors du click sur l'alerte
		/// </summary>
		/// <param name="callBack">Fonction de callback</param>
		public void AddClick(EventHandler callBack)
		{
			Click += callBack;
			flatLabelText.Click += callBack;
		}

		[Description("Texte"), Category("Data")]
		public override string Text
		{
			get => flatLabelText.Text;
			set => flatLabelText.Text = value;
		}

		/// <summary>
		/// Définit ou récupère l'état d'activation de l'alerte
		/// </summary>
		/// <param name="value">Etat d'activation</param>
		public bool Enable
		{
			get => _enabled;
			set
			{
				_enabled = value;

				Display(_enabled);

				if (_enabled)
					timer.Start();
			}
		}

		/// <summary>
		/// Change la taille que peut prendre l'alerte en s'étendant
		/// </summary>
		/// <param name="value">Taille maximum de l'alerte</param>
		public int HeightMax
		{
			get => _heightMax;
			set => _heightMax = value;
		}
	}
}
