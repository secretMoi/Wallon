using Mobile.Core;

namespace Mobile.ViewModels
{
	public class ShellViewModel : BaseViewModel
	{
		public bool IsLogged => Session.Instance.IsSet;
		public bool IsGuest => !IsLogged;
	}
}
