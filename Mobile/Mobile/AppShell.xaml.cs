using Mobile.Views;
using System;
using Mobile.Views.Locataires;
using Mobile.Views.Taches;
using Xamarin.Forms;

namespace Mobile
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

			//Routing.RegisterRoute("disconnect", typeof(LogInPage));

			Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
			Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
			Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
			Routing.RegisterRoute(nameof(AddTachePage), typeof(AddTachePage));
			Routing.RegisterRoute(nameof(MesTachesPage), typeof(MesTachesPage));
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync($"{nameof(LogInPage)}");
		}
	}
}
