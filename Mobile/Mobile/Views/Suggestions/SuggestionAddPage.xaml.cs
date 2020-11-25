using System;
using Mobile.Controllers;
using Mobile.ViewModels.Suggestions.SuggestionAdd;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Suggestions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuggestionAddPage : ContentPage
	{
		private readonly SuggestionAddViewModel _viewModel;

		public SuggestionAddPage()
		{
			InitializeComponent();

			_viewModel = new SuggestionAddViewModel(FactoryController.CreateSuggestion());
			BindingContext = _viewModel;
		}

		private async void Button_OnClicked(object sender, EventArgs e)
		{
			string result = await _viewModel.SendSuggestion();

			await DisplayAlert("Information", result, "OK");
		}
	}
}