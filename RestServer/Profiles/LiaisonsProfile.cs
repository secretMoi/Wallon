using AutoMapper;
using Models.Dtos.LiaisonsTachesLocataires;
using Models.Dtos.Locataires;
using Models.Models;

namespace RestServer.Profiles
{
	public class LiaisonsProfile : Profile
	{
		public LiaisonsProfile()
		{
			// arg 1 from, arg 2 To
			// source -> target
			CreateMap<LiaisonCreateDto, LiaisonTacheLocataire>();
			CreateMap<LiaisonTacheLocataire, LiaisonReadDto>();
			CreateMap<Locataire, LocataireReadDto>();
		}
	}
}
