﻿using Wallon.Controllers;
using Wallon.Pages.Controllers.Taches;

namespace Wallon.Pages.Vue.Taches
{
	public partial class MesTaches : BaseConsulter
	{
		private readonly ControllerMesTaches _controllerMesTaches;

		public MesTaches()
		{
			InitializeComponent();

			_controllerMesTaches = new ControllerMesTaches();

			SetTitre("Mes tâches");
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
	}
}
