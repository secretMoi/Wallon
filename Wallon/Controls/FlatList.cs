using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Controls;
using Controls.Buttons;

namespace Controls
{
	public partial class FlatList : UserControl
	{
		private readonly List<string> _elements;
		private int _hauteurCase = 30;

		public FlatList()
		{
			InitializeComponent();

			flatLabelTitre.ForeColor = Theme.Back;

			_elements = new List<string>();
		}

		public void Add(string element)
		{
			_elements.Add(element);

			FlatButton flatButton = new FlatButton
			{
				Height = _hauteurCase,
				Text = @"   " + element,
				BackColor = Theme.Back,
				TextAlign = ContentAlignment.MiddleLeft,
				Width = panelCorps.Width, // fit la largeur du bouton au panel
				Location = new Point(0, _elements.Count * _hauteurCase),
				AutoSize = true // agrandit le bouton pour afficher le texte si il est trop long
			};
		}

		public void Add(string[] elements)
		{
			foreach (string element in elements)
				Add(element);
		}

		public override string Text
		{
			get => flatLabelTitre.Text;
			set => flatLabelTitre.Text = value;
		}

		private void panelCorps_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Theme.Back, ButtonBorderStyle.Solid);
		}

		private void panelTitre_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Theme.Back, ButtonBorderStyle.Solid);
		}
	}
}
