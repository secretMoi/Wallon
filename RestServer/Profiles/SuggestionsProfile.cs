using AutoMapper;
using Models.Dtos.Suggestions;
using Models.Dtos.Taches;
using Models.Models;

namespace RestServer.Profiles
{
	public class SuggestionsProfile : Profile
	{
		public SuggestionsProfile()
		{
			// arg 1 from, arg 2 To
			// source -> target
			CreateMap<Suggestion, SuggestionReadDto>();
			CreateMap<SuggestionCreateDto, Suggestion>();
			CreateMap<SuggestionUpdateDto, Suggestion>();
		}
	}
}
