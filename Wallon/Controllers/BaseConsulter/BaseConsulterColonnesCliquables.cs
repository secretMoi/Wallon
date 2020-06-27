using System.Collections.Generic;
using System.Drawing;
using FlatControls.Core;

namespace Wallon.Controllers.BaseConsulter
{
	public class BaseConsulterColonnesCliquables
	{
		private readonly Dictionary<Cliquable, Image> _images;
		private readonly List<(string, Cliquable)> _enabled; // stock le nom d'affichage de la colonne ainsi que son type

		public enum Cliquable
		{
			Edit, Delete, See, Add, Up, Down
		}

		public BaseConsulterColonnesCliquables()
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

		public void Enable(params (string, Cliquable)[] colonnes)
		{
			foreach ((string, Cliquable) colonne in colonnes)
				_enabled.Add((colonne.Item1, colonne.Item2));
		}

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

		public Image GetImage(Cliquable type)
		{
			return _images[type];
		}

		private Image SetImage(string path)
		{
			string finalPath = "Ressources/Images/" + path + ".png";
			return new CoreImage(finalPath).ResizeImage(32, 32);
		}
	}
}
