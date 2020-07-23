using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlatControls.Core;
using Couche_Classe;
using Models.Dtos.Locataires;
using Wallon.Pages.Vue.Utilisateurs;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerListe
	{
		private readonly RepositoryLocataires _repositoryLocataires = RepositoryLocataires.Instance;

		/// <summary>
		/// Indique la liste des colonnes à afficher dans la dgv
		/// </summary>
		/// <param name="page">Page contenant les méthodes pour peupler les colonnes</param>
		public void ListeColonnes(Liste page)
		{
			page.SetColonnes("Nom");

			page.AddColumnsFill(
				("Nom", DataGridViewAutoSizeColumnMode.Fill)
			);
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		/// <param name="useGridView">Dgv où insérer les données trouvées</param>
		public async Task GetData(UseGridView useGridView)
		{
			IList<LocataireReadDto> locataires = await _repositoryLocataires.Lire(); // récupère les données dans la bdd

			foreach (LocataireReadDto locataire in locataires) // les lie à la dgv
				useGridView.Add(
					locataire.Nom
				);
		}
	}
}
