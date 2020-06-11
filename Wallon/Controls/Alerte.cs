using System;
using System.Drawing;
using System.Windows.Forms;
using Controls;

namespace Wallon.Controls
{
	public partial class Alerte : UserControl
	{
		private bool _enabled;

		public Alerte()
		{
			InitializeComponent();

			Size = new Size(Width, 0);

			ThemeError();
		}

		private void ThemeError()
		{
			flatLabelText.ForeColor = Theme.Texte;
			BackColor = Theme.Error;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (Size.Height <= MaximumSize.Height)
				Size = new Size(Size.Width, Size.Height + 1);

			else
				timer.Stop();
		}

		public void AddClick(EventHandler callBack)
		{
			Click += callBack;
			flatLabelText.Click += callBack;
		}

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

				if(_enabled)
					timer.Start();
			}
		}

		public int HeightMax
		{
			get => MaximumSize.Height;
			set => MaximumSize = new Size(Width, value);
		}
	}
}
