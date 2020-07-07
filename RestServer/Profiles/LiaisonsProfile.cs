using AutoMapper;
using RestServer.Dtos.LiaisonsTachesLocataires;
using RestServer.Models;

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
		}
	}
}
