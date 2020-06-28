using System.Drawing;
using System.Drawing.Drawing2D;

namespace FlatControls.Core
{
	public class CoreImage
	{
		private Image _image;

		public CoreImage(string path)
		{
			_image = Image.FromFile(path);
		}

		/// <summary>
		/// Redimensionne une image dans une colonne
		/// </summary>
		/// <param name="width">Largeur que l'image doit atteindre</param>
		/// <param name="height">Hauteur que l'image doit atteindre</param>
		/// <param name="preserveAspectRatio">Booléen indiquant si l'image peut être déformée ou non, ratio préservé par défaut</param>
		public Image Resize(int width, int height, bool preserveAspectRatio = true)
		{
			return Resize(new Size(width, height), preserveAspectRatio);
		}

		/// <summary>
		/// Redimensionne une image dans une colonne
		/// </summary>
		/// <param name="size">Taille que l'image doit atteindre</param>
		/// <param name="preserveAspectRatio">Booléen indiquant si l'image peut être déformée ou non, ratio préservé par défaut</param>
		public Image Resize(Size size, bool preserveAspectRatio = true)
		{
			int newWidth;
			int newHeight;

			if (size == _image.Size)
				return _image;

			if (preserveAspectRatio)
			{
				int originalWidth = _image.Width;
				int originalHeight = _image.Height;

				float percentWidth = (float)size.Width / (float)originalWidth;
				float percentHeight = (float)size.Height / (float)originalHeight;
				float percent = percentHeight < percentWidth ? percentHeight : percentWidth;

				newWidth = (int)(originalWidth * percent);
				newHeight = (int)(originalHeight * percent);
			}
			else
			{
				newWidth = size.Width;
				newHeight = size.Height;
			}

			Image newImage = new Bitmap(newWidth, newHeight);

			using (Graphics graphicsHandle = Graphics.FromImage(newImage))
			{
				graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphicsHandle.DrawImage(_image, 0, 0, newWidth, newHeight);
			}

			_image = newImage;
			return newImage;
		}


	}
}
