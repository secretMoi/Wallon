using Wallon.Controllers;
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

			SetColonnes(
			_controllerConsulter.ListeColonnes()
			);

			await _controllerConsulter.GetDataAsync(_useGridView);

			AfterLoad();
		}
	}
}
