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

		public string Run()
		{
			try
			{
				string test = Installer.Path + ExePath;
				Process process = new Process
				{
					StartInfo = {
						//FileName = Installer.Path + ExePath,
						//FileName = @"D:\Programmes\Plex\Plex.exe"
						FileName = @"C:\Users\Quentin\source\repos\secretMoi\Wallon\Wallon\bin\Debug\Wallon.exe"
						//FileName = @"C:\Users\Quentin\source\repos\MySyno\MySyno\bin\Debug\MySyno.exe"
					}
				};

				// Configure the process using the StartInfo properties.
				process.StartInfo.WorkingDirectory =
					@"C:\Users\Quentin\source\repos\secretMoi\Wallon\Wallon\bin\Debug\";
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
	}
}
