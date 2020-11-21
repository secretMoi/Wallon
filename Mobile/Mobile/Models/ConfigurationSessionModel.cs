using System;

namespace Mobile.Models
{
	[Serializable]
	public class ConfigurationSessionModel
	{
		public int Id { get; set; }

		public string Nom { get; set; }

		public byte[] Password { get; set; }
	}
}
