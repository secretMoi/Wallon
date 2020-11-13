﻿using System;
using Mobile.ViewModels.Locataires.LogIn;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Locataires
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInPage : ContentPage
	{
		private readonly LogInViewModel _viewModel = new LogInViewModel();

		public LogInPage()
		{
			InitializeComponent();

			BindingContext = _viewModel;
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

				//todo rediriger
			}
		}

		private void ShowPassword(object sender, EventArgs e)
		{
			_viewModel.TogglePassword();
		}
	}
}