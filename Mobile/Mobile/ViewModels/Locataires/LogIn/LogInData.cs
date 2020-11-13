namespace Mobile.ViewModels.Locataires.LogIn
{
	public class LogInData : BaseViewModel
	{
		private string _mail, _password;

		private bool _showPassword;
		private string _passwordImageEye;

		public string Mail
		{
			get => _mail;
			set => SetProperty(ref _mail, value);
		}

		public string Password
		{
			get => _password;
			set => SetProperty(ref _password, value);
		}

		public bool ShowPassword
		{
			get => _showPassword;
			set => SetProperty(ref _showPassword, value);
		}

		public string PasswordImageEye
		{
			get => _passwordImageEye;
			set => SetProperty(ref _passwordImageEye, value);
		}
	}
}
