using System.Collections.Generic;
using System.Threading.Tasks;
using Updater.Downloads;

namespace Updater
{
	public class Transferer
	{
		private static readonly List<Task> TasksList = new List<Task>();
		public IDownload Protocol;

		public Transferer(IDownload protocol)
		{
			Protocol = protocol;
		}

		public async Task<bool> Exists()
		{ 
			return await Protocol.Exists();
		}

		public void Download()
		{
			TasksList.Add(Protocol.Download());
		}

		public string Source
		{
			get => Protocol.Source;
			set => Protocol.Source = value;
		}

		public string Destination
		{
			get => Protocol.Destination;
			set => Protocol.Destination = value;
		}

		public void WaitTasksForEnding()
		{
			Task.WaitAll(TasksList.ToArray());
		}
	}
}
