using System.Drawing;

namespace Core.Figures
{
    public class Cercle : Figure
    {
        public Cercle(Graphics graphique, Couple position, int rayon, Color contour, int largeurContour) :
            base(position, new Couple(rayon, rayon), null, contour, largeurContour)
        {
        }

        public override void Genere()
        {
            int rayon = dimension.Xi;

            Graphique.DrawEllipse(Contour,
                position.Xf, position.Yf,
                rayon, rayon); // dessine le cercle dans l'image
        }
    }
}