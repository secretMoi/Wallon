using System.Collections.Generic;
using Models.Dtos.Locataires;

namespace Models.Mocks
{
	public interface IDtoMock<T>
	{
		IList<T> Data { get; }
	}
}