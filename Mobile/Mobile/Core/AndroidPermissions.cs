using Xamarin.Essentials;

namespace Mobile.Core
{
	public class AndroidPermissions
	{
		public static bool HasInternet()
		{
			return Connectivity.NetworkAccess == NetworkAccess.Internet;
		}
	}
}
