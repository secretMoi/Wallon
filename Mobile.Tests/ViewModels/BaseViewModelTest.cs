using Mobile.ViewModels;
using Xunit;

namespace Mobile.Tests.ViewModels
{
	public class BaseViewModelTest
	{
		[Fact]
		public void SetBusy_ShouldBeTrue()
		{
			var viewModel = new BaseViewModel
			{
				IsBusy = true
			};


			Assert.True(viewModel.IsBusy);
		}

		[Fact]
		public void SetTitle_ShouldBeEqualToCoucou()
		{
			string title = "Coucou";
			var viewModel = new BaseViewModel
			{
				Title = title
			};


			Assert.Equal(title, viewModel.Title);
		}
	}
}
