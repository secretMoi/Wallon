using System.Linq;
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

			_controllerAjouter = new ControllerAjouter(flatList);

			flatList.Text = @"Liste des locataires";
			flatList.Add(_controllerAjouter.ListeLocataires(), _controllerAjouter.ClickListeLocataires);

			SetColors();
		}
	}
}
