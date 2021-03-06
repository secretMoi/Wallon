﻿using System.Collections.Generic;
using AutoMapper;
using Models.Dtos.Taches;
using Models.Models;

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
			CreateMap<LiaisonTacheLocataire, TacheReadDto>();
		}
	}
}
