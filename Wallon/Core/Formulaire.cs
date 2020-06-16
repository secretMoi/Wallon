namespace Wallon.Core
{
	public class Formulaire
	{
		/// <summary>
		/// Vérifie que tous les objets ayent une valeur
		/// </summary>
		/// <param name="arguments">Tableau d'objets à vérifier</param>
		/// <returns>false si tous les objets sont initialisés, true sinon</returns>
		public static bool IsNotNull(params object[] arguments)
		{
			foreach (object argument in arguments)
				if (argument == null)
					return true;

			return false;
		}

		/// <summary>
		/// Vérifie que tous les objets soient correctement initialisés
		/// </summary>
		/// <param name="arguments">Tableau d'objets à vérifier</param>
		/// <returns>true si les objets CONNUS sont initialisés, false sinon</returns>
		public static bool IsValid(params object[] arguments)
		{
			if (IsNotNull(arguments)) return false;

			foreach (dynamic argument in arguments)
			{
				if (argument is string)
					if (argument == "") return false;

			}

			return true;
		}
	}
}
