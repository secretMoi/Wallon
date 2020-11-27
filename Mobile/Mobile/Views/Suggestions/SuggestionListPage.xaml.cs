using System.Threading.Tasks;
using Mobile.Controllers;
using Mobile.Controllers.Suggestion;
using Mobile.ViewModels.Suggestions.List;
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

		private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			//todo finir
			//throw new System.NotImplementedException();
		}
	}
}