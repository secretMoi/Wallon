﻿using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FlatControls.Core
{
	public class UseGridView
	{
		private readonly DataTable _table; // table pour formatter les données
		private readonly BindingSource _liens; // permet de lier les données à une dgv

		public UseGridView()
		{
			_table = new DataTable();
			_liens = new BindingSource();
		}

		public UseGridView(params string[] titles) : this()
		{
			CreateColumns(titles);
		}

		/// <summary>
		/// Crée des colonnes de texte
		/// </summary>
		/// <param name="titles">Titres des colonnes</param>
		public void CreateColumns(params string[] titles)
		{
			foreach (string title in titles)
				_table.Columns.Add(new DataColumn(title));
		}

		/// <summary>
		/// Crée des colonnes contenant une image
		/// </summary>
		/// <param name="titles">Titres des colonnes</param>
		/// <returns>Un tableau contenant l'index des colonnes créées</returns>
		public int[] CreateImageColumn(params string[] titles)
		{
			int[] indexColonne = new int[titles.Length]; // tableau des index de colonnes cliquables
			int compteur = 0;

			foreach (string title in titles)
			{
				indexColonne[compteur] = _table.Columns.Count;
				_table.Columns.Add(title, typeof(Bitmap)); // ajoute la colonne
				compteur++;
			}

			return indexColonne;
		}

		/// <summary>
		/// Ajoute des données aux colonnes
		/// </summary>
		/// <param name="records">Données à ajouter aux colonnes</param>
		public void Add(params object[] records)
		{
			_table.Rows.Add(records); // structure les données en tableau
			_liens.DataSource = _table; // prepare à envoyer à une dgv
		}

		/// <summary>
		/// Remet à 0 toutes les données
		/// </summary>
		public void ResetAllData()
		{
			_table.Rows.Clear();
			_liens.DataSource = _table;
		}

		public BindingSource Liens => _liens;
		public DataTable Table => _table;
	}
}
