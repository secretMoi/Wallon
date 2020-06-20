using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
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
			Couple nouvelleTaille = new Couple(textBox.Location.X, (Height - textBox.Height) / 2);
			textBox.Location = nouvelleTaille.ToPoint();
		}

		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			
		}

		private char ConvertChar(KeyEventArgs e)
		{
			int keyValue = e.KeyValue;

			// si c'est une minuscule
			if (!e.Shift && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
				return (char)(keyValue + 32);

			return (char)keyValue; // sinon c'est une majuscule
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			/*if (!_isPassword || Text.Length < 1) return;

			_clearPassword.Append(Text[Text.Length - 1]); // ajoute le caractère au mot de passe

			StringBuilder text = new StringBuilder();

			for (int i = 0; i < Text.Length; i++) // remplace les caractères
				text.Append(@"*");

			Text = text.ToString();

			// place le curseur à la fin de la chaine
			textBox.SelectionStart = Text.Length;
			textBox.SelectionLength = 0;*/
		}
	}
}
