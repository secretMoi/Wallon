using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FlatControls.Controls.Buttons;

namespace FlatControls.Controls.MainMenu
{
	public sealed partial class MainMenu : UserControl
	{
		private readonly List<MenuFlatButton> _menuItems; // élément de menu de base
		private readonly List<MenuFlatButton> _menuBottomItems; // élément de menu de base en bas
		private readonly List<FlowLayoutPanel> _panelMenu; // panel pour menu déroulant
		private readonly List<(MenuFlatButton, MenuFlatButton)> _subMenuItems; // élément de sous-menu (parent + lui-même)
		private MenuFlatButton _lastParent; // sauvegarde le dernier parent créé afin que les enfants n'aient pas besoin de le rappeler

		private readonly List<Panel> _subMenuPanelToHide = new List<Panel>(); // liste des panel à masquer
		private Panel _subMenuPanelToShow; // panel à dérouler

		/// <summary>
		/// Retourne le dernier parent créé
		/// </summary>
		private MenuFlatButton LastParent => _lastParent;

		/// <summary>
		/// Méthode à appeler lors du click sur un bouton du menu
		/// </summary>
		/// <param name="value">Lien vers la méthode à rappeler</param>
		public EventHandler DefaultCallback { get; set; }

		/// <summary>
		/// Définit la hauteur de chacun des boutons du menu
		/// </summary>
		/// <param name="value">Hauteur en pixel</param>
		public int HeightItem { get; set; } = 80;

		/// <summary>
		/// Définit la vitesse d'ouverture et fermeture du menu pendant l'animation
		/// </summary>
		/// <param name="value">Vitesse</param>
		public int SpeedStep { get; set; } = 8;

		/// <summary>
		/// Permet de définir un répertoire par défaut où trouver les icônes pour les boutons
		/// </summary>
		/// <param name="value">Lien vers la méthode à rappeler</param>
		public string DefaultPath { get; set; }

		/// <summary>
		/// Couleur d'arrière-plan du menu et des boutons principaux
		/// </summary>
		/// <param name="value">Nouvelle couleur</param>
		public new Color BackColor { get => panelContainer.BackColor; set => panelContainer.BackColor = value; }

		/// <summary>
		/// Couleur d'arrière-plan des boutons de sous-menu
		/// </summary>
		/// <param name="value">Nouvelle couleur</param>
		public Color BackColorSub { get; set; }

		/// <summary>
		/// Retourne la liste des panels
		/// </summary>
		public List<FlowLayoutPanel> PanelList => _panelMenu;

		/// <summary>
		/// Liste des types de boutons
		/// </summary>
		private enum Type
		{
			MainMenu, // menu principal
			SubMenu // sous-menu
		}

		public MainMenu()
		{
			InitializeComponent();

			// initialise les listes
			_menuItems = new List<MenuFlatButton>();
			_panelMenu = new List<FlowLayoutPanel>();
			_subMenuItems = new List<(MenuFlatButton, MenuFlatButton)>();
			_menuBottomItems = new List<MenuFlatButton>();

			// désactive les barres de scroll mais rend le scroll possible
			panelContainer.AutoScroll = false;
			panelContainer.VerticalScroll.Enabled = false;
			panelContainer.VerticalScroll.Visible = false;
			panelContainer.VerticalScroll.Maximum = 0;

			panelContainer.HorizontalScroll.Enabled = false;
			panelContainer.HorizontalScroll.Visible = false;
			panelContainer.HorizontalScroll.Maximum = 0;
			panelContainer.AutoScroll = true;

			flowLayoutPanelBottom.Size = new Size(Width, 0);
		}

		/// <summary>
		/// Ajoute un item de menu principal
		/// </summary>
		/// <param name="name">Nom du control</param>
		/// <param name="image">Chemin de l'image à afficher</param>
		/// <param name="text">Texte à afficher si différent du nom</param>
		public void AddMenuItem(string name, string image, string text = null)
		{
			if (text == null)
				text = name;

			MenuFlatButton button = CreateButton(Type.MainMenu, name, text, image);
			_menuItems.Add(button);

			_lastParent = button;

			panelContainer.Controls.Add(button);
		}

		/// <summary>
		/// Ajoute un item de menu principal en bas
		/// </summary>
		/// <param name="name">Nom du control</param>
		/// <param name="image">Chemin de l'image à afficher</param>
		/// <param name="callBack">Méthode à rappeler lors du clic</param>
		/// <param name="text">Texte à afficher si différent du nom</param>
		public void AddMenuBottomItem(string name, string image, EventHandler callBack = null, string text = null)
		{
			if (text == null)
				text = name;

			MenuFlatButton button = CreateButton(Type.MainMenu, name, text, image);

			if(callBack != null)
				button.Click += callBack;

			_menuBottomItems.Add(button);

			_lastParent = button;

			button.Dock = DockStyle.Bottom;

			flowLayoutPanelBottom.Controls.Add(button);
			flowLayoutPanelBottom.Size = new Size(Width, flowLayoutPanelBottom.Height + HeightItem);
		}

		/// <summary>
		/// Ajoute un item de sous-menu
		/// </summary>
		/// <param name="parent">Nom du control parent (une partie suffit)</param>
		/// <param name="name">Nom du control</param>
		/// <param name="image">Chemin de l'image à afficher</param>
		/// <param name="text">Texte à afficher si différent du nom</param>
		public void AddSubMenuItem(string parent, string name, string image, string text = null)
		{
			if (text == null)
				text = name;

			name = parent + "_" + name;

			if (FindParent(parent, _panelMenu) == null) // si c'est le premier élément de sous-menu
				_panelMenu.Add(CreatePanel(parent)); // crée le panel dédié

			Control controlParent = FindParent(parent, _panelMenu);

			MenuFlatButton button = CreateButton(Type.SubMenu, name, text, image); // crée le bouton

			// ajoute le bouton au panel;
			_subMenuItems.Add(
				(
					FindParent(parent, _menuItems) as MenuFlatButton,
					button
				)
			);

			controlParent?.Controls.Add(button);

			RefreshMaxHeight(controlParent);
		}

		/// <summary>
		/// Ajoute un item de sous-menu
		/// </summary>
		/// <param name="name">Nom du control</param>
		/// <param name="image">Chemin de l'image à afficher</param>
		/// <param name="text">Texte à afficher si différent du nom</param>
		public void AddSubMenuItem(string name, string image, string text = null)
		{
			string parent = _lastParent.Name.Split('_')[1]; // récupère le nom du dernier control créé

			AddSubMenuItem(parent, name, image, text);
		}

		/// <summary>
		/// Agrandit la taille maximale d'un control avec l'attribut HeightItem
		/// </summary>
		/// <param name="control">Control à redimensionner</param>
		private void RefreshMaxHeight(Control control)
		{
			control.MaximumSize = new Size(control.MaximumSize.Width, control.MaximumSize.Height + HeightItem);
		}

		/// <summary>
		/// Crée un FlowLayoutPanel englobant le sous-menu
		/// </summary>
		/// <param name="name">Nom du bouton de menu parent</param>
		/// <returns>Le FlowLayoutPanel créé</returns>
		private FlowLayoutPanel CreatePanel(string name)
		{
			FlowLayoutPanel panel = new FlowLayoutPanel
			{
				Name = "panelSousMenu_" + name,
				BackColor = BackColor,
				Dock = DockStyle.Top,
				Location = new Point(0, 0),
				MaximumSize = new Size(Width, 0),
				Size = new Size(Width, 0),
				Padding = new Padding(0),
				Margin = new Padding(0)
			};

			panelContainer.Controls.Add(panel);

			return panel;
		}

		/// <summary>
		/// Retrouve un Control grâce à une partie de son nom
		/// </summary>
		/// <param name="parentName">Partie du nom</param>
		/// <param name="liste">Liste de control dans laquelle chercher</param>
		/// <returns>Le Control trouvé, null si rien trouvé</returns>
		private Control FindParent<T>(string parentName, List<T> liste)
		{
			foreach (dynamic button in liste)
				if (button.Name.Contains(parentName))
					return button;

			return null;
		}

		/// <summary>
		/// Crée un bouton pour le menu
		/// </summary>
		/// <param name="type">Indique si le bouton est pour le menu principal ou le sous-menu</param>
		/// <param name="name">Nom du bouton</param>
		/// <param name="text">Texte que le bouton affichera</param>
		/// <param name="pathImage">Chemin de l'image du bouton</param>
		/// <returns>Le MenuFlatButton créé</returns>
		private MenuFlatButton CreateButton(Type type, string name, string text, string pathImage)
		{
			Image image = Image.FromFile(DefaultPath + pathImage);

			Color backColor = BackColor;

			if (type == Type.MainMenu)
			{
				name = "menu_" + name;
				backColor = BackColor;
			}
			else if(type == Type.SubMenu)
			{
				name = "subMenu_" + name;
				backColor = BackColorSub;
			}

			MenuFlatButton button = new MenuFlatButton
			{
				Text = @"   " + text,
				Image = image,
				Dock = DockStyle.Top,
				BackColor = backColor,
				Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point),
				ForeColor = Color.White,
				ImageAlign = ContentAlignment.MiddleLeft,
				Location = new Point(0,0),
				Name = name,
				Size = new Size(Width, HeightItem),
				TextImageRelation = TextImageRelation.ImageBeforeText,
				FlatStyle = FlatStyle.Flat,
				UseVisualStyleBackColor = false,
				Padding = new Padding(0),
				Margin = new Padding(0)
			};

			if(type == Type.MainMenu)
				button.Click += ClickMenuItem_Click;
			button.Click += DefaultCallback;

			return button;
		}

		/// <summary>
		/// Ouvre le menu désiré lors du click
		/// </summary>
		/// <param name="sender">Objet qui a lancé l'event du clic</param>
		/// <param name="e">Arguments</param>
		public void ClickMenuItem_Click(object sender, EventArgs e)
		{
			string nom = ((Button) sender).Name.Split('_')[1];

			foreach (FlowLayoutPanel panel in _panelMenu)
			{
				if(panel.Name.Contains(nom))
					ShowSubMenu(panel);
			}
		}

		/// <summary>
		/// Rétrécit les sous-menus autres que le cliqué
		/// </summary>
		private void HideSubMenu()
		{
			foreach (FlowLayoutPanel panel in _panelMenu)
			{
				if (panel.Size.Height >= panel.MinimumSize.Height && panel != _subMenuPanelToShow)
					_subMenuPanelToHide.Add(panel);
			}
		}

		/// <summary>
		/// Ouvre le sous-menu cliqué
		/// </summary>
		/// <param name="subMenu">Sous-menu à ouvrir</param>
		public void ShowSubMenu(FlowLayoutPanel subMenu)
		{
			if (subMenu.Size.Height == subMenu.MinimumSize.Height)
			{
				_subMenuPanelToShow = subMenu;
				HideSubMenu(); // cache les autres sous-menus
			}

			timer.Start();
		}

		/// <summary>
		/// Indique si le bouton appartient à un sous-menu ou non
		/// </summary>
		/// <param name="button">Bouton à vérifier</param>
		public bool IsSubMenu(Button button)
		{
			return button.Name.Contains("subMenu_");
		}

		/// <summary>
		/// Déroule et enroule les sous-menus périodiquement créant l'animation
		/// </summary>
		/// <param name="sender">Objet qui a lancé l'event du clic</param>
		/// <param name="e">Arguments</param>
		private void timerMenuDeroulant_Tick(object sender, EventArgs e)
		{
			// enroule les sous-menus ouverts
			foreach (Panel panelToHide in _subMenuPanelToHide.ToArray())
			{
				panelToHide.Height -= SpeedStep;

				if (panelToHide.Size.Height == panelToHide.MinimumSize.Height)
					_subMenuPanelToHide.Remove(panelToHide);
			}

			bool hideDone = !(_subMenuPanelToHide.Count > 0);

			// déroule le sous-menu cliqué
			if (_subMenuPanelToShow != null)
			{
				_subMenuPanelToShow.Height += SpeedStep;

				if (_subMenuPanelToShow.Size.Height >= _subMenuPanelToShow.MaximumSize.Height)
					_subMenuPanelToShow = null;
			}

			// si tous les panels ont atteint leur position finale
			if (_subMenuPanelToShow == null && hideDone)
				timer.Stop();
		}
	}
}
