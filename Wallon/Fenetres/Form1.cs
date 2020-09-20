using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlatControls;
using FlatControls.Controls;
using FlatControls.Core;
using Squirrel;
using Wallon.Pages.Controllers;
using Wallon.Pages.Vue;

namespace Wallon.Fenetres
{
	public partial class Form1 : Form
	{
		private bool _isResizing;
		private Point _anciennePositionCurseur;
		private Size _ancienneTailleFenetre;

		public Form1()
		{
			InitializeComponent();

			pictureBoxClose.Image = Image.FromFile("Ressources/Images/close.png");
			pictureBoxReduce.Image = Image.FromFile("Ressources/Images/minus.png");

			Resize += Form1_Resize;

			SetColors();

			SetMenu();

			AddVersionNumber();
		}

		private void AddVersionNumber()
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			Text += $@" V.{versionInfo.FileVersion}";
		}

		private async Task CheckForUpdate()
		{
			await Task.Run(async () =>
			{
				using (var manager = UpdateManager.GitHubUpdateManager("https://github.com/secretMoi/Wallon"))
				{
					try
					{
						await manager.Result.UpdateApp();
					}
					catch (Exception exception)
					{
						MessageBox.Show(@"Erreur : " + exception.Message);
					}
				}
			});
		}

		private void SetMenu()
		{
			mainMenu.BackColor = Theme.BackDark;
			mainMenu.BackColorSub = Theme.BackLight;
			mainMenu.DefaultCallback = Menu_Click;

			mainMenu.DefaultPath = "Ressources/Images/";

			mainMenu.AddMenuItem("Accueil", "box.png");

			mainMenu.AddMenuItem("Utilisateurs", "multiple-users-silhouette.png");
			mainMenu.AddSubMenuItem("Profil", "user.png");
			mainMenu.AddSubMenuItem("Liste", "list.png");
			mainMenu.AddSubMenuItem("Ajouter", "signs.png");

			mainMenu.AddMenuItem("Taches", "list.png", "Tâches");
			mainMenu.AddSubMenuItem("MesTaches", "list.png", "Mes tâches");
			mainMenu.AddSubMenuItem("Ajouter", "signs.png");
			mainMenu.AddSubMenuItem("Consulter", "pie-chart.png");

			mainMenu.AddMenuBottomItem("Se Déconnecter", "broken-cable.png", Disconnect_Click);
			mainMenu.AddMenuBottomItem("Quitter", "logout.png", Quitter_Click);
		}

		private void SetColors()
		{
			panelHeader.BackColor = Theme.BackDark;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			RestApiClient.ApiHelper.InitializeClient();

			Connexion accueil = new Connexion(); // charge la page de connexion comme page d'accueil

			panelContainer.Controls.Add(accueil); // affiche la page

			//SelfUpdate.CheckUpdate(); // vérifie les maj
		}

		public void Disconnect_Click(object sender, EventArgs e)
		{
			ControllerConnection.Disconnect();

			panelContainer.Controls.Clear();
			panelContainer.Controls.Add(new Connexion());
		}

		public void Quitter_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Menu_Click(object sender, EventArgs e)
		{
			if(!Settings.Auth)
			{
				Dialog.Show("Veuillez vous identifier afin d'accéder au programme !");
				return; // si le locataire n'est pas authentifié, il n'a pas accès au menu
			}

			string nom = ((Button)sender).Name; // récupère le nom du controle appelant
			string[] chaine = nom.Split('_'); // scinde le nom pour avoir les 2 parties

			Reflection reflection = new Reflection(GetType());

			string @namespace, @class;

			if (mainMenu.IsSubMenu((Button)sender)) // si c'est un bouton de sous-menu
			{
				@namespace = reflection.FirstNamespace + ".Pages.Vue." + chaine[1];
				@class = chaine[2];
			}
			else // si c'est un bouton de menu
			{
				// charge directement la page
				@namespace = reflection.FirstNamespace + ".Pages.Vue";
				@class = chaine[1];
			}

			LoadPage(@namespace + "." + @class);
		}

		public void LoadPage(string cheminPage, params object[] arguments)
		{
			Type typeClasse = Type.GetType(cheminPage); // trouve la classe
			if (typeClasse == null) return; // quitte si la classe est introuvable

			if (!(Activator.CreateInstance(typeClasse) is ThemePanel page)) return;

			panelContainer.Controls.Clear();
			panelContainer.Controls.Add(page);

			page.Hydrate(arguments);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			/*Ssh.ClearEvents();
			Ssh.Disconnect();
			Ssh.Dispose();*/
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxReduce_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void panelHeader_MouseMove(object sender, MouseEventArgs e)
		{
			MoveForm(panelHeader, e);
		}

		private void pictureBoxLogo_MouseMove(object sender, MouseEventArgs e)
		{
			MoveForm(pictureBoxLogo, e);
		}

		private void MoveForm(Control control, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				// Release the mouse capture started by the mouse down.
				control.Capture = false;

				// Create and send a WM_NCLBUTTONDOWN message.
				const int wmNclbuttondown = 0x00A1;
				const int htcaption = 2;
				Message msg =
					Message.Create(Handle, wmNclbuttondown,
						new IntPtr(htcaption), IntPtr.Zero);
				DefWndProc(ref msg);
			}
		}

		private void pictureBoxResize_MouseDown(object sender, MouseEventArgs e)
		{
			_isResizing = true;
			_anciennePositionCurseur = MousePosition;
			_ancienneTailleFenetre = Size;
		}

		private void pictureBoxResize_MouseUp(object sender, MouseEventArgs e)
		{
			_isResizing = false;
		}

		private void pictureBoxResize_MouseMove(object sender, MouseEventArgs e)
		{
			if (_isResizing)
			{
				Width = MousePosition.X - _anciennePositionCurseur.X + _ancienneTailleFenetre.Width;
				Height = MousePosition.Y - _anciennePositionCurseur.Y + _ancienneTailleFenetre.Height;
			}
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			Update();
		}

		private void pictureBoxClose_MouseEnter(object sender, EventArgs e)
		{
			new Animation(pictureBoxClose).Zoom(48);
		}

		private void pictureBoxClose_MouseLeave(object sender, EventArgs e)
		{
			new Animation(pictureBoxClose).Zoom(32);
		}

		private void pictureBoxReduce_MouseEnter(object sender, EventArgs e)
		{
			new Animation(pictureBoxReduce).Zoom(48);
		}

		private void pictureBoxReduce_MouseLeave(object sender, EventArgs e)
		{
			new Animation(pictureBoxReduce).Zoom(32);
		}

		// appelée lors du premier affichage de la fenêtre
		private async void Form1_Shown(object sender, EventArgs e)
		{
			//await CheckForUpdate();
		}
	}
}