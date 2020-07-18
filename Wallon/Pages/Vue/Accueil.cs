using System.Collections.Generic;
using System.Text;
using RestApiClient.Controllers;
using RestApiClient.Dtos.Locataires;
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

			//IEnumerable<LocataireReadDto> locataires = await LocatairesController.GetAllLocataires();
			/*LocataireCreateDto locataire = new LocataireCreateDto()
			{
				Nom = "test",
				Password = Encoding.ASCII.GetBytes("test")
			};

			await LocatairesController.PostLocataire(locataire);*/

			LocataireReadDto locataire = await LocatairesController.GetLocataireById(4);
		}
	}
}
