using DependencyInjection;
using DependencyInjection.Interfaces;
using Mobile.Core;
using Mobile.Core.Logger;
using Mobile.Core.Navigation;
using Mobile.Services;
using Mobile.Views.Locataires;
using RestApiClient;
using RestApiClient.Controllers;
using Xamarin.Forms;
using INavigation = Mobile.Core.Navigation.INavigation;

namespace Mobile
{
	public partial class App : Application
	{
		public static string ConfigurationPath => "config.ini";

		private readonly IDiServiceCollection _services = new DiServiceCollection();

		public static IDiContainer Container { get; set; }
		
		private static App Instance { get; set; }

		public App()
		{
			InitializeComponent();

			ApiHelper.InitializeClient();

			Instance = this;

			ConfigureServices(_services);
			Container = _services.GenerateContainer();
			
			MainPage = new LogInPage();
		}

		private void ConfigureServices(IDiServiceCollection serviceCollection)
		{
			DependencyService.Register<MockDataStore>();
			
			serviceCollection.RegisterSingleton<INavigation, Navigation>();
			serviceCollection.RegisterSingleton<ILogger, Logger>();
		}

		protected override async void OnStart()
		{
			if (AndroidPermissions.HasInternet())
				await new BaseController().InitConnection();
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
