using System;
using System.Runtime.CompilerServices;

namespace Mobile.Core.Logger
{
	public class Logger : ILogger
	{
		/**
		 * <summary>Permet de logger une erreur</summary>
		 * <param name="message">Message de l'erreur</param>
		 * <param name="lineNumber">Ligne où est survenue l'erreur</param>
		 * <param name="caller">Méthode appelante</param>
		 * <param name="fileName">Nom du fichier dans lequel est survenue l'erreur</param>
		 */
		public static void LogError(
			string message,
			[CallerLineNumber] int lineNumber = 0,
			[CallerMemberName] string caller = null,
			[CallerFilePath] string fileName = null)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine(
				$@"[{DateTime.Now.ToShortTimeString()}] Erreur ({message}) dans le fichier {fileName} à la ligne {lineNumber} par {caller}"
			);

			Console.ForegroundColor = oldColor;
		}

		/**
		 * <summary>Permet de logger une info</summary>
		 * <param name="message">Message de l'information</param>
		 */
		public static void LogInfo(string message)
		{
			Console.WriteLine(
				$@"[{DateTime.Now.ToShortTimeString()}] Info : {message}"
			);
		}
	}
}
