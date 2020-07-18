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

			// lire tout
			//IEnumerable<LocataireReadDto> locataires = await LocatairesController.GetAllLocataires();

			// post
			/*LocataireCreateDto locataire = new LocataireCreateDto()
			{
				Nom = "test",
				Password = Encoding.ASCII.GetBytes("test")
			};

			await LocatairesController.PostLocataire(locataire);*/

			// lire 1
			//LocataireReadDto locataire = await LocatairesController.GetLocataireById(4);

			// update
			LocataireCreateDto locataire = new LocataireCreateDto()
			{
				Nom = "test4",
				Password = Encoding.ASCII.GetBytes("test5")
			};

			await LocatairesController.UpdateLocataire(4, locataire);
		}
	}
}
