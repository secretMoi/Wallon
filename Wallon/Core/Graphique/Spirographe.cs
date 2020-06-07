using System.Collections.Generic;
using Core;

namespace QMag.Core.Graphique
{
    public class Spirographe
    {
        private readonly SortedList<double, double> _listePoints;

        public Spirographe()
        {
            _listePoints = new SortedList<double, double>();
        }

        public bool Add(Couple point)
        {
            if (!EstValide(point)) return false; // vérifie que le point est valide

            _listePoints.Add(point.X, point.Y);

            return true;
        }

        public bool Add(int x, int y)
        {
            // utilise l'ajoutre méthode Add
            Couple point = new Couple(x, y);

            return Add(point);
        }

        public bool Add(double x, double y)
        {
            // utilise l'ajoutre méthode Add
            Couple point = new Couple(x, y);

            return Add(point);
        }

        public void RemoveAt(int position)
        {
            _listePoints.RemoveAt(position);
        }

        public Couple GetAt(int position)
        {
            return new Couple(_listePoints.Keys[position], _listePoints.Values[position]);
        }

        public bool EstValide(Couple point)
        {
            if (_listePoints.ContainsKey(point.X)) return false;

            return true;
        }

        public List<Couple> Liste()
        {
            List<Couple> pointsRetour = new List<Couple>();

            for (int i = 0; i < _listePoints.Count; i++)
                pointsRetour.Add(GetAt(i));

            return pointsRetour;
        }

        public List<Couple> InverseY()
        {
            // crée une copie par valeur de la liste points
            List<Couple> pointsInverse = new List<Couple>();

            for (int i = 0; i < _listePoints.Count; i++)
                pointsInverse.Add(new Couple(_listePoints.Keys[i], -_listePoints.Values[i]));

            return pointsInverse;
        }

        public int Count => _listePoints.Count;

        public Couple this[int position] => new Couple(_listePoints.Keys[position], _listePoints.Values[position]);
    }
}
