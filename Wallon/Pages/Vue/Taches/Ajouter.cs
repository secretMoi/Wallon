using Controls;
using Wallon.Pages.Controllers.Taches;

namespace Wallon.Pages.Vue.Taches
{
	public partial class Ajouter : ThemePanel
	{
		private readonly ControllerAjouter _controllerAjouter;

		public Ajouter()
		{
			InitializeComponent();

			SetTitre("Ajouter une tâche");

			_controllerAjouter = new ControllerAjouter();

			flatList.Text = @"Liste des locataires";
			flatList.Add(_controllerAjouter.ListeLocataires());

			SetColors();
		}

		private void flatButtonAjouter_Click(object sender, System.EventArgs e)
		{
			_controllerAjouter.Ajouter(
				flatTextName.Text,
				flatTextBoxDatteDebut.Text,
				flatTextBoxCycle.Text,
				flatList.SelectedId()
			);
		}
	}
}
