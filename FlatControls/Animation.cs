using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FlatControls
{
	public class Animation
	{
		private Timer _timer; // timer à utiliser
		private object[] _args; // liste d'arguments pour les fonctions threaddées

		private readonly Control _control; // control qui sera animé

		// liste statique des control et les timers qu'ils utilisent pour éviter les conflits
		private static readonly Dictionary<Control, Timer> ControlsUsed = new Dictionary<Control, Timer>();

		// délégué à appeler pour éviter les conflits inter-thread
		private delegate void SafeCallDelegate(object source, ElapsedEventArgs e);

		/// <summary>
		/// Constructeur de la classe Animation
		/// </summary>
		/// <param name="control">Nom du control qui sera animé</param>
		public Animation(Control control)
		{
			_control = control;
		}

		/// <summary>
		/// Génère un tableau d'arguments
		/// </summary>
		/// <param name="args">Liste des arguments à ajouter</param>
		private void CreateArgs(params object[] args)
		{
			_args = args;
		}

		/// <summary>
		/// Stop le timer et libère le control si il est déjà utilisé dans une autre animation
		/// </summary>
		private void FreeControl()
		{
			if (ControlsUsed.ContainsKey(_control))
			{
				ControlsUsed[_control].Stop();
				ControlsUsed.Remove(_control);
			}
		}

		/// <summary>
		/// Lance l'animation
		/// </summary>
		/// <param name="onTimedEvent">Liste des arguments à ajouter</param>
		private void LaunchAnimation(ElapsedEventHandler onTimedEvent)
		{
			SetTimer(onTimedEvent); // lance le timer
			ControlsUsed.Add(_control, _timer); // ajoute l'animation à la liste statique
		}

		/// <summary>
		/// Permet de zoomer (in & out) jusq'à une taille finale
		/// </summary>
		/// <param name="nouvelleTaille">Taille que le control doit atteindre à la fin de l'animation</param>
		public void Zoom(int nouvelleTaille)
		{
			CreateArgs(nouvelleTaille, 2); // génère les arguments

			FreeControl(); // s'assure de terminer les autres animations sur CE control

			LaunchAnimation(ZoomTickEvent); // démarre l'animation
		}

		/// <summary>
		/// Code exécuter lors du zoom sur un control
		/// </summary>
		/// <param name="source">Control ayant lancé l'event</param>
		/// <param name="e">Arguments du timer</param>
		private void ZoomTickEvent(object source, ElapsedEventArgs e)
		{
			int tailleFinale = (int)_args[0];
			int vitesse = (int)_args[1];

			if (_control.InvokeRequired) // si besoin d'invoquer depuis le thread UI
			{
				var d = new SafeCallDelegate(ZoomTickEvent);
				_control.Invoke(d, source, e);
			}
			else
			{
				int sensZoom = 1;

				Size ancienneTaille = _control.Size;

				if (tailleFinale < ancienneTaille.Width)
					sensZoom = -1;

				if (_control.Size.Width >= tailleFinale && sensZoom == 1)
				{
					_timer.Stop();
					return;
				}
				else if (_control.Size.Width <= tailleFinale && sensZoom == -1)
				{
					_timer.Stop();
					ControlsUsed.Remove(_control);
					return;
				}

				Point nouvellePosition = new Point(
					_control.Location.X + vitesse / 2  * sensZoom * (-1),
					_control.Location.Y + vitesse / 2 * sensZoom * (-1)
				);
				_control.Location = nouvellePosition;
				_control.Size = new Size(_control.Width + (vitesse * sensZoom), _control.Height + (vitesse * sensZoom));
			}
		}

		/// <summary>
		/// Démarre le timer
		/// </summary>
		/// <param name="tickMethod">Méthode à appeler lors de chaque tick</param>
		private void SetTimer(ElapsedEventHandler tickMethod)
		{
			_timer = new Timer(15);
			_timer.Elapsed += tickMethod;
			_timer.AutoReset = true;
			_timer.Enabled = true;
		}
	}
}
