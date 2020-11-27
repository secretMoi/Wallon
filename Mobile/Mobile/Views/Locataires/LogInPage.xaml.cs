using System;
using Mobile.Controllers;
using Mobile.ViewModels.Locataires.LogIn;
using Mobile.Views.Taches;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Locataires
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInPage : ContentPage
	{
		private readonly LogInViewModel _viewModel = new LogInViewModel(App.ConfigurationPath, FactoryController.CreateLocataire());

		public LogInPage()
		{
			InitializeComponent();

			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			IsBusy = true;
			if (await _viewModel.LoadSessionAsync())
			{
				await DisplayAlert("Succès", "Connexion réussie", "OK");
				Application.Current.MainPage = new AppShell();
			}

			IsBusy = false;

			base.OnAppearing();
		}

		private async void btnLogIn_OnClicked(object sender, EventArgs e)
		{
			_viewModel.LogInData.IsBusy = true;
			string res = await _viewModel.LogIn();
			_viewModel.LogInData.IsBusy = false;

			if (res != null)
				await DisplayAlert("Erreur", res, "OK");
			else
			{
				await DisplayAlert("Succès", "Connexion réussie", "OK");
				Application.Current.MainPage = new AppShell();

				// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
				//await Shell.Current.GoToAsync($"{nameof(ListPage)}");
			}
		}

		private void ShowPassword(object sender, EventArgs e)
		{
			_viewModel.TogglePassword();
		}
	}
}