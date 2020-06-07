using System.Drawing;

namespace Core.Figures
{
    public class Ligne : Figure
    {
        public Ligne(Graphics graphique, Couple positionSource, Couple positionDestination, Color contour, int largeurContour) : 
            base(positionSource, positionDestination, null, contour, largeurContour)
        {
        }

        // on doit overrider Deplace sinon seul le premier point bouge vu que le 2è est associé aux dimensions 
        public override void Deplace(int x, int y)
        {
            Couple anciennePosition = position;
            base.Deplace(x, y);

            dimension.X -= anciennePosition.X - position.X;
            dimension.Y -= anciennePosition.Y - position.Y;
        }

        public override void Genere()
        {
            Graphique.DrawLine(Contour,
                position.Xf, position.Yf,
                dimension.Xf, dimension.Yf); // dessine la ligne
        }
    }
}