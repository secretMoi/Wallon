﻿using System.ComponentModel;

namespace RestServer.Models
{
	public class Locataire
	{
		public int Id { get; set; }

		public string Nom { get; set; }

		public byte[] Password { get; set; }

		[DefaultValue(true)]
		public bool Actif { get; set; }
	}
}
