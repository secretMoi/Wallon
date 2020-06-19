using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Controls.Buttons;
// todo supprimer élément sélectionné
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

			// désactive les barres de scroll mais rend le panel scrollable
			panelCorps.HorizontalScroll.Enabled = false;
			panelCorps.HorizontalScroll.Visible = false;
			panelCorps.HorizontalScroll.Maximum = 0;

			panelCorps.VerticalScroll.Enabled = false;
			panelCorps.VerticalScroll.Visible = false;
			panelCorps.VerticalScroll.Maximum = 0;
			panelCorps.AutoScroll = true;
		}

		/// <summary>
		/// Permet d'ajouter un élément
		/// </summary>
		/// <param name="element">Elément à ajouter à la flatlist</param>
		/// <param name="click">Fonction de callback si l'utilisateur clic sur un bouton</param>
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

		/// <summary>
		/// Permet d'ajouter une liste d'éléments
		/// </summary>
		/// <param name="elements">Liste des éléments à ajouter à la flatlist</param>
		/// <param name="click">Fonction de callback si l'utilisateur clic sur un bouton</param>
		public void Add(string[] elements, EventHandler click = null)
		{
			foreach (string element in elements)
				Add(element, click);
		}

		/// <summary>
		/// Permet d'ajouter une liste d'éléments
		/// </summary>
		/// <param name="elements">Liste des éléments à ajouter à la flatlist</param>
		/// <param name="click">Fonction de callback si l'utilisateur clic sur un bouton</param>
		public void Add(List<string> elements, EventHandler click = null)
		{
			foreach (string element in elements)
				Add(element, click);
		}

		/// <summary>
		/// Event lors du clic sur un bouton de la liste
		/// </summary>
		/// <param name="sender">Le bouton qui lance l'event</param>
		/// <param name="e">Les arguments transmis</param>
		private new void Click(object sender, EventArgs e)
		{
			FlatButton flatButton = (FlatButton) sender;

			// trouve l'id
			_selected.Add(flatButton);

			flatButton.BackColor = Theme.BackLight;
		}

		/// <summary>
		/// Récupère la liste des éléments sélectionnés
		/// </summary>
		/// <returns>Une liste contenant tous les textes des éléments sélectionnés</returns>
		public List<string> SelectedItems()
		{
			return _selected.Select(x => x.Text).ToList();
		}

		/// <summary>
		/// Récupère la liste des id sélectionnés
		/// </summary>
		/// <returns>La liste des id sélectionnés</returns>
		public List<int> SelectedId()
		{
			List<int> idSelected = new List<int>();
			string name;

			foreach (FlatButton flatButton in _selected)
			{
				name = flatButton.Name.Split('_')[1];
				idSelected.Add(int.Parse(name));
			}

			return idSelected;
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
