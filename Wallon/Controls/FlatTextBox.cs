using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Controls;
using Core;

namespace QMag.Controls
{
    public partial class FlatTextBox : UserControl
    {
        public FlatTextBox()
        {
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
        public override string Text {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        private void ResizeControl(object sender, EventArgs e)
        {
            Couple nouvelleTaille = new Couple(textBox.Location.X, (Height - textBox.Height) / 2);
            textBox.Location = nouvelleTaille.ToPoint();
        }
    }
}
