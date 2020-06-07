using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QMag.Controls;

namespace QMag.Core
{
	public class UseGridView
	{
		private readonly DataTable _table;
		private readonly BindingSource _liens;
		//private FlatDataGridView _flatDataGridView;
		private int _nombreElements;

		public UseGridView()
		{
			_table = new DataTable();
			_liens = new BindingSource();
		}

		public UseGridView(params string[] titles) : this()
		{
			CreateColumns(titles);
		}

		public void CreateColumns(params string[] titles)
		{
			foreach (string title in titles)
				_table.Columns.Add(new DataColumn(title));
		}

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

		public void Add(params object[] records)
		{
			_table.Rows.Add(records);
			_liens.DataSource = _table;
			_nombreElements++;
		}

		public int Count => _nombreElements;
		public BindingSource Liens => _liens;
	}
}
