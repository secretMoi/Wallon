using System.Collections.Generic;
using DependencyInjection.Interfaces;

namespace DependencyInjection
{
	// permet d'enregistrer les services
	public class DiServiceCollection : IDiServiceCollection
	{
		private readonly List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();
		
		// enregistre un singleton
		public void RegisterSingleton<TService>()
		{
			_serviceDescriptors.Add(
				new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singleton)
			);
		}
		
		// enregistre une interface et son implémentation
		public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
		{
			_serviceDescriptors.Add(
				new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Singleton)
			);
		}
		
		// enregistre via une interface TService ET une instanciation TImplementation
		public void RegisterSingleton<TService, TImplementation>(TImplementation implementation) where TImplementation : TService
		{
			_serviceDescriptors.Add(
				new ServiceDescriptor(typeof(TService), implementation, ServiceLifeTime.Singleton)
			);
		}
		
		// enregistre via un objet / une implémentation
		public void RegisterSingleton<TService>(TService implementation)
		{
			_serviceDescriptors.Add(
				new ServiceDescriptor(typeof(TService), implementation, ServiceLifeTime.Singleton)
			);
		}
		
		// enregistre via un type / classe
		public void RegisterTransient<TService>()
		{
			_serviceDescriptors.Add(
				new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient)
			);
		}
		
		// enregistre une interface et son implémentation
		public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
		{
			_serviceDescriptors.Add(
				new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Transient)
			);
		}

		public DiContainer GenerateContainer()
		{
			return new DiContainer(_serviceDescriptors);
		}
	}
}