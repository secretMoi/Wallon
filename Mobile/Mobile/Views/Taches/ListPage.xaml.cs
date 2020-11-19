using System;
using System.Threading.Tasks;
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

			await LoadTaches();
		}

		private async Task LoadTaches()
		{
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
			var tache = ((sender as View)?.BindingContext as TacheReadDto);

			var result = await DisplayAlert(
				"Attention",
				$@"Voulez-vous vraimment supprimer la tâche {tache.Nom} ?",
				"Oui",
				"Non"
			);

			if (!result) return;

			result = await _viewModel.DeleteTache(tache.Id);
			string message;

			if (result)
				message = $"La tâche {tache.Nom} a bien été supprimée";
			else
				message = $"La tâche {tache.Nom} n'a pas pu être supprimée";

			await DisplayAlert(
				"Information",
				message,
				"D'accord"
			);

			await LoadTaches();
		}
	}
}