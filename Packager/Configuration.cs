using System.IO;
using Newtonsoft.Json;

namespace Packager
{
	public class Configuration
	{
		public static T LoadConfig<T>(string configFile)
		{
			string jsonConfig = File.ReadAllText(configFile); // lit le fichier de configuration
			return JsonConvert.DeserializeObject<T>(jsonConfig); // charge le contenu dans nos modèles
		}
	}
}
