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
			this.flatLabelNom = new Controls.FlatLabel();
			this.flatTextName = new Controls.FlatTextBox();
			this.flatTextBox1 = new Controls.FlatTextBox();
			this.flatLabelPassword = new Controls.FlatLabel();
			this.panelTitre.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Size = new System.Drawing.Size(1856, 120);
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
			// flatTextBox1
			// 
			this.flatTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flatTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextBox1.Location = new System.Drawing.Point(937, 286);
			this.flatTextBox1.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextBox1.Name = "flatTextBox1";
			this.flatTextBox1.Size = new System.Drawing.Size(215, 40);
			this.flatTextBox1.TabIndex = 9;
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
			// Connexion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.flatTextBox1);
			this.Controls.Add(this.flatLabelPassword);
			this.Controls.Add(this.flatTextName);
			this.Controls.Add(this.flatLabelNom);
			this.Name = "Connexion";
			this.Size = new System.Drawing.Size(1856, 893);
			this.Controls.SetChildIndex(this.panelTitre, 0);
			this.Controls.SetChildIndex(this.flatLabelNom, 0);
			this.Controls.SetChildIndex(this.flatTextName, 0);
			this.Controls.SetChildIndex(this.flatLabelPassword, 0);
			this.Controls.SetChildIndex(this.flatTextBox1, 0);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.FlatLabel flatLabelNom;
		private Controls.FlatTextBox flatTextName;
		private Controls.FlatTextBox flatTextBox1;
		private Controls.FlatLabel flatLabelPassword;
	}
}
