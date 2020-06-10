using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Core;
using Wallon.Fenetres;

//todo border fenetre
namespace Controls
{
	public partial class ThemePanel : UserControl
	{
		protected static string Connexion;
		protected List<object> _arguments;

		public ThemePanel(/*IContainer components*/)
		{
			//this.components = components;
			InitializeComponent();

			Dock = DockStyle.Fill;
			AutoScaleMode = AutoScaleMode.Dpi;
			DoubleBuffered = true;

			_arguments = new List<object>();
		}

		/*protected ThemePanel()
		{
			
		}*/

		protected void SetPanelTitre(Panel panel)
		{
			panel.Height = Theme.HauteurHeaderTitre;
		}

		protected void SetTitre(string titre)
		{
			labelTitre.Text = titre;
		}

		// méthode appelée après la création d'une page pour charger des arguments
		public virtual void Hydrate(params object[] args)
		{
			if (args.Length > 0)
				foreach (object arg in args)
					_arguments.Add(arg);
		}

		protected void LoadPage(string page, params object[] arguments)
		{
			string @namespace = new Reflection(GetType()).FirstNamespace;
			 //Form1 lastOpenedForm = (Form1) Form.ActiveForm; //méthode basique mais peu fiable
			var test = Application.OpenForms;
			Form1 lastOpenedForm = Application.OpenForms[Application.OpenForms.Count - 1] as Form1; // récupère la dernière form active
			lastOpenedForm?.LoadPage(@namespace + ".Pages.Vue." + page, arguments); // charge la page Ajouter
		}

		public static void SetConnection(string connexion)
		{
			Connexion = connexion;
		}
	}
}
