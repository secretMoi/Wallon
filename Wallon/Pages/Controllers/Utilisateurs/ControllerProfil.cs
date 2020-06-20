using Couche_Classe;
using FlatControls.Controls;
using Wallon.Core;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerProfil
	{
		private const string ChampNom = "Nom";
		private readonly RepositoryLocataires locataire;

		public ControllerProfil()
		{
			locataire = new RepositoryLocataires();
		}

		/// <summary>
		/// Définit le titre de la page
		/// </summary>
		/// <returns>Envoie le titre formatté avec le nom du locataire actuellement connecté</returns>
		public string TitrePage()
		{
			return "Bienvenue sur votre profil " + LocalOptions.Instance.GetOption(ChampNom);
		}

		/// <summary>
		/// Pré-rempli les champs avec les données du locataire
		/// </summary>
		/// <param name="flatTextBoxNom">Textbox pour modifier le nom du locataire</param>
		/// <param name="flatTextBoxPassword">Textbox pour modifier le mot de passe du locataire</param>
		public void RempliChamps(FlatTextBox flatTextBoxNom, FlatTextBox flatTextBoxPassword)
		{
			Locataire locataireCourant = locataire.LireId(Settings.IdLocataire); // récupère le locataire dans la bdd

			// modifie les champs
			flatTextBoxNom.Text = locataireCourant.Nom;
			flatTextBoxPassword.Text = Cryptage.Uncrypt(locataireCourant.Password);
		}

		/// <summary>
		/// Update la bdd dse nouvelles informations de l'utilisateur
		/// </summary>
		/// <param name="nom">Nouveau nom du locataire</param>
		/// <param name="password">Nouveau mot de passe en clair du locataire</param>
		public void Update(string nom, string password)
		{
			locataire.Modifier(Settings.IdLocataire, nom, Cryptage.Crypt(password));
		}
	}
}
