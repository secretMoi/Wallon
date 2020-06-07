using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Core;
using Core.Figures;
using Rectangle = QMag.Core.Figures.Rectangle;

namespace QMag.Core
{
    public class Element
    {
        private readonly Dictionary<string, Figure> _elements; // contient les figures de l'élément
        private Couple _position; // position courante de l'élément
        private Couple _dimensions; // utlisé lors de la création de chaque figure
        private double zoom;

        private Graphics Graphique;

        #region Constructeurs

        public Element()
        {
            _elements = new Dictionary<string, Figure>();

            _position = new Couple(0, 0);

            this.zoom = 1;
        }

        public Element(Couple position) : this()
        {
            this._position = position.Copie();
        }

        public Element(Graphics graphics) : this()
        {
            Graphique = graphics;
        }

        public Element(PictureBox pictureBox) : this()
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
            _dimensions = new Couple(x * zoom, y * zoom);
        }
        public void Dimensionne(float x)
        {
            _dimensions = new Couple(x * zoom, x * zoom);
        }
        public void Dimensionne(double x, double y)
        {
            _dimensions = new Couple(x * zoom, y * zoom);
        }
        public void Dimensionne(double x)
        {
            _dimensions = new Couple(x * zoom, x * zoom);
        }
        public void Dimensionne(Size taille)
        {
            _dimensions = new Couple(taille);
        }
        public void Dimensionne(Couple taille)
        {
            _dimensions = taille.Copie();
        }

        #endregion

        #region Positionne

        public void Positionne(float x, float y)
        {
            _position = new Couple(x * zoom, y * zoom);
        }
        public void Positionne(float x)
        {
            _position = new Couple(x * zoom, x * zoom);
        }
        public void Positionne(double x, double y)
        {
            _position = new Couple(x * zoom, y * zoom);
        }
        public void Positionne(double x)
        {
            _position = new Couple(x * zoom, x * zoom);
        }
        public void Positionne(Couple pos)
        {
            _position = pos.Copie();
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
            if (_elements.ContainsKey(cle)) return;
            _elements.Add(cle, new Rectangle(Graphique, _position, _dimensions, remplissage));
        }

        public void AjouterDisque(string cle, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (_elements.ContainsKey(cle)) return;
            _elements.Add(cle, new Disque(Graphique, _position, _dimensions.Xi, remplissage, contour, largeurContour));
        }

        public void AjouterCercle(string cle, Color contour, int largeurContour = 1)
        {
            if (_elements.ContainsKey(cle)) return;
            _elements.Add(cle, new Cercle(Graphique, _position, _dimensions.Xi, contour, largeurContour));
        }

        public void AjouterEllipse(string cle, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (_elements.ContainsKey(cle)) return;
            _elements.Add(cle, new Ellipse(Graphique, _position, _dimensions, remplissage, contour, largeurContour));
        }

        public void AjouterLigne(string cle, Color contour, int largeurContour)
        {
            if (_elements.ContainsKey(cle)) return;

            Couple positionSource = _position;
            Couple positionDestination = _dimensions;
            _elements.Add(cle, new Ligne(Graphique, positionSource, positionDestination, contour, largeurContour));
        }

        public void AjouterArc(string cle, Color contour, int largeurContour, float angleDebut, float amplitude)
        {
            if (_elements.ContainsKey(cle)) return;
            _elements.Add(cle, new Arc(Graphique, _position, _dimensions, contour, largeurContour, angleDebut, amplitude));
        }

        public void AjouterTexte(string cle, string texte, Color remplissage, FontStyle style = default, string police = "Yu Gothic UI")
        {
            if (_elements.ContainsKey(cle)) return;
            _elements.Add(cle, new Texte(Graphique, texte, _position, remplissage, _dimensions.Xf, style, police));
        }

        public void AjouterRectangleArrondi(string cle, int arrondi, Color? remplissage = null, Color? contour = null, int largeurContour = 0)
        {
            if (_elements.ContainsKey(cle)) return;
            _elements.Add(cle, new RectangleArrondi(Graphique, _position, _dimensions, arrondi, remplissage, contour, largeurContour));
        }

        #endregion

        public void Remove(string cle)
        {
            if (!_elements.ContainsKey(cle)) return;
            _elements.Remove(cle);
        }

        #region Deplace

        // déplace à une position donnée
        public void Deplace(Couple positionDestination)
        {
            positionDestination.X -= _position.X;
            positionDestination.Y -= _position.Y;

            Deplace(positionDestination.Xi, positionDestination.Yi);
        }

        // déplace en translation
        public void Deplace(int x, int y = 0)
        {
            Figure figure;

            _position.X += x;
            _position.Y += y;

            for (int id = 0; id < _elements.Values.Count; id++)
            {
                figure = _elements.ElementAt(id).Value;

                figure?.Deplace(figure.Position.Xi + x, figure.Position.Yi + y);
            }
        }

        // déplace en translation
        public void Deplace(string key, int x, int y = 0)
        {
            Figure figure = _elements[key];

            _position.X += x;
            _position.Y += y;

            figure.Deplace(figure.Position.Xi + x, figure.Position.Yi + y);
        }

        #endregion

        public List<Figure> ListeElements()
        {
            List<Figure> figures = new List<Figure>();

            foreach (Figure figure in _elements.Values)
            {
                figures.Add(figure);
            }

            return figures;
        }

        public void RotationFigure(string cle, double angle)
        {
            if (_elements.ContainsKey(cle))
                _elements[cle].Rotation.Position(angle);
        }

        protected void AjoutEnfant(string enfant, string parent)
        {
            // si les clés existent
            if (_elements.ContainsKey(parent) && _elements.ContainsKey(enfant))
                _elements[parent].AjoutEnfant(enfant);
        }

        // rectifie la position par rapport au parent
        protected void AjustePosition(string enfant, string parent, Couple positionPreCalculee = default)
        {
            if (positionPreCalculee == default)
                _elements[enfant].Position = _elements[parent].PointAdjacent(Figure.Y);
            else
                _elements[enfant].Position = positionPreCalculee;

            AjoutEnfant(enfant, parent);
        }

        public Figure GetFigure(string cle)
        {
            // on vérifie l'existence de la clé
            if (!_elements.ContainsKey(cle)) return null;

            return _elements[cle];
        }

        public Couple Position(string cle)
        {
            if (GetFigure(cle) != null)
                return GetFigure(cle).Position;

            return _position;
        }

        public Couple Dimension(string cle)
        {
            if (GetFigure(cle) != null)
                return GetFigure(cle).Dimension;

            return _dimensions;
        }

        public Couple GetPosition => _position;
        public Couple GetDimension => _dimensions;

        public Dictionary<string, Figure> ListeFigures()
        {
            return _elements;
        }

        public void Clear()
        {
            _elements.Clear();
        }
    }
}