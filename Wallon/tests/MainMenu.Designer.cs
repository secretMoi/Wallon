namespace Wallon.tests
{
	sealed partial class MainMenu
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
			this.components = new System.ComponentModel.Container();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.panelContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Interval = 15;
			this.timer.Tick += new System.EventHandler(this.timerMenuDeroulant_Tick);
			// 
			// panelContainer
			// 
			this.panelContainer.AutoScroll = true;
			this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContainer.Location = new System.Drawing.Point(0, 0);
			this.panelContainer.Margin = new System.Windows.Forms.Padding(0);
			this.panelContainer.Name = "panelContainer";
			this.panelContainer.Size = new System.Drawing.Size(488, 587);
			this.panelContainer.TabIndex = 0;
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.panelContainer);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "MainMenu";
			this.Size = new System.Drawing.Size(488, 587);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.FlowLayoutPanel panelContainer;
	}
}
