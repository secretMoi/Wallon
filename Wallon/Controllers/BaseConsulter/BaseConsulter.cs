using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FlatControls.Core;
using Wallon.Fenetres;
using Wallon.Pages.Vue;
using FlatDataGridView = FlatControls.Controls.FlatDataGridView;

namespace Wallon.Controllers.BaseConsulter
{
	public class BaseConsulter : ThemePanel
	{
		public UseGridView UseGridView; // permet d'insérer les données à transmettre à la dgv
		protected FlatDataGridView _flatDataGridView; // permet d'accéder en direct à la dgv
		protected List<(string, DataGridViewAutoSizeColumnMode)> _columnToResize; // gère les colonnes à redimensionner
		protected ColonnesCliquables _gestionColonnesCliquables; // gère les colonnes cliquables

		public FlatDataGridView FlatDataGridView => _flatDataGridView;

		public BaseConsulter()
		{
			InitializeComponent();

			_columnToResize = new List<(string, DataGridViewAutoSizeColumnMode)>();
		}

		/// <summary>
		/// Permet de redimensionner une colonne (string) avec un mode donné (DataGridViewAutoSizeColumnMode)
		/// <param name="colonnes">Tableau de tuples (string, typeTailleColonne)</param>
		/// </summary>
		public void AddColumnsFill(params (string, DataGridViewAutoSizeColumnMode)[] colonnes)
		{
			foreach ((string, DataGridViewAutoSizeColumnMode) colonne in colonnes) // pour chaque colonne passée en paramètre
				_columnToResize.Add(colonne);
		}

		/// <summary>
		/// Rempli les données dans la dgv et y ajoute les images de colonnes associés à leur type
		/// <param name="data">Tableau de de données constituant une ligne</param>
		/// </summary>
		public void FillDgv(params object[] data)
		{
			if (_gestionColonnesCliquables == null)
			{
				UseGridView.Add(data); // envoie la ligne vers la dgv
				return;
			}

			object[] images = new object[_gestionColonnesCliquables.GetTitlesColumn().Length];

			// récupère les colonnes cliquables
			for (int i = 0; i < _gestionColonnesCliquables.GetTitlesColumn().Length; i++)
			{
				ColonnesCliquables.Cliquable imageType = _gestionColonnesCliquables.TypeFromId(i);
				images[i] = _gestionColonnesCliquables.GetImage(imageType);
			}

			object[] finalData = new object[data.Length + images.Length]; // ligne finale à insérer

			// construit la ligne finale
			for (int i = 0; i < finalData.Length; i++)
			{
				if (i < data.Length) // si c'est une donnée normale (en param)
					finalData[i] = data[i];
				else // sinon c'est une image à rajouter
					finalData[i] = images[i - data.Length];
			}

			UseGridView.Add(finalData); // envoie la ligne vers la dgv
		}

		/// <summary>
		/// Charge les données qui ont été calculées dans la dgv
		/// </summary>
		protected virtual async void AfterLoad()
		{
			

			//_flatDataGridView.DataSource = UseGridView.Liens; // ajout(liage) des colonnes à la gridview
			await _flatDataGridView.DataSourceAsync(UseGridView.Liens); // ajout(liage) des colonnes à la gridview

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
			_flatDataGridView.AddClickMethod(EffetClic); // s'inscrit aux event de clic dans la dgv
			UseGridView = new UseGridView(titres);
		}

		/// <summary>
		/// Crée de nouvelles colonnes d'images
		/// </summary>
		/// <param name="titres">Liste des titres de chaque colonne</param>
		protected void SetColonnesCliquables(params string[] titres)
		{
			_flatDataGridView.SetColonnesCliquables(
				UseGridView.CreateImageColumn(titres)
			);
		}

		/// <summary>
		/// Retourne l'image d'un type de colonne
		/// </summary>
		/// <param name="type">Type de la colonne</param>
		/// <returns>Image</returns>
		public Image GetImageColumn(ColonnesCliquables.Cliquable type)
		{
			return _gestionColonnesCliquables.GetImage(type);
		}

		/// <summary>
		/// Active certaines colonnes connues par défaut
		/// </summary>
		/// <param name="colonnes">Liste des colonnes à activer</param>
		public void EnableColumn(params (string, ColonnesCliquables.Cliquable)[] colonnes)
		{
			if(_gestionColonnesCliquables == null)
				_gestionColonnesCliquables = new ColonnesCliquables();

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
