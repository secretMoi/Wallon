namespace Wallon.Pages.Vue.Utilisateurs
{
	partial class Profil
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
			this.flatLabelNom = new FlatControls.Controls.FlatLabel();
			this.flatLabelPassword = new FlatControls.Controls.FlatLabel();
			this.flatTextBoxNom = new FlatControls.Controls.FlatTextBox();
			this.flatTextBoxPassword = new FlatControls.Controls.FlatTextBox();
			this.flatButtonUpdate = new FlatControls.Controls.Buttons.FlatButton();
			this.alerte = new FlatControls.Controls.Alerte();
			this.panelTitre.SuspendLayout();
			this.panelCorps.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Controls.Add(this.alerte);
			this.panelTitre.Size = new System.Drawing.Size(1856, 120);
			this.panelTitre.Controls.SetChildIndex(this.labelTitre, 0);
			this.panelTitre.Controls.SetChildIndex(this.alerte, 0);
			// 
			// panelCorps
			// 
			this.panelCorps.Controls.Add(this.flatButtonUpdate);
			this.panelCorps.Controls.Add(this.flatTextBoxPassword);
			this.panelCorps.Controls.Add(this.flatTextBoxNom);
			this.panelCorps.Controls.Add(this.flatLabelPassword);
			this.panelCorps.Controls.Add(this.flatLabelNom);
			this.panelCorps.Size = new System.Drawing.Size(1856, 773);
			// 
			// flatLabelNom
			// 
			this.flatLabelNom.AutoSize = true;
			this.flatLabelNom.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelNom.ForeColor = System.Drawing.Color.Black;
			this.flatLabelNom.Location = new System.Drawing.Point(20, 29);
			this.flatLabelNom.Name = "flatLabelNom";
			this.flatLabelNom.Size = new System.Drawing.Size(61, 30);
			this.flatLabelNom.TabIndex = 0;
			this.flatLabelNom.Text = "Nom";
			// 
			// flatLabelPassword
			// 
			this.flatLabelPassword.AutoSize = true;
			this.flatLabelPassword.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelPassword.ForeColor = System.Drawing.Color.Black;
			this.flatLabelPassword.Location = new System.Drawing.Point(20, 91);
			this.flatLabelPassword.Name = "flatLabelPassword";
			this.flatLabelPassword.Size = new System.Drawing.Size(142, 30);
			this.flatLabelPassword.TabIndex = 1;
			this.flatLabelPassword.Text = "Mot de passe";
			// 
			// flatTextBoxNom
			// 
			this.flatTextBoxNom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextBoxNom.IsPassword = false;
			this.flatTextBoxNom.Location = new System.Drawing.Point(192, 19);
			this.flatTextBoxNom.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextBoxNom.Name = "flatTextBoxNom";
			this.flatTextBoxNom.Size = new System.Drawing.Size(257, 40);
			this.flatTextBoxNom.TabIndex = 2;
			// 
			// flatTextBoxPassword
			// 
			this.flatTextBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextBoxPassword.IsPassword = false;
			this.flatTextBoxPassword.Location = new System.Drawing.Point(192, 81);
			this.flatTextBoxPassword.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextBoxPassword.Name = "flatTextBoxPassword";
			this.flatTextBoxPassword.Size = new System.Drawing.Size(257, 40);
			this.flatTextBoxPassword.TabIndex = 3;
			// 
			// flatButtonUpdate
			// 
			this.flatButtonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.flatButtonUpdate.FlatAppearance.BorderSize = 0;
			this.flatButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatButtonUpdate.ForeColor = System.Drawing.Color.White;
			this.flatButtonUpdate.Location = new System.Drawing.Point(192, 143);
			this.flatButtonUpdate.Name = "flatButtonUpdate";
			this.flatButtonUpdate.Size = new System.Drawing.Size(257, 36);
			this.flatButtonUpdate.TabIndex = 4;
			this.flatButtonUpdate.Text = "Mettre à jour";
			this.flatButtonUpdate.UseVisualStyleBackColor = false;
			this.flatButtonUpdate.Click += new System.EventHandler(this.flatButtonUpdate_Click);
			// 
			// alerte
			// 
			this.alerte.BackColor = System.Drawing.Color.Tomato;
			this.alerte.Dock = System.Windows.Forms.DockStyle.Top;
			this.alerte.Enable = false;
			this.alerte.HeightMax = 40;
			this.alerte.Location = new System.Drawing.Point(0, 0);
			this.alerte.Name = "alerte";
			this.alerte.Size = new System.Drawing.Size(1539, 39);
			this.alerte.TabIndex = 2;
			this.alerte.Visible = false;
			// 
			// Profil
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Name = "Profil";
			this.Size = new System.Drawing.Size(1856, 893);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.panelCorps.ResumeLayout(false);
			this.panelCorps.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private FlatControls.Controls.Buttons.FlatButton flatButtonUpdate;
		private FlatControls.Controls.FlatTextBox flatTextBoxPassword;
		private FlatControls.Controls.FlatTextBox flatTextBoxNom;
		private FlatControls.Controls.FlatLabel flatLabelPassword;
		private FlatControls.Controls.FlatLabel flatLabelNom;
		private FlatControls.Controls.Alerte alerte;
	}
}
