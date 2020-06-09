using Controls;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accueil));
			this.buttonVendre = new System.Windows.Forms.Button();
			this.buttonAcheter = new System.Windows.Forms.Button();
			this.buttonStock = new System.Windows.Forms.Button();
			this.panelCorps = new System.Windows.Forms.Panel();
			this.panelTitre.SuspendLayout();
			this.panelCorps.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Size = new System.Drawing.Size(1856, 120);
			// 
			// buttonVendre
			// 
			this.buttonVendre.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.buttonVendre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.buttonVendre.FlatAppearance.BorderSize = 0;
			this.buttonVendre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonVendre.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonVendre.ForeColor = System.Drawing.Color.White;
			this.buttonVendre.Image = ((System.Drawing.Image)(resources.GetObject("buttonVendre.Image")));
			this.buttonVendre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.buttonVendre.Location = new System.Drawing.Point(54, 299);
			this.buttonVendre.Name = "buttonVendre";
			this.buttonVendre.Size = new System.Drawing.Size(175, 175);
			this.buttonVendre.TabIndex = 1;
			this.buttonVendre.Text = "\r\nVendre";
			this.buttonVendre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonVendre.UseVisualStyleBackColor = false;
			this.buttonVendre.Click += new System.EventHandler(this.buttonVendre_Click);
			// 
			// buttonAcheter
			// 
			this.buttonAcheter.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonAcheter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.buttonAcheter.FlatAppearance.BorderSize = 0;
			this.buttonAcheter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAcheter.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAcheter.ForeColor = System.Drawing.Color.White;
			this.buttonAcheter.Image = ((System.Drawing.Image)(resources.GetObject("buttonAcheter.Image")));
			this.buttonAcheter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.buttonAcheter.Location = new System.Drawing.Point(844, 299);
			this.buttonAcheter.Name = "buttonAcheter";
			this.buttonAcheter.Size = new System.Drawing.Size(175, 175);
			this.buttonAcheter.TabIndex = 2;
			this.buttonAcheter.Text = "\r\nAcheter";
			this.buttonAcheter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonAcheter.UseVisualStyleBackColor = false;
			this.buttonAcheter.Click += new System.EventHandler(this.buttonAcheter_Click);
			// 
			// buttonStock
			// 
			this.buttonStock.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.buttonStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.buttonStock.FlatAppearance.BorderSize = 0;
			this.buttonStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonStock.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStock.ForeColor = System.Drawing.Color.White;
			this.buttonStock.Image = ((System.Drawing.Image)(resources.GetObject("buttonStock.Image")));
			this.buttonStock.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.buttonStock.Location = new System.Drawing.Point(1634, 299);
			this.buttonStock.Name = "buttonStock";
			this.buttonStock.Size = new System.Drawing.Size(175, 175);
			this.buttonStock.TabIndex = 3;
			this.buttonStock.Text = "\r\nStock";
			this.buttonStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonStock.UseVisualStyleBackColor = false;
			this.buttonStock.Click += new System.EventHandler(this.buttonStock_Click);
			// 
			// panelCorps
			// 
			this.panelCorps.Controls.Add(this.buttonStock);
			this.panelCorps.Controls.Add(this.buttonVendre);
			this.panelCorps.Controls.Add(this.buttonAcheter);
			this.panelCorps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCorps.Location = new System.Drawing.Point(0, 120);
			this.panelCorps.Name = "panelCorps";
			this.panelCorps.Size = new System.Drawing.Size(1856, 773);
			this.panelCorps.TabIndex = 4;
			// 
			// Accueil
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panelCorps);
			this.Name = "Accueil";
			this.Size = new System.Drawing.Size(1856, 893);
			this.Controls.SetChildIndex(this.panelTitre, 0);
			this.Controls.SetChildIndex(this.panelCorps, 0);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.panelCorps.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button buttonVendre;
		private System.Windows.Forms.Button buttonAcheter;
		private System.Windows.Forms.Button buttonStock;
		private System.Windows.Forms.Panel panelCorps;
	}
}
