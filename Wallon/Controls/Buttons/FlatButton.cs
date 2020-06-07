using System.Drawing;
using System.Windows.Forms;
using Core;

namespace QMag.Controls.Buttons
{
    public partial class FlatButton : Button
    {
        private static readonly Couple _size = new Couple(75, 23);

        public FlatButton()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(33, 150, 245);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            UseVisualStyleBackColor = false;
            Size = _size.ToSize();
        }

        protected override bool ShowFocusCues => false;

        public new static Couple DefaultSize => _size;
    }
}
