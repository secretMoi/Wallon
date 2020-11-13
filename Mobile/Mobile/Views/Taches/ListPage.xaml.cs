using Mobile.ViewModels.Taches.List;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Taches
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
	{
		private readonly ListViewModel _viewModel = new ListViewModel();

		public ListPage()
		{
			InitializeComponent();

			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			_viewModel.IsBusy = true;
			await _viewModel.Hydrate();
			_viewModel.IsBusy = false;
		}

		private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			
		}
	}
}