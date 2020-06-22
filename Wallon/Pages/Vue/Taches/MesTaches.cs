using System.Windows.Forms;
using Wallon.Controllers;
using Wallon.Pages.Controllers.Taches;

namespace Wallon.Pages.Vue.Taches
{
	public partial class MesTaches : BaseConsulter
	{
		private readonly ControllerMesTaches _controllerMesTaches;

		public MesTaches()
		{
			InitializeComponent();

			_controllerMesTaches = new ControllerMesTaches(flatDataGridView, this);

			SetTitre("Mes tâches");
		}

		public override void Hydrate(params object[] args)
		{
			base.Hydrate(args);

			if (args.Length == 0) return;

			alerte.ThemeValid();
			alerte.Show(args[0] as string);
		}

		private void MesTaches_Load(object sender, System.EventArgs e)
		{
			_flatDataGridView = flatDataGridView;

			SetColonnes(
				_controllerMesTaches.ListeColonnes()
			);

			_controllerMesTaches.ColonnesCliquables(this);

			_controllerMesTaches.GetData(_useGridView, this);

			AfterLoad();
		}

		public override void EffetClic(object sender, DataGridViewCellMouseEventArgs e)
		{
			_controllerMesTaches.Clic(sender, e);
		}
	}
}
