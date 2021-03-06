﻿using System;
using System.IO;
using System.Threading.Tasks;
using Mobile.Core.Logger;

namespace Mobile.Core.LocalFiles
{
	public class LocalFile : ILocalFile
	{
		public string Path { get; set; }

		private readonly string _appPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

		public LocalFile()
		{
			
		}

		public LocalFile(string path)
		{
			Path = path;
		}

		/**
		 * <summary>Sauvegarde des bytes dans un fichier</summary>
		 * <param name="data">Données à sauvegarder</param>
		 * <returns>true si tout s'est bien passé, false en cas d'erreur</returns>
		 */
		public async Task<bool> SaveBytes(byte[] data)
		{
			if (!ValidPath(Path)) return false;

			try
			{
				await Task.Run(() => File.WriteAllBytes(System.IO.Path.Combine(_appPath, Path), data));

				return true;
			}
			catch (Exception e)
			{
				//Logger.Logger.LogError(e.Message);
				App.Container.GetService<ILogger>().LogError(e.Message);

				return false;
			}
		}

		/**
		 * <summary>RestoreAsync un fichier de bytes</summary>
		 * <returns>Un tabluea de byte contenant les données si tout s'est bien, null sinon</returns>
		 */
		public async Task<byte[]> ReadBytes()
		{
			if (!ValidPath(Path)) return null;

			try
			{
				return await Task.Run(() =>
				{
					if(File.Exists(System.IO.Path.Combine(_appPath, Path)))
						return File.ReadAllBytes(System.IO.Path.Combine(_appPath, Path));

					return null;
				});
			}
			catch (Exception e)
			{
				//Logger.Logger.LogError(e.Message);
				App.Container.GetService<ILogger>().LogError(e.Message);

				return null;
			}
		}

		/**
		 * <summary>Vérifie qu'un chemin est valide</summary>
		 * <param name="path">Nom du chemin</param>
		 * <returns>true si il est valide, false sinon</returns>
		 */
		public bool ValidPath(string path)
		{
			return !string.IsNullOrEmpty(path);
		}
	}
}
