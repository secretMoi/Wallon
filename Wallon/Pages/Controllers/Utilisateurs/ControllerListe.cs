using System.Collections.Generic;
using System.Windows.Forms;
using FlatControls.Core;
using Couche_Classe;
using Wallon.Pages.Vue.Utilisateurs;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Utilisateurs
{
	public class ControllerListe
	{
		private readonly RepositoryLocataires _locataire;

		public ControllerListe()
		{
			_locataire = new RepositoryLocataires();
		}

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
		public void GetData(UseGridView useGridView)
		{
			List<Locataire> locataires = _locataire.Lire("id"); // récupère les données dans la bdd

			foreach (Locataire locataire in locataires) // les lie à la dgv
				useGridView.Add(
					locataire.Nom
				);
		}
	}
}
