namespace Controls
{
    partial class Utilisation
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
            this.labelNom = new System.Windows.Forms.Label();
            this.labelEspace = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNom.Location = new System.Drawing.Point(3, 0);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(51, 20);
            this.labelNom.TabIndex = 0;
            this.labelNom.Text = "label1";
            // 
            // labelEspace
            // 
            this.labelEspace.AutoSize = true;
            this.labelEspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEspace.Location = new System.Drawing.Point(3, 54);
            this.labelEspace.Name = "labelEspace";
            this.labelEspace.Size = new System.Drawing.Size(51, 20);
            this.labelEspace.TabIndex = 1;
            this.labelEspace.Text = "label2";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 23);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(222, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Utilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelEspace);
            this.Controls.Add(this.labelNom);
            this.Name = "Utilisation";
            this.Size = new System.Drawing.Size(232, 74);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelEspace;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
