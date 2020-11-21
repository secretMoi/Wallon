using System;
using System.Threading.Tasks;
using Mobile.Core;
using Mobile.ViewModels.Taches.MesTaches;
using Models.Dtos.Taches;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace Mobile.Views.Taches
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MesTachesPage : ContentPage
	{
		private readonly MesTachesViewModel _viewModel = new MesTachesViewModel(Session.Instance.Get);

		public MesTachesPage()
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
			await _viewModel.Hydrate();
			_viewModel.IsBusy = false;
		}

		/**
		 * <summary>Actions à effectuer lors de la validation d'une tâche</summary>
		 */
		private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
		{
			var tache = ((sender as View)?.BindingContext as TacheReadDto); // récupère les infos sur la tâche

			// message d'avertissement
			var choice = await DisplayAlert(
				"Attention",
				$@"Avez-vous bien fini la tâche {tache?.Nom} ?",
				"Oui",
				"Non"
			);

			if (!choice || tache == null) return; // si on ne veut pas supprimer on quitte ou si la tâches n'est pas correcte

			string result = await _viewModel.ValidTache(tache);

			await DisplayAlert("Information", result, "OK");

			await LoadTaches(); // recharge les tâches
		}

		private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			await _viewModel.OnItemSelected(e.ItemData as TacheReadDto);
		}
	}
}