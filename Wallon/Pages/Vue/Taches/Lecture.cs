using Wallon.Pages.Controllers.Taches;

namespace Wallon.Pages.Vue.Taches
{
	public partial class Lecture : ThemePanel
	{
		private readonly ControllerLecture _controllerLecture = new ControllerLecture();

		public Lecture()
		{
			InitializeComponent();

			SetColors();
		}

		public override async void Hydrate(params object[] args)
		{
			base.Hydrate(args);
			if (!AnyArgs()) return; // si aucun argument on arrête

			await _controllerLecture.Hydrate((int)_arguments[0]);

			SetTitre("Lecture de la tâche " + _controllerLecture.Tache.Nom);

			flatTextBoxDescription.Text = _controllerLecture.Tache.Description;
		}

		private void flatTextBoxDescription_Resize(object sender, System.EventArgs e)
		{
			_controllerLecture.SetSizeTextField(flatTextBoxDescription);
		}

		private async void flatButtonModifier_Click(object sender, System.EventArgs e)
		{
			await _controllerLecture.Modifier(flatTextBoxDescription.Text);
		}
	}
}