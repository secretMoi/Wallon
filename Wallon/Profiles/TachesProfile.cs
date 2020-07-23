using AutoMapper;
using Models.Dtos.Taches;

namespace Wallon.Profiles
{
	public class TachesProfile : Profile
	{
		public TachesProfile()
		{
			// source -> target
			CreateMap<TacheReadDto, TacheCreateDto>();
		}

		public static Mapper ReadToCreate()
		{
			MapperConfiguration config = new MapperConfiguration(cfg =>
				{
					cfg.CreateMap<TacheReadDto, TacheCreateDto>();
				});

			Mapper mapper = new Mapper(config);

			return mapper;
		}
    }
}
