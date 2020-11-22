using Mobile.ViewModels.Locataires.Disconnect;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Locataires
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisconnectPage : ContentPage
	{
		private readonly DisconnectViewModel _viewModel = new DisconnectViewModel();

		public DisconnectPage()
		{
			InitializeComponent();

			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			bool result = await _viewModel.Disconnect();

			if (result)
				await DisplayAlert("Succès", "Vous avez bien été déconnecté", "Au revoir");
			else
				await DisplayAlert("Erreur", "Une erreur est survenue lors de la déconnexion", "D'accord");

			base.OnAppearing();
		}
	}
}