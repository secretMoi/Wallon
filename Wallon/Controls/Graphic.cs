using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Core;
using Core.Figures;
using QMag.Core.Graphique;

namespace QMag.Controls
{
	public partial class Graphic : PictureBox
	{
		private Graphique _graphique;
		private readonly Spirographe _spirographe;

		public Graphic()
		{
			InitializeComponent();

			Figure.InitialiseConteneur(this);
			_spirographe = new Spirographe();
		}

		public void Rafraichir()
		{
			_graphique = new Graphique(
				this,
				new Couple(Width / 2, Height / 2),
				new Couple(Width, Height)
			);

			_graphique.ListePoints(_spirographe.InverseY());

			Invalidate();
		}

		[Category("Apparence")]
		public bool AjoutPoint(Couple point)
		{
			bool resultat = _spirographe.Add(point);

			Rafraichir();

			return resultat;
		}

		public void Encadre(List<int> positionPoints)
		{
			_graphique.EncadreNettoie();
			Spirographe points = new Spirographe();

			foreach (int position in positionPoints)
				points.Add(_spirographe[position]);

			_graphique.Encadre(points.InverseY());
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if(e != null)
				_graphique.Affiche(e.Graphics);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			/*_spirographe.Add(0, 0);
			_spirographe.Add(50, -50);
			_spirographe.Add(60, -50);
			_spirographe.Add(75, -75);
			_spirographe.Add(100, 100);
			_spirographe.Add(110, 100);*/

			Rafraichir();
		}

		public Spirographe Points => _spirographe;
	}
}
