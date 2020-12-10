using System;
using Mobile.Controllers;
using Mobile.Core;
using Mobile.ViewModels.Locataires.Compte;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Locataires
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ComptePage
	{
		private readonly CompteViewModel _viewModel;
		
		public ComptePage()
		{
			InitializeComponent();
			
			_viewModel = new CompteViewModel(FactoryController.CreateLocataire());
			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			IsBusy = true;
			await _viewModel.HydrateAsync(Session.Instance.Get.Id);
			IsBusy = false;
			
			base.OnAppearing();
		}

		private void ShowPassword(object sender, EventArgs e)
		{
			_viewModel.TogglePassword();
		}

		private async void Button_OnClicked(object sender, EventArgs e)
		{
			_viewModel.IsBusy = true;
			bool res = await _viewModel.UpdateProfile();
			_viewModel.IsBusy = false;

			if (!res)
				await DisplayAlert("Erreur", "Une erreur est survenue durant la modification de votre profil", "D'accord");
			else
			{
				await DisplayAlert("Succès", "Votre profil a bien été modifié", "Merci");
			}
		}
	}
}