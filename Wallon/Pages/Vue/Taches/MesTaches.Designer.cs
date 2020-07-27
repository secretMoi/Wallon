namespace Wallon.Pages.Vue.Taches
{
	partial class MesTaches
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
			this.flatDataGridView = new FlatControls.Controls.FlatDataGridView();
			this.alerte = new FlatControls.Controls.Alerte();
			this.panelTitre.SuspendLayout();
			this.panelCorps.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Controls.Add(this.alerte);
			this.panelTitre.Size = new System.Drawing.Size(3001, 120);
			this.panelTitre.Controls.SetChildIndex(this.labelTitre, 0);
			this.panelTitre.Controls.SetChildIndex(this.alerte, 0);
			// 
			// panelCorps
			// 
			this.panelCorps.Controls.Add(this.flatDataGridView);
			this.panelCorps.Size = new System.Drawing.Size(3001, 1096);
			// 
			// flatDataGridView
			// 
			this.flatDataGridView.DataSource = null;
			this.flatDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flatDataGridView.Location = new System.Drawing.Point(0, 0);
			this.flatDataGridView.Name = "flatDataGridView";
			this.flatDataGridView.Size = new System.Drawing.Size(3001, 1096);
			this.flatDataGridView.TabIndex = 0;
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
			// MesTaches
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Name = "MesTaches";
			this.Size = new System.Drawing.Size(3001, 1216);
			this.Load += new System.EventHandler(this.MesTaches_Load);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.panelCorps.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private FlatControls.Controls.FlatDataGridView flatDataGridView;
		private FlatControls.Controls.Alerte alerte;
	}
}
