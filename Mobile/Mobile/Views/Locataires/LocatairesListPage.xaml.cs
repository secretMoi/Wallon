using Mobile.Controllers;
using Mobile.ViewModels.Locataires.List;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Locataires
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocatairesListPage : ContentPage
	{
		private readonly LocatairesListViewModel _viewModel;

		public LocatairesListPage()
		{
			InitializeComponent();

			_viewModel = new LocatairesListViewModel(
				FactoryController.CreateLocataire()
			);
			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			await _viewModel.HydrateAsync();

			base.OnAppearing();
		}
	}
}