using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection
{
	// permet de manipuler les services
	public class DiContainer
	{
		private readonly List<ServiceDescriptor> _serviceDescriptors;
		
		public DiContainer(List<ServiceDescriptor> serviceDescriptors)
		{
			_serviceDescriptors = serviceDescriptors;
		}

		public object GetService(Type serviceType)
		{
			var descriptor = _serviceDescriptors
				.SingleOrDefault(x => x.ServiceType == serviceType);

			if(descriptor == null)
				throw new Exception($"Service of type {serviceType.Name} isn't registered");
			
			if (descriptor.Implementation != null)
				return descriptor.Implementation;

			var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;
			
			if(actualType.IsAbstract || actualType.IsInterface)
				throw new Exception("Cannot instantiate abstract classes or interfaces");

			var constructorInfo = actualType.GetConstructors().First();

			var parameters = constructorInfo.GetParameters()
				.Select(x => GetService(x.ParameterType)).ToArray(); 
			
			// essaye de créer ImplementationType si non null
			// sinon crée ServiceType
			// crée un objet
			var implementation = Activator.CreateInstance(actualType, parameters);

			if (descriptor.LifeTime == ServiceLifeTime.Singleton) // si c'est un singleton
			{
				// on l'enregistre
				descriptor.Implementation = implementation;
			}
			
			// retourne l'objet
			return implementation;
		}

		public T GetService<T>()
		{
			return (T) GetService(typeof(T));
		}
	}
}