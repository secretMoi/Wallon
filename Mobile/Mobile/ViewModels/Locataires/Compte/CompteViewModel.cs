using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mobile.Controllers.Locataire;
using Mobile.Core;
using Mobile.Core.Logger;
using Models.Dtos.Locataires;

namespace Mobile.ViewModels.Locataires.Compte
{
	public class CompteViewModel : BaseViewModel
	{
		private CompteData _compteData = new CompteData();
		private readonly ILocataireController _locataireController;
		
		private const string ImageShowPassword = "eye.png";
		private const string ImageHidePassword = "eyeClose.png";

		public CompteData CompteData
		{
			get => _compteData;
			set => SetProperty(ref _compteData, value);
		}

		public CompteViewModel(ILocataireController locataireController)
		{
			Title = "Modification de votre compte";
			CompteData.ShowPassword = true;
			CompteData.PasswordImageEye = ImageHidePassword;
			
			_locataireController = locataireController ?? throw new ArgumentNullException(nameof(locataireController));
		}

		public async Task HydrateAsync(int idLocataire)
		{
			var locataire = await _locataireController.GetByIdAsync(idLocataire);
			
			CompteData.Nom = locataire.Nom;
			CompteData.Password = Cryptage.Uncrypt(locataire.Password);
		}

		/**
		 * <summary>Set ou déset l'affichage du mot de passe</summary>
		 */
		public void TogglePassword()
		{
			CompteData.ShowPassword = !CompteData.ShowPassword;

			CompteData.PasswordImageEye = CompteData.ShowPassword ? ImageHidePassword : ImageShowPassword;
		}

		public async Task<bool> UpdateProfile()
		{
			if (CompteData.Nom == null || CompteData.Password == null ||
			    CompteData.Nom.Length == 0 || CompteData.Password.Length == 0 ||
			    !IsValidPassword())
				return false;
			
			try
			{
				var locataire = await _locataireController.GetByIdAsync(Session.Instance.Get.Id);
				locataire.Nom = CompteData.Nom;
				locataire.Password = Cryptage.Crypt(CompteData.Password);
					
				await _locataireController.UpdateAsync(
					Mapping.Map(locataire, new LocataireUpdateDto())
				);
			}
			catch (Exception e)
			{
				App.Container.GetService<ILogger>().LogError(e.Message);
				return false;
			}

			return true;

			bool IsValidPassword()
			{
				//todo regex
				try
				{
					return Regex.IsMatch(CompteData.Password,
						@"^.{4,50}",
						RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(50));
				}
				catch (RegexMatchTimeoutException)
				{
					return false;
				}
			}
		}
	}
}