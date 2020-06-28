using System;
using System.Windows.Forms;
using FlatControls.Core;

namespace FlatControls.Controls
{
	public partial class Waiting : PictureBox
	{
		public Waiting()
		{
			InitializeComponent();

			try
			{
				Image = new CoreImage(@"Ressources\Images\waiting.gif").Image;
			}
			catch
			{
				// ignored
			}

			SizeMode = PictureBoxSizeMode.AutoSize;
		}
	}
}
