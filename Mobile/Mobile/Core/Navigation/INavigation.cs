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
		
		/**
		 * <summary>Navigue vers une page avec paramètres</summary>
		 * <param name="parameterName">Nom du paramètre</param>
		 * <param name="data">Données à transmettre à la nouvelle page</param>
		 */
		Task PushAsync<T>(string parameterName, object data) where T : Page;
	}
}