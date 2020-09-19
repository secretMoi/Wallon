using System;
using System.Net;
using Updater.Downloads;

namespace Updater
{
	class Program
	{
		static void Main(string[] args)
		{
			Transferer transferer = new Transferer(new Http())
			{
				Source = "http://192.168.1.124/RELEASES",
				Destination = "COUCOU3"
			};

			transferer.Download();
			transferer.WaitTasksForEnding();


			/*Http ftp = new Http()
			{
				Source = "http://192.168.1.124/RELEASES",
				Destination = "COUCOU3"
			};

			ftp.Download();
			ftp.WaitTasksForEnding();*/
		}
	}
}
