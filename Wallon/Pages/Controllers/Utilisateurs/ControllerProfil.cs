namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerProfil
	{
		private const string ChampNom = "Nom";

		public ControllerProfil()
		{

		}

		/// <summary>
		/// Définit le titre de la page
		/// </summary>
		/// <returns>Envoie le titre formatté avec le nom du locataire actuellement connecté</returns>
		public string TitrePage()
		{
			return "Bienvenue sur votre profil " + LocalOptions.Instance.GetOption(ChampNom);
		}
	}
}
