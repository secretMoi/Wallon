using System.Collections.Generic;
using System.Linq;
using Controls;
using Couche_Classe;
using Couche_Gestion;

namespace Wallon.Pages.Vue
{
	public partial class Connexion : ThemePanel
	{
		public Connexion()
		{
			InitializeComponent();

			SetTitre("Connexion");

			SetColors();

			//new Gestion_Locataire(Connexion).Ajouter("Quentin", "6463f184f");
			List<Locataire> locataire = new Gestion_Locataire(Connexion).Lire("id");
			SetTitre(locataire[0].Nom);
		}

		private void SetColors()
		{
			// change la couleur de tous les flatLabel
			foreach (FlatLabel label in Controls.OfType<FlatLabel>())
				label.ForeColor = Theme.BackDark;
		}
	}
}
