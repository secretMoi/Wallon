namespace Wallon.Pages.Vue
{
	public partial class Accueil : ThemePanel
	{
		public Accueil()
		{
			InitializeComponent();

			SetTitre("Accueil");

			//new GestionTaches(Connexion).Ajouter("test", DateTime.Now, true);

			if(!Settings.Auth)
				LoadPage("Connexion");
		}
	}
}
