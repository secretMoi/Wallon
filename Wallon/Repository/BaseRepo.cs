namespace Wallon.Repository
{
	//todo delete
	public class BaseRepo
	{
		private static object _controller;

		protected T Controller<T>() where T : new()
		{
			if (_controller == null)
				_controller = new T();

			return (T) _controller;
		}
	}
}
