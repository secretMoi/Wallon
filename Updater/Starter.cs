using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Updater.Folders;

namespace Updater
{
	public class Starter
	{
		public string ExePath { get; set; }
		public string ExeFile { get; set; }

		public string Run()
		{
			try
			{
				Process process = new Process
				{
					StartInfo = {
						FileName = ExePath + ExeFile
					}
				};

				// Configure the process using the StartInfo properties.
				process.StartInfo.WorkingDirectory = ExePath;
				process.StartInfo.UseShellExecute = false;
				process.Start();
				
				process.WaitForExit();// Waits here for the process to exit.
				return process.ExitCode.ToString();
				return null;
			}
			catch
			{
				return "Unable to start at " + Installer.Path + ExePath;
			}
		}

		public string Run(string exePath, string exeFile)
		{
			ExePath = exePath;
			ExeFile = exeFile;

			return Run();
		}
	}
}
