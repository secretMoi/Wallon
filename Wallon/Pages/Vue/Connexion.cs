﻿using System.Linq;
using Controls;
using Wallon.Controllers;
using Wallon.Pages.Controllers;

namespace Wallon.Pages.Vue
{
	public partial class Connexion : ThemePanel
	{
		private readonly ControllerLocataires _controllerLocataires;
		private readonly ControllerConnection _controllerConnection;

		public Connexion()
		{
			InitializeComponent();

			_controllerLocataires = new ControllerLocataires();
			_controllerConnection = new ControllerConnection();

			if (_controllerConnection.AuthInCacheValid(_controllerLocataires))
			{
				_controllerConnection.Auth();
				LoadPage("Accueil");
			}

			SetTitre("Connexion");

			SetColors();
		}

		private void SetColors()
		{
			// change la couleur de tous les flatLabel
			foreach (FlatLabel label in Controls.OfType<FlatLabel>())
				label.ForeColor = Theme.BackDark;
		}

		private void flatButtonConnexion_Click(object sender, System.EventArgs e)
		{
			// récupère les text des champs
			string nom = flatTextName.Text;
			string password = flatTextBoxPassword.Text;

			if (_controllerLocataires.Authentifie(nom, password)) // si les identifiants entrés sont bons
			{
				_controllerConnection.Save(nom, password); // enregistre la session dans le fichier local
				_controllerConnection.Auth(); // authentifie dans le programme

				LoadPage("Accueil"); // redirige vers la page d'accueil
			}
			else
				alerte.Show("Identifiants invalides");
		}
	}
}
