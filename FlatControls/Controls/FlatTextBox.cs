using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FlatControls.Core;

namespace FlatControls.Controls
{
	public partial class FlatTextBox : UserControl
	{
		private bool _isPassword;
		private readonly string _clearPassword;

		public FlatTextBox()
		{
			_clearPassword = null;
			InitializeComponent();

			BackColor = Theme.Back;

			InitTextBox();

			ResizeControl(null, null);
		}

		private void InitTextBox()
		{
			textBox.BorderStyle = BorderStyle.None;
			textBox.BackColor = Theme.Back;
			textBox.ForeColor = Theme.Texte;
			textBox.TextAlign = HorizontalAlignment.Right;
			textBox.Font = new Font(Theme.TypeFace, 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
		}

		[Description("TextAlign"), Category("Data"), Browsable(true)]
		public HorizontalAlignment TextHorizontalAlign { get => textBox.TextAlign; set => textBox.TextAlign = value; }

		[Description("Multiline"), Category("Data"), Browsable(true)]
		public bool Multiline { get => textBox.Multiline; set => textBox.Multiline = value; }

		[Description("SizeTextField"), Category("Data"), Browsable(true)]
		public Size SizeTextField
		{
			get => textBox.Size;
			set => textBox.Size = value;
		}

		//public VerticalAlignment TextVerticalAlignment { get => textBox; set => textBox.TextAlign = value; }

		[Description("Text"), Category("Data"), Browsable(true)]
		public override string Text
		{
			get => textBox.Text;
			set => textBox.Text = value;
		}

		public bool IsPassword { 
			get => _isPassword;
			set
			{
				_isPassword = value;
				if(_isPassword)
					textBox.PasswordChar = '\u25CF';
				//_clearPassword = new StringBuilder();
			} 
		}

		public string GetClearPassword => _clearPassword.ToString();

		private void ResizeControl(object sender, EventArgs e)
		{
			Couple nouvelleTaille;
			if (textBox.Multiline)
			{
				nouvelleTaille = new Couple(textBox.Location.X, 10);
			}
			else
			{
				nouvelleTaille = new Couple(textBox.Location.X, (Height - textBox.Height) / 2);
			}

			textBox.Location = nouvelleTaille.ToPoint();
		}
	}
}
