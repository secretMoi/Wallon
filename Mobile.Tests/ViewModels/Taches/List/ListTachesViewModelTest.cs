using System;
using System.Collections.Generic;
using Models.Dtos.Taches;

namespace Mobile.Tests.ViewModels.Taches.List
{
	public class ListTachesViewModelTest
	{
		/*[Fact]
		public async Task Execute_Hydrate()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<TacheController>()
					.Setup(x => x.GetAllAsync().Result)
					.Returns(GetSampleTaches());

				var cls = mock.Create<ListViewModel>();
				var expected = GetSampleTaches();
				await cls.Hydrate();
				var actual = cls.Taches.ToList();

				Assert.True(actual != null);
			
			}
		}*/

		private IList<TacheReadDto> GetSampleTaches()
		{
			IList<TacheReadDto> output = new List<TacheReadDto>
			{
				new TacheReadDto
				{
					Id = 1,
					Active = true,
					Cycle = 0,
					DateFin = DateTime.Now,
					Description = null,
					LocataireId = 5,
					Nom = "Balayer"
				},
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
			};

			return output;
		}

		/*new TacheReadDto()
				{
					Id = 1,
					Actif = true,
					Nom = "Quentin",
					Password = new byte[]
					{
						21, 55, 128
					}
				},
				new TacheReadDto()
				{
					Id = 1000,
					Actif = false,
					Nom = "Goku",
					Password = new byte[]
					{
						21, 55, 128
					}
				}*/
	}
}
