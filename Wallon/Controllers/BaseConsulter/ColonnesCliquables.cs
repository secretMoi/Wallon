using System.Collections.Generic;
using System.Drawing;
using FlatControls.Core;

namespace Wallon.Controllers.BaseConsulter
{
	public class ColonnesCliquables
	{
		private readonly Dictionary<Cliquable, Image> _images;
		private readonly List<(string, Cliquable)> _enabled; // stock le nom d'affichage de la colonne ainsi que son type

		public enum Cliquable
		{
			Edit, Delete, See, Add, Up, Down
		}

		public ColonnesCliquables()
		{
			_enabled = new List<(string, Cliquable)>();
			_images = new Dictionary<Cliquable, Image>
			{
				{Cliquable.Edit, SetImage("editer")},
				{Cliquable.Delete, SetImage("supprimer")},
				{Cliquable.See, SetImage("loupe")},
				{Cliquable.Add, SetImage("correct")},
				{Cliquable.Up, SetImage("arrow-up-sign-to-navigate")},
				{Cliquable.Down, SetImage("arrow-down-sign-to-navigate")}
			};
		}

		/// <summary>
		/// Récupère le type d'une colonne grâce à sa position
		/// </summary>
		/// <param name="position">Position de la colonne dans la liste interne _enabled</param>
		/// <returns>Le type de la colonne demandé</returns>
		public Cliquable TypeFromId(int position)
		{
			return _enabled[position].Item2;
		}

		/// <summary>
		/// Active une liste de colonnes
		/// </summary>
		/// <param name="colonnes">Liste des colonnes à ajouter</param>
		public void Enable(params (string, Cliquable)[] colonnes)
		{
			foreach ((string, Cliquable) colonne in colonnes)
				_enabled.Add((colonne.Item1, colonne.Item2));
		}

		/// <summary>
		/// Récupère un tableau des titres de colonnes
		/// </summary>
		/// <returns>Liste des titres de colonnes</returns>
		/// <returns>Image</returns>
		public string[] GetTitlesColumn()
		{
			string[] titles = new string[_enabled.Count];
			int i = 0;

			foreach ((string, Cliquable) colonne in _enabled)
			{
				titles[i] = colonne.Item1;
				i++;
			}

			return titles;
		}

		/// <summary>
		/// Retourne l'image d'un type de colonne
		/// </summary>
		/// <param name="type">Type de la colonne</param>
		/// <returns>Image</returns>
		public Image GetImage(Cliquable type)
		{
			return _images[type];
		}

		/// <summary>
		/// Crée une image et la redimensionne
		/// </summary>
		/// <param name="path">Nom de l'image</param>
		/// <returns>L'image</returns>
		private Image SetImage(string path)
		{
			string finalPath = "Ressources/Images/" + path + ".png";
			return new CoreImage(finalPath).Resize(32, 32);
		}
	}
}
