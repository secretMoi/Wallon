using System.Windows.Forms;
using Controls;

namespace FlatControls.Controls
{
    public partial class FlatLabel : Label
    {
        public FlatLabel()
        {
            InitializeComponent();

            ForeColor = Theme.Texte;
            Font = Theme.Font;
        }
    }
}
