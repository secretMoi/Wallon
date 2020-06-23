using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FlatControls.Controls.Buttons;

namespace Wallon.tests
{
	public partial class MainMenu : UserControl
	{
		private readonly List<FlatButton> _menuItems; // élément de menu de base
		private readonly List<Panel> _panelMenu; // panel pour menu déroulant
		private readonly List<(FlatButton, FlatButton)> _subMenuItems; // élément de sous-menu

		public EventHandler DefaultCallback { get; set; }

		public int HeightItem { get; set; } = 70;

		public new Color BackColor { get => panelContainer.BackColor; set => panelContainer.BackColor = value; }

		public MainMenu()
		{
			InitializeComponent();

			_menuItems = new List<FlatButton>();
			_panelMenu = new List<Panel>();
			_subMenuItems = new List<(FlatButton, FlatButton)>();
		}

		public void AddMenuItem(string name, string text, Image image)
		{
			FlatButton button = CreateButton(name, text, image);
			_menuItems.Add(button);

			panelContainer.Controls.Add(button);
			panelContainer.Refresh();
		}

		public void AddSubMenuItem(string parent, string name, string text, Image image)
		{
			if (FindPanel(parent) == null)
				_panelMenu.Add(CreatePanel(parent));

			_subMenuItems.Add(
				(
					FindParent(parent),
					CreateButton(name, text, image)
				)
			);
		}

		private Panel CreatePanel(string parent)
		{
			Panel panel = new Panel
			{
				Name = "panelSousMenu_" + parent,
				BackColor = BackColor,
				Dock = DockStyle.Top,
				Location = new Point(0, _panelMenu.Count * HeightItem),
				MaximumSize = new Size(Width, 0),
				Size = new Size(Width, 0)
			};

			return panel;
		}

		private Panel FindPanel(string parentName)
		{
			foreach (Panel panel in _panelMenu)
				if (panel.Name.Contains(parentName))
					return panel;

			return null;
		}

		private FlatButton FindParent(string parentName)
		{
			foreach (FlatButton button in _menuItems)
				if (button.Name.Contains(parentName))
					return button;

			return null;
		}

		private FlatButton CreateButton(string name, string text, Image image)
		{
			FlatButton button = new FlatButton
			{
				Text = @"   " + text,
				Width = Width,
				Height = HeightItem,
				Image = image,
				Dock = DockStyle.Top,
				BackColor = BackColor,
				Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point),
				ForeColor = Color.White,
				ImageAlign = ContentAlignment.MiddleLeft,
				Location = new Point(0, 0),
				Name = "menu_" + name,
				Size = new Size(Width, HeightItem),
				TextImageRelation = TextImageRelation.ImageBeforeText
			};

			var test = button.Location;

			button.Click += DefaultCallback;

			return button;
		}
	}
}
