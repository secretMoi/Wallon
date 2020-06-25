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
		/// Fourni des paramètres à donner à la page lors de son chargement
		/// </summary>
		/// <param name="args">Arguments pouvant être passé en paramètre lors du chargement d'une page</param>
		public override void Hydrate(params object[] args)
		{
			base.Hydrate(args);

			if(!AnyArgs()) return;

			int idTache = (int) _arguments[0];

			Couche_Classe.Taches tache = _controllerAjouter.GetTache(idTache); // récupère la tâche

			SetTitre("Modification de la tâche " + tache.Nom); // modifie le titre

			// modifie les champs
			flatTextName.Text = tache.Nom;
			flatTextBoxDatteDebut.Text = tache.DatteFin.ToShortDateString();
			flatTextBoxCycle.Text = tache.Cycle.ToString();

			flatButtonAjouter.Text = @"Modifier"; // modifie le texte du bouton de validation
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
