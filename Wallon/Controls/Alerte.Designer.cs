namespace Controls
{
	partial class Alerte
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
			this.flatLabelText = new FlatLabel();
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Interval = 15;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// flatLabelText
			// 
			this.flatLabelText.AutoSize = true;
			this.flatLabelText.Font = new System.Drawing.Font("Yu Gothic UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelText.ForeColor = System.Drawing.Color.White;
			this.flatLabelText.Location = new System.Drawing.Point(12, 9);
			this.flatLabelText.Name = "flatLabelText";
			this.flatLabelText.Size = new System.Drawing.Size(83, 23);
			this.flatLabelText.TabIndex = 0;
			this.flatLabelText.Text = "flatLabel1";
			// 
			// Alerte
			// 
			this.Controls.Add(this.flatLabelText);
			this.Name = "Alerte";
			this.Size = new System.Drawing.Size(1358, 150);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer timer;
		private FlatLabel flatLabelText;
	}
}
