using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Wallon.Core
{
	public static class Cryptage
	{
		private static readonly byte[] Cle = Encoding.UTF8.GetBytes("$R!JtG?3R3(NnV@/");
		private static readonly byte[] Iv = Encoding.UTF8.GetBytes("42dkR3L/w8F)NQne");

		public static byte[] Crypt(string plainText)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			byte[] encrypted;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Cle;
				aesAlg.IV = Iv;

				// Create an encryptor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							//Write all data to the stream.
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}

			// Return the encrypted bytes from the memory stream.
			return encrypted;
		}

		public static string Uncrypt(byte[] cipherText)
		{
			// Check arguments.
			if (cipherText == null || cipherText.Length <= 0)
				throw new ArgumentNullException("cipherText");

			// Declare the string used to hold
			// the decrypted text.
			string plaintext = null;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Cle;
				aesAlg.IV = Iv;

				// Create a decryptor to perform the stream transform.
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for decryption.
				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{

							// Read the decrypted bytes from the decrypting stream
							// and place them in a string.
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}
			}

			return plaintext;
		}

		/// <summary>
		/// Crypte du texte
		/// </summary>
		/// <param name="clearPassword">Texte à crypter</param>
		/// <returns>Le texte crypté</returns>
		/*public static string Crypt(string clearPassword)
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
		}*/
	}
}
