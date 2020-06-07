using System.Drawing;

namespace Core.Figures
{
    class Texte : Figure
    {
        private readonly Font _font;
        private readonly string _texte;

        public Texte(Graphics graphique, string texte, Couple position, Color remplissage, float taille = 12.5f, FontStyle style = default, string police = "Yu Gothic UI") :
            base(position, position, remplissage)
        {
            _texte = texte;
            _font = new Font(police, taille, style);
        }

        public override void Genere()
        {
            Graphique.DrawString(_texte, _font, Remplissage, position.Xf, position.Yf);
        }
    }
}
