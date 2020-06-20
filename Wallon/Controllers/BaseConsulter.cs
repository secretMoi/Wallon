using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Controls;
using FlatControls.Core;
using Wallon.Fenetres;
using Wallon.Pages.Vue;
using FlatDataGridView = FlatControls.Controls.FlatDataGridView;

namespace Wallon.Controllers
{
	public class BaseConsulter : ThemePanel
	{
		protected UseGridView _useGridView;
		protected FlatDataGridView _flatDataGridView;

		protected Image _imageEditer;
		protected Image _imageSupprimer;
		protected Image _imageVoir;

		private bool _editEnabled;
		private bool _deleteEnabled;
		private bool _seeEnabled;

		public BaseConsulter()
		{
			InitializeComponent();
		}

		protected object ArgumentsValides(Type type, params object[] args)
		{
			if (args.Length < 1) // vérifie qu'il y a bien un argument
				return null;

			Type typ = GetType();

			object objet = args[0]; // cast l'argument

			return objet;
		}

		protected virtual void AfterLoad()
		{
			_flatDataGridView.AddClickMethod(EffetClic); // s'inscrit aux event de clic dans la dgv

			_flatDataGridView.DataSource = _useGridView.Liens; // ajout(liage) des colonnes à la gridview

			if (_editEnabled)
				_flatDataGridView.Column["Editer"].Width = 150;
			if (_deleteEnabled)
				_flatDataGridView.Column["Supprimer"].Width = 200;
			if (_seeEnabled)
				_flatDataGridView.Column["Voir"].Width = 150;
		}

		protected void SetColonnes(params string[] titres)
		{
			_useGridView = new UseGridView(titres);
		}

		protected void SetColonnesCliquables(params string[] titres)
		{
			_flatDataGridView.SetColonnesCliquables(
				_useGridView.CreateImageColumn(titres)
			);
		}

		protected void EnableColumn(params string[] colonnes)
		{
			if (colonnes.Contains("editer"))
			{
				_editEnabled = true;
				SetColonnesCliquables("Editer");
				_imageEditer = Image.FromFile("Ressources/Images/editer.png");
			}
			if (colonnes.Contains("supprimer"))
			{
				_deleteEnabled = true;
				SetColonnesCliquables("Supprimer");
				_imageSupprimer = Image.FromFile("Ressources/Images/supprimer.png");
			}
			if (colonnes.Contains("voir"))
			{
				_seeEnabled = true;
				SetColonnesCliquables("Voir");
				_imageVoir = Image.FromFile("Ressources/Images/loupe.png");
			}
		}

		public virtual void EffetClic(object sender, DataGridViewCellMouseEventArgs e)
		{

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
