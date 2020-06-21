﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Controls;
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
		}

		protected void SetPanelTitre(Panel panel)
		{
			panel.Height = FlatControls.Controls.Theme.HauteurHeaderTitre;
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

		public void LoadPage(string page, params object[] arguments)
		{
			string @namespace = new Reflection(GetType()).FirstNamespace;

			Form1 lastOpenedForm = Application.OpenForms[Application.OpenForms.Count - 1] as Form1; // récupère la dernière form active
			lastOpenedForm?.LoadPage(@namespace + ".Pages.Vue." + page, arguments); // charge la page Ajouter
		}

		protected void SetColors()
		{
			// change la couleur de tous les flatLabel
			foreach (FlatControls.Controls.FlatLabel label in panelCorps.Controls.OfType<FlatControls.Controls.FlatLabel>())
				label.ForeColor = Theme.BackDark;
		}

		public static void SetConnection(string connexion)
		{
			Connexion = connexion;
		}
	}
}
