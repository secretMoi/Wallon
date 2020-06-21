﻿using System;
using System.Collections.Generic;
using Couche_Classe;
using Couche_Gestion;
using Wallon.Controllers;

namespace Wallon.Repository
{
	public class RepositoryTaches
	{
		private readonly GestionTaches _gestion;

		public RepositoryTaches()
		{
			_gestion = new GestionTaches(Settings.Connection);
		}

		public List<Taches> Lire(string index)
		{
			try
			{
				return _gestion.Lire(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire les tâches : \n" + ex.Message);
			}
		}

		public Taches LireId(int index)
		{
			try
			{
				return _gestion.LireId(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire la tâche " + index + "  : \n" + ex.Message);
			}
		}

		public List<Taches> TachesCourantesDuLocataire(int idLocataireCourant)
		{
			try
			{
				return _gestion.TachesCourantesDuLocataire(idLocataireCourant);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de lire les tâches du locataire " + idLocataireCourant + "  : \n" + ex.Message);
			}
		}

		/*public int Supprimer(int index)
		{
			try
			{
				return _gestion.Supprimer(index);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de supprimer le locataire avec l'id " + index + "  : \n" + ex.Message);
			}
		}*/

		public int Ajouter(Taches tache)
		{
			try
			{
				return _gestion.Ajouter(tache);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible d'ajouter la tâche " + tache.Nom + "  : \n" + ex.Message);
			}
		}

		public int ModifierLocataireCourant(int id, int idLocataire)
		{
			try
			{
				Taches tache = LireId(id); // récupère les infos sur la tâche
				tache.DatteFin = tache.DatteFin.AddDays(tache.Cycle); // met à jour la datte de fin
				tache.LocataireCourant = idLocataire; // met à jour le locataire courant

				return _gestion.Modifier(tache);
			}
			catch (Exception ex)
			{
				throw new Exception("Impossible de modifier la tâche " + id + "  : \n" + ex.Message);
			}
		}

		/// <summary>
		/// Récupère le nom du locataire grâce à son id
		/// </summary>
		/// <param name="id">Id du locataire</param>
		/// <returns>Le nom du locataire</returns>
		public string NomLocataireCourant(int id)
		{
			return new ControllerLocataires().GetById(id).Nom;
		}
	}
}
