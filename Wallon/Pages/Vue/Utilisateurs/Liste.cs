﻿using System;
using Wallon.Controllers;
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

		private void Liste_Load(object sender, EventArgs e)
		{
			_flatDataGridView = flatDataGridView;

			SetColonnes(
				_controllerListe.ListeColonnes()
			);

			_controllerListe.GetData(_useGridView);

			AfterLoad();
		}
	}
}