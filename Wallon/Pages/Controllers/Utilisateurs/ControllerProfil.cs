namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerProfil
	{
		private const string ChampNom = "Nom";

		public ControllerProfil()
		{

		}

		public string TitrePage()
		{
			return "Bienvenue sur votre profil " + LocalOptions.Instance.GetOption(ChampNom);
		}
	}
}
