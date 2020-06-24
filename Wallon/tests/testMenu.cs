using System;
using System.Drawing;
using System.Windows.Forms;
using FlatControls.Controls;
using FlatControls.Core;

namespace Wallon.tests
{
	public partial class TestMenu : Form
	{
		public TestMenu()
		{
			InitializeComponent();

			mainMenu1.BackColor = Theme.BackDark;
			mainMenu1.DefaultCallback = Menu_Click;
			mainMenu1.AddMenuItem("test1", "test1", Image.FromFile("Ressources/Images/box.png"));
			mainMenu1.AddMenuItem("test2", "test2", Image.FromFile("Ressources/Images/box.png"));
			mainMenu1.AddMenuItem("test3", "test3", Image.FromFile("Ressources/Images/box.png"));
			mainMenu1.AddSubMenuItem("test3", "test6", "2", Image.FromFile("Ressources/Images/box.png"));
			mainMenu1.AddSubMenuItem("test3", "test7", "3", Image.FromFile("Ressources/Images/box.png"));
			mainMenu1.AddSubMenuItem("test3", "test7", "3", Image.FromFile("Ressources/Images/box.png"));
			mainMenu1.AddSubMenuItem("test3", "test7", "3", Image.FromFile("Ressources/Images/box.png"));
			mainMenu1.AddMenuItem("test4", "test4", Image.FromFile("Ressources/Images/box.png"));
			mainMenu1.AddSubMenuItem("test4", "test5", "1", Image.FromFile("Ressources/Images/box.png"));
		}

		private void Menu_Click(object sender, EventArgs e)
		{
			
			string nom = ((Button)sender).Name; // récupère le nom du controle appelant
			string[] chaine = nom.Split('_'); // scinde le nom pour avoir les 2 parties

			Panel panel = mainMenu1.PanelList.Find(x => x.Name == "panelSousMenu_" + chaine[1]);

			if (panel != null) // si un panel existe
				mainMenu1.ShowSubMenu(panel);

			/*Reflection reflection = new Reflection(GetType());

			string @namespace, @class;

			if (chaine.Length == 3) // si c'est un bouton de sous-menu
			{
				@namespace = reflection.FirstNamespace + ".Pages.Vue." + chaine[1];
				@class = chaine[2];
			}
			else // si c'est un bouton de menu
			{
				// charge directement la page
				@namespace = reflection.FirstNamespace + ".Pages.Vue";
				@class = chaine[1];

				// trouve le panel correspondant
				/*Control[] panel = Controls.Find("PanelSousMenu" + chaine[1], true);
				if (panel.Length > 0) // si un panel existe
					mainMenu1.ShowSubMenu((Panel)panel[0]);
			}*/

			//LoadPage(@namespace + "." + @class);
		}

		
	}
}
