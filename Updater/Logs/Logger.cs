using System;
using System.IO;

namespace Updater.Logs
{
	public class Logger : ILog
	{
		public string Path { get; set; }
		public string File { get; set; }
		public void Write(string logText)
		{
			using (StreamWriter sw = System.IO.File.AppendText($"{Path}/{File}"))
			{
				sw.Write(DateTime.UtcNow); // heure et datte en utc
				sw.Write(" === ");
				sw.WriteLine(logText);
			}
		}
	}
}
