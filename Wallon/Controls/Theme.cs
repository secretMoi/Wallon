using System.Drawing;

namespace Controls
{
    static class Theme
    {
        // Couleurs
        public static readonly Color Texte = Color.White;
        public static readonly Color Back = Color.FromArgb(25, 118, 211);
        public static readonly Color BackLight = Color.FromArgb(33, 150, 245);
        public static readonly Color BackDark = Color.FromArgb(22, 101, 193);

        // Police
        public static readonly float TextSize = 12.5f;
        public static readonly string TypeFace = "Yu Gothic UI";
        public static readonly Font Font = new Font(TypeFace, TextSize);

        // converti la classe couleur en code couleur hexa
        public static string ColorToHex(Color color)
        {
	        return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        public static (int, int, int) ColorToRgb(Color color)
        {
	        int red = color.R;
	        int green = color.G;
	        int blue = color.B;
	        //int alpha = color.A;

	        return (red, green, blue/*, alpha*/);
        }
    }
}
