using Mobile.Core;
using Mobile.Core.Navigation;
using Mobile.Services;
using Mobile.Views.Locataires;
using RestApiClient;
using RestApiClient.Controllers;
using Xamarin.Forms;

namespace Mobile
{
	public partial class App : Application
	{
		public static string ConfigurationPath => "config.ini";

		public static Page HomePage
		{
			get => Instance.MainPage;
			set => Instance.MainPage = value;
		}
		
		public static Shell Shell
		{
			get;
			set;
		}
		
		private static App Instance { get; set; }

		public App()
		{
			InitializeComponent();

			ApiHelper.InitializeClient();

			Instance = this;

			new Shell();
			DependencyService.Register<MockDataStore>();
			DependencyService.RegisterSingleton(new Navigation());
			
			MainPage = new LogInPage();
			HomePage = MainPage;
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
