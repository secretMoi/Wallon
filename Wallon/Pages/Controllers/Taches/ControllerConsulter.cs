using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Couche_Classe;
using FlatControls.Core;
using Wallon.Controllers;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerConsulter
	{
		private readonly RepositoryTaches _taches;
		private readonly Mutex _mutex = new Mutex();

		private readonly List<object[]> _list;

		public ControllerConsulter()
		{
			_taches = new RepositoryTaches();
			_list = new List<object[]>();
		}

		/// <summary>
		/// Indique la liste des colonnes à afficher dans la dgv
		/// </summary>
		/// <returns>Un tableau du nom des colonnes</returns>
		public string[] ListeColonnes()
		{
			return new[] { "Nom", "Locataire en charge", "Prochain locataire", "Date de fin" };
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		/// <param name="useGridView">Dgv où insérer les données trouvées</param>
		public async Task GetDataAsync(UseGridView useGridView)
		{
			List<Couche_Classe.Taches> taches = await _taches.LireAsync("datteFin"); // récupère les données dans la bdd

			// parrallel async mais problème de désordre
			/*List<Task> tasks = new List<Task>();

			foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
			{

				tasks.Add(Task.Run(() => AddToDgv(tache)));
			}*/

			foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
			{
				await Task.Run(() => AddToDgv(tache));
			}

			//await Task.WhenAll(tasks);

			foreach (object[] element in _list)
				useGridView.Add(element);
		}

		/// <summary>
		/// Ajoute une tâche dans la dgv
		/// </summary>
		/// <param name="tache">Données à insérer</param>
		private void AddToDgv(Couche_Classe.Taches tache)
		{
			_mutex.WaitOne();

			string dateFin;

			if (tache.Cycle == 0) // si la tâche n'a pas de cycle fixe
				dateFin = "";
			else // sinon on ajoute le cycle à la date de fin
				dateFin = tache.DatteFin.AddDays(tache.Cycle).ToShortDateString();

			int idLocataireSuivant = new ControllerTaches().LocataireSuivant(tache.Id, tache.LocataireCourant); // récupère l'id du locataire suivant
			Locataire locataireSuivant = new RepositoryLocataires().LireId(idLocataireSuivant);

			_list.Add(
				new object[]
				{
					tache.Nom,
					_taches.NomLocataireCourant(tache.LocataireCourant),
					locataireSuivant.Nom,
					dateFin
				}
			);

			_mutex.ReleaseMutex();
		}
	}
}
