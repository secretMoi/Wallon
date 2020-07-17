using System.Collections.Generic;
using RestApiClient.Controllers;
using RestServer.Dtos.Locataires;
using Wallon.Pages.Controllers;

namespace Wallon.Pages.Vue
{
	public partial class Accueil : ThemePanel
	{
		ControllerAccueil _controller = new ControllerAccueil();

		public Accueil()
		{
			InitializeComponent();

			SetTitre("Accueil");
		}

		private async void Accueil_Load(object sender, System.EventArgs e)
		{
			RestApiClient.ApiHelper.InitializeClient();

			IEnumerable<LocataireReadDto> locataires = await LocatairesController.GetAllLocataires();
		}
	}
}
