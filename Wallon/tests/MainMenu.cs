using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FlatControls.Controls.Buttons;

namespace Wallon.tests
{
	public sealed partial class MainMenu : UserControl
	{
		private readonly List<MenuFlatButton> _menuItems; // élément de menu de base
		private readonly List<Panel> _panelMenu; // panel pour menu déroulant
		private readonly List<(MenuFlatButton, MenuFlatButton)> _subMenuItems; // élément de sous-menu (parent + lui-même)

		private readonly List<Panel> _subMenuPanelToHide = new List<Panel>();
		private Panel _subMenuPanelToShow;

		public EventHandler DefaultCallback { get; set; }

		public int HeightItem { get; set; } = 80;
		public int SpeedStep { get; set; } = 7;

		public new Color BackColor { get => panelContainer.BackColor; set => panelContainer.BackColor = value; }
		public List<Panel> PanelList => _panelMenu;

		public MainMenu()
		{
			InitializeComponent();

			_menuItems = new List<MenuFlatButton>();
			_panelMenu = new List<Panel>();
			_subMenuItems = new List<(MenuFlatButton, MenuFlatButton)>();

			// désactive les barres de scroll
			panelContainer.AutoScroll = false;
			panelContainer.VerticalScroll.Enabled = false;
			panelContainer.VerticalScroll.Visible = false;
			panelContainer.VerticalScroll.Maximum = 0;

			panelContainer.HorizontalScroll.Enabled = false;
			panelContainer.HorizontalScroll.Visible = false;
			panelContainer.HorizontalScroll.Maximum = 0;
			panelContainer.AutoScroll = true;
		}

		public void AddMenuItem(string name, string text, Image image)
		{
			MenuFlatButton button = CreateButton(name, text, image);
			_menuItems.Add(button);

			panelContainer.Controls.Add(button);
		}

		public void AddSubMenuItem(string parent, string name, string text, Image image)
		{
			if (FindPanel(parent) == null) // si c'est le premier élément de sous-menu
				_panelMenu.Add(CreatePanel(parent)); // crée le panel dédié

			Control controlParent = FindPanel(parent);

			FlatButton button = CreateButton(name, text, image); // crée le bouton

			// ajoute le bouton au panel;
			_subMenuItems.Add(
				(
					FindParent(parent),
					CreateButton(name, text, image)
				)
			);

			controlParent?.Controls.Add(button);

			RefreshMaxHeight(controlParent);
		}

		private void RefreshMaxHeight(Control control)
		{
			control.MaximumSize = new Size(control.MaximumSize.Width, control.MaximumSize.Height + HeightItem);
		}

		private Panel CreatePanel(string parent)
		{
			Panel panel = new Panel
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

		private Panel FindPanel(string parentName)
		{
			foreach (Panel panel in _panelMenu)
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

		private MenuFlatButton CreateButton(string name, string text, Image image)
		{
			MenuFlatButton button = new MenuFlatButton
			{
				Text = @"   " + text,
				Image = image,
				Dock = DockStyle.Top,
				BackColor = BackColor,
				Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point),
				ForeColor = Color.White,
				ImageAlign = ContentAlignment.MiddleLeft,
				Location = new Point(0,0),
				Name = "menu_" + name,
				Size = new Size(Width, HeightItem),
				TextImageRelation = TextImageRelation.ImageBeforeText,
				FlatStyle = FlatStyle.Flat,
				UseVisualStyleBackColor = false,
				Padding = new Padding(0),
				Margin = new Padding(0)
			};

			button.Click += DefaultCallback;

			return button;
		}

		private void HideSubMenu()
		{
			foreach (Panel panel in _panelMenu)
			{
				if (panel.Size.Height >= panel.MinimumSize.Height && panel != _subMenuPanelToShow)
					_subMenuPanelToHide.Add(panel);
			}
		}

		public void ShowSubMenu(Panel subMenu)
		{
			//bool sameMenu;
			foreach (Panel panel in _panelMenu)
			{
				if (panel.Size.Height == panel.MinimumSize.Height)
				{
					_subMenuPanelToShow = subMenu;
					HideSubMenu(); // cache les autres sous-menus7

					//otherMenu = true;
				}
			}

			
			/*else
				_subMenuPanelToHide.Add(subMenu);*/

			timer.Start();
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
