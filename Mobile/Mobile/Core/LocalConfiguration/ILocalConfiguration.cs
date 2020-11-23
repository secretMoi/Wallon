using System.Threading.Tasks;
using Mobile.Models;

namespace Mobile.Core.LocalConfiguration
{
	public interface ILocalConfiguration
	{
		ConfigurationModel Configuration { get; set; }

		/**
		 * <summary>Sauvegarde la configuration dans le fichier</summary>
		 * <returns>true si tout s'est bien passé, false sinon</returns>
		 */
		Task<bool> SaveAsync();

		/**
		 * <summary>Charge la configuration depuis le fichier</summary>
		 * <returns>true si tout s'est bien passé, false sinon</returns>
		 */
		Task<bool> RestoreAsync();
	}
}