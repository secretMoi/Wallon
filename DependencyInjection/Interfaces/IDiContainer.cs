using System;

namespace DependencyInjection.Interfaces
{
	public interface IDiContainer
	{
		object GetService(Type serviceType);
		T GetService<T>();
	}
}