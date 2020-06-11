using FlatLabel = Controls.FlatLabel;
using FlatTextBox = Controls.FlatTextBox;
using FlatButton = Controls.Buttons.FlatButton;

namespace Wallon.Pages.Vue
{
	partial class Connexion
	{
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur de composants

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private new void InitializeComponent()
		{
			this.flatLabelNom = new FlatLabel();
			this.flatTextName = new FlatTextBox();
			this.flatTextBoxPassword = new FlatTextBox();
			this.flatLabelPassword = new FlatLabel();
			this.flatButtonConnexion = new FlatButton();
			this.alerte = new Wallon.Controls.Alerte();
			this.panelTitre.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Controls.Add(this.alerte);
			this.panelTitre.Size = new System.Drawing.Size(1856, 120);
			this.panelTitre.Controls.SetChildIndex(this.labelTitre, 0);
			this.panelTitre.Controls.SetChildIndex(this.alerte, 0);
			// 
			// flatLabelNom
			// 
			this.flatLabelNom.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatLabelNom.AutoSize = true;
			this.flatLabelNom.Font = new System.Drawing.Font("Yu Gothic UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelNom.ForeColor = System.Drawing.Color.Black;
			this.flatLabelNom.Location = new System.Drawing.Point(705, 197);
			this.flatLabelNom.Name = "flatLabelNom";
			this.flatLabelNom.Size = new System.Drawing.Size(82, 40);
			this.flatLabelNom.TabIndex = 6;
			this.flatLabelNom.Text = "Nom";
			// 
			// flatTextName
			// 
			this.flatTextName.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatTextName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextName.Location = new System.Drawing.Point(937, 197);
			this.flatTextName.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextName.Name = "flatTextName";
			this.flatTextName.Size = new System.Drawing.Size(215, 40);
			this.flatTextName.TabIndex = 7;
			// 
			// flatTextBoxPassword
			// 
			this.flatTextBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatTextBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextBoxPassword.Location = new System.Drawing.Point(937, 286);
			this.flatTextBoxPassword.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextBoxPassword.Name = "flatTextBoxPassword";
			this.flatTextBoxPassword.Size = new System.Drawing.Size(215, 40);
			this.flatTextBoxPassword.TabIndex = 9;
			// 
			// flatLabelPassword
			// 
			this.flatLabelPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatLabelPassword.AutoSize = true;
			this.flatLabelPassword.Font = new System.Drawing.Font("Yu Gothic UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelPassword.ForeColor = System.Drawing.Color.Black;
			this.flatLabelPassword.Location = new System.Drawing.Point(705, 286);
			this.flatLabelPassword.Name = "flatLabelPassword";
			this.flatLabelPassword.Size = new System.Drawing.Size(192, 40);
			this.flatLabelPassword.TabIndex = 8;
			this.flatLabelPassword.Text = "Mot de passe";
			// 
			// flatButtonConnexion
			// 
			this.flatButtonConnexion.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatButtonConnexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.flatButtonConnexion.FlatAppearance.BorderSize = 0;
			this.flatButtonConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatButtonConnexion.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatButtonConnexion.ForeColor = System.Drawing.Color.White;
			this.flatButtonConnexion.Location = new System.Drawing.Point(824, 389);
			this.flatButtonConnexion.Name = "flatButtonConnexion";
			this.flatButtonConnexion.Size = new System.Drawing.Size(215, 56);
			this.flatButtonConnexion.TabIndex = 10;
			this.flatButtonConnexion.Text = "Se connecter";
			this.flatButtonConnexion.UseVisualStyleBackColor = false;
			this.flatButtonConnexion.Click += new System.EventHandler(this.flatButtonConnexion_Click);
			// 
			// alerte
			// 
			this.alerte.BackColor = System.Drawing.Color.Tomato;
			this.alerte.Dock = System.Windows.Forms.DockStyle.Top;
			this.alerte.Enable = false;
			this.alerte.HeightMax = 0;
			this.alerte.Location = new System.Drawing.Point(0, 0);
			this.alerte.MaximumSize = new System.Drawing.Size(1358, 0);
			this.alerte.Name = "alerte";
			this.alerte.Size = new System.Drawing.Size(1358, 0);
			this.alerte.TabIndex = 2;
			// 
			// Connexion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.flatButtonConnexion);
			this.Controls.Add(this.flatTextBoxPassword);
			this.Controls.Add(this.flatLabelPassword);
			this.Controls.Add(this.flatTextName);
			this.Controls.Add(this.flatLabelNom);
			this.Name = "Connexion";
			this.Size = new System.Drawing.Size(1856, 893);
			this.Controls.SetChildIndex(this.panelTitre, 0);
			this.Controls.SetChildIndex(this.flatLabelNom, 0);
			this.Controls.SetChildIndex(this.flatTextName, 0);
			this.Controls.SetChildIndex(this.flatLabelPassword, 0);
			this.Controls.SetChildIndex(this.flatTextBoxPassword, 0);
			this.Controls.SetChildIndex(this.flatButtonConnexion, 0);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private FlatLabel flatLabelNom;
		private FlatTextBox flatTextName;
		private FlatTextBox flatTextBoxPassword;
		private FlatLabel flatLabelPassword;
		private FlatButton flatButtonConnexion;
		private Controls.Alerte alerte;
	}
}
