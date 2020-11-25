using Models.Dtos.Locataires;
using Models.Dtos.Taches;

namespace Models.Mocks
{
	public class GenericMockModel
	{
		public static IDtoMock<T> GetMock<T>()
		{
			if (typeof(ILocataire).IsAssignableFrom(typeof(T)))
				return new LocataireMock() as IDtoMock<T>;
			else if(typeof(ITache).IsAssignableFrom(typeof(T)))
				return new TacheMock() as IDtoMock<T>;

			return null;
		}
	}
}
