using Xamarin.Forms;

namespace Mobile.CustomControls
{
	public class ExtendedViewCell : ViewCell
	{
		/// <summary>
		/// The SelectedBackgroundColor property.
		/// </summary>
		public static readonly BindableProperty SelectedBackgroundColorProperty =
			BindableProperty.Create("SelectedBackgroundColor", typeof(Color), typeof(ExtendedViewCell), Color.Default);

		/// <summary>
		/// Gets or sets the SelectedBackgroundColor.
		/// </summary>
		public Color SelectedBackgroundColor
		{
			get => (Color)GetValue(SelectedBackgroundColorProperty);
			set => SetValue(SelectedBackgroundColorProperty, value);
		}
	}
}
