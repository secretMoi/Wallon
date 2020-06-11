using System.Linq;
using Controls;
using Couche_Classe;
using Couche_Gestion;
using Wallon.Fenetres;
using Wallon.Pages.Controlleur;

namespace Wallon.Pages.Vue
{
	public partial class Connexion : ThemePanel
	{
		private ControllerLocataires _controllerLocataires;

		public Connexion()
		{
			InitializeComponent();

			_controllerLocataires = new ControllerLocataires();

			SetTitre("Connexion");

			SetColors();

			//new Gestion_Locataire(Connexion).Supprimer(5);
			/*List<Locataire> _controllerLocataires = new Gestion_Locataire(Connexion).Lire("id");
			SetTitre(_controllerLocataires[9].Nom);*/

			/*Locataire locataire = _controllerLocataires.GetById(2);
			SetTitre(locataire.Nom);*/
		}

		private void SetColors()
		{
			// change la couleur de tous les flatLabel
			foreach (FlatLabel label in Controls.OfType<FlatLabel>())
				label.ForeColor = Theme.BackDark;
		}

		private void flatButtonConnexion_Click(object sender, System.EventArgs e)
		{
			string nom = flatTextName.Text;
			string password = flatTextBoxPassword.Text;

			if(_controllerLocataires.Authentifie(nom, password))
				LoadPage("Accueil");
			else
			{
				Dialog.Show("Identifiants invalides");
			}
		}
	}
}
