using System;
using Mobile.ViewModels.Taches.List;
using Models.Dtos.Taches;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;
using SwipeEndedEventArgs = Syncfusion.ListView.XForms.SwipeEndedEventArgs;

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

		private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs tappedEventArgs)
		{
			await _viewModel.OnItemSelected(tappedEventArgs.ItemData as TacheReadDto);
		}

		private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
		{
			var nom = ((sender as View)?.BindingContext as TacheReadDto)?.Nom;

			await DisplayAlert(
				"Attention",
				$"Voulez-vous vraimment supprimer {nom} ?",
				"Oui",
				"Non"
			);
		}
	}
}