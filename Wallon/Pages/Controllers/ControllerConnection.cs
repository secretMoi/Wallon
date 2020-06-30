using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Wallon.Controllers;
using Wallon.Core;

namespace Wallon.Pages.Controllers
{
	public class ControllerConnection
	{
		private static readonly LocalOptions LocalOptions = LocalOptions.Instance;

		private const string ChampNom = "Nom";
		private const string ChampPassword = "Password";

		public ControllerConnection()
		{

		}

		/// <summary>
		/// Vérifie que les identifiants contenu sur le disque dur local sont valides avec la base de données
		/// </summary>
		/// <param name="controllerLocataires">Accès au contrôleur de gestion de la table Locataires de la bdd</param>
		/// <returns>true si les identifiants sont trouvés et valides, false sinon</returns>
		public bool AuthInCacheValid(ControllerLocataires controllerLocataires)
		{
			(string, byte[]) result = Get();

			if (result.Item1 != null && result.Item2 != null)
				if (controllerLocataires.Authentifie(result.Item1,  Cryptage.Uncrypt(result.Item2)))
					return true;

			return false;
		}

		/// <summary>
		/// Enregistre les identifiants dans le fichier de sauvegarde local du pc
		/// </summary>
		/// <param name="nom">Le nom d'utilisateur</param>
		/// <param name="password">Le mot de passe</param>
		public void Save(string nom, string password)
		{
			LocalOptions.SetOption(ChampNom, nom);
			LocalOptions.SetOption(ChampPassword,  Cryptage.Crypt(password));

			LocalOptions.Enregistre();
		}

		/// <summary>
		/// Récupère les identifiants dans le fichier local du pc
		/// </summary>
		/// <returns>Item1 le nom d'utilisateur, item2 le mot de passe</returns>
		public (string, byte[]) Get()
		{
			(string, byte[]) result;

			result.Item1 = LocalOptions.GetOption(ChampNom) as string;

			string password = LocalOptions.GetOption(ChampPassword) as string;
			if (password == null)
			{
				result.Item2 = null;
				return result;
			}
			result.Item2 = Convert.FromBase64String(password);

			return result;
		}

		public void Auth(ControllerLocataires controllerLocataires)
		{
			Settings.Auth = true; // initialise la session
			Settings.IdLocataire = controllerLocataires.IdValid; // sauvegarde l'id de la session courante
		}
	}
}
