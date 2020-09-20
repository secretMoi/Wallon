using Packager.Transfers;

namespace Packager
{
	public class Run
	{
		private const string ProjectPath = "../../../../Wallon/bin/Debug";
		private const string TempPath = "../../../../Wallon/bin/Temp/Source";

		private const string ArchiveName = "test.zip";
		private const string ArchivePath = "../../../../Wallon/bin/Temp/" + ArchiveName;

		public Run()
		{
			Selecter selecter = new Selecter();
			selecter.RemoveExtensions("pdb", "zip");
			selecter.CopyFiles(ProjectPath, TempPath);

			string zipPath = Compress.Zip(TempPath, ArchivePath);

			IAuth upload = new Ftp()
			{
				User = "",
				Password = "",
				Source = zipPath,
				Destination = "ftp://192.168.1.124/" + ArchiveName
			};

			upload.Upload();

			//todo hash
		}
	}
}
