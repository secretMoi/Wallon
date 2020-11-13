using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Mobile.Core
{
	public class Cryptage
	{
		private static readonly byte[] Cle = Aes.Create().Key = Encoding.UTF8.GetBytes("$R!JtG?3R3(NnV@/");
		private static readonly byte[] Iv = Aes.Create().IV = Encoding.UTF8.GetBytes("42dkR3L/w8F)NQne");

		public static byte[] Crypt(string plainText)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException(nameof(plainText));
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

		public static byte[] Crypt(byte[] plainText)
		{
			return Crypt(Encoding.ASCII.GetString(plainText));
		}

		public static string Uncrypt(string cipherText)
		{
			return Uncrypt(Encoding.ASCII.GetBytes(cipherText));
		}

		public static string Uncrypt(byte[] cipherText)
		{
			// Check arguments.
			if (cipherText == null || cipherText.Length <= 0)
				throw new ArgumentNullException(nameof(cipherText));

			// Declare the string used to hold
			// the decrypted text.
			string plaintext;

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
	}
}
