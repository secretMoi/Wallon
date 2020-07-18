using AutoMapper;
using Models.Dtos.Locataires;
using Models.Models;

namespace RestServer.Profiles
{
	// hérite de la classe profile qui gère l'auto map
	public class LocatairesProfile : Profile
	{
		public LocatairesProfile()
		{
			// arg 1 from, arg 2 To
			// source -> target
			CreateMap<Locataire, LocataireReadDto>();
			CreateMap<LocataireCreateDto, Locataire>();
			CreateMap<LocataireUpdateDto, Locataire>();
		}
	}
}
