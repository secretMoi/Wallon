using System.Collections.Generic;
using System.Windows.Forms;
using FlatControls.Core;

namespace FlatControls.Controls
{
	public partial class FlatDataGridView
	{
		/// <summary>
		/// Définit une liste de colonnes cliquables
		/// </summary>
		/// <param name="colonnes">Liste des noms de colonnes</param>
		public void SetColonnesCliquables(params int[] colonnes)
		{
			foreach (int colonne in colonnes)
				_colonnesCliquables.Add(colonne);
		}

		/// <summary>
		/// Permet de cacher une colonne
		/// </summary>
		/// <param name="colonne">Nom de la colonne à masquer</param>
		public void HideColonne(string colonne)
		{
			if (_hidedColumns == null)
				_hidedColumns = new List<string>();

			_hidedColumns.Add(colonne);
		}

		/// <summary>
		/// Permet de lier les données à la dgv
		/// </summary>
		/// <param name="value">DataSource à envoyer dans la dgv</param>
		public BindingSource DataSource
		{
			set
			{
				dataGridView.SuspendLayout(); // met en suspentles dessins
				dataGridView.DataSource = value; // lie les données

				foreach (string colonne in _hidedColumns) // masque les colonnes masquées
				{
					if (dataGridView.Columns.Contains(colonne))
						dataGridView.Columns[colonne].Visible = false;
				}

				dataGridView.ResumeLayout(); // reprend l'affichage
			}
		}

		public DataGridViewColumnCollection Column => dataGridView.Columns;

		/// <summary>
		/// Récupère les données de la dgv à une position donnée
		/// </summary>
		/// <param name="coordonnees">Couple définissant les coodonnées (x définissant la ligne et y la colonne)</param>
		public string Get(Couple coordonnees)
		{
			if (dataGridView.Rows.Count > coordonnees.Xi && dataGridView.ColumnCount > coordonnees.Yi)
				return dataGridView.Rows[coordonnees.Xi].Cells[coordonnees.Yi].Value.ToString();

			return null;
		}

		/// <summary>
		/// Récupère les données de la dgv à une position donnée
		/// </summary>
		/// <param name="x">Position en ligne</param>
		/// <param name="y">Position en colonne</param>
		public string Get(int x, int y)
		{
			return Get(new Couple(x, y));
		}

		/// <summary>
		/// Supprime une ligne à une position donnée
		/// </summary>
		/// <param name="ligne">Position de la ligne à supprimer</param>
		public void RemoveRowAt(int ligne)
		{
			DataGridViewRow dgvDelRow = dataGridView.Rows[ligne];
			dataGridView.Rows.Remove(dgvDelRow);
		}

		/// <summary>
		/// Modifie une ligne à une position donnée
		/// </summary>
		/// <param name="ligne">Position de la ligne à supprimer</param>
		/// <param name="newData">Données à insérer à la place des anciennes</param>
		public void UpdateRowAt(int ligne, params object[] newData)
		{
			DataGridViewRow nouvelleLigne = dataGridView.Rows[ligne];

			for (int colonne = 0; colonne < dataGridView.ColumnCount; colonne++)
				nouvelleLigne.Cells[colonne].Value = newData[colonne];
		}

		// retourne une collection des lignes
		public DataGridViewRowCollection Rows => dataGridView.Rows;
		public int SelectedRow => dataGridView.CurrentCell.RowIndex;
	}
}
