using System.Collections.Generic;

namespace Models.Mocks
{
	public interface IDtoMock<T>
	{
		IList<T> Data { get; }
	}
}