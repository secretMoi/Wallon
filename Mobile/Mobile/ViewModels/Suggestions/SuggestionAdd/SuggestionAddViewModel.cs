using System;
using System.Threading.Tasks;
using Mobile.Controllers.Suggestion;
using Mobile.Core;
using Mobile.Core.Logger;
using Mobile.Validators;
using Models.Dtos.Suggestions;

namespace Mobile.ViewModels.Suggestions.SuggestionAdd
{
	public class SuggestionAddViewModel : BaseViewModel
	{
		private readonly ISuggestionController _suggestionController;

		private SuggestionAddData _suggestionData;

		public SuggestionAddData SuggestionData
		{
			get => _suggestionData;
			set => SetProperty(ref _suggestionData, value);
		}

		public SuggestionAddViewModel(ISuggestionController suggestionController)
		{
			SuggestionData = new SuggestionAddData();
			Title = "Proposer une suggestion";

			_suggestionController = suggestionController;
		}

		public async Task<string> SendSuggestion()
		{
			SuggestionData.Suggestion.LocataireId = Session.Instance.Get.Id;

			// validation des données
			var result = await new SuggestionValidator().ValidateAsync(SuggestionData.Suggestion);
			if (!result.IsValid)
				return $"{result.Errors[0].ErrorMessage}";

			// converti le dto de lecture en create
			var suggestionCreate = Mapping.Map(SuggestionData.Suggestion, new SuggestionCreateDto());

			// ajoute la suggestion
			try
			{
				var createdSuggestion = await _suggestionController.PostAsync(suggestionCreate);
				return $"La suggestion {createdSuggestion.Nom} a bien été ajoutée";
			}
			catch (Exception e)
			{
				Logger.LogError(e.Message);
				return "Erreur lors de l'ajout de la proposition";
			}
		}
	}
}
