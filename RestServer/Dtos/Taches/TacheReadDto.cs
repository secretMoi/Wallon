using System;
using RestServer.Models;

namespace RestServer.Dtos.Taches
{
	// copié/collé de la classe Tache
	// on retire les annotations car inutiles, on ne va pas dialoguer avec la bdd
	public class TacheReadDto
	{
		public int Id { get; set; }

		public int Nom { get; set; }

		public DateTime DatteFin { get; set; }

		public bool Active { get; set; }

		public int LocataireId { get; set; } // foreign key
		public Locataire LocataireCourant { get; set; } // contenu de status lié à l'objet

		public int Cycle { get; set; }
	}
}
