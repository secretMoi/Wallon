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

			flatTextBoxDatteDebut.Text = _controllerAjouter.FillFieldDate(); // pré-rempli la datte pour faciliter l'encodage
		}

		/// <summary>
		/// FOnction de callback lors du clic sur un élément de la FlatList
		/// </summary>
		/// <param name="sender">Bouton de la FlatList qui a lancé l'event</param>
		/// <param name="e">Arguments</param>
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
