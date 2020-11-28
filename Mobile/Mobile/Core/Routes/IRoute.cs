using Xamarin.Forms;

namespace Mobile.Core.Routes
{
	public interface IRoute
	{
		void RegisterRoute<T>() where T : Page;
		string RouteName(string completeNamespace);
	}
}