﻿namespace RestServer.Dtos.Locataires
{
	public class LocataireReadDto
	{
		public int Id { get; set; }

		public string Nom { get; set; }

		public byte[] Password { get; set; }

		public bool Actif { get; set; }
	}
}