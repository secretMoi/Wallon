using System;
using System.Deployment.Application;
using System.Windows.Forms;
using Wallon.Fenetres;

namespace Wallon
{
	public class SelfUpdate
	{
		public static void CheckUpdate()
		{
			UpdateCheckInfo info;

			if (ApplicationDeployment.IsNetworkDeployed)
			{
				ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

				try
				{
					info = ad.CheckForDetailedUpdate();

				}
				catch (DeploymentDownloadException dde)
				{
					Dialog.Show(
						"Impossible de télécharger la nouvelle version, vérifier votre connexion internet ou essayer plus tard. Erreur: " +
						dde.Message
					);
					return;
				}
				catch (InvalidDeploymentException ide)
				{
					Dialog.Show(
						"La mise à jour semble corrompue. Erreur: " +
						ide.Message
					);
					return;
				}
				catch (InvalidOperationException ioe)
				{
					Dialog.Show("La mise à jour ne peut pas s'effectuer. Erreur: " + ioe.Message);
					return;
				}

				if (info.UpdateAvailable)
				{
					Boolean doUpdate = true;

					if (!info.IsUpdateRequired)
					{
						DialogResult dr = Dialog.ShowYesNo("Mise à jour disponible. Voulez-vous l'installer ?", "Nouvelle mise à jour");

						if (DialogResult.No == dr)
							doUpdate = false;
					}
					else
					{
						// Display a message that the app MUST reboot. Display the minimum required version.
						Dialog.Show("This application has detected a mandatory update from your current " +
							"version to version " + info.MinimumRequiredVersion +
							". The application will now install the update and restart.",
							"Update Available");
					}

					if (doUpdate)
					{
						try
						{
							ad.Update();
							Dialog.Show("L'application a bien été mise à jour et va bientôt redémarrer...");
							Application.Restart();
						}
						catch (DeploymentDownloadException dde)
						{
							Dialog.Show(
								"Impossible d'installer la dernière version. \n\nVérifier votre connexion ou essayer plus tard. Erreur: " +
								dde
							);
							return;
						}
					}
				}
			}
		}
	}
}
