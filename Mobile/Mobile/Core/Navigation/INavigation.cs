using System.Threading.Tasks;
using Mobile.ViewModels;
using Xamarin.Forms;

namespace Mobile.Core.Navigation
{
	public interface INavigation
	{
		Task AsRootPage(Page page);
		void ChangeFlow(Page page);
		void GoToMainFlow();
		void GoToLogInFlow();
		Task PushAsync<T>() where T : Page;
	}
}