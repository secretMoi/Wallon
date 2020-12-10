using System;
using System.Threading.Tasks;
using Mobile.Controllers;
using Mobile.ViewModels.Taches.List;
using Models.Dtos.Taches;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace Mobile.Views.Taches
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage
	{
		private readonly ListViewModel _viewModel = new ListViewModel(FactoryController.CreateTache(), FactoryController.CreateLiaison());

		public ListPage()
		{
			InitializeComponent();

			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await LoadTaches();
		}

		/**
		 * <summary>Charge les tâches de la bdd dans la vue</summary>
		 */
		private async Task LoadTaches()
		{
			_viewModel.IsBusy = true;
			await _viewModel.Hydrate("");
			_viewModel.IsBusy = false;
		}

		/**
		 * <summary>Action à effectuer lors de la sélection d'une tâche dans la vue</summary>
		 */
		private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs tappedEventArgs)
		{
			await _viewModel.OnItemSelected(tappedEventArgs.ItemData as TacheReadDto);
		}

		/**
		 * <summary>Action à effectuer lorsque l'on demande de supprimer une tâche</summary>
		 */
		private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
		{
			var tache = (sender as View)?.BindingContext as TacheReadDto; // récupère les infos sur la tâche

			// message d'avertissement
			var result = await DisplayAlert(
				"Attention",
				$@"Voulez-vous vraiment supprimer la tâche {tache?.Nom} ?",
				"Oui",
				"Non"
			);

			if (!result || tache == null) return; // si on ne veut pas supprimer on quitte ou si la tâches n'est pas correcte

			result = await _viewModel.DeleteTache(tache.Id); // supprime la tâche
			string message;

			// indication sur le succès ou pas de suppression ed la tâche
			if (result)
				message = $"La tâche {tache.Nom} a bien été supprimée";
			else
				message = $"La tâche {tache.Nom} n'a pas pu être supprimée";

			await DisplayAlert(
				"Information",
				message,
				"D'accord"
			);

			await LoadTaches(); // recharge les tâches
		}

		private async void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			await _viewModel.Hydrate(e.NewTextValue);
		}
	}
}