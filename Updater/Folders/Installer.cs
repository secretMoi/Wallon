using System;
using System.IO;

namespace Updater.Folders
{
	public class Installer
	{
		public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "WallonsTest/";
		public static string LastInstallFile = "lastInstall.txt";

		public static bool AlreadyUpdated(string serverVersion)
		{
			if (!Directory.Exists(Path)) return true;

			if (File.Exists(Path + LastInstallFile))
				if (serverVersion == InstalledVersion())
					return true;

			return false;
		}

		public static string InstalledVersion()
		{
			return File.ReadAllText(LastInstallFile);
		}

		public static void ApplyInstallation(string file)
		{
			using (StreamWriter sw = File.CreateText(LastInstallFile))
			{
				sw.WriteLine("Version === " + ReplaceExtension(file, ""));
			}
		}

		private static string ReplaceExtension(string filename, string newExtension)
		{
			string oldExtension = System.IO.Path.GetExtension(filename);
			return filename.Replace(oldExtension, newExtension);
		}
	}
}
