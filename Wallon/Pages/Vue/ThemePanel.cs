using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FlatControls.Controls;
using FlatControls.Core;
using Wallon.Fenetres;

//todo border fenetre
namespace Wallon.Pages.Vue
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

			BorderStyle = BorderStyle.None;
		}

		protected void SetPanelTitre(Panel panel)
		{
			panel.Height = Theme.HauteurHeaderTitre;
		}

		/// <summary>
		/// Définit le titre de la page qui sera indiqué dans le panelHeader
		/// </summary>
		/// <param name="titre">Titre de la page</param>
		protected void SetTitre(string titre)
		{
			labelTitre.Text = titre;
		}

		/// <summary>
		/// Fourni des paramètres à donner à la page lors de son chargement
		/// </summary>
		/// <param name="args">Arguments pouvant être passé en paramètre lors du chargement d'une page</param>
		public virtual void Hydrate(params object[] args)
		{
			if (args.Length > 0)
				foreach (object arg in args)
					_arguments.Add(arg);
		}

		/// <summary>
		/// Permet de savoir si des arguments ont été passé en paramètre
		/// </summary>
		/// <returns>true si des arguments sont présents, false sinon</returns>
		protected bool AnyArgs()
		{
			return _arguments.Count > 0;
		}

		/// <summary>
		/// Charge une page depuis le dossier Vue
		/// </summary>
		/// <param name="page">Nom de le page à charger</param>
		/// <param name="arguments">Arguments à transmettre à la page</param>
		public void LoadPage(string page, params object[] arguments)
		{
			string @namespace = new Reflection(GetType()).FirstNamespace;

			Form1 lastOpenedForm = Application.OpenForms[Application.OpenForms.Count - 1] as Form1; // récupère la dernière form active
			lastOpenedForm?.LoadPage(@namespace + ".Pages.Vue." + page, arguments); // charge la page Ajouter
		}

		/// <summary>
		/// Unifie les couleurs des composants dans les pages
		/// </summary>
		protected void SetColors()
		{
			// change la couleur de tous les flatLabel
			foreach (FlatLabel label in panelCorps.Controls.OfType<FlatLabel>())
				label.ForeColor = Theme.BackDark;
		}

		/// <summary>
		/// Définit la constante de connection à la BDD qui sera transmise lors des requêtes
		/// </summary>
		/// <param name="connexion">Chaine de connexion à la base de données</param>
		public static void SetConnection(string connexion)
		{
			Connexion = connexion;
		}
	}
}
