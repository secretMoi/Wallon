using System.Windows.Forms;
using FlatControls.Core;

namespace FlatControls.Controls
{
	public partial class Waiting : PictureBox
	{
		private CoreImage Animation;
		private string _pathImage;

		public string PathImage
		{
			get => _pathImage;
			set
			{
				_pathImage = value;
				LoadNewImage();
			}
		}

		public Waiting()
		{
			InitializeComponent();

			PathImage = @"Ressources\Images\waiting.gif";

			try
			{
				LoadNewImage();
			}
			catch
			{
				// ignored
			}

			SizeMode = PictureBoxSizeMode.AutoSize;
		}

		private void LoadNewImage()
		{
			Animation = new CoreImage(PathImage);
			Image = Animation.Image;
		}
	}
}
