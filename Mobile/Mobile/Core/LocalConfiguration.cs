using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Mobile.Models;

namespace Mobile.Core
{
	public class LocalConfiguration
	{
		private readonly LocalFile _localFile;
		public ConfigurationModel Configuration { get; set; }

		public LocalConfiguration(string path)
		{
			Configuration = new ConfigurationModel();
			_localFile = new LocalFile(path);
		}

		public async Task<bool> SaveAsync()
		{
			try
			{
				var data = ObjectToByteArray(Configuration);

				if(data == null)
					throw new NullReferenceException("Les données binaires ne sont pas valides");

				await _localFile.SaveBytes(data);
				return true;
			}
			catch (Exception e)
			{
				Catcher.LogError(e.Message);
				return false;
			}
			
		}

		public async Task<bool> RestoreAsync()
		{
			try
			{
				var data = await _localFile.ReadBytes();

				if(data == null)
					throw new NullReferenceException("Les données binaires ne sont pas valides");

				Configuration = ByteArrayToObject<ConfigurationModel>(data);

				return Configuration != null;
			}
			catch (Exception e)
			{
				Catcher.LogError(e.Message);

				return false;
			}
		}

		/**
		 * <summary>Converti un objet en un tableau de byte</summary>
		 * <param name="obj">Objet à sérialiser</param>
		 * <returns>L'objet sérialisé</returns>
		 */
		private static byte[] ObjectToByteArray(object obj)
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (var ms = new MemoryStream())
			{
				bf.Serialize(ms, obj);
				return ms.ToArray();
			}
		}

		/**
		 * <summary>Converti un tableau de byte en un objet</summary>
		 * <param name="arrBytes">Tableau de byte à désérialiser</param>
		 * <returns>L'objet C#</returns>
		 */
		private static T ByteArrayToObject<T>(byte[] arrBytes) where T : class
		{
			using (var memStream = new MemoryStream())
			{
				var binForm = new BinaryFormatter();

				memStream.Write(arrBytes, 0, arrBytes.Length);
				memStream.Seek(0, SeekOrigin.Begin);
				var obj = binForm.Deserialize(memStream);

				return obj as T;
			}
		}
	}
}
