using System.Drawing;

namespace Core.Figures
{
    public class Ellipse : Figure
    {
        public Ellipse(Graphics graphique, Couple position, Couple dimension, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) : 
            base(position, dimension, couleurRemplissage, contour, largeurContour)
        {
            
        }
        
        public override void Genere()
        {
            Graphique.FillEllipse(Remplissage, position.Xf, position.Yf, 
                dimension.Xf, dimension.Yf);
            
            Graphique.DrawEllipse(Contour,
                position.Xf, position.Yf, 
                dimension.Xf, dimension.Yf); // dessine le cercle dans l'image
        }
    }
}