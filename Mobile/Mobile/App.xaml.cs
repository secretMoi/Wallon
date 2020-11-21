using Mobile.Services;
using RestApiClient;
using Xamarin.Forms;

namespace Mobile
{
	public partial class App : Application
	{
		public static string ConfigurationPath => "config.ini";

		public App()
		{
			InitializeComponent();

			ApiHelper.InitializeClient();

			DependencyService.Register<MockDataStore>();
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
