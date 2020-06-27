using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using FlatControls.Core;
using Wallon.Fenetres;
using Wallon.Pages.Vue;
using FlatDataGridView = FlatControls.Controls.FlatDataGridView;

namespace Wallon.Controllers
{
	public class BaseConsulter : ThemePanel
	{
		public UseGridView _useGridView;
		protected FlatDataGridView _flatDataGridView;
		protected List<(string, DataGridViewAutoSizeColumnMode)> _columnToFill;

		public Image ImageEditer;
		public Image ImageSupprimer;
		public Image ImageVoir;
		public Image ImageValider;
		public Image ImageUp;
		public Image ImageDown;

		private bool _editEnabled;
		private bool _deleteEnabled;
		private bool _seeEnabled;
		private bool _validateEnabled;
		private bool _upEnabled;
		private bool _downEnabled;

		public FlatDataGridView FlatDataGridView => _flatDataGridView;

		public BaseConsulter()
		{
			InitializeComponent();

			_columnToFill = new List<(string, DataGridViewAutoSizeColumnMode)>();
		}

		public void AddColumnsFill(params (string, DataGridViewAutoSizeColumnMode)[] colonnes)
		{
			foreach ((string, DataGridViewAutoSizeColumnMode) colonne in colonnes)
				_columnToFill.Add(colonne);
		}

		/// <summary>
		/// Charge les données qui ont été calculées dans la dgv
		/// </summary>
		protected virtual async void AfterLoad()
		{
			_flatDataGridView.AddClickMethod(EffetClic); // s'inscrit aux event de clic dans la dgv

			//_flatDataGridView.DataSource = _useGridView.Liens; // ajout(liage) des colonnes à la gridview
			await _flatDataGridView.DataSourceAsync(_useGridView.Liens); // ajout(liage) des colonnes à la gridview

			foreach ((string, DataGridViewAutoSizeColumnMode) colonne in _columnToFill)
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

		/// <summary>
		/// Active certaines colonnes connues par défaut
		/// </summary>
		/// <param name="colonnes">Liste des colonnes à activer</param>
		public void EnableColumn(params string[] colonnes)
		{
			//todo automatiser avec dictionnaire + enum
			foreach (string colonne in colonnes)
			{
				if (colonne == "editer")
				{
					_editEnabled = true;
					SetColonnesCliquables("Editer");

					SetImage(ref ImageEditer, "editer");
				}
				else if (colonne == "supprimer")
				{
					_deleteEnabled = true;
					SetColonnesCliquables("Supprimer");

					SetImage(ref ImageSupprimer, "supprimer");
				}
				else if (colonne == "voir")
				{
					_seeEnabled = true;
					SetColonnesCliquables("Voir");

					SetImage(ref ImageVoir, "loupe");
				}
				else if (colonne == "valider")
				{
					_validateEnabled = true;
					SetColonnesCliquables("Valider");

					SetImage(ref ImageValider, "correct");
				}
				else if (colonne == "up")
				{
					_upEnabled = true;
					SetColonnesCliquables("Monter");

					SetImage(ref ImageUp, "arrow-up-sign-to-navigate");
				}
				else if (colonne == "down")
				{
					_downEnabled = true;
					SetColonnesCliquables("Descendre");

					SetImage(ref ImageDown, "arrow-down-sign-to-navigate");
				}
			}
		}

		private void SetImage(ref Image image, string path)
		{
			image = Image.FromFile("Ressources/Images/" + path + ".png");
			image = ResizeImage(image, new Size(32, 32));
		}

		/// <summary>
		/// Redimensionne une image dans une colonne
		/// </summary>
		/// <param name="image">Image à redimensionner</param>
		/// <param name="size">Taille que l'image doit atteindre</param>
		/// <param name="preserveAspectRatio">Booléen indiquant si l'image peut être déformée ou non, ratio préservé par défaut</param>
		public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
		{
			int newWidth;
			int newHeight;

			if (size == image.Size)
				return image;

			if (preserveAspectRatio)
			{
				int originalWidth = image.Width;
				int originalHeight = image.Height;

				float percentWidth = (float)size.Width / (float)originalWidth;
				float percentHeight = (float)size.Height / (float)originalHeight;
				float percent = percentHeight < percentWidth ? percentHeight : percentWidth;

				newWidth = (int)(originalWidth * percent);
				newHeight = (int)(originalHeight * percent);
			}
			else
			{
				newWidth = size.Width;
				newHeight = size.Height;
			}

			Image newImage = new Bitmap(newWidth, newHeight);

			using (Graphics graphicsHandle = Graphics.FromImage(newImage))
			{
				graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
			}

			return newImage;
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
