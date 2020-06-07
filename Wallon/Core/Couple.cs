using System;
using System.Drawing;

namespace Core
{
    public class Couple
    {
        private double x, y;
        private const float MargeErreur = Single.Epsilon;

        #region Constructeurs
        public Couple(PointF point = default)
        {
            X = point.X;
            Y = point.Y;
        }
        public Couple(Point point)
        {
            X = point.X;
            Y = point.Y;
        }
        public Couple(Size point)
        {
            X = point.Width;
            Y = point.Height;
        }
        public Couple(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Couple(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Couple(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Operateurs
        public static Couple operator +(Couple couple1, Couple couple2)
        {
            Couple coupleResultat = new Couple(
                couple1.X + couple2.X,
                couple1.Y + couple2.Y
            );

            return coupleResultat;
        }

        public static Couple operator +(Couple couple, float nombre)
        {
            Couple coupleResultat = new Couple(
                couple.X + nombre,
                couple.Y + nombre
            );

            return coupleResultat;
        }

        public static Couple operator -(Couple couple1, Couple couple2)
        {
            Couple coupleResultat = new Couple(
                couple1.X - couple2.X,
                couple1.Y - couple2.Y
            );

            return coupleResultat;
        }

        public static Couple operator -(Couple couple, float nombre)
        {
            Couple coupleResultat = new Couple(
                couple.X - nombre,
                couple.Y - nombre
            );

            return coupleResultat;
        }
        #endregion

        // reset les valeurs
        public static Couple Vide()
        {
            return new Couple(0, 0);
        }

        // convertit un point en couple
        public static Couple ToCouple(Point point)
        {
            return new Couple(point);
        }
        public static Couple ToCouple(PointF point)
        {
            return new Couple(point);
        }
        public static Couple ToCouple(Size point)
        {
            return new Couple(point);
        }

        // convertit en point int
        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public Size ToSize()
        {
	        return new Size((int)X, (int)Y);
        }

        #region GettersSetters
        public double X
        {
            get => x;
            set => x = value;
        }
        public double Y
        {
            get => y;
            set => y = value;
        }
        public float Xf
        {
            get => (float)x;
            set => x = value;
        }
        public float Yf
        {
            get => (float)y;
            set => y = value;
        }
        public int Xi
        {
            get => (int)x;
            set => x = value;
        }
        public int Yi
        {
            get => (int)y;
            set => y = value;
        }

        public static double MaxValue => Double.MaxValue;
        public static double MinValue => Double.MinValue;
        #endregion

        public override string ToString()
        {
            return "(" + X + "; " + Y + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;

            Couple objet = obj as Couple;
            return Egal(X, objet.X) && Egal(Y, objet.Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // vérifie que les valeurs stockées sont identiques
        private bool Egal(double nombre1, double nombre2)
        {
            return Math.Abs(nombre1 - nombre2) < MargeErreur;
        }

        // utile lors d'effet de bord car quand on fait Couple1 = Couple2, les références sont copiées et non les valeurs
        public Couple Copie()
        {
            return new Couple(X, Y);
        }
    }
}
