namespace Updater.Logs
{
	public interface ILog
	{
		public string Path { get; set; }
		public string File { get; set; }
		public void Write(string logText);
	}
}
