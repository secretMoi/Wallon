using Mobile.Controllers;
using Mobile.ViewModels.Suggestions.Detail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Suggestions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuggestionDetailPage : ContentPage
	{
		private readonly SuggestionDetailViewModel _viewModel;
		
		public SuggestionDetailPage()
		{
			InitializeComponent();
			
			_viewModel = new SuggestionDetailViewModel(FactoryController.CreateSuggestion());
			BindingContext = _viewModel;
		}
	}
}