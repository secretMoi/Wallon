using System.Threading.Tasks;
using Mobile.ViewModels;
using Mobile.Views.Locataires;
using Xamarin.Forms;

namespace Mobile.Core.Navigation
{
	public class Navigation : INavigation
	{
		public void ChangeFlow(Page page)
		{
			Application.Current.MainPage = page;
		}
		
		public void GoToMainFlow()
		{
			ChangeFlow(new AppShell());
		}
		
		public void GoToLogInFlow()
		{
			ChangeFlow(new LogInPage());
		}

		public Task PushAsync<T>() where T : BaseViewModel
		{
			return Shell.Current.GoToAsync(nameof(T));
		}
	}
}