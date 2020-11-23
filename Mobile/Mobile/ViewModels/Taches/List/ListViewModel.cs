﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Controllers.Liaison;
using Mobile.Controllers.Tache;
using Mobile.ViewModels.Taches.Detail;
using Mobile.Views.Taches;
using Models.Dtos.Taches;
using Xamarin.Forms;

namespace Mobile.ViewModels.Taches.List
{
	public class ListViewModel : BaseViewModel
	{
		private ListData _listData = new ListData();
		private readonly ITacheController _taches = TacheController.Instance;
		private readonly ILiaisonController _liaisons = LiaisonController.Instance;

		public Command AddTacheCommand { get; }
		public ObservableCollection<TacheReadDto> Taches { get; private set; }

		public ListData LogInData // élément sélectionné dans la dgv
		{
			get => _listData;
			set => SetProperty(ref _listData, value);
		}

		public ListViewModel()
		{
			Title = "Liste des tâches";
			Taches = new ObservableCollection<TacheReadDto>();

			AddTacheCommand = new Command(NavigateToAddTache);
		}

		private async void NavigateToAddTache()
		{
			await Shell.Current.GoToAsync($"{nameof(AddTachePage)}");
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

			// This will push the ItemDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailViewModel.TacheId)}={tache.Id}");
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
				Console.WriteLine(e.Message);

				return false;
			}
		}
	}
}
