using Mobile.ViewModels.Taches.List;
using Models.Dtos.Taches;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

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

		private async void ListView_OnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs itemTappedEventArgs)
		{
			await _viewModel.OnItemSelected(itemTappedEventArgs.Item as TacheReadDto);
		}
	}
}