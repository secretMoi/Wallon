using System;
using Models.Models;

namespace Mobile.Core
{
	public class Session
	{
		private static readonly Lazy<Session> Lazy = new Lazy<Session>(() => new Session());

		private Locataire _session;

		public static Session Instance => Lazy.Value;

		private Session()
		{

		}

		/**
		 * <summary>Vérifie si une session est crée ou pas</summary>
		 */
		public bool IsSet => _session != null;

		/**
		 * <summary>Crée une session</summary>
		 */
		public Locataire Connect
		{
			set => _session = value;
		}

		/**
		 * <summary>Détruis la session courante</summary>
		 */
		public void Disconnect()
		{
			_session = null;
		}

		/**
		 * <summary>Renvoie les informations sur la session courante</summary>
		 */
		public Locataire Get => _session;
	}
}
