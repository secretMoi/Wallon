using System;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Models;

namespace Models.Dtos.Taches
{
	// copié/collé de la classe Tache
	// on retire les annotations car inutiles, on ne va pas dialoguer avec la bdd
	public class TacheReadDto : IRead
	{
		public int Id { get; set; }

		public string Nom { get; set; }

		public DateTime DateFin { get; set; }

		public bool? Active { get; set; }

		public int LocataireId { get; set; } // foreign key

		[ForeignKey("LocataireId")]
		public virtual Locataire Locataire { get; set; } // contenu de status lié à l'objet

		public int Cycle { get; set; }
	}
}
