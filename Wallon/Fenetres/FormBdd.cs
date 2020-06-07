using System.Windows.Forms;

namespace Wallon.Fenetres
{
	public partial class FormBdd : Form
	{
		private readonly string _connexion = "Data Source=ROGSTRIXSCAR;Initial Catalog=magasin;Integrated Security=True";

		public FormBdd()
		{
			InitializeComponent();
		}

		public string Connexion => _connexion;
	}
}
