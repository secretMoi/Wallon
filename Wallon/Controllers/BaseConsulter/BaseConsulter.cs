using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatControls.Core;
using Wallon.Fenetres;
using Wallon.Pages.Vue;
using FlatDataGridView = FlatControls.Controls.FlatDataGridView;

namespace Wallon.Controllers.BaseConsulter
{
	public class BaseConsulter : ThemePanel
	{
		public UseGridView _useGridView;
		protected FlatDataGridView _flatDataGridView;
		protected List<(string, DataGridViewAutoSizeColumnMode)> _columnToResize;
		protected BaseConsulterColonnesCliquables _gestionColonnesCliquables;

		public Image ImageEditer;
		public Image ImageSupprimer;
		public Image ImageVoir;
		public Image ImageValider;
		public Image ImageUp;
		public Image ImageDown;

		public FlatDataGridView FlatDataGridView => _flatDataGridView;

		public BaseConsulter()
		{
			InitializeComponent();

			_columnToResize = new List<(string, DataGridViewAutoSizeColumnMode)>();
		}

		public void AddColumnsFill(params (string, DataGridViewAutoSizeColumnMode)[] colonnes)
		{
			foreach ((string, DataGridViewAutoSizeColumnMode) colonne in colonnes)
				_columnToResize.Add(colonne);
		}

		/// <summary>
		/// Charge les données qui ont été calculées dans la dgv
		/// </summary>
		protected virtual async void AfterLoad()
		{
			_flatDataGridView.AddClickMethod(EffetClic); // s'inscrit aux event de clic dans la dgv

			//_flatDataGridView.DataSource = _useGridView.Liens; // ajout(liage) des colonnes à la gridview
			await _flatDataGridView.DataSourceAsync(_useGridView.Liens); // ajout(liage) des colonnes à la gridview

			foreach ((string, DataGridViewAutoSizeColumnMode) colonne in _columnToResize)
				if(_flatDataGridView.Column.Contains(colonne.Item1))
					_flatDataGridView.Column[colonne.Item1].AutoSizeMode = colonne.Item2;
		}

		/// <summary>
		/// Crée de nouvelles colonnes de texte
		/// </summary>
		/// <param name="titres">Liste des titres de chaque colonne</param>
		public void SetColonnes(params string[] titres)
		{
			_useGridView = new UseGridView(titres);
		}

		/// <summary>
		/// Crée de nouvelles colonnes d'images
		/// </summary>
		/// <param name="titres">Liste des titres de chaque colonne</param>
		protected void SetColonnesCliquables(params string[] titres)
		{
			_flatDataGridView.SetColonnesCliquables(
				_useGridView.CreateImageColumn(titres)
			);
		}

		public Image GetImageColumn(BaseConsulterColonnesCliquables.Cliquable type)
		{
			return _gestionColonnesCliquables.GetImage(type);
		}

		/// <summary>
		/// Active certaines colonnes connues par défaut
		/// </summary>
		/// <param name="colonnes">Liste des colonnes à activer</param>
		public void EnableColumn(params (string, BaseConsulterColonnesCliquables.Cliquable)[] colonnes)
		{
			if(_gestionColonnesCliquables == null)
				_gestionColonnesCliquables = new BaseConsulterColonnesCliquables();

			_gestionColonnesCliquables.Enable(colonnes);

			SetColonnesCliquables(_gestionColonnesCliquables.GetTitlesColumn());
		}

		/// <summary>
		/// Méthode pouvant être redéfinie afin de customiser les events de clic dans la dgv
		/// </summary>
		/// <param name="sender">Control lançant l'event</param>
		/// <param name="e">Arguments éventuels</param>
		public virtual void EffetClic(object sender, DataGridViewCellMouseEventArgs e)
		{
			int ligne = e.RowIndex;
			int colonne = e.ColumnIndex;

			if (colonne == _flatDataGridView.GetColumnId("Monter") && ligne > 0) // si la colonne cliquée correspond
			{
				_flatDataGridView.SwapRow(ligne, ligne - 1);
			}
			if (colonne == _flatDataGridView.GetColumnId("Descendre") && ligne < _flatDataGridView.Rows.Count - 1) // si la colonne cliquée correspond
			{
				_flatDataGridView.SwapRow(ligne, ligne + 1);
			}
		}

		protected DialogResult DialogDelete(string question)
		{
			return Dialog.ShowYesNo("Voulez-vous vraiment supprimer " + question);
		}

		private new void InitializeComponent()
		{
			panelTitre.SuspendLayout();
			SuspendLayout();
			// 
			// panelTitre
			// 
			panelTitre.Size = new Size(1856, 120);
			// 
			// panelCorps
			// 
			panelCorps.Size = new Size(1856, 773);
			// 
			// BaseConsulter
			// 
			AutoScaleDimensions = new SizeF(96F, 96F);
			Name = "BaseConsulter";
			Size = new Size(1856, 893);
			panelTitre.ResumeLayout(false);
			panelTitre.PerformLayout();
			ResumeLayout(false);

		}
	}
}
