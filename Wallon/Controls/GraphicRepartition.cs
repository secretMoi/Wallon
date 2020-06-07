using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Core;
using Core.Figures;
using QMag.Controls;

namespace Controls
{
	public partial class GraphicRepartition : UserControl
    {
        private readonly ElementGraphic _element;
		private Dictionary<string, float> _data;

		// utilisé pour ne pas scroller trop haut ou trop bas
		private Figure _premiereFigure;
		private Figure _derniereFigure;

		public GraphicRepartition()
		{
			InitializeComponent();

			_element = new ElementGraphic(pictureBox1);

			pictureBox1.MouseWheel += pictureBox1_MouseWheel;
		}

		public void CreateElement(Dictionary<string, float> incomingData = null)
		{
			if(incomingData == null && _data == null) return; // si aucune donnée ne peut être utilisée

			Clear();

			if(incomingData != null) // si on ne recycle pas les données existantes mais qu'on en prend des nouvelles
				_data = incomingData;

			int compteur = 0;

            Couple positionSourceLigneVerticale = new Couple();
            Couple positionDestinationLigneVerticale = new Couple();

			float rapport = (Width - 100) / PlusGrandeValeur() * 0.95f;
			foreach (KeyValuePair<string, float> item in _data)
			{
				// nom
				// hauteur 12.5 * 5 => 62
				_element.Dimensionne(12.5f);
                _element.Positionne(
                    10,
                    compteur * _element.GetDimension.Y * 5
                );

                _element.AjouterTexte("Label" + item.Key, item.Key, Color.Black);

				// barre
				// hauteur = 62 + 25 = 87
				// hauteur finale = 87 + 20 = 107
                _element.Positionne(
                    100,
                    _element.GetPosition.Y + 25
                );
                _element.Dimensionne((int) (item.Value * rapport), 20);
                _element.AjouterRectangle("Rectangle" + item.Key, Theme.BackLight);

				// valeur
                _element.Dimensionne(12.5f);
                _element.Positionne(
                    _element.GetPosition.X + 7,
                    _element.GetPosition.Y - 1
                );

				_element.AjouterTexte("Valeur" + item.Key, ConvertitNombre(item.Value), Color.Black);

                if (compteur == 0) // si premier élément
                {
                    _premiereFigure = _element.GetFigure("Label" + item.Key);

                    positionSourceLigneVerticale = new Couple(
                        _element.GetFigure("Rectangle" + item.Key).Position.X + _element.GetFigure("Rectangle" + item.Key).Dimension.X,
                        _element.GetFigure("Rectangle" + item.Key).Position.Y
					);

                }

                if (compteur == _data.Count - 1) // si dernier élément
				{
                    _derniereFigure = _element.GetFigure("Label" + item.Key);

                    positionDestinationLigneVerticale = new Couple(
                        positionSourceLigneVerticale.X,
                        _element.GetFigure("Rectangle" + item.Key).Position.Y + _element.GetFigure("Rectangle" + item.Key).Dimension.Y
					);
				}

                compteur++;
			}

			_element.Positionne(positionSourceLigneVerticale);
			_element.Dimensionne(positionDestinationLigneVerticale);
            _element.AjouterLigne("LigneVerticale", Color.Black, 1);

			pictureBox1.Invalidate();
		}

		// nombre déjà de base en Ko
		// convertit le nombre float en une chaine lisible
        private static string ConvertitNombre(float nombre)
        {
            string resultat;

            // CultureInfo.CurrentCulture pour adapter la chaine à une vue UI
            // CultureInfo.InvariantCulture pour garder les données brutes, les enregistrer dans un fichier par exemple

            if (nombre > Math.Pow(1024, 2))
            {
                nombre /= (float)Math.Pow(1024, 2);
                nombre = Truncate(nombre, 2);
                resultat = nombre.ToString(CultureInfo.CurrentCulture);
                resultat += " Go";
            }
            else if(nombre > 1024)
            {
                nombre /= 1024;
                nombre = Truncate(nombre, 2);
				resultat = nombre.ToString(CultureInfo.CurrentCulture);
                resultat += " Mo";
            }
            else
            {
                nombre = Truncate(nombre, 2);
				resultat = nombre.ToString(CultureInfo.CurrentCulture);
                resultat += " Ko";
			}

			return resultat;
        }

		// arrondi le nombre
        public static float Truncate(float value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

		// trouve la plus grande valeur du dictionnaire
		private float PlusGrandeValeur()
		{
			float valeurMax = float.MinValue;

			foreach (KeyValuePair<string, float> element in _data)
				if (element.Value > valeurMax)
					valeurMax = element.Value;

			return valeurMax;
		}

		// event lors du scolling
		private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
		{
			int scroll = e.Delta;
            int valeur = 107; // vient de la hauteur totale d'un composant
            if (e.Delta < 0)
                valeur = -valeur;

			if (_premiereFigure.Position.Y + scroll < 110 && _derniereFigure.Position.Y + scroll > 0)
			{
                _element.Deplace(0, valeur);

				pictureBox1.Invalidate();
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
            _element.Affiche(e.Graphics);
		}

		// event lors du redimensionnement de la fenêtre
		private void pictureBox1_SizeChanged(object sender, EventArgs e)
		{
			Clear();
			CreateElement();
		}

		// permet de donner à la picturebox la priorité du scolling
		private void pictureBox1_MouseHover(object sender, EventArgs e)
		{
			pictureBox1.Focus();
		}

        public void Clear()
        {
            _element.Clear();
            pictureBox1.Image = null;
		}
	}
}
