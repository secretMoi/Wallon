using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Core.Figures
{
    public abstract class Figure
    {
        protected List<string> enfants;
        protected Couple position;
        protected Couple dimension;
        protected readonly Rotation rotation;
        protected Color CouleurRemplissage;
        protected Color CouleurContour;
        protected int largeurContour;
        
        protected static Graphics GraphiquePartage;
        protected Graphics Graphique;
        protected SolidBrush Remplissage;
        protected Pen Contour;

        public const bool X = true;
        public const bool Y = false;

        public Figure(Couple position, Couple dimension, Color? couleurRemplissage = null, Color? contour = null, int largeurContour = 0)
        {
            this.position = position.Copie();
            this.dimension = dimension.Copie();
            rotation = new Rotation();
            enfants = new List<string>();

            if (couleurRemplissage != null)
                this.CouleurRemplissage = (Color) couleurRemplissage;
            if (contour != null)
                this.CouleurContour = (Color) contour;
            this.largeurContour = largeurContour;

            Graphique = GraphiquePartage;
            
            //Dessine();
        }

        public Figure(Graphics graphique, Couple position, Couple dimension, Color? couleurRemplissage = null, Color? contour = null, int largeurContour = 0)
        {
            this.position = position.Copie();
            this.dimension = dimension.Copie();
            rotation = new Rotation();
            enfants = new List<string>();

            if (couleurRemplissage != null)
                this.CouleurRemplissage = (Color)couleurRemplissage;
            if (contour != null)
                this.CouleurContour = (Color)contour;
            this.largeurContour = largeurContour;

            Graphique = graphique;

            //Dessine();
        }

        public void SetGraphique(Graphics graphics)
        {
            Graphique = graphics;
        }

        public static void InitialiseConteneur(PictureBox pictureBox)
        {
            GraphiquePartage = Graphics.FromHwnd(pictureBox.Handle);
        }

        public void Afficher(Graphics graphics, SmoothingMode mode = SmoothingMode.AntiAlias)
        {
            graphics.SmoothingMode = mode;
            Dessine(graphics);
        }

        public abstract void Genere();

        public void Dessine(Graphics graphics = null)
        {
            PreparationAffichage(graphics);
            
            Genere();
            
            FinDessin();
        }

        public void FinDessin()
        {
            // permet de rectifier l'angle pour ne pas impacter les autres éléments
            CorrectionAngle(true);
        }

        protected void PreparationAffichage(Graphics graphics = null)
        {
            if(Remplissage == null)
                Remplissage = new SolidBrush(CouleurRemplissage);
            if(Contour == null)
                Contour = new Pen(CouleurContour, largeurContour);
            
            if (graphics != null)
                Graphique = graphics;

            CorrectionAngle();
        }

        protected void CorrectionAngle(bool corrige = false)
        {
            if (rotation.Angle > rotation.SensibiliteAngle)
            {
                int inverseur = 1;
                if (corrige) inverseur = -1;
                Graphique.TranslateTransform(position.Xf, position.Yf);
                // rotation
                Graphique.RotateTransform((float) (inverseur * rotation.Angle));
                Graphique.TranslateTransform(-(position.Xf), -position.Yf);
            }
        }

        public virtual void Deplace(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public Couple PointOppose()
        {
            Couple pointFin = new Couple();
            
            // rayon du pt1 au point 3
            double distanceFin = Math.Sqrt(dimension.X * dimension.X + dimension.Y * dimension.Y);
            
            // angle du pt1 au pt 3
            double angleFin = Math.Atan(dimension.Y / dimension.X);

            // coordonnées du pt 3 à l'état initial'
            pointFin.X = (int)(distanceFin * Math.Cos(angleFin));
            pointFin.Y = (int)(distanceFin * Math.Sin(angleFin));
            // position coint opposé initiale
            
            
            // rajouter l'angle de l'objet
            return rotation.RotationPoint(position, pointFin);
        }
        
        public Couple PointAdjacent(bool xy = X)
        {
            Couple pointFin = new Couple();

            /*** calcul point de départ ***/
            // si le côté dominant est en absisse
            if (xy == X) pointFin.X += dimension.X;
            else pointFin.Y += dimension.Y;
            /*** fin point de départ ***/

            /*** calcul angle de la figure parente ***/
            return rotation.RotationPoint(position, pointFin);
        }

        public void AjoutEnfant(string enfant)
        {
            // si la liste ne contient pas déjà l'élément
            if(!enfants.Contains(enfant))
                enfants.Add(enfant);
        }

        public List<string> ListeEnfants()
        {
            return enfants;
        }

        public void SetBrosse(Color nouvelleBrosse)
        {
            Remplissage = new SolidBrush(nouvelleBrosse);
        }

        public Couple Dimension => dimension;

        public Couple Position
        {
            get => position;
            set => position = value;
        }

        public double Angle => rotation.Angle;

        public Rotation Rotation => rotation;
    }
}