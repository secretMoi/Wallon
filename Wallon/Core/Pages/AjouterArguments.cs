using System;
using System.Windows.Forms;
using Controls;
using QMag.Controls;
using QMag.Controls.Buttons;
using Wallon.Controls;

namespace QMag.Core.Pages
{
	public class AjouterArguments
	{
		public AjouterArguments(Type type, string name, string texte = null)
		{
			Type = type;
			Name = name;

			if(texte != null)
				Text = texte;
		}

		public static Type WhatIs(string name)
		{
			if (name.Contains("FlatTextBox"))
				return typeof(FlatTextBox);
			if (name.Contains("FlatLabel"))
				return typeof(FlatLabel);
			if (name.Contains("FlatButton"))
				return typeof(FlatButton);
			if (name.Contains("FlatListBox"))
				return typeof(FlatListBox);
			if (name.Contains("FlatList"))
				return typeof(FlatList);

			return null;
		}

		public string Text { get; set; }
		public string Name { get; set; }
		public Type Type { get; set; }
	}
}
