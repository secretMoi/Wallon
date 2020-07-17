using System;
using System.ComponentModel;

namespace RestServer.Models
{
	public class Tache
	{
		public int Id { get; set; }
		public string Nom { get; set; }
		public DateTime DatteFin { get; set; }

		[DefaultValue(true)]
		public bool Active { get; set; }
		public int LocataireId { get; set; } // foreign key
		public Locataire LocataireCourant { get; set; } // contenu de status lié à l'objet
		public int Cycle { get; set; }
	}
}
