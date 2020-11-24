using Mobile.Controllers;
using Mobile.ViewModels.Taches.MesTaches;
using Models.Dtos.Locataires;
using RestApiClient;
using Xunit;

namespace Mobile.Tests.ViewModels.Taches.MesTaches
{
	public class MesTachesViewModelTest
	{
		public MesTachesViewModelTest()
		{
			ApiHelper.InitializeClient();
		}

		[Fact]
		public async void Execute_Hydrate_WithoutError()
		{
			var viewModel = new MesTachesViewModel(
				new LocataireReadDto
				{
					Id = 2
				},
				FactoryController.CreateMockTache()
			);
			
			Assert.NotNull(viewModel.TachesData);

			await viewModel.Hydrate();

			Assert.NotEmpty(viewModel.TachesData);

			await viewModel.Hydrate();

			Assert.NotEmpty(viewModel.TachesData);
		}

		private MesTachesViewModel ViewModel()
		{
			return new MesTachesViewModel(
				new LocataireReadDto
				{
					Id = 2
				},
				FactoryController.CreateMockTache()
			);
		}
	}
}
