using System;

namespace Core
{
	public class Reflection
	{
		private Type _type;

		public Reflection(Type type)
		{
			_type = type;
		}

		/// <summary>
		/// Récupère le namespace complet
		/// </summary>
		/// <returns>Le namespace complet sous forme de string</returns>
		public string Namespace => _type.Namespace;

		/// <summary>
		/// Récupère le premier élément du namespace (namespace de l'application courante par exemple)
		/// </summary>
		/// <returns>Le premier élément du namespace sous forme de string</returns>
		public string FirstNamespace => _type.Namespace?.Split('.')[0];

		/// <summary>
		/// Récupère le dernier élément dans le namespace
		/// </summary>
		/// <returns>Le dernier élément du namespace</returns>
		public string LastItemNamespace
		{
			get
			{
				string @namespace = _type.Namespace;
				string[] @class = @namespace?.Split('.');
				return @class?[@class.Length - 1];
			}
		}

		/// <summary>
		/// Récupère le type de l'objet
		/// </summary>
		/// <returns>Le type de l'objet</returns>
		public Type Type
		{
			get => _type;
			set => _type = value;
		}
	}

	
}
