using System;
using Mobile.ViewModels.Taches.Add;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Taches
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTachePage : ContentPage
	{
		private readonly AddTacheViewModel _viewModel = new AddTacheViewModel();

		public AddTachePage()
		{
			InitializeComponent();

			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await _viewModel.Load();
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
			//todo implémenter
			string result = await _viewModel.OnSendClicked();

			await DisplayAlert("Info", result, "OK");
		}
	}
}