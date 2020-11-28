using System.Threading.Tasks;
using Mobile.Views.Locataires;
using Xamarin.Forms;

namespace Mobile.Core.Navigation
{
	public class Navigation : INavigation
	{
		private readonly string _viewNamespace;
		
		public Navigation(string viewNamespace)
		{
			_viewNamespace = viewNamespace;
		}
		
		public Task AsRootPage(Page page)
		{
			return Shell.Current.GoToAsync("//" + page);
		}

		public void ChangeFlow(Page page)
		{
			Application.Current.MainPage = page;
		}
		
		public void GoToMainFlow()
		{
			ChangeFlow(new AppShell("Mobile.Views."));
		}
		
		public void GoToLogInFlow()
		{
			ChangeFlow(new LogInPage());
		}

		public Task PushAsync<T>() where T : Page
		{
			return Shell.Current.GoToAsync(typeof(T).Name);
		}
	}
}