using System;
using System.Runtime.CompilerServices;

namespace Mobile.Core
{
	public class Catcher
	{
		public static void LogError(
			string message,
			[CallerLineNumber] int lineNumber = 0,
			[CallerMemberName] string caller = null,
			[CallerFilePath] string fileName = null)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine($@"
					[{DateTime.Now.ToShortTimeString()}] 
					Erreur ({message}) dans le fichier {fileName} à la ligne {lineNumber} par {caller}");

			Console.ForegroundColor = oldColor;
		}

		public static void LogInfo(string message)
		{
			Console.WriteLine($@"
					[{DateTime.Now.ToShortTimeString()}] 
					Info : {message}");
		}
	}
}
