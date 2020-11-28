using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Controllers.Liaison;
using Mobile.Controllers.Tache;
using Mobile.Core.Logger;
using Mobile.ViewModels.Taches.Detail;
using Mobile.Views.Taches;
using Models.Dtos.Taches;
using Xamarin.Forms;
using INavigation = Mobile.Core.Navigation.INavigation;

namespace Mobile.ViewModels.Taches.List
{
	public class ListViewModel : BaseViewModel
	{
		private ListData _listData = new ListData();
		private readonly ITacheController _taches;
		private readonly ILiaisonController _liaisons;

		public Command AddTacheCommand { get; }
		public ObservableCollection<TacheReadDto> Taches { get; private set; }

		public ListData LogInData // élément sélectionné dans la dgv
		{
			get => _listData;
			set => SetProperty(ref _listData, value);
		}

		public ListViewModel(ITacheController tacheController, ILiaisonController liaisonController)
		{
			Title = "Liste des tâches";
			Taches = new ObservableCollection<TacheReadDto>();

			_taches = tacheController;
			_liaisons = liaisonController;

			AddTacheCommand = new Command(NavigateToAddTache);
		}

		private async void NavigateToAddTache()
		{
			await App.Container.GetService<INavigation>().PushAsync<AddTachePage>();
		}

		/**
		 * <summary>Hydrate les données de la page en async</summary>
		 */
		public async Task Hydrate()
		{
			if(Taches.Count != 0)
			{
				Taches.Clear();
			}

			var taches = await _taches.GetAllAsync();

			foreach (var tache in taches)
			{
				Taches.Add(tache);
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

			await App.Container.GetService<INavigation>().PushAsync<DetailPage>(nameof(DetailViewModel.TacheId), tache.Id);
		}

		/**
		 * <summary>Supprimer une tâche via son id</summary>
		 * <param name="tacheId">Id de la tâche à supprimer</param>
		 * <returns>true si tout s'est bien passé, false sinon</returns>
		 */
		public async Task<bool> DeleteTache(int tacheId)
		{
			try
			{
				await _liaisons.DeleteLiaisonsFromTacheAsync(tacheId);
				await _taches.DeleteAsync(tacheId);

				return true;
			}
			catch (Exception e)
			{
				App.Container.GetService<ILogger>().LogError(e.Message);

				return false;
			}
		}
	}
}
