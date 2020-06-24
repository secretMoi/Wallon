using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FlatControls.Controls.Buttons;

namespace FlatControls.Controls.MainMenu
{
	public sealed partial class MainMenu : UserControl
	{
		private readonly List<MenuFlatButton> _menuItems; // élément de menu de base
		private readonly List<FlowLayoutPanel> _panelMenu; // panel pour menu déroulant
		private readonly List<(MenuFlatButton, MenuFlatButton)> _subMenuItems; // élément de sous-menu (parent + lui-même)
		private MenuFlatButton _lastParent;

		private readonly List<Panel> _subMenuPanelToHide = new List<Panel>();
		private Panel _subMenuPanelToShow;

		private MenuFlatButton LastParent => _lastParent;

		public EventHandler DefaultCallback { get; set; }

		public int HeightItem { get; set; } = 80;
		public int SpeedStep { get; set; } = 8;

		public string DefaultPath { get; set; }

		public new Color BackColor { get => panelContainer.BackColor; set => panelContainer.BackColor = value; }
		public Color BackColorSub { get; set; }
		public List<FlowLayoutPanel> PanelList => _panelMenu;

		private enum Type
		{
			MainMenu, SubMenu
		}

		public MainMenu()
		{
			InitializeComponent();

			_menuItems = new List<MenuFlatButton>();
			_panelMenu = new List<FlowLayoutPanel>();
			_subMenuItems = new List<(MenuFlatButton, MenuFlatButton)>();

			// désactive les barres de scroll mais rend le scroll possible
			panelContainer.AutoScroll = false;
			panelContainer.VerticalScroll.Enabled = false;
			panelContainer.VerticalScroll.Visible = false;
			panelContainer.VerticalScroll.Maximum = 0;

			panelContainer.HorizontalScroll.Enabled = false;
			panelContainer.HorizontalScroll.Visible = false;
			panelContainer.HorizontalScroll.Maximum = 0;
			panelContainer.AutoScroll = true;
		}

		public void AddMenuItem(string name, string image, string text = null)
		{
			if (text == null)
				text = name;

			MenuFlatButton button = CreateButton(Type.MainMenu, name, text, image);
			_menuItems.Add(button);

			_lastParent = button;

			panelContainer.Controls.Add(button);
		}

		public void AddSubMenuItem(string parent, string name, string image, string text = null)
		{
			if (text == null)
				text = name;

			if (FindPanel(parent) == null) // si c'est le premier élément de sous-menu
				_panelMenu.Add(CreatePanel(parent)); // crée le panel dédié

			Control controlParent = FindPanel(parent);

			MenuFlatButton button = CreateButton(Type.SubMenu, name, text, image); // crée le bouton

			// ajoute le bouton au panel;
			_subMenuItems.Add(
				(
					FindParent(parent),
					button
				)
			);

			controlParent?.Controls.Add(button);

			RefreshMaxHeight(controlParent);
		}

		public void AddSubMenuItem(string name, string image, string text = null)
		{
			if (text == null)
				text = name;

			string parent = _lastParent.Name.Split('_')[1];

			if (FindPanel(parent) == null) // si c'est le premier élément de sous-menu
				_panelMenu.Add(CreatePanel(parent)); // crée le panel dédié

			Control controlParent = FindPanel(parent);

			MenuFlatButton button = CreateButton(Type.SubMenu, name, text, image); // crée le bouton

			// ajoute le bouton au panel;
			_subMenuItems.Add(
				(
					FindParent(parent),
					button
				)
			);

			controlParent?.Controls.Add(button);

			RefreshMaxHeight(controlParent);
		}

		private void RefreshMaxHeight(Control control)
		{
			control.MaximumSize = new Size(control.MaximumSize.Width, control.MaximumSize.Height + HeightItem);
		}

		private FlowLayoutPanel CreatePanel(string parent)
		{
			FlowLayoutPanel panel = new FlowLayoutPanel
			{
				Name = "panelSousMenu_" + parent,
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

		private FlowLayoutPanel FindPanel(string parentName)
		{
			foreach (FlowLayoutPanel panel in _panelMenu)
				if (panel.Name.Contains(parentName))
					return panel;

			return null;
		}

		private MenuFlatButton FindParent(string parentName)
		{
			foreach (MenuFlatButton button in _menuItems)
				if (button.Name.Contains(parentName))
					return button;

			return null;
		}

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

		public void ClickMenuItem_Click(object sender, EventArgs e)
		{
			string nom = ((Button) sender).Name.Split('_')[1];

			foreach (FlowLayoutPanel panel in _panelMenu)
			{
				if(panel.Name.Contains(nom))
					ShowSubMenu(panel);
			}
		}

		private void HideSubMenu()
		{
			foreach (FlowLayoutPanel panel in _panelMenu)
			{
				if (panel.Size.Height >= panel.MinimumSize.Height && panel != _subMenuPanelToShow)
					_subMenuPanelToHide.Add(panel);
			}
		}

		public void ShowSubMenu(Panel subMenu)
		{
			//bool sameMenu;
			foreach (FlowLayoutPanel panel in _panelMenu)
			{
				if (panel.Size.Height == panel.MinimumSize.Height)
				{
					_subMenuPanelToShow = subMenu;
					HideSubMenu(); // cache les autres sous-menus

					//otherMenu = true;
				}
			}

			
			/*else
				_subMenuPanelToHide.Add(subMenu);*/

			timer.Start();
		}

		public bool IsSubMenu(Button button)
		{
			return button.Name.Contains("subMenu_");
		}

		private void timerMenuDeroulant_Tick(object sender, EventArgs e)
		{
			foreach (Panel panelToHide in _subMenuPanelToHide.ToArray())
			{
				panelToHide.Height -= SpeedStep;

				if (panelToHide.Size.Height == panelToHide.MinimumSize.Height)
					_subMenuPanelToHide.Remove(panelToHide);
			}

			bool hideDone = !(_subMenuPanelToHide.Count > 0);

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
