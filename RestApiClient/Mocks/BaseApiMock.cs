using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Dtos;
using Models.Mocks;
using RestApiClient.Interfaces;

namespace RestApiClient.Mocks
{
	public class BaseApiMock : IBaseController
	{
		private IDtoMock<object> _mock;

		protected void InitMock<T>()
		{
			if (_mock == null)
				_mock = GenericMockModel.GetMock<T>() as IDtoMock<object>;
		}

		protected IDtoMock<T> GetMock<T>()
		{
			return _mock as IDtoMock<T>;
		}

		protected IList<T> CastListToIList<T>(List<T> list)
		{
			IList<T> newList = new List<T>();

			foreach (var element in list)
			{
				newList.Add(element);
			}

			return newList;
		}

		public Task<T> GetById<T>(int id) where T : class, IRead
		{
			return Task.Run(() =>
				{
					//var element = GenericMockModel.GetMock<T>().Data.FirstOrDefault(x => x.Id == id);
					var element = GetMock<T>().Data.FirstOrDefault(x => x.Id == id);
					return element;
				}
			);
		}

		public Task<IList<T>> GetAll<T>() where T : class, IRead
		{
			return Task.Run(() =>
				{
					var list = GetMock<T>().Data;
					return CastListToIList(list.ToList());
				}
			);
		}

		public Task Update<T>(T data) where T : IUpdate
		{
			return Task.Run(() =>
				{
					var indexOf = GetMock<T>().Data.IndexOf(
						GetMock<T>().Data.FirstOrDefault(x => x.Id == data.Id)
					);

					GetMock<T>().Data[indexOf] = data;
				}
			);
		}

		public Task<TU> Post<T, TU>(T input) where TU : IRead
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
