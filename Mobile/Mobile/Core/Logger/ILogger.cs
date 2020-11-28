using System.Runtime.CompilerServices;

namespace Mobile.Core.Logger
{
	public interface ILogger
	{
		void LogError(
			string message,
			[CallerLineNumber] int lineNumber = 0,
			[CallerMemberName] string caller = null,
			[CallerFilePath] string fileName = null);

		void LogInfo(string message);
	}
}