using System;
using System.Threading.Tasks;
using Mobile.Core;
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
				var configuration = new LocalConfiguration(App.ConfigurationPath);
				await configuration.RestoreAsync(); // restaure les paramètres
				configuration.Configuration.Session = new ConfigurationSessionModel(); // reinit la session des paramètres
				await configuration.SaveAsync(); // sauvegarde les paramètres sans la session

				return !Session.Instance.IsSet;
			}
			catch (Exception e)
			{
				Catcher.LogError(e.Message);

				return false;
			}
		}
	}
}
