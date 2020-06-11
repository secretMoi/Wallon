using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Controls;

namespace Wallon.Controls
{
	public partial class Alerte : UserControl
	{
		private bool _enabled;
		private int _heightMax = 45;

		public Alerte()
		{
			InitializeComponent();

			Display(false);

			ThemeError();
		}

		private void ThemeError()
		{
			flatLabelText.ForeColor = Theme.Texte;
			BackColor = Theme.Error;
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

		public int HeightMax
		{
			get => _heightMax;
			set => _heightMax = value;
		}
	}
}
