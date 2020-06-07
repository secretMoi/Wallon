using Controls;

namespace Wallon.Pages
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
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accueil));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelAlerte = new System.Windows.Forms.Panel();
			this.flatLabelAlerte = new FlatLabel();
			this.labelTitre = new System.Windows.Forms.Label();
			this.buttonVendre = new System.Windows.Forms.Button();
			this.buttonAcheter = new System.Windows.Forms.Button();
			this.buttonStock = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.panelAlerte.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.panel1.Controls.Add(this.panelAlerte);
			this.panel1.Controls.Add(this.labelTitre);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1856, 220);
			this.panel1.TabIndex = 0;
			// 
			// panelAlerte
			// 
			this.panelAlerte.BackColor = System.Drawing.Color.White;
			this.panelAlerte.Controls.Add(this.flatLabelAlerte);
			this.panelAlerte.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelAlerte.Location = new System.Drawing.Point(0, 0);
			this.panelAlerte.Margin = new System.Windows.Forms.Padding(0);
			this.panelAlerte.MaximumSize = new System.Drawing.Size(0, 45);
			this.panelAlerte.Name = "panelAlerte";
			this.panelAlerte.Size = new System.Drawing.Size(1856, 45);
			this.panelAlerte.TabIndex = 4;
			this.panelAlerte.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelAlerte_MouseClick);
			// 
			// flatLabelAlerte
			// 
			this.flatLabelAlerte.AutoSize = true;
			this.flatLabelAlerte.Font = new System.Drawing.Font("Yu Gothic UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelAlerte.ForeColor = System.Drawing.Color.Black;
			this.flatLabelAlerte.Location = new System.Drawing.Point(20, 10);
			this.flatLabelAlerte.Name = "flatLabelAlerte";
			this.flatLabelAlerte.Size = new System.Drawing.Size(769, 23);
			this.flatLabelAlerte.TabIndex = 0;
			this.flatLabelAlerte.Text = "Il existe des articles en quantité insuffisante ! Cliquez sur ce message pour con" +
	"sulter l\'état du stock.";
			this.flatLabelAlerte.Click += new System.EventHandler(this.flatLabelAlerte_Click);
			// 
			// labelTitre
			// 
			this.labelTitre.AutoSize = true;
			this.labelTitre.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitre.ForeColor = System.Drawing.Color.White;
			this.labelTitre.Location = new System.Drawing.Point(17, 85);
			this.labelTitre.Margin = new System.Windows.Forms.Padding(0);
			this.labelTitre.Name = "labelTitre";
			this.labelTitre.Size = new System.Drawing.Size(224, 37);
			this.labelTitre.TabIndex = 1;
			this.labelTitre.Text = "Tableau de bord";
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
			this.buttonVendre.Location = new System.Drawing.Point(54, 208);
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
			this.buttonAcheter.Location = new System.Drawing.Point(844, 208);
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
			this.buttonStock.Location = new System.Drawing.Point(1634, 208);
			this.buttonStock.Name = "buttonStock";
			this.buttonStock.Size = new System.Drawing.Size(175, 175);
			this.buttonStock.TabIndex = 3;
			this.buttonStock.Text = "\r\nStock";
			this.buttonStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonStock.UseVisualStyleBackColor = false;
			this.buttonStock.Click += new System.EventHandler(this.buttonStock_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.buttonStock);
			this.panel2.Controls.Add(this.buttonVendre);
			this.panel2.Controls.Add(this.buttonAcheter);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 220);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1856, 590);
			this.panel2.TabIndex = 4;
			// 
			// timer
			// 
			this.timer.Interval = 15;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// Accueil
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "Accueil";
			this.Size = new System.Drawing.Size(1856, 810);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panelAlerte.ResumeLayout(false);
			this.panelAlerte.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonVendre;
		private System.Windows.Forms.Button buttonAcheter;
		private System.Windows.Forms.Label labelTitre;
		private System.Windows.Forms.Button buttonStock;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panelAlerte;
		private FlatLabel flatLabelAlerte;
		private System.Windows.Forms.Timer timer;
	}
}
