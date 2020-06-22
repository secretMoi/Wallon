namespace Wallon.Pages.Vue
{
	partial class ThemePanel
	{

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
		protected void InitializeComponent()
		{
			this.panelTitre = new System.Windows.Forms.Panel();
			this.labelTitre = new System.Windows.Forms.Label();
			this.panelCorps = new System.Windows.Forms.Panel();
			this.panelTitre.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.panelTitre.Controls.Add(this.labelTitre);
			this.panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitre.Location = new System.Drawing.Point(0, 0);
			this.panelTitre.Name = "panelTitre";
			this.panelTitre.Size = new System.Drawing.Size(800, 120);
			this.panelTitre.TabIndex = 5;
			// 
			// labelTitre
			// 
			this.labelTitre.AutoSize = true;
			this.labelTitre.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitre.ForeColor = System.Drawing.Color.White;
			this.labelTitre.Location = new System.Drawing.Point(17, 42);
			this.labelTitre.Margin = new System.Windows.Forms.Padding(0);
			this.labelTitre.Name = "labelTitre";
			this.labelTitre.Size = new System.Drawing.Size(78, 37);
			this.labelTitre.TabIndex = 1;
			this.labelTitre.Text = "Titre";
			// 
			// panelCorps
			// 
			this.panelCorps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCorps.Location = new System.Drawing.Point(0, 120);
			this.panelCorps.Name = "panelCorps";
			this.panelCorps.Size = new System.Drawing.Size(800, 480);
			this.panelCorps.TabIndex = 6;
			// 
			// ThemePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panelCorps);
			this.Controls.Add(this.panelTitre);
			this.Name = "ThemePanel";
			this.Size = new System.Drawing.Size(800, 600);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		protected System.Windows.Forms.Panel panelTitre;
		protected System.Windows.Forms.Label labelTitre;
		private System.ComponentModel.IContainer components;
		protected System.Windows.Forms.Panel panelCorps;
	}
}
