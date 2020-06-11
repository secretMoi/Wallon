using System;
using System.Text;
using System.Security.Cryptography;

namespace Wallon.Core
{
	public static class Cryptage
	{
		private static readonly byte[] _cle = Encoding.UTF8.GetBytes("wa");

		public static string Crypt(string clearPassword/*, string cle*/)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(clearPassword);
			//_cle = Encoding.UTF8.GetBytes(cle);

			byte[] protectedBytes = ProtectedData.Protect(bytes, _cle, DataProtectionScope.CurrentUser);

			return Convert.ToBase64String(protectedBytes);
		}

		public static string Uncrypt(string protectedPassword/*, string cle = null*/)
		{
			byte[] protectedBytes = Convert.FromBase64String(protectedPassword);
			/*if (cle != null)
				_cle = Encoding.UTF8.GetBytes(cle);*/

			byte[] bytes = ProtectedData.Unprotect(protectedBytes, _cle, DataProtectionScope.CurrentUser);

			return Encoding.UTF8.GetString(bytes);
		}
	}
}
