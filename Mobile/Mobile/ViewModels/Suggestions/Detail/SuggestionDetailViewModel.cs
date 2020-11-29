using System;
using Mobile.Controllers.Suggestion;
using Mobile.Core.Logger;
using Xamarin.Forms;

namespace Mobile.ViewModels.Suggestions.Detail
{
	[QueryProperty(nameof(SuggestionId), nameof(SuggestionId))]
	public class SuggestionDetailViewModel : BaseViewModel
	{
		private readonly ISuggestionController _suggestionController;
		
		public SuggestionDetailData SuggestionDetail { get; private set; }

		public SuggestionDetailViewModel(ISuggestionController suggestionController)
		{
			_suggestionController = suggestionController;
			
			SuggestionDetail = new SuggestionDetailData();
		}
		
		private string _itemId;
		
		public string SuggestionId
		{
			get => _itemId;
			set
			{
				_itemId = value;
				LoadItemId(value);
			}
		}
		
		/**
		 * <summary>Charge les données de la suggestion de la bdd</summary>
		 * <param name="itemId">Id de la suggestion à charger</param>
		 */
		public async void LoadItemId(string itemId)
		{
			IsBusy = true;
			
			try
			{
				int idSuggestion = Convert.ToInt32(itemId);
				SuggestionDetail.Suggestion = await _suggestionController.GetByIdAsync(idSuggestion);
				Title = "Modification de la suggestion " + SuggestionDetail.Suggestion.Nom;
			}
			catch (Exception e)
			{
				App.Container.GetService<ILogger>().LogError("Impossible de charger la suggestion avec l'id : " + itemId + e.Message);
			}

			IsBusy = false;
		}
	}
}