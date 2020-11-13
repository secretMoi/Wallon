using Mobile.ViewModels.Taches.Detail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Taches
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		private readonly DetailViewModel _viewModel = new DetailViewModel();

		public DetailPage()
		{
			InitializeComponent();

			BindingContext = _viewModel;
		}
	}
}