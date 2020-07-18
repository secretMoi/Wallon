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
			//IEnumerable<LocataireReadDto> locataires = await new LocatairesController().GetAll<LocataireReadDto>();

			// post
			/*LocataireCreateDto locataire = new LocataireCreateDto()
			{
				Nom = "test",
				Password = Encoding.ASCII.GetBytes("test")
			};
			await new LocatairesController().Post(locataire);*/
			//await LocatairesController.PostLocataire(locataire);

			// lire 1
			//LocataireReadDto locataire = await LocatairesController.GetLocataireById(4);

			// update
			LocataireCreateDto locataire = new LocataireCreateDto()
			{
				Nom = "45",
				Password = Encoding.ASCII.GetBytes("test5")
			};
			string res = await new LocatairesController().Update(5, locataire);

			/*await LocatairesController.UpdateLocataire(4, locataire);*/
		}
	}
}
