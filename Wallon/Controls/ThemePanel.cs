using System.Collections.Generic;
using System.Windows.Forms;
using Wallon.Fenetres;

//todo border fenetre
namespace Controls
{
	public partial class ThemePanel : UserControl
	{
		protected static string Connexion;
		protected List<object> _arguments;

		public ThemePanel()
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
			AutoScaleMode = AutoScaleMode.Dpi;
			DoubleBuffered = true;

			_arguments = new List<object>();
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
			// Form1 form = (Form1) Form.ActiveForm; méthode basique mais peu fiable
			Form1 lastOpenedForm = Application.OpenForms[Application.OpenForms.Count - 1] as Form1; // récupère la dernière form active
			lastOpenedForm?.LoadPage("QMag.Pages." + page, arguments); // charge la page Ajouter
		}

		public static void SetConnection(string connexion)
		{
			Connexion = connexion;
		}
	}
}
