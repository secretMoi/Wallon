namespace DependencyInjection.Interfaces
{
	public interface IDiServiceCollection
	{
		void RegisterSingleton<TService>();
		void RegisterSingleton<TService, TImplementation>() where TImplementation : TService;
		void RegisterSingleton<TService>(TService implementation);
		void RegisterTransient<TService>();
		void RegisterTransient<TService, TImplementation>() where TImplementation : TService;
		DiContainer GenerateContainer();
	}
}