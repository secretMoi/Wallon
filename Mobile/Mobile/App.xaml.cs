using DependencyInjection;
using Mobile.Core;
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

		private readonly DiServiceCollection _services = new DiServiceCollection();

		public static DiContainer Container { get; set; }
		
		private static App Instance { get; set; }

		public App()
		{
			InitializeComponent();

			ApiHelper.InitializeClient();

			Instance = this;

			//new Shell();
			DependencyService.Register<MockDataStore>();
			
			_services.RegisterSingleton<INavigation, Navigation>();
			Container = _services.GenerateContainer();
			
			MainPage = new LogInPage();
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
