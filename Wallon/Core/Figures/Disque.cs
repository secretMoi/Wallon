using System.Drawing;

namespace Core.Figures
{
    public class Disque : Figure
    {
        public Disque(Graphics graphique, Couple position, int rayon, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) :
            base(position, new Couple(rayon, rayon), couleurRemplissage, contour, largeurContour)
        {
        }

        public override void Genere()
        {
            int rayon = dimension.Xi;
            
            Graphique.FillEllipse(Remplissage, position.Xf, position.Yf, 
                dimension.Xf, dimension.Yf);
            
            Graphique.DrawEllipse(Contour,
                position.Xf, position.Yf,
                rayon, rayon); // dessine le disque dans l'image
        }
    }
}