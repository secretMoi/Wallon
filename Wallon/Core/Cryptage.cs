using System;
using System.Text;
using System.Security.Cryptography;

namespace Wallon.Core
{
	public static class Cryptage
	{
		private static readonly byte[] Cle = Encoding.UTF8.GetBytes("Wallons");

		public static string Crypt(string clearPassword)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(clearPassword);

			byte[] protectedBytes = ProtectedData.Protect(bytes, Cle, DataProtectionScope.CurrentUser);

			return Convert.ToBase64String(protectedBytes);
		}

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
