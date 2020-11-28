using Mobile.Views;
using System;
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

		private readonly string _viewNamespace;

		public AppShell(string viewNamespace)
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

			Routing.RegisterRoute(nameof(DisconnectPage), typeof(DisconnectPage));

			Routing.RegisterRoute("locataires/login", typeof(LogInPage));
			Routing.RegisterRoute("taches/list", typeof(ListPage));
			Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
			//Routing.RegisterRoute(nameof(AddTachePage), typeof(AddTachePage));
			Routing.RegisterRoute(nameof(MesTachesPage), typeof(MesTachesPage));
			Routing.RegisterRoute(nameof(LocatairesListPage), typeof(LocatairesListPage));
			Routing.RegisterRoute(nameof(SuggestionAddPage), typeof(SuggestionAddPage));
			Routing.RegisterRoute(nameof(SuggestionListPage), typeof(SuggestionListPage));
			BindingContext = _viewModel;

			_viewNamespace = viewNamespace;
			//RegisterRoute<AddTachePage>();
			App.Container.GetService<IRoute>().RegisterRoute<AddTachePage>();
		}

		/*private void RegisterRoute<T>() where T : Page
		{
			Type type = typeof(T); // récupère le type
			string route = SetRouteName(type.ToString());
			
			Routing.RegisterRoute(route, type);
		}

		private string SetRouteName(string completeNamespace)
		{
			string route = completeNamespace.Remove(0, _viewNamespace.Length); // ne garde que les dossiers dans view
			return route.Replace('.', '/'); // remplace les . du namespace par des / pour créer la route
		}*/
		
		public bool ConnectionState
		{
			set
			{
				_viewModel.IsLogged = value;
				_viewModel.IsGuest = !value;
			}
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync($"{nameof(LogInPage)}");
		}
	}
}
