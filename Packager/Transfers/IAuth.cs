namespace Packager.Transfers
{
	public interface IAuth : IUpload
	{
		public string User { get; set; }
		public string Password { get; set; }
	}
}
