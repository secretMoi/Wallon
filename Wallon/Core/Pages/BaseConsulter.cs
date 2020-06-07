using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Controls;
using QMag.Controls;
using Wallon.Fenetres;

namespace QMag.Core.Pages
{
	public partial class BaseConsulter : ThemePanel
	{
		protected UseGridView _useGridView;
		protected FlatDataGridView _flatDataGridView;

		protected Image _imageEditer;
		protected Image _imageSupprimer;
		protected Image _imageVoir;

		private bool _editEnabled = false;
		private bool _deleteEnabled = false;
		private bool _seeEnabled = false;

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
			if(_deleteEnabled)
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
	}
}
