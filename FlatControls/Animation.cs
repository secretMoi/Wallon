using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FlatControls
{
	public class Animation
	{
		private Timer _timer;
		private object[] _args;

		private readonly Control _control;
		private static Dictionary<Control, Timer> _controlsUsed = new Dictionary<Control, Timer>();

		private delegate void SafeCallDelegate(object source, ElapsedEventArgs e);

		public Animation(Control control)
		{
			_control = control;
		}

		public void Zoom(int nouvelleTaille)
		{
			_args = new object[]
			{
				nouvelleTaille,
				1
			};

			if (_controlsUsed.ContainsKey(_control))
			{
				_controlsUsed[_control].Stop();
				_controlsUsed.Remove(_control);
			}

			SetTimer(OnTimedEvent);
			_controlsUsed.Add(_control, _timer);
		}

		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			int tailleFinale = (int)_args[0];
			int vitesse = (int)_args[1];

			if (_control.InvokeRequired) // si besoin d'invoquer depuis le thread UI
			{
				var d = new SafeCallDelegate(OnTimedEvent);
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
					_controlsUsed.Remove(_control);
					return;
				}

				Point nouvellePosition = new Point(
					_control.Location.X + (_control.Width + (vitesse * sensZoom) - ancienneTaille.Width) / 2,
					_control.Location.Y + (_control.Height + (vitesse * sensZoom) - ancienneTaille.Height) / 2
				);
				_control.Location = nouvellePosition;
				_control.Size = new Size(_control.Width + (vitesse * sensZoom), _control.Height + (vitesse * sensZoom));
			}
		}

		private void SetTimer(ElapsedEventHandler tickMethod)
		{
			_timer = new Timer(15);
			_timer.Elapsed += tickMethod;
			_timer.AutoReset = true;
			_timer.Enabled = true;
		}
	}
}
