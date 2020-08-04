﻿using Couche_Classe;
using RestApiClient.Controllers;
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

		private async void Accueil_Load(object sender, System.EventArgs e)
		{
			//await RepositoryLiaisonTachesLocataires.Instance.DeleteLiaisonsFromTache(11);

			// lire tout
			//IEnumerable<LocataireReadDto> locataires = await new LocatairesController().GetAll<LocataireReadDto>();

			// post
			/*LocataireCreateDto locataire = new LocataireCreateDto()
			{
				Nom = "test",
				Password = Encoding.ASCII.GetBytes("test")
			};
			await RepositoryLocataires.Instance.Ajouter(locataire);*/

			// lire 1
			//LocataireReadDto locataire = await LocatairesController.GetLocataireById(4);

			// update
			/*LocataireUpdateDto locataire = new LocataireUpdateDto()
			{
				Id = 5,
				Nom = "1",
				Password = Encoding.ASCII.GetBytes("test5")
			};
			string res = await new LocatairesController().Update(locataire);*/

			// get taches from locataire
			//IEnumerable<TacheReadDto> taches = await new TachesController().GetTachesFromLocataire(1);

			//IEnumerable<TacheReadDto> taches = await new TachesController().GetAll<TacheReadDto>();

			//LocataireReadDto locataire = await new LocatairesController().GetById<LocataireReadDto>(5);

			//IList<LocataireReadDto> liaison = await new LocatairesController().GetAll<LocataireReadDto>();

			//var test = await new RepositoryLocataires().LireTest(1);
		}
	}
}
