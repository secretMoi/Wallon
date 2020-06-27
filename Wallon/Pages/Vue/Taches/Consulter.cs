using System.Windows.Forms;
using Wallon.Controllers;
using Wallon.Controllers.BaseConsulter;
using Wallon.Pages.Controllers.Taches;

namespace Wallon.Pages.Vue.Taches
{
	public partial class Consulter : BaseConsulter
	{
		private readonly ControllerConsulter _controllerConsulter;

		public Consulter()
		{
			InitializeComponent();

			SetTitre("Liste des tâches");

			_controllerConsulter = new ControllerConsulter();
		}

		private async void Consulter_Load(object sender, System.EventArgs e)
		{
			_flatDataGridView = flatDataGridView;

			_controllerConsulter.ListeColonnes(this); // init les colonnes

			await _controllerConsulter.GetDataAsync(_useGridView); // rempli les données

			AfterLoad();
		}

		public override void EffetClic(object sender, DataGridViewCellMouseEventArgs e)
		{
			_controllerConsulter.Clic(sender, e);
		}
	}
}
