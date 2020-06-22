using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

//todo optimiser grosse liste de data, mettre toutes les données dans une liste en ram et n'afficher que celles visibles
namespace FlatControls.Controls
{
	public partial class FlatDataGridView : UserControl
	{
		private readonly List<int> _colonnesCliquables;

		private Dictionary<int, Color> _rowsBackground; // lignes dont on change la couleur d'arrière-plan
		private Dictionary<int, Color> _rowsForeground; // lignes dont on change la couleur du texte

		private List<string> _hidedColumns;

		public FlatDataGridView()
		{
			InitializeComponent();

			_colonnesCliquables = new List<int>();
			//_colonnesMasquees = new Dictionary<int, object>();

			dataGridView.GridColor = Theme.Back;
			dataGridView.ForeColor = Theme.BackDark;

			dataGridView.BorderStyle = BorderStyle.None;

			// désactive les bordures des titres
			dataGridView.AdvancedColumnHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
			dataGridView.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
			dataGridView.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

			// mets en couleur les titres
			dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Theme.BackLight;
			dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Theme.Texte;
			dataGridView.EnableHeadersVisualStyles = false;

			// change l'élément sélectionné
			dataGridView.DefaultCellStyle.SelectionBackColor = Theme.BackLight;
			dataGridView.DefaultCellStyle.SelectionForeColor = Theme.Texte;

			// désactive la première colonne
			dataGridView.RowHeadersVisible = false;

			// change la hauteur des cellules
			dataGridView.RowTemplate.Height = 38;

			dataGridView.CellMouseEnter += Cliquable; // event lorsque le curseur entre dans une cellule

			// active le double buffer pour rendre le redimensionnement plus fluide
			Type dgvType = dataGridView.GetType();
			PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
				BindingFlags.Instance | BindingFlags.NonPublic);
			pi.SetValue(dataGridView, true, null);

			// désactive les barres de scroll mais rend le panel scrollable
			dataGridView.ScrollBars = ScrollBars.None;
			this.dataGridView.MouseWheel += new MouseEventHandler(Mouse_Wheel);
		}

		// permet de subscribe une méthode à l'event
		public void AddClickMethod(DataGridViewCellMouseEventHandler methode)
		{
			dataGridView.CellMouseClick += methode;
		}

		private void Cliquable(object sender, DataGridViewCellEventArgs e)
		{
			// vérifie que la case sélectionnée est valide
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			if(_colonnesCliquables.Contains(e.ColumnIndex))
				dataGridView.Cursor = Cursors.Hand;
			else
				dataGridView.Cursor = Cursors.Default;
		}

		// code exécuté après le chargement de la dgv
		private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			if(dataGridView.Rows.Count > 0) // vérifie qu'il y a bien des cellules pour ne pas provoquer de bug
				dataGridView.FirstDisplayedCell.Selected = false; // désactive la sélection automatique
		}

		/// <summary>
		/// Permet de changer la couleur d'arrière-plan d'une ligne demandée
		/// </summary>
		/// <param name="idLigne">Position de la ligne à modifier</param>
		/// <param name="couleur">Couleur d'arrière-plan que la ligne prendra</param>
		public void BackgroundColor(int idLigne, Color couleur)
		{
			if(_rowsBackground == null)
				_rowsBackground = new Dictionary<int, Color>();
			_rowsBackground.Add(idLigne, couleur);

			dataGridView.InvalidateRow(idLigne);
		}

		/// <summary>
		/// Permet de changer la couleur du texte d'une ligne demandée
		/// </summary>
		/// <param name="idLigne">Position de la ligne à modifier</param>
		/// <param name="couleur">Couleur du texte que la ligne prendra</param>
		public void ForegroundColor(int idLigne, Color couleur)
		{
			if (_rowsForeground == null)
				_rowsForeground = new Dictionary<int, Color>();
			_rowsForeground.Add(idLigne, couleur);

			dataGridView.InvalidateRow(idLigne);
		}

		// permet de redessiner les lignes avec d'autres effets visuels
		// cet event ne rafraichit que les lignes qui en ont besoin, efficace
		private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			dataGridView.SuspendLayout();

			if (_rowsBackground != null)
				foreach (KeyValuePair<int, Color> ligne in _rowsBackground)
					for (int colonne = 0; colonne < dataGridView.ColumnCount; colonne++)
						dataGridView.Rows[ligne.Key].Cells[colonne].Style.BackColor = ligne.Value;

			if (_rowsForeground != null)
				foreach (KeyValuePair<int, Color> ligne in _rowsForeground)
					for (int colonne = 0; colonne < dataGridView.ColumnCount; colonne++)
						dataGridView.Rows[ligne.Key].Cells[colonne].Style.ForeColor = ligne.Value;

			dataGridView.ResumeLayout();
		}

		// refait le scroll
		private void Mouse_Wheel(object sender, MouseEventArgs e)
		{
			// si on veut remonter
			if (e.Delta > 0 && dataGridView.FirstDisplayedScrollingRowIndex > 0)
				dataGridView.FirstDisplayedScrollingRowIndex--;
			else if (e.Delta < 0) // descendre
				dataGridView.FirstDisplayedScrollingRowIndex++;
		}
	}
}
