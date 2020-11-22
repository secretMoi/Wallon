using Mobile.Views;
using System;
using Mobile.ViewModels;
using Mobile.Views.Locataires;
using Mobile.Views.Taches;
using Xamarin.Forms;

namespace Mobile
{
	public partial class AppShell : Shell
	{
		public static AppShell Instance { get; private set; }
		private readonly ShellViewModel _viewModel = new ShellViewModel();

		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

			Routing.RegisterRoute(nameof(DisconnectPage), typeof(DisconnectPage));

			Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
			Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
			Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
			Routing.RegisterRoute(nameof(AddTachePage), typeof(AddTachePage));
			Routing.RegisterRoute(nameof(MesTachesPage), typeof(MesTachesPage));

			Instance = this;
			BindingContext = _viewModel;
		}

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
