using System;
using System.Windows.Forms;
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

			_controllerConsulter = new ControllerConsulter(this);

			
			//HideControls(typeof(FlatLabel));
		}

		private void HideControls(params Type[] controlsArray)
		{
			_controllerConsulter.HideControls(controlsArray);
		}

		private async void Consulter_Load(object sender, EventArgs e)
		{
			_flatDataGridView = flatDataGridView;
			

			_controllerConsulter.ListeColonnes(); // init les colonnes

			await _controllerConsulter.GetDataAsync(); // rempli les données

			AfterLoad();
		}

		public override void EffetClic(object sender, DataGridViewCellMouseEventArgs e)
		{
			_controllerConsulter.Clic(sender, e);
		}

		private void Consulter_SizeChanged(object sender, EventArgs e)
		{
			_controllerConsulter.SetLoading(panelCorps, true);
		}
	}
}
