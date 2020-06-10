using System;
using System.Collections.Generic;

namespace Couche_Classe
{
	public abstract class Base
	{
		protected static readonly List<(string, Type)> _champs = new List<(string, Type)>();

		public abstract List<(string, Type)> GetChamps();
	}
}
