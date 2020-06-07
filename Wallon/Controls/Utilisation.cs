using System;
using System.Linq;
using System.Windows.Forms;

namespace Controls
{
    public partial class Utilisation : UserControl
    {
        private string _nom;
        private int _utilises, _total;

        public Utilisation()
        {
            InitializeComponent();
        }

        private string RemoveCharacter(string text)
        {
            return new string(text.Where(char.IsDigit).ToArray());
        }

        public void SetLabelEspace(string utilises, string total)
        {
            labelEspace.Text = utilises + @" utilisés sur " + total;
        }

        public void Set(string utilisation, string total = "100")
        {
            _total = Convert.ToInt32(total);
            _utilises = Convert.ToInt32(RemoveCharacter(utilisation));

            SetProgress(_utilises, _total);
        }

        public void SetProgress(int valeur, int maximum = 100)
        {
            progressBar.Maximum = maximum;
            progressBar.Value = valeur;
        }

        public string Nom
        {
            get => _nom;
            set
            {
                _nom = value;
                labelNom.Text = value;
            } 
        }

        public ProgressBar ProgressBar { get; private set; }
    }
}
