using System;
using Xamarin.Forms;

namespace Mobile.Core.Routes
{
	public class Route : IRoute
	{
		private readonly string _viewNamespace;
		
		public Route(string viewNamespace)
		{
			_viewNamespace = viewNamespace;
		}
		
		public void RegisterRoute<T>() where T : Page
		{
			Type type = typeof(T); // récupère le type
			string route = RouteName(type.ToString());
			
			Routing.RegisterRoute(route, type);
		}

		public string RouteName(string completeNamespace)
		{
			string route = completeNamespace.Remove(0, _viewNamespace.Length); // ne garde que les dossiers dans view
			return route.Replace('.', '/'); // remplace les . du namespace par des / pour créer la route
		}
	}
}