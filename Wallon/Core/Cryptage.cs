using System;
using System.Text;
using System.Security.Cryptography;

namespace Wallon.Core
{
	public static class Cryptage
	{
		private static readonly byte[] Cle = Encoding.UTF8.GetBytes("Wallons");

		/// <summary>
		/// Crypte du texte
		/// </summary>
		/// <param name="clearPassword">Texte à crypter</param>
		/// <returns>Le texte crypté</returns>
		public static string Crypt(string clearPassword)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(clearPassword);

			byte[] protectedBytes = ProtectedData.Protect(bytes, Cle, DataProtectionScope.CurrentUser);

			return Convert.ToBase64String(protectedBytes);
		}

		/// <summary>
		/// Décrypte du texte
		/// </summary>
		/// <param name="protectedPassword">Le texte crypté</param>
		/// <returns>Le texte décrypté</returns>
		public static string Uncrypt(string protectedPassword)
		{
			try
			{
				byte[] protectedBytes = Convert.FromBase64String(protectedPassword);
				byte[] bytes = ProtectedData.Unprotect(protectedBytes, Cle, DataProtectionScope.CurrentUser);
				return Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				return null;
			}
		}
	}
}
