using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Controllers.Tache;
using Mobile.Core;
using Mobile.ViewModels.Taches.Detail;
using Mobile.Views.Taches;
using Models.Dtos;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;
using INavigation = Mobile.Core.Navigation.INavigation;

namespace Mobile.ViewModels.Taches.MesTaches
{
	public class MesTachesViewModel : BaseViewModel
	{
		private readonly ITacheController _tacheController;
		private readonly IRead _locataireLogged;

		public ObservableCollection<TacheReadDto> TachesData { get; private set; }

		public MesTachesViewModel(IRead locataire, ITacheController tacheController)
		{
			Title = "Mes tâches à réaliser";
			TachesData = new ObservableCollection<TacheReadDto>();
			
			_locataireLogged = locataire;
			_tacheController = tacheController;
		}

		/**
		 * <summary>Hydrate les données de la âge en async</summary>
		 */
		public async Task Hydrate()
		{
			if (TachesData.Count != 0)
			{
				TachesData.Clear();
			}

			var taches = await _tacheController.GetTachesFromLocataireAsync(_locataireLogged.Id);

			foreach (var tache in taches)
			{
				TachesData.Add(tache);
			}
		}

		/**
		 * <summary>Navigue vers la page de détail de la tâche sélectionnée</summary>
		 * <param name="tache">Données de la tâche sélectionnée</param>
		 */
		public async Task OnItemSelected(TacheReadDto tache)
		{
			if (tache == null)
				return;

			// This will push the ItemDetailPage onto the navigation stack
			await App.Container.GetService<INavigation>().PushAsync<DetailPage>(nameof(DetailViewModel.TacheId), tache.Id);
		}

		/**
		 * <summary>Valide une tâche dans la bdd</summary>
		 * <param name="tache">Donnée de la tâche à valider</param>
		 */
		public async Task<string> ValidTache(TacheReadDto tache)
		{
			string result;

			try
			{
				// récupère l'id du locataire suivant
				LocataireReadDto locataireSuivant = await _tacheController.TrouveLocataireSuivant(tache.Id, Session.Instance.Get.Id);

				await _tacheController.LocataireSuivant(tache.Id, locataireSuivant.Id); // modifie le locataire devant effectuer la tâche

				result = $"La tâche {tache.Nom} est validée";
			}
			catch
			{
				result = "Une erreur est survenue pendant la validation de la tâche";
			}

			return result;
		}
	}
}
