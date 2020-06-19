namespace Wallon.Pages.Vue
{
	partial class Accueil
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
			this.panelTitre.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Size = new System.Drawing.Size(1539, 120);
			// 
			// panelCorps
			// 
			this.panelCorps.Size = new System.Drawing.Size(1539, 436);
			// 
			// Accueil
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.Name = "Accueil";
			this.Size = new System.Drawing.Size(1539, 556);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		//private System.Windows.Forms.Panel panelCorps;
	}
}
