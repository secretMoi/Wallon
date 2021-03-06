﻿using System;
using System.Threading.Tasks;
using Mobile.Core.Routes;
using Mobile.Views.Locataires;
using Xamarin.Forms;

namespace Mobile.Core.Navigation
{
	public class Navigation : INavigation
	{
		private readonly IRoute _route;
		
		public Navigation(IRoute route)
		{
			_route = route ?? throw new ArgumentNullException(nameof(route));
		}
		
		public Task AsRootPage(Page page)
		{
			if (page == null) throw new ArgumentNullException(nameof(page));
			
			return Shell.Current.GoToAsync("//" + page);
		}

		public void ChangeFlow(Page page)
		{
			Application.Current.MainPage = page ?? throw new ArgumentNullException(nameof(page));
		}
		
		public void GoToMainFlow()
		{
			ChangeFlow(new AppShell());
		}
		
		public void GoToLogInFlow()
		{
			ChangeFlow(new LogInPage());
		}

		public Task PushAsync<T>() where T : Page
		{
			return Shell.Current.GoToAsync(_route.RouteName(typeof(T).ToString()));
		}
		
		/**
		 * <summary>Navigue vers une page avec paramètres</summary>
		 * <param name="parameterName">Nom du paramètre</param>
		 * <param name="data">Données à transmettre à la nouvelle page</param>
		 */
		public Task PushAsync<T>(string parameterName, object data) where T : Page
		{
			if (parameterName == null) throw new ArgumentNullException(nameof(parameterName));
			if (data == null) throw new ArgumentNullException(nameof(data));

			return Shell.Current.GoToAsync(
				_route.RouteName(typeof(T).ToString()) +
				"?" +
				parameterName +
				"=" +
				data
			);
		}
	}
}