using System;

namespace QMag.Core
{
	public class Reflection
	{
		private Type _type;

		public Reflection(Type type)
		{
			_type = type;
		}

		public string Namespace => _type.Namespace;

		public string FirstNamespace => _type.Namespace?.Split('.')[0];

		public string LastItemNamespace
		{
			get
			{
				string @namespace = _type.Namespace;
				string[] @class = @namespace?.Split('.');
				return @class?[@class.Length - 1];
			}
		}

		public Type Type
		{
			get => _type;
			set => _type = value;
		}
	}

	
}
