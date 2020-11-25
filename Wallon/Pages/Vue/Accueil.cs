using System.Text;
using Models.Dtos.Locataires;
using Wallon.Pages.Controllers;
using Wallon.Repository;

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

		private void Accueil_Load(object sender, System.EventArgs e)
		{
			// lire tout
			//IEnumerable<LocataireReadDto> locataires = await new LocatairesApiController().GetAll<LocataireReadDto>();

			// post
			/*LocataireCreateDto locataire = new LocataireCreateDto
			{
				Nom = "Quentin",
				Password = Encoding.ASCII.GetBytes("test")
			};
			await RepositoryLocataires.Instance.Ajouter(locataire);*/

			// lire 1
			//LocataireReadDto locataire = await LocatairesApiController.GetLocataireById(4);

			// update
			/*LocataireUpdateDto locataire = new LocataireUpdateDto()
			{
				Id = 5,
				Nom = "1",
				Password = Encoding.ASCII.GetBytes("test5")
			};
			string res = await new LocatairesApiController().Update(locataire);*/

			// get taches from locataire
			//IEnumerable<TacheReadDto> taches = await new TachesApiController().GetTachesFromLocataire(1);

			//IEnumerable<TacheReadDto> taches = await new TachesApiController().GetAll<TacheReadDto>();

			//LocataireReadDto locataire = await new LocatairesApiController().GetById<LocataireReadDto>(5);

			//IList<LocataireReadDto> liaison = await new LocatairesApiController().GetAll<LocataireReadDto>();

			//var test = await new RepositoryLocataires().LireTest(1);
		}
	}
}
