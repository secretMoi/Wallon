using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Controllers.Locataire;
using Models.Dtos.Locataires;

namespace Mobile.ViewModels.Locataires.List
{
	public class LocatairesListViewModel : BaseViewModel
	{
		private readonly ILocataireController _locataireController;

		public LocatairesListData Locataires { get; set; }

		/**
		 * <param name="locataireController"><see cref="ILocataireController"/>Contient le controller qui gère les locataires</param>
		 */
		public LocatairesListViewModel(ILocataireController locataireController)
		{
			Locataires = new LocatairesListData
			{
				List = new ObservableCollection<LocataireReadDto>()
			};

			_locataireController = locataireController;
		}

		/**
		 * <summary>Ajoute les données de la bdd dans la liste des locataires</summary>
		 */
		public async Task HydrateAsync()
		{
			if (Locataires.List.Count != 0)
			{
				Locataires.List.Clear();
			}

			var taches = await _locataireController.GetAllAsync();

			foreach (var tache in taches)
			{
				Locataires.List.Add(tache);
			}
		}
	}
}
