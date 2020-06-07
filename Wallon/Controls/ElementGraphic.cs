using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Core;
using Core.Figures;
using Rectangle = QMag.Core.Figures.Rectangle;

namespace QMag.Controls
{
    public partial class ElementGraphic
    {
        private readonly Dictionary<string, Figure> elements; // contient les figures de l'élément
        private Couple position; // position courante de l'élément
        private Couple dimensions; // utlisé lors de la création de chaque figure
        private double zoom;

        private Graphics Graphique;

        #region Constructeurs

        public ElementGraphic()
        {
            elements = new Dictionary<string, Figure>();

            position = new Couple(0, 0);

            this.zoom = 1;
        }

        public ElementGraphic(Couple position) : this()
        {
            this.position = position.Copie();
        }

        public ElementGraphic(Graphics graphics) : this()
        {
            Graphique = graphics;
        }

        public ElementGraphic(PictureBox pictureBox) : this()
        {
            InitGraphiqueFromPictureBox(pictureBox);
        }

        #endregion


        public void InitGraphiqueFromPictureBox(PictureBox pictureBox)
        {
            Graphique = Graphics.FromHwnd(pictureBox.Handle);
        }

        // change la mise à l'échelle'
        public virtual void Zoom(double zoom)
        {
            this.zoom = zoom;
        }

        #region Dimensionne

        // permet de mettre à l'échelle un élément
        public void Dimensionne(float x, float y)
        {
            dimensions = new Couple(x * zoom, y * zoom);
        }
        public void Dimensionne(float x)
        {
            dimensions = new Couple(x * zoom, x * zoom);
        }
        public void Dimensionne(double x, double y)
        {
            dimensions = new Couple(x * zoom, y * zoom);
        }
        public void Dimensionne(double x)
        {
            dimensions = new Couple(x * zoom, x * zoom);
        }
        public void Dimensionne(Size taille)
        {
            dimensions = new Couple(taille);
        }
        public void Dimensionne(Couple taille)
        {
            dimensions = taille.Copie();
        }

        #endregion

        #region Positionne

        public void Positionne(float x, float y)
        {
            position = new Couple(x * zoom, y * zoom);
        }
        public void Positionne(float x)
        {
            position = new Couple(x * zoom, x * zoom);
        }
        public void Positionne(double x, double y)
        {
            position = new Couple(x * zoom, y * zoom);
        }
        public void Positionne(double x)
        {
            position = new Couple(x * zoom, x * zoom);
        }
        public void Positionne(Couple pos)
        {
            position = pos.Copie();
        }

        #endregion

        // affiche toutes les figures de l'élément
        public virtual void Affiche(Graphics graphics)
        {
            // redessine toutes les parties des éléments
            foreach (Figure figure in ListeElements())
            {
                figure.Afficher(graphics);

                // indique aux enfants de redéfinir leur position selon la rotation du parent
                foreach (string enfant in figure.ListeEnfants())
                {
                    // récupère le nom de la méthode dynamiquement
                    MethodInfo method = GetType().GetMethod(enfant, BindingFlags.Instance | BindingFlags.Public);
                    method?.Invoke(this, null);
                }
            }
        }

        #region Ajouterfigure

        public void AjouterRectangle(string cle, Color? remplissage = null)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Rectangle(Graphique, position, dimensions, remplissage));
        }

        public void AjouterDisque(string cle, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Disque(Graphique, position, dimensions.Xi, remplissage, contour, largeurContour));
        }

        public void AjouterCercle(string cle, Color contour, int largeurContour = 1)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Cercle(Graphique, position, dimensions.Xi, contour, largeurContour));
        }

        public void AjouterEllipse(string cle, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Ellipse(Graphique, position, dimensions, remplissage, contour, largeurContour));
        }

        public void AjouterLigne(string cle, Color contour, int largeurContour)
        {
            if (elements.ContainsKey(cle)) return;

            Couple positionSource = position;
            Couple positionDestination = dimensions;
            elements.Add(cle, new Ligne(Graphique, positionSource, positionDestination, contour, largeurContour));
        }

        public void AjouterArc(string cle, Color contour, int largeurContour, float angleDebut, float amplitude)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Arc(Graphique, position, dimensions, contour, largeurContour, angleDebut, amplitude));
        }

        public void AjouterTexte(string cle, string texte, Color remplissage, FontStyle style = default, string police = "Yu Gothic UI")
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Texte(Graphique, texte, position, remplissage, dimensions.Xf, style, police));
        }

        public void AjouterRectangleArrondi(string cle, int arrondi, Color? remplissage = null, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new RectangleArrondi(Graphique, position, dimensions, arrondi, remplissage, contour, largeurContour));
        }

        #endregion

        public void Remove(string cle)
        {
            if (!elements.ContainsKey(cle)) return;
            elements.Remove(cle);
        }

        #region Deplace

        // déplace à une position donnée
        public void Deplace(Couple positionDestination)
        {
            positionDestination.X -= position.X;
            positionDestination.Y -= position.Y;

            Deplace(positionDestination.Xi, positionDestination.Yi);
        }

        // déplace en translation
        public void Deplace(int x, int y = 0)
        {
            Figure figure;

            position.X += x;
            position.Y += y;

            for (int id = 0; id < elements.Values.Count; id++)
            {
                figure = elements.ElementAt(id).Value;

                figure?.Deplace(figure.Position.Xi + x, figure.Position.Yi + y);
            }
        }

        // déplace en translation
        public void Deplace(string key, int x, int y = 0)
        {
            Figure figure = elements[key];

            position.X += x;
            position.Y += y;

            figure.Deplace(figure.Position.Xi + x, figure.Position.Yi + y);
        }

        #endregion

        public List<Figure> ListeElements()
        {
            List<Figure> figures = new List<Figure>();

            foreach (Figure figure in elements.Values)
            {
                figures.Add(figure);
            }

            return figures;
        }

        public void RotationFigure(string cle, double angle)
        {
            if (elements.ContainsKey(cle))
                elements[cle].Rotation.Position(angle);
        }

        protected void AjoutEnfant(string enfant, string parent)
        {
            // si les clés existent
            if (elements.ContainsKey(parent) && elements.ContainsKey(enfant))
                elements[parent].AjoutEnfant(enfant);
        }

        // rectifie la position par rapport au parent
        protected void AjustePosition(string enfant, string parent, Couple positionPreCalculee = default)
        {
            if (positionPreCalculee == default)
                elements[enfant].Position = elements[parent].PointAdjacent(Figure.Y);
            else
                elements[enfant].Position = positionPreCalculee;

            AjoutEnfant(enfant, parent);
        }

        public Figure GetFigure(string cle)
        {
            // on vérifie l'existence de la clé
            if (!elements.ContainsKey(cle)) return null;

            return elements[cle];
        }

        public Couple Position(string cle)
        {
            if (GetFigure(cle) != null)
                return GetFigure(cle).Position;

            return position;
        }

        public Couple Dimension(string cle)
        {
            if (GetFigure(cle) != null)
                return GetFigure(cle).Dimension;

            return dimensions;
        }

        public Couple GetPosition => position;
        public Couple GetDimension => dimensions;

        public Dictionary<string, Figure> ListeFigures()
        {
            return elements;
        }

        public void Clear()
        {
            elements.Clear();
        }
    }
}
