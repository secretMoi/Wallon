namespace Mobile.ViewModels
{
	public class ShellViewModel : BaseViewModel
	{
		private bool _isLogged;
		private bool _isGuest;

		public bool IsLogged
		{
			get => _isLogged;
			set => SetProperty(ref _isLogged, value);
		}

		public bool IsGuest
		{
			get => _isGuest;
			set => SetProperty(ref _isGuest, value);
		}
	}
}
