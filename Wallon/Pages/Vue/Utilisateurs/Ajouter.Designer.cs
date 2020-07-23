namespace Wallon.Pages.Vue.Utilisateurs
{
	partial class Ajouter
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
			this.flatButtonAjouter = new FlatControls.Controls.Buttons.FlatButton();
			this.flatTextBoxPassword = new FlatControls.Controls.FlatTextBox();
			this.flatLabelPassword = new FlatControls.Controls.FlatLabel();
			this.flatTextName = new FlatControls.Controls.FlatTextBox();
			this.flatLabelNom = new FlatControls.Controls.FlatLabel();
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
			this.panelCorps.Controls.Add(this.flatButtonAjouter);
			this.panelCorps.Controls.Add(this.flatTextBoxPassword);
			this.panelCorps.Controls.Add(this.flatLabelPassword);
			this.panelCorps.Controls.Add(this.flatTextName);
			this.panelCorps.Controls.Add(this.flatLabelNom);
			this.panelCorps.Size = new System.Drawing.Size(1856, 773);
			// 
			// flatButtonAjouter
			// 
			this.flatButtonAjouter.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatButtonAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.flatButtonAjouter.FlatAppearance.BorderSize = 0;
			this.flatButtonAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatButtonAjouter.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatButtonAjouter.ForeColor = System.Drawing.Color.White;
			this.flatButtonAjouter.Location = new System.Drawing.Point(824, 276);
			this.flatButtonAjouter.Name = "flatButtonAjouter";
			this.flatButtonAjouter.Size = new System.Drawing.Size(215, 56);
			this.flatButtonAjouter.TabIndex = 15;
			this.flatButtonAjouter.Text = "Ajouter";
			this.flatButtonAjouter.UseVisualStyleBackColor = false;
			this.flatButtonAjouter.Click += new System.EventHandler(this.flatButtonAjouter_Click);
			// 
			// flatTextBoxPassword
			// 
			this.flatTextBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatTextBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextBoxPassword.IsPassword = false;
			this.flatTextBoxPassword.Location = new System.Drawing.Point(937, 173);
			this.flatTextBoxPassword.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextBoxPassword.Name = "flatTextBoxPassword";
			this.flatTextBoxPassword.Size = new System.Drawing.Size(215, 40);
			this.flatTextBoxPassword.TabIndex = 14;
			// 
			// flatLabelPassword
			// 
			this.flatLabelPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatLabelPassword.AutoSize = true;
			this.flatLabelPassword.Font = new System.Drawing.Font("Yu Gothic UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelPassword.ForeColor = System.Drawing.Color.Black;
			this.flatLabelPassword.Location = new System.Drawing.Point(705, 173);
			this.flatLabelPassword.Name = "flatLabelPassword";
			this.flatLabelPassword.Size = new System.Drawing.Size(192, 40);
			this.flatLabelPassword.TabIndex = 13;
			this.flatLabelPassword.Text = "Mot de passe";
			// 
			// flatTextName
			// 
			this.flatTextName.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatTextName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextName.IsPassword = false;
			this.flatTextName.Location = new System.Drawing.Point(937, 84);
			this.flatTextName.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextName.Name = "flatTextName";
			this.flatTextName.Size = new System.Drawing.Size(215, 40);
			this.flatTextName.TabIndex = 12;
			// 
			// flatLabelNom
			// 
			this.flatLabelNom.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatLabelNom.AutoSize = true;
			this.flatLabelNom.Font = new System.Drawing.Font("Yu Gothic UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelNom.ForeColor = System.Drawing.Color.Black;
			this.flatLabelNom.Location = new System.Drawing.Point(705, 84);
			this.flatLabelNom.Name = "flatLabelNom";
			this.flatLabelNom.Size = new System.Drawing.Size(82, 40);
			this.flatLabelNom.TabIndex = 11;
			this.flatLabelNom.Text = "Nom";
			// 
			// alerte
			// 
			this.alerte.BackColor = System.Drawing.Color.Tomato;
			this.alerte.Dock = System.Windows.Forms.DockStyle.Top;
			this.alerte.Enable = false;
			this.alerte.HeightMax = 40;
			this.alerte.Location = new System.Drawing.Point(0, 0);
			this.alerte.Name = "alerte";
			this.alerte.Size = new System.Drawing.Size(1856, 39);
			this.alerte.TabIndex = 2;
			this.alerte.Visible = false;
			// 
			// Ajouter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Name = "Ajouter";
			this.Size = new System.Drawing.Size(1856, 893);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.panelCorps.ResumeLayout(false);
			this.panelCorps.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private FlatControls.Controls.Buttons.FlatButton flatButtonAjouter;
		private FlatControls.Controls.FlatTextBox flatTextBoxPassword;
		private FlatControls.Controls.FlatLabel flatLabelPassword;
		private FlatControls.Controls.FlatTextBox flatTextName;
		private FlatControls.Controls.FlatLabel flatLabelNom;
		private FlatControls.Controls.Alerte alerte;
	}
}
