using System;
using Wallon.Controllers.BaseConsulter;
using Wallon.Pages.Controllers.Utilisateurs;

namespace Wallon.Pages.Vue.Utilisateurs
{
	public partial class Liste : BaseConsulter
	{
		private readonly ControllerListe _controllerListe;

		public Liste()
		{
			InitializeComponent();

			SetTitre("Liste des locataires");

			_controllerListe = new ControllerListe();
		}

		private async void Liste_Load(object sender, EventArgs e)
		{
			_flatDataGridView = flatDataGridView;

			_controllerListe.ListeColonnes(this);

			await _controllerListe.GetData(UseGridView);

			AfterLoad();
		}
	}
}