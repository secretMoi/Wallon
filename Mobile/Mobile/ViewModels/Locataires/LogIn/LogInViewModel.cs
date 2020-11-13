using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mobile.Core;
using Mobile.Views;
using Models.Dtos.Locataires;
using Models.Models;
using RestApiClient.Controllers;
using Xamarin.Forms;

namespace Mobile.ViewModels.Locataires.LogIn
{
	public class LogInViewModel : BaseViewModel
	{
		private LogInData _logInData = new LogInData();
		private readonly LocatairesController _client = new LocatairesController();

		private const string ImageShowPassword = "eye.png";
		private const string ImageHidePassword = "eyeClose.png";

		public LogInData LogInData // élément sélectionné dans la dgv
		{
			get => _logInData;
			set => SetProperty(ref _logInData, value);
		}

		public LogInViewModel()
		{
			LogInData.ShowPassword = true;
			LogInData.PasswordImageEye = ImageHidePassword;
		}

		/**
		 * <summary>Set ou déset l'affichage du mot de passe</summary>
		 */
		public void TogglePassword()
		{
			LogInData.ShowPassword = !LogInData.ShowPassword;

			if (LogInData.ShowPassword)
				LogInData.PasswordImageEye = ImageHidePassword;
			else
				LogInData.PasswordImageEye = ImageShowPassword;
		}

		/**
		 * <summary>Permet à un client de se connecter</summary>
		 * <returns>Une string si une erreur est survenue, null si tout s'est bien passé</returns>
		 */
		public async Task<string> LogIn()
		{
			// vérifie qu'on a accès à internet avant de continuer
			if (!AndroidPermissions.HasInternet()) return "Pas d'accès à internet";

			// vérifie les champs
			if (LogInData.Nom == null || LogInData.Password == null)
				return "Veuillez saisir vos informations !";

			LocataireReadDto result;

			try
			{
				//todo finir
				//result = await _client.ByMail(LogInData.Nom);
				result = await Existe(LogInData.Nom);
			}
			catch (Exception e)
			{
				return e.Message;
			}

			if (result == null) // si son adresse mail n'existe pas
				return "Adresse mail invalide";

			byte[] password = Cryptage.Crypt(LogInData.Password);

			// si le mot de passe rentré n'est pas le bon
			if (!result.Password.SequenceEqual(password))
				return "Mot de passe incorrect";

			Session.Instance.Connect = Mapping.Map(result, new Locataire()); // connecte l'utilisateur

			// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
			await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

			return null;
		}

		/// <summary>
		/// Vérifie que le nom du locataire passé en paramètres existe dans la bdd
		/// </summary>
		/// <param name="nom">Le nom du locataire</param>
		/// <returns>Renvoie un objet locataire si trouvé, null sinon</returns>
		public async Task<LocataireReadDto> Existe(string nom)
		{
			IList<LocataireReadDto> locataires = await _client.GetAll<LocataireReadDto>();

			foreach (LocataireReadDto locataire in locataires)
				if (locataire.Nom == nom)
					return locataire;

			return null;
		}
	}
}
