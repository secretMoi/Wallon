using System.Collections.Generic;
using System.Threading.Tasks;
using FlatControls.Core;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerConsulter
	{
		private readonly RepositoryTaches _taches;

		public ControllerConsulter()
		{
			_taches = new RepositoryTaches();
		}

		/// <summary>
		/// Indique la liste des colonnes à afficher dans la dgv
		/// </summary>
		/// <returns>Un tableau du nom des colonnes</returns>
		public string[] ListeColonnes()
		{
			return new[] { "Nom", "Locataire en charge", "DatteFin" };
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		/// <param name="useGridView">Dgv où insérer les données trouvées</param>
		public async Task GetDataAsync(UseGridView useGridView)
		{
			//List<Couche_Classe.Taches> taches = _taches.Lire("id"); // récupère les données dans la bdd
			List<Couche_Classe.Taches> taches = await _taches.LireAsync("id"); // récupère les données dans la bdd
			List<Task> tasks = new List<Task>();

			foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
				tasks.Add(Task.Run(() => AddToDgv(useGridView, tache)));

			await Task.WhenAll(tasks);
		}

		/// <summary>
		/// Ajoute une tâche dans la dgv
		/// </summary>
		/// <param name="useGridView">Dgv où insérer les données</param>
		/// <param name="tache">Données à insérer</param>
		private void AddToDgv(UseGridView useGridView, Couche_Classe.Taches tache)
		{
			useGridView.Add(
				tache.Nom,
				_taches.NomLocataireCourant(tache.LocataireCourant),
				tache.DatteFin.ToShortDateString()
			);
		}
	}
}
