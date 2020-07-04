using AutoMapper;
using RestServer.Dtos.Locataires;
using RestServer.Models;

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
