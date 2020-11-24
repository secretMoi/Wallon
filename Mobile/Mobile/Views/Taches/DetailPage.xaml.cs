using System;
using Mobile.Controllers;
using Mobile.ViewModels.Taches.Detail;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Taches
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		private readonly DetailViewModel _viewModel = new DetailViewModel(
			FactoryController.CreateTache(),
			FactoryController.CreateLocataire(),
			FactoryController.CreateLiaison()
		);

		public DetailPage()
		{
			InitializeComponent();

			BindingContext = _viewModel;
		}

		private void ListViewLocataires_OnItemDragging(object sender, ItemDraggingEventArgs e)
		{
			if (e.Action == DragAction.Drop)
			{
				_viewModel.DropedItem(e.OldIndex, e.NewIndex);
			}
		}

		private async void Button_OnClicked(object sender, EventArgs e)
		{
			string result = await _viewModel.OnSendClicked();

			await DisplayAlert("Info", result, "OK");
		}

		private void CheckBox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			_viewModel.HydrateCheckedLocataires();
		}
	}
}