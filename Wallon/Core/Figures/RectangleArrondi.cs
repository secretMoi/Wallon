using System.Drawing;
using System.Drawing.Drawing2D;

namespace Core.Figures
{
    class RectangleArrondi : Figure
    {
        private int _arrondi;
        public RectangleArrondi(Graphics graphique, Couple position, Couple dimension, int arrondi, Color? couleurRemplissage = default, Color? contour = default, int largeurContour = 0) :
            base(position, dimension, couleurRemplissage, contour, largeurContour)
        {
            _arrondi = arrondi;
        }

        public override void Genere()
        {
            if (_arrondi == 0) return;

            int diameter = _arrondi * 2;

            Size size = new Size(diameter, diameter);
            RectangleF arc = new RectangleF(position.ToPoint(), size);
            GraphicsPath path = new GraphicsPath();

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            //arc.X = bounds.Right - diameter;
            arc.X = position.Xf + dimension.Xf - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            //arc.Y = bounds.Bottom - diameter;
            arc.Y = position.Yf + dimension.Yf - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            //arc.X = bounds.Left;
            arc.X = position.Xf;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();

            Graphique.FillPath(Remplissage, path);
        }
    }
}
