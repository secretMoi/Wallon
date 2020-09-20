using System;
using System.Threading.Tasks;
using Updater.Folders;
using Updater.Logs;

namespace Updater
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Run run = new Run();

			string result = await run.Execute();

			ILog logger = new Logger()
			{
				Path = "./",
				File = "logs.txt"
			};
			logger.Write(result);

			Console.WriteLine(result);
		}
	}
}
