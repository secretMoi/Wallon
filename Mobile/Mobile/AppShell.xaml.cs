using Mobile.Core.Routes;
using Mobile.ViewModels;
using Mobile.Views.Locataires;
using Mobile.Views.Suggestions;
using Mobile.Views.Taches;
using Xamarin.Forms;

namespace Mobile
{
	public partial class AppShell : Shell
	{
		private readonly ShellViewModel _viewModel = new ShellViewModel();

		public AppShell()
		{
			InitializeComponent();
			
			BindingContext = _viewModel;

			// taches
			App.Container.GetService<IRoute>().RegisterRoute<AddTachePage>();
			App.Container.GetService<IRoute>().RegisterRoute<ListPage>();
			App.Container.GetService<IRoute>().RegisterRoute<MesTachesPage>();
			App.Container.GetService<IRoute>().RegisterRoute<DetailPage>();
			
			// locataires
			App.Container.GetService<IRoute>().RegisterRoute<LogInPage>();
			App.Container.GetService<IRoute>().RegisterRoute<DisconnectPage>();
			App.Container.GetService<IRoute>().RegisterRoute<LocatairesListPage>();
			App.Container.GetService<IRoute>().RegisterRoute<ComptePage>();
			
			// suggestions
			App.Container.GetService<IRoute>().RegisterRoute<SuggestionAddPage>();
			App.Container.GetService<IRoute>().RegisterRoute<SuggestionListPage>();
			App.Container.GetService<IRoute>().RegisterRoute<SuggestionDetailPage>();
		}
	}
}
