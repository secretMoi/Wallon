using AutoMapper;

namespace Mobile.Core
{
	public class Mapping
	{
		/**
		 * <summary>Map une source vers une destination</summary>
		 * <param name="source">Objet source</param>
		 * <param name="destination">Objet destination (c'est le type qui importe)</param>
		 * <returns>Retourne un nouvel objet du type de la destination avec les valeurs de la source</returns>
		 */
		public static TU Map<T, TU>(T source, TU destination)
		{
			// configure le mapper
			var config = new MapperConfiguration(cfg => cfg.CreateMap<T, TU>());

			var mapper = config.CreateMapper(); // crée le mapper
			return mapper.Map<TU>(source); // map et retourne le résultat
		}
	}
}
