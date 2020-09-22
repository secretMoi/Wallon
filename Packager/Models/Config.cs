namespace Packager.Models
{
	public class Config
	{
		public string Server { get; set; }
		public string ProjectPath { get; set; }
		public string TempPath { get; set; }

		public Archive Archive { get; set; }
		public Hash Hash { get; set; }
	}
}
