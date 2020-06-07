using System.Drawing;

namespace Core.Figures
{
    public class Arc : Figure
    {
        private readonly float angleDebut;
        private readonly float amplitude;
        
        public Arc(Graphics graphique, Couple position, Couple dimension, Color contour, int largeurContour, float angleDebut, float amplitude) : base(position, dimension, null, contour, largeurContour)
        {
            this.angleDebut = angleDebut;
            this.amplitude = amplitude;
        }

        public override void Genere()
        {
            Graphique.DrawArc(Contour, position.Xf, position.Yf,
                dimension.Xf, dimension.Yf,
                angleDebut, amplitude);
        }
    }
}