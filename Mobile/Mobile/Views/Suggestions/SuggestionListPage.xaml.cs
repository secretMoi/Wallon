using System;
using System.Threading.Tasks;
using Mobile.Controllers;
using Mobile.ViewModels.Suggestions.List;
using Models.Dtos.Suggestions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace Mobile.Views.Suggestions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuggestionListPage : ContentPage
	{
		private readonly SuggestionListViewModel _viewModel;
		
		public SuggestionListPage()
		{
			InitializeComponent();
			
			_viewModel = new SuggestionListViewModel(FactoryController.CreateSuggestion());
			BindingContext = _viewModel;
		}
		
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await LoadSuggestions();
		}
		
		/**
		 * <summary>Charge les tâches de la bdd dans la vue</summary>
		 */
		private async Task LoadSuggestions()
		{
			_viewModel.IsBusy = true;
			await _viewModel.LoadSuggestions();
			_viewModel.IsBusy = false;
		}

		private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			await _viewModel.OnItemSelected(e.ItemData as SuggestionReadDto);
		}

		private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
		{
			var suggestion = (sender as View)?.BindingContext as SuggestionReadDto; // récupère les infos sur la suggestion
			
			// message d'avertissement
			var result = await DisplayAlert(
				"Attention",
				$@"Voulez-vous vraiment supprimer la suggestion {suggestion?.Nom} ?",
				"Oui",
				"Non"
			);

			if (!result || suggestion == null) return; // si on ne veut pas supprimer on quitte ou si la tâches n'est pas correcte
			
			result = await _viewModel.Delete(suggestion.Id); // supprime la tâche
			string message;
			
			// indication sur le succès ou pas de suppression ed la tâche
			if (result)
				message = $"La suggestion {suggestion.Nom} a bien été supprimée";
			else
				message = $"La suggestion {suggestion.Nom} n'a pas pu être supprimée";

			await DisplayAlert(
				"Information",
				message,
				"D'accord"
			);
			
			await LoadSuggestions(); // recharge les tâches
		}
	}
}