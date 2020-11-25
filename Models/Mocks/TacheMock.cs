using System;
using System.Collections.Generic;
using Models.Dtos.Taches;

namespace Models.Mocks
{
	public class TacheMock : IDtoMock<TacheReadDto>
	{
		public IList<TacheReadDto> Data { get; }

		public TacheMock()
		{
			Data.Add(
				new TacheReadDto
				{
					Id = 1,
					Active = true,
					Cycle = 0,
					DateFin = DateTime.Now,
					Description = null,
					LocataireId = 5,
					Nom = "Balayer"
				}
			);
			Data.Add(
				new TacheReadDto
				{
					Id = 1000,
					Active = false,
					Cycle = 10,
					DateFin = DateTime.Now,
					Description = "coucou",
					LocataireId = 1,
					Nom = "Laver"
				}
			);
		}
	}
}
