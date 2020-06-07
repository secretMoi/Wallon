using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Figures;
using QMag.Controls;

namespace QMag.Core.Graphique
{
	public class Graphique
	{
		private int _compteur;
		private int _compteurCadre;
		private readonly Dictionary<int, double> _maximum;
		private readonly Couple _dimensionsFenetre;
		private readonly Couple _ajustementZoom;
		private readonly ElementGraphic _element;

		private const int Gauche = 0, Haut = 1, Droite = 2, Bas = 3;
		private const string AxeX = "Abscisse", Point = "Point", Cadre = "Cadre", Ligne = "Ligne";

		public Graphique(PictureBox pictureBox, Couple position, Couple dimensionsFenetre)// : base(position)
		{
			_element = new ElementGraphic(Graphics.FromHwnd(pictureBox.Handle));
			_element.Positionne(position);

			this._dimensionsFenetre = dimensionsFenetre.Copie();
			_compteur = 0;
			_compteurCadre = 0;
			_ajustementZoom = new Couple();

			_maximum = new Dictionary<int, double>
			{
				{Gauche, Couple.MinValue},
				{Haut, Couple.MinValue},
				{Droite, Couple.MaxValue},
				{Bas, Couple.MaxValue}
			};
		}

		public void ListePoints(List<Couple> points)
		{
			if (!points.Any()) return;

			TrouveMaximum(points); // trouve les points extremes
			Zoom(); // effectue un "zoom" pour que les points collent au bord de la fenêtre
			Abscisse(); // place les axes
			PlacePoints(points); // place les points
			Relier(); // relie les points entre eux
			
		}

		private void Abscisse()
		{
			_element.Dimensionne(_dimensionsFenetre.Xi, 4);

			_element.Positionne(
				0,
				PositionneY(0, _element.GetDimension.Y / 2)
				//-PositionneY(0, _element.GetDimension.Y / 2)
			);

			_element.AjouterRectangle(AxeX, Color.Red);
		}

		private void PlacePoints(List<Couple> points)
		{
			_element.Dimensionne(6, 6); // définit la taille du point

			foreach (Couple point in points)
			{
				_element.Positionne(Positionne(point));

				_element.AjouterDisque(Point + _compteur, Color.Blue);

				_compteur++;
			}
		}

		// encadre les points
		public void Encadre(List<Couple> points)
		{
			_element.Dimensionne(16, 16);

			foreach (Couple point in points)
			{
				//position = Positionne(point, -5);
				_element.Positionne(Positionne(point, -5));

				_element.AjouterCercle(Cadre + _compteurCadre, Color.Green, 2);

				_compteurCadre++;
			}
		}

		// supprime les points précédents
		public void EncadreNettoie()
		{
			for (int i = 0; i < _element.ListeFigures().Count; i++)
			{
				if (_element.ListeFigures().ElementAt(i).Key.Contains(Cadre))
					_element.ListeFigures().Remove(_element.ListeFigures().ElementAt(i).Key);
			}
		}

		private Couple Positionne(Couple point, double decalage = 0)
		{
			// étire + réajuste avec le décalage étiré
			Couple pointAjuste = new Couple(
				PositionneX(point.X, decalage),
				PositionneY(point.Y, decalage)
			);

			return pointAjuste;
		}

		private double PositionneX(double x, double decalage = 0)
		{
			return x * _ajustementZoom.X -
				   _maximum[Gauche] * _ajustementZoom.X +
				   decalage;
		}
		private double PositionneY(double y, double decalage = 0)
		{
			return y * _ajustementZoom.Y +
				   (-_maximum[Bas]) * _ajustementZoom.Y +
				   decalage;
		}

		//todo utiliser DrawBezier pour afficher des courbes au lieu de lignes droites
		private void Relier()
		{
			List<Figure> liste = _element.ListeElements();

			for (int i = 0; i < _compteur; i++)
			{
				// si 2 éléments consécutifs sont bien des points
				if (_element.ListeFigures().ElementAt(i).Key.Contains(Point) && _element.ListeFigures().ElementAt(i + 1).Key.Contains(Point))
				{
					_element.Dimensionne(liste[i].Position + 3);
					_element.Positionne(liste[i + 1].Position + 3);

					_element.AjouterLigne(Ligne + i, Color.Blue, 3);
				}
			}
		}

		private void TrouveMaximum(List<Couple> points)
		{
			_maximum[Gauche] = points[0].X;
			_maximum[Droite] = points[points.Count - 1].X;

			foreach (Couple point in points)
			{
				if (point.Y < _maximum[Bas]) _maximum[Bas] = point.Y;
				if (point.Y > _maximum[Haut]) _maximum[Haut] = point.Y;
			}
		}

		private void Zoom()
		{
			Couple deltaMaximum = new Couple(
				_maximum[Droite] - _maximum[Gauche],
				_maximum[Haut] - _maximum[Bas]
			);

			// tailleFenetre / delta => facteur de zoom
			_ajustementZoom.Y = _dimensionsFenetre.Y / deltaMaximum.Y * 0.96;
			_ajustementZoom.X = _dimensionsFenetre.X / deltaMaximum.X * 0.98;

			// si le delta vaut 0 (cas où les X ou Y ne varient pas)
			if (Math.Abs(deltaMaximum.X) < 0.001)
				_ajustementZoom.X = 1;
			if (Math.Abs(deltaMaximum.Y) < 0.001)
				_ajustementZoom.Y = 1;
		}

		public void Affiche(Graphics graphics)
		{
			_element.Affiche(graphics);
		}
	}
}
