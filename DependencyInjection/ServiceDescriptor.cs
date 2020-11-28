using System;

 namespace DependencyInjection
{
	// contient les infos d'un service enregistré
	public class ServiceDescriptor
	{
		public Type ServiceType { get; }
		
		public Type ImplementationType { get; }
		
		public object Implementation { get; internal set; }

		public ServiceLifeTime LifeTime { get; }

		// utilisé lorsque l'on passe un objet
		public ServiceDescriptor(object implementation, ServiceLifeTime lifeTime)
		{
			ServiceType = implementation.GetType();
			Implementation = implementation;
			LifeTime = lifeTime;
		}
		
		
		// utilisé lorsque l'on donne un type / classe
		public ServiceDescriptor(Type serviceType, ServiceLifeTime lifeTime)
		{
			ServiceType = serviceType;
			LifeTime = lifeTime;
		}
		
		// utilisé lorsque l'on passe une interface ET son implémentation
		public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifeTime lifeTime)
		{
			ServiceType = serviceType;
			ImplementationType = implementationType;
			LifeTime = lifeTime;
		}
		
		// interface + objet déjà instancié
		public ServiceDescriptor(Type serviceType, object implementation, ServiceLifeTime lifeTime)
		{
			ServiceType = serviceType;
			Implementation = implementation;
			LifeTime = lifeTime;
		}
	}
}