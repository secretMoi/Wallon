using Mobile.Core;
using Mobile.ViewModels.Taches.MesTaches;
using Models.Dtos.Locataires;
using RestApiClient;
using Xunit;

namespace Mobile.Tests.ViewModels.MesTaches
{
	public class MesTachesViewModelTest
	{
		public MesTachesViewModelTest()
		{
			ApiHelper.InitializeClient();
		}

		[Fact]
		public async void Execute_Hydrate()
		{
			var viewModel = new MesTachesViewModel(new LocataireReadDto
			{
				Id = 2
			});
			
			Assert.NotNull(viewModel.TachesData);

			await viewModel.Hydrate();

			Assert.NotEmpty(viewModel.TachesData);
		}
	}
}
