﻿using FlatControls.Controls;

namespace Wallon.Pages.Vue.Taches
{
	partial class Consulter
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
			this.panelTitre.SuspendLayout();
			this.panelCorps.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Size = new System.Drawing.Size(1472, 120);
			// 
			// panelCorps
			// 
			this.panelCorps.Controls.Add(this.flatDataGridView);
			this.panelCorps.Size = new System.Drawing.Size(1472, 1420);
			// 
			// flatDataGridView
			// 
			this.flatDataGridView.DataSource = null;
			this.flatDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flatDataGridView.Location = new System.Drawing.Point(0, 0);
			this.flatDataGridView.Name = "flatDataGridView";
			this.flatDataGridView.Size = new System.Drawing.Size(1472, 1420);
			this.flatDataGridView.TabIndex = 0;
			// 
			// Consulter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Name = "Consulter";
			this.Size = new System.Drawing.Size(1472, 1540);
			this.Load += new System.EventHandler(this.Consulter_Load);
			this.SizeChanged += new System.EventHandler(this.Consulter_SizeChanged);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.panelCorps.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private FlatDataGridView flatDataGridView;
	}
}
