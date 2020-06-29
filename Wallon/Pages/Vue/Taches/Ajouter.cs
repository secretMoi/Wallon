using System.Windows.Forms;
using Wallon.Controllers.BaseConsulter;
using Wallon.Pages.Controllers.Taches;

namespace Wallon.Pages.Vue.Taches
{
	public partial class Ajouter : BaseConsulter
	{
		private readonly ControllerAjouter _controllerAjouter;

		public Ajouter()
		{
			InitializeComponent();

			SetTitre("Ajouter une tâche");

			_controllerAjouter = new ControllerAjouter(this);

			SetColors();

			flatTextBoxDatteDebut.Text = _controllerAjouter.FillFieldDate(); // pré-rempli la datte pour faciliter l'encodage

			flatLabelLocataireCourant.Visible = false;
			flatListBoxLocataireCourant.Visible = false;
		}

		private void Ajouter_Load(object sender, System.EventArgs e)
		{
			_flatDataGridView = flatDataGridView;

			_controllerAjouter.InitColonnes();

			_controllerAjouter.FillDgv();

			AfterLoad();
		}

		/// <summary>
		/// Fourni des paramètres à donner à la page lors de son chargement
		/// </summary>
		/// <param name="args">Arguments pouvant être passé en paramètre lors du chargement d'une page</param>
		public override void Hydrate(params object[] args)
		{
			base.Hydrate(args);

			if(!AnyArgs()) return; // si aucun argument on arrête

			_controllerAjouter.IdTache = (int)_arguments[0]; // sinon récupère l'id de la tâche

			Couche_Classe.Taches tache = _controllerAjouter.GetTache(); // récupère la tâche

			SetTitre("Modification de la tâche " + tache.Nom); // modifie le titre

			// modifie les champs
			flatTextName.Text = tache.Nom;
			flatTextBoxDatteDebut.Text = tache.DatteFin.ToShortDateString();
			flatTextBoxCycle.Text = tache.Cycle.ToString();

			flatLabelLocataireCourant.Visible = true;
			flatListBoxLocataireCourant.Visible = true;
			flatListBoxLocataireCourant.Text = _controllerAjouter.FillFieldLocataireCourant(tache.LocataireCourant);

			flatListBoxLocataireCourant.Add(_controllerAjouter.FillListLocataireCourant());

			_flatDataGridView.DataSourceChanged(_controllerAjouter.UpdateDgv);

			flatButtonAjouter.Text = @"Modifier"; // modifie le texte du bouton de validation
		}

		/// <summary>
		/// FOnction de callback lors du clic sur un élément de la FlatList
		/// </summary>
		/// <param name="sender">Bouton de la FlatList qui a lancé l'event</param>
		/// <param name="e">Arguments</param>
		private void flatButtonAjouter_Click(object sender, System.EventArgs e)
		{
			_controllerAjouter.Envoyer(
				flatTextName.Text,
				flatTextBoxDatteDebut.Text,
				flatTextBoxCycle.Text
			);
		}

		public override void EffetClic(object sender, DataGridViewCellMouseEventArgs e)
		{
			base.EffetClic(sender, e);
			_controllerAjouter.Clic(sender, e);
		}
	}
}
