using System;
using System.Threading.Tasks;
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
				DisableRenderWhilePopulating();

				BindData(value);

				HideRenderedColoumns();

				EnableRenderWhilePopulating();
			}
		}

		/// <summary>
		/// Permet de lier les données à la dgv de manière asynchrone
		/// </summary>
		/// <param name="bindingSource">Données à insérer dans la dgv</param>
		public async Task DataSourceAsync(BindingSource bindingSource)
		{
			DisableRenderWhilePopulating();

			await BindDataAsync(bindingSource);

			HideRenderedColoumns();

			EnableRenderWhilePopulating();
		}

		/// <summary>
		/// Désactive le rendu et la mise à l'échelle des colonnes pendant le remplissage de la dgv
		/// </summary>
		private void DisableRenderWhilePopulating()
		{
			dataGridView.SuspendLayout(); // met en suspentles dessins
			dataGridView.RowHeadersVisible = false;
			dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		}

		/// <summary>
		/// Masque les colonnes marquées comme invisible
		/// </summary>
		private void HideRenderedColoumns()
		{
			foreach (string colonne in _hidedColumns) // masque les colonnes masquées
			{
				if (dataGridView.Columns.Contains(colonne))
					dataGridView.Columns[colonne].Visible = false;
			}
		}

		/// <summary>
		/// Réactive le rendu et la mise à l'échelle des colonnes après le remplissage de la dgv
		/// </summary>
		private void EnableRenderWhilePopulating()
		{
			dataGridView.ResumeLayout(); // reprend l'affichage
			dataGridView.RowHeadersVisible = false;
			dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		}

		/// <summary>
		/// Insère des données dans la dgv
		/// </summary>
		/// <param name="bindingSource">Données à insérer</param>
		private void BindData(BindingSource bindingSource)
		{
			dataGridView.DataSource = bindingSource; // lie les données
		}

		/// <summary>
		/// Insère des données dans la dgv de manière asynchrone
		/// </summary>
		/// <param name="bindingSource">Données à insérer</param>
		private async Task BindDataAsync(BindingSource bindingSource)
		{
			dataGridView.DataSource = await Task.Run(() => bindingSource); // lie les données
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
		/// Remplace les données d'une cellule
		/// </summary>
		/// <param name="coordonnees">Couple définissant les coodonnées (x définissant la ligne et y la colonne)</param>
		/// /// <param name="value">Valeur à insérer</param>
		/// <returns>true si la modification s'est bien passée, false sinon</returns>
		public bool Set(Couple coordonnees, object value)
		{
			if (dataGridView.Rows.Count > coordonnees.Xi && dataGridView.ColumnCount > coordonnees.Yi)
			{
				dataGridView.Rows[coordonnees.Xi].Cells[coordonnees.Yi].Value = value;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Remplace les données d'une cellule
		/// </summary>
		/// <param name="x">Position en ligne</param>
		/// <param name="y">Position en colonne</param>
		/// <param name="value">Valeur à insérer</param>
		/// <returns>true si la modification s'est bien passée, false sinon</returns>
		public bool Set(int x, int y, object value)
		{
			return Set(new Couple(x, y), value);
		}

		/// <summary>
		/// Récupère l'id du nom d'une colonne
		/// </summary>
		/// <param name="name">Nom de la colonne</param>
		/// <returns>La position de la colonne, null si non trouvée</returns>
		public int? GetColumnId(string name)
		{
			if(Column.Contains(name))
				return Column[name]?.DisplayIndex;

			return null;
		}

		/// <summary>
		/// Echange 2 lignes de la dgv
		/// </summary>
		/// <param name="ligneSource">Ligne source qui doit se déplacer</param>
		/// <param name="ligneDestination">Ligne d'arrivée qui va swaper sa place</param>
		public void SwapRow(int ligneSource, int ligneDestination)
		{
			if(ligneSource < 0 || ligneDestination < 0) return;
			DataGridViewRow donneesAMonter = dataGridView.Rows[ligneSource]; // backup les données monter

			DataGridViewRow swapRow = dataGridView.Rows[ligneDestination];
			object[] values = new object[swapRow.Cells.Count];

			foreach (DataGridViewCell cell in swapRow.Cells)
			{
				values[cell.ColumnIndex] = cell.Value;
				cell.Value = donneesAMonter.Cells[cell.ColumnIndex].Value;
			}

			foreach (DataGridViewCell cell in donneesAMonter.Cells)
				cell.Value = values[cell.ColumnIndex];
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
