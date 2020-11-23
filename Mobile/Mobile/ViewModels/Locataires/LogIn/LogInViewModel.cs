using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mobile.Controllers.Locataire;
using Mobile.Core;
using Mobile.Core.LocalConfiguration;
using Mobile.Core.Logger;
using Mobile.Models;
using Models.Dtos.Locataires;

namespace Mobile.ViewModels.Locataires.LogIn
{
	public class LogInViewModel : BaseViewModel
	{
		private LogInData _logInData = new LogInData();
		private readonly ILocataireController _locataire = LocataireController.Instance;
		private readonly ILocalConfiguration _configuration;

		private const string ImageShowPassword = "eye.png";
		private const string ImageHidePassword = "eyeClose.png";

		public LogInData LogInData // élément sélectionné dans la dgv
		{
			get => _logInData;
			set => SetProperty(ref _logInData, value);
		}

		public LogInViewModel(string configurationPath)
		{
			Title = "Se connecter";
			LogInData.ShowPassword = true;
			LogInData.PasswordImageEye = ImageHidePassword;

			_configuration = new LocalConfiguration(configurationPath);
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
				result = await ExisteAsync(LogInData.Nom);
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

			Session.Instance.Connect = Mapping.Map(result, new LocataireReadDto()); // connecte l'utilisateur
			if (!await SaveSessionAsync(Session.Instance.Get))
				return
					"Vous êtes connecté, mais vous devrez vous reconnecter la prochaine fois dû à une erreur de stockage";

			return null;
		}

		/// <summary>
		/// Enregistre les identifiants dans le fichier de sauvegarde local
		/// </summary>
		/// <param name="locataire">Informations sur le locataire courant</param>
		public async Task<bool> SaveSessionAsync(LocataireReadDto locataire)
		{
			try
			{
				_configuration.Configuration.Session = Mapping.Map(locataire, new ConfigurationSessionModel());
				return await _configuration.SaveAsync();
			}
			catch (Exception e)
			{
				Logger.LogError(e.Message);
				return false;
			}
		}

		/**
		 * <summary>Charge une session locale pour éviter de se relogger</summary>
		 */
		public async Task<bool> LoadSessionAsync()
		{
			bool result = await _configuration.RestoreAsync(); // charge la session dans le fichier local
			if (!result || _configuration.Configuration.Session.Nom == null) return false; // si aucune erreur on continue

			// charge les infos du locataire depuis la bdd
			var locataireInDb = await ExisteAsync(_configuration.Configuration.Session.Nom);

			// si la session == au locataire dans la db
			if (_configuration.Configuration.Session.Nom == locataireInDb.Nom &&
			    _configuration.Configuration.Session.Password.SequenceEqual(locataireInDb.Password))
			{
				Session.Instance.Connect = locataireInDb; // connecte l'utilisateur
				
				return true;
			}

			return false;
		}

		/// <summary>
		/// Vérifie que le nom du locataire passé en paramètres existe dans la bdd
		/// </summary>
		/// <param name="nom">Le nom du locataire</param>
		/// <returns>Renvoie un objet locataire si trouvé, null sinon</returns>
		public async Task<LocataireReadDto> ExisteAsync(string nom)
		{
			IList<LocataireReadDto> locataires = await _locataire.GetAllAsync();

			foreach (LocataireReadDto locataire in locataires)
				if (locataire.Nom == nom)
					return locataire;

			return null;
		}
	}
}
