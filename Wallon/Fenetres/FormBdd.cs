using System.Windows.Forms;

namespace Wallon.Fenetres
{
	public partial class FormBdd : Form
	{
		private readonly string _connexion = "Data Source=192.168.1.106;Initial Catalog=Wallons;Persist Security Info=True;User ID=sa;Password=6463f184f";

		public FormBdd()
		{
			InitializeComponent();
		}

		public string Connexion => _connexion;
	}
}
