using System;
using Models.Dtos.Locataires;

namespace Mobile.Core
{
	public class Session
	{
		private static readonly Lazy<Session> Lazy = new Lazy<Session>(() => new Session());

		private LocataireReadDto _session;

		public static Session Instance => Lazy.Value;

		private Session()
		{

		}

		/**
		 * <summary>Vérifie si une session est créée ou pas</summary>
		 */
		public bool IsSet => _session != null;

		/**
		 * <summary>Crée une session</summary>
		 */
		public LocataireReadDto Connect
		{
			set
			{
				_session = value;
				//AppShell.Instance.ConnectionState = IsSet;
			}
		}

		/**
		 * <summary>Détruis la session courante</summary>
		 */
		public void Disconnect()
		{
			_session = null;
			//AppShell.Instance.ConnectionState = IsSet;
		}

		/**
		 * <summary>Renvoie les informations sur la session courante</summary>
		 */
		public LocataireReadDto Get => _session;
	}
}
