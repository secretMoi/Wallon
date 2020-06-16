using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Controls.Buttons;

namespace Controls
{
	public partial class FlatList : UserControl
	{
		private readonly List<string> _elements;
		private readonly List<FlatButton> _selected;
		private int _hauteurCase = 30;

		public FlatList()
		{
			InitializeComponent();

			flatLabelTitre.ForeColor = Theme.Back;

			_elements = new List<string>();
			_selected = new List<FlatButton>();
		}

		public void Add(string element, EventHandler click = null)
		{
			FlatButton flatButton = new FlatButton
			{
				Height = _hauteurCase,
				Text = element,
				BackColor = Theme.Back,
				TextAlign = ContentAlignment.MiddleCenter,
				Width = panelCorps.Width, // fit la largeur du bouton au panel
				Location = new Point(0, _elements.Count * _hauteurCase),
				AutoSize = true, // agrandit le bouton pour afficher le texte si il est trop long
				Name = "Element_" + _elements.Count
		};

			panelCorps.Controls.Add(flatButton);

			_elements.Add(element);

			flatButton.Click += Click; // abonne la fonction de cette classe, permettant d'ouvrir/fermer le menu
			if (click != null)
				flatButton.Click += click; // abonne la fonction utilisateur
		}

		public void Add(string[] elements, EventHandler click = null)
		{
			foreach (string element in elements)
				Add(element, click);
		}

		public void Add(List<string> elements, EventHandler click = null)
		{
			foreach (string element in elements)
				Add(element, click);
		}

		private new void Click(object sender, EventArgs e)
		{
			FlatButton flatButton = (FlatButton) sender;

			// trouve l'id
			_selected.Add(flatButton);

			flatButton.BackColor = Theme.BackLight;
		}

		public List<string> SelectedItems()
		{
			return _selected.Select(x => x.Text).ToList();
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
