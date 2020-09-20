namespace Packager.Transfers
{
	public interface IUpload
	{
		public string Source { get; set; }
		public string Destination { get; set; }
		string Upload();
	}
}
