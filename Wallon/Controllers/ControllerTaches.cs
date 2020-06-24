﻿using System;
using System.Collections.Generic;
using Wallon.Repository;

namespace Wallon.Controllers
{
	public class ControllerTaches
	{
		public ControllerTaches()
		{

		}

		public int LocataireSuivant(int idTache, int idLocataire)
		{
			List<int> liaison = new RepositoryLiaisonTachesLocataires().ListeLocataires(idTache); // liste des locataires participant à la tâche

			int indexActuel = liaison.IndexOf(idLocataire); // situe le locataire actuel dans la liste
			if(indexActuel == -1) // si la liste ne le contient pas
				throw new Exception("Le locataire " + indexActuel + " n'est pas dans la tâche " + idTache);

			return ProchainLocataire(indexActuel, liaison); // renvoie l'id du prochain locataire
		}

		/// <summary>
		/// Passe à l'élément suivant dans la liste
		/// </summary>
		/// <param name="indexActuel">Position actuelle dans la liste</param>
		/// <param name="listeLocataires">Liste en lecture seule à parcourir</param>
		/// <returns>La prochaine position dans la liste</returns>
		private int ProchainLocataire(int indexActuel, IReadOnlyList<int> listeLocataires)
		{
			if (indexActuel + 1 < listeLocataires.Count) // si il y encore des locataires dans la liste
				return listeLocataires[indexActuel + 1]; // renvoie le suivant

			return listeLocataires[0]; // renvoie le premier
		}
	}
}
