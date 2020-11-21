using System;
using Models.Dtos.Locataires;

namespace Mobile.Models
{
	[Serializable]
	public class ConfigurationModel
	{
		public ConfigurationSessionModel Session { get; set; }
	}
}
