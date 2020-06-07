using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Controls;
using Core;
using QMag.Controls;
using QMag.Controls.Buttons;
using Wallon.Controls;

namespace QMag.Core.Pages
{
	public class Formulaire
	{
		private readonly Dictionary<string, Control> _controls;

		public Formulaire(params object[] tuples)
		{
			_controls = new Dictionary<string, Control>();

			AutoAdd(tuples);
		}

		// ajoute de manière intelligente les control
		private void AutoAdd(params object[] tuples)
		{
			string name = null;
			string texte;
			foreach (object tuple in tuples)
			{
				if (name == null) // si c'est le deuxieme
					name = tuple as string;
				else // sinon c'est le troisième
				{
					texte = tuple as string;

					Add(new AjouterArguments(AjouterArguments.WhatIs(name), name, texte)); // ajoute le control

					name = null;
				}
			}
		}

		// crée un control
		public void Add(AjouterArguments arguments)
		{
			_controls.Add(arguments.Name, CreateControl(arguments));
		}

		// affiche les controls dans un panel définit
		public void Display(Panel panel)
		{
			foreach (KeyValuePair<string, Control> control in _controls)
				panel.Controls.Add(control.Value);
		}

		// positionne les controles à une position donnée
		public Couple LocateControlAt(Type controlAsked, Couple position)
		{
			int compteur = 0;
			Couple lastLocation = new Couple();

			foreach (Control control in Being(controlAsked))
			{
				control.Left = position.Xi;
				control.Top = position.Yi + 60 * compteur;
				compteur++;

				lastLocation = new Couple(control.Location);
			}

			return lastLocation; // retourne la position du dernier contrôle
		}

		// récupère un control particulier via son nom
		public Control Get(string name)
		{
			if (_controls.ContainsKey(name))
				return _controls[name];

			return null;
		}

		// retourne une liste du type de control désiré
		public List<Control> Being(Type controlAsked)
		{
			List<Control> controls = new List<Control>();

			foreach (KeyValuePair<string, Control> control in _controls)
			{
				if (control.Value.GetType() == controlAsked) // si le type du control est celui désiré
					controls.Add(control.Value); // on l'ajoute à la liste
			}

			return controls;
		}

		// Crée un control
		private Control CreateControl(AjouterArguments form)
		{
			Control control = null;

			// définit le type du control
			if (form.Type == typeof(FlatTextBox)) // textbox
				control = new FlatTextBox();
			else if (form.Type == typeof(FlatListBox)) // listbox
				control = new FlatListBox();
			else if (form.Type == typeof(FlatLabel)) // label
				control = new FlatLabel()
				{
					ForeColor = Theme.BackDark
				};
			else if (form.Type == typeof(FlatButton)) // bouton
				control = new FlatButton()
				{
					Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
				};
			else if (form.Type == typeof(FlatList)) // listbox
				control = new FlatList();

			// initialise certaines valeurs du control
			if (control != null)
			{
				control.Name = form.Name;
				control.Text = form.Text;
			}

			return control;
		}
	}
}
