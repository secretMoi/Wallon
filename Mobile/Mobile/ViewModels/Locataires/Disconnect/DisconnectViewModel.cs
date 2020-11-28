using System;
using System.Threading.Tasks;
using Mobile.Core;
using Mobile.Core.LocalConfiguration;
using Mobile.Core.Logger;
using Mobile.Models;

namespace Mobile.ViewModels.Locataires.Disconnect
{
	public class DisconnectViewModel : BaseViewModel
	{
		/**
		 * <summary>Permet de fermer la session courante</summary>
		 * <returns>true si tout s'est bien passé, false sinon</returns>
		 */
		public async Task<bool> Disconnect()
		{
			try
			{
				Session.Instance.Disconnect(); // déconnecte la session

				// supprime la session courante sauvegardée
				ILocalConfiguration configuration = new LocalConfiguration(App.ConfigurationPath);
				await configuration.RestoreAsync(); // restaure les paramètres
				configuration.Configuration.Session = new ConfigurationSessionModel(); // reinit la session des paramètres
				await configuration.SaveAsync(); // sauvegarde les paramètres sans la session

				return !Session.Instance.IsSet;
			}
			catch (Exception e)
			{
				App.Container.GetService<ILogger>().LogError(e.Message);
				//Logger.LogError(e.Message);

				return false;
			}
		}
	}
}
