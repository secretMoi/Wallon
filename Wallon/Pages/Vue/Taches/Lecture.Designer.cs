namespace Wallon.Pages.Vue.Taches
{
    partial class Lecture
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.flatButtonModifier = new FlatControls.Controls.Buttons.FlatButton();
			this.flatTextBoxDescription = new FlatControls.Controls.FlatTextBox();
			this.alerte = new FlatControls.Controls.Alerte();
			this.panelTitre.SuspendLayout();
			this.panelCorps.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitre
			// 
			this.panelTitre.Controls.Add(this.alerte);
			this.panelTitre.Size = new System.Drawing.Size(1856, 120);
			this.panelTitre.Controls.SetChildIndex(this.labelTitre, 0);
			this.panelTitre.Controls.SetChildIndex(this.alerte, 0);
			// 
			// panelCorps
			// 
			this.panelCorps.Controls.Add(this.panel1);
			this.panelCorps.Controls.Add(this.flatTextBoxDescription);
			this.panelCorps.Size = new System.Drawing.Size(1856, 772);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.flatButtonModifier);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 711);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1856, 61);
			this.panel1.TabIndex = 1;
			// 
			// flatButtonModifier
			// 
			this.flatButtonModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flatButtonModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.flatButtonModifier.FlatAppearance.BorderSize = 0;
			this.flatButtonModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatButtonModifier.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatButtonModifier.ForeColor = System.Drawing.Color.White;
			this.flatButtonModifier.Location = new System.Drawing.Point(1668, 3);
			this.flatButtonModifier.Name = "flatButtonModifier";
			this.flatButtonModifier.Size = new System.Drawing.Size(150, 54);
			this.flatButtonModifier.TabIndex = 0;
			this.flatButtonModifier.Text = "Modifier";
			this.flatButtonModifier.UseVisualStyleBackColor = false;
			this.flatButtonModifier.Click += new System.EventHandler(this.flatButtonModifier_Click);
			// 
			// flatTextBoxDescription
			// 
			this.flatTextBoxDescription.AutoSize = true;
			this.flatTextBoxDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flatTextBoxDescription.IsPassword = false;
			this.flatTextBoxDescription.Location = new System.Drawing.Point(0, 0);
			this.flatTextBoxDescription.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextBoxDescription.Multiline = true;
			this.flatTextBoxDescription.Name = "flatTextBoxDescription";
			this.flatTextBoxDescription.Size = new System.Drawing.Size(1856, 772);
			this.flatTextBoxDescription.SizeTextField = new System.Drawing.Size(140, 20);
			this.flatTextBoxDescription.TabIndex = 0;
			this.flatTextBoxDescription.TextHorizontalAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.flatTextBoxDescription.Resize += new System.EventHandler(this.flatTextBoxDescription_Resize);
			// 
			// alerte
			// 
			this.alerte.BackColor = System.Drawing.Color.Tomato;
			this.alerte.Dock = System.Windows.Forms.DockStyle.Top;
			this.alerte.Enable = false;
			this.alerte.HeightMax = 40;
			this.alerte.Location = new System.Drawing.Point(0, 0);
			this.alerte.Margin = new System.Windows.Forms.Padding(0);
			this.alerte.Name = "alerte";
			this.alerte.Size = new System.Drawing.Size(1856, 39);
			this.alerte.TabIndex = 2;
			this.alerte.Visible = false;
			// 
			// Lecture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Name = "Lecture";
			this.Size = new System.Drawing.Size(1856, 892);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.panelCorps.ResumeLayout(false);
			this.panelCorps.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private FlatControls.Controls.FlatTextBox flatTextBoxDescription;
		private System.Windows.Forms.Panel panel1;
		private FlatControls.Controls.Buttons.FlatButton flatButtonModifier;
		private FlatControls.Controls.Alerte alerte;
	}
}
