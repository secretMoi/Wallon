using System;
using System.Collections.Generic;
using FlatControls.Core;
using Wallon.Controllers;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerMesTaches
	{
		private readonly RepositoryTaches _taches;

		public ControllerMesTaches()
		{
			_taches = new RepositoryTaches();
		}

		/// <summary>
		/// Indique la liste des colonnes à afficher dans la dgv
		/// </summary>
		/// <returns>Un tableau du nom des colonnes</returns>
		public string[] ListeColonnes()
		{
			return new[]
			{
				"Nom",
				"Temps restant (en jours)"
			};
		}

		public void ColonnesCliquables(BaseConsulter baseConsulter)
		{
			baseConsulter.EnableColumn("valider");
		}

		/// <summary>
		/// Récupère les données demandées et les ajoute à la dgv
		/// </summary>
		/// <param name="useGridView">Dgv où insérer les données trouvées</param>
		public void GetData(UseGridView useGridView, BaseConsulter baseConsulter)
		{
			List<Couche_Classe.Taches> taches = _taches.Lire("id"); // récupère les données dans la bdd

			//todo lire les taches seulement de l'utilisateur courant
			//todo ajout event valider

			foreach (Couche_Classe.Taches tache in taches) // les lie à la dgv
				useGridView.Add(
					tache.Nom,
					(tache.DatteFin - DateTime.Now.Date).Days,
					baseConsulter._imageValider
				);
		}
	}
}
