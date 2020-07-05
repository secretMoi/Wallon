using AutoMapper;
using RestServer.Dtos.Taches;
using RestServer.Models;

namespace RestServer.Profiles
{
	public class TachesProfile : Profile
	{
		public TachesProfile()
		{
			// arg 1 from, arg 2 To
			// source -> target
			CreateMap<Tache, TacheReadDto>();
			CreateMap<TacheCreateDto, Tache>();
			CreateMap<TacheUpdateDto, Tache>();
		}
	}
}
