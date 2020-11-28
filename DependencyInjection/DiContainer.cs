using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.Interfaces;

namespace DependencyInjection
{
	// permet de manipuler les services
	public class DiContainer : IDiContainer
	{
		private readonly List<ServiceDescriptor> _serviceDescriptors;
		
		public DiContainer(List<ServiceDescriptor> serviceDescriptors)
		{
			_serviceDescriptors = serviceDescriptors;
		}

		public object GetService(Type serviceType)
		{
			// récupère les infos du service
			var descriptor = _serviceDescriptors
				.SingleOrDefault(x => x.ServiceType == serviceType);

			// si il est null, il y a eu une erreur lors de l'enregistrement du service
			if(descriptor == null)
				throw new Exception($"Service of type {serviceType.Name} isn't registered");
			
			// si il a déjà une implémentation c'est un singleton => on retourne direct
			if (descriptor.Implementation != null)
				return descriptor.Implementation;

			// si une implémentation ou un nom de type a été fourni
			var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;
			
			// si on demande d'instancier une classe abstraite ou une interface (donc impossible à instancier)
			if(actualType.IsAbstract || actualType.IsInterface)
				throw new Exception("Cannot instantiate abstract classes or interfaces");

			// récupère mes constructeurs du type à instancier
			var constructorInfo = actualType.GetConstructors().First();

			// récupère les paramètres à instancier et se rappel en récursif si le constructeur a besoin d'autres objets
			var parameters = constructorInfo.GetParameters()
				.Select(x => GetService(x.ParameterType)).ToArray(); 
			
			// instancie le type
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