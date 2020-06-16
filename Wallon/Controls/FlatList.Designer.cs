using Controls;

namespace Controls
{
	partial class FlatList
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
		private void InitializeComponent()
		{
			this.panelTitre = new System.Windows.Forms.Panel();
			this.flatLabelTitre = new Controls.FlatLabel();
			this.panelCorps = new System.Windows.Forms.Panel();
			this.panelTitre.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelTitre.BackColor = System.Drawing.Color.White;
			this.panelTitre.Controls.Add(this.flatLabelTitre);
			this.panelTitre.Location = new System.Drawing.Point(0, 0);
			this.panelTitre.Name = "panelTitre";
			this.panelTitre.Size = new System.Drawing.Size(420, 75);
			this.panelTitre.TabIndex = 0;
			this.panelTitre.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitre_Paint);
			// 
			// flatLabelTitre
			// 
			this.flatLabelTitre.AutoSize = true;
			this.flatLabelTitre.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelTitre.ForeColor = System.Drawing.Color.White;
			this.flatLabelTitre.Location = new System.Drawing.Point(16, 18);
			this.flatLabelTitre.Name = "flatLabelTitre";
			this.flatLabelTitre.Size = new System.Drawing.Size(0, 30);
			this.flatLabelTitre.TabIndex = 0;
			// 
			// panelCorps
			// 
			this.panelCorps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelCorps.BackColor = System.Drawing.Color.White;
			this.panelCorps.Location = new System.Drawing.Point(0, 75);
			this.panelCorps.Name = "panelCorps";
			this.panelCorps.Size = new System.Drawing.Size(420, 242);
			this.panelCorps.TabIndex = 1;
			this.panelCorps.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCorps_Paint);
			// 
			// FlatList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panelCorps);
			this.Controls.Add(this.panelTitre);
			this.Name = "FlatList";
			this.Size = new System.Drawing.Size(420, 317);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelTitre;
		private FlatLabel flatLabelTitre;
		private System.Windows.Forms.Panel panelCorps;
	}
}
