using FlatControls.Controls;
using FlatControls.Controls.Buttons;

namespace Wallon.Pages.Vue.Taches
{
	partial class Ajouter
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
			this.flatListBoxLocataireCourant = new FlatControls.Controls.FlatListBox();
			this.flatLabelLocataireCourant = new FlatControls.Controls.FlatLabel();
			this.flatTextBoxCycle = new FlatControls.Controls.FlatTextBox();
			this.flatLabelCycle = new FlatControls.Controls.FlatLabel();
			this.flatButtonAjouter = new FlatControls.Controls.Buttons.FlatButton();
			this.flatTextBoxDatteDebut = new FlatControls.Controls.FlatTextBox();
			this.flatLabelDateDebut = new FlatControls.Controls.FlatLabel();
			this.flatTextName = new FlatControls.Controls.FlatTextBox();
			this.flatLabelNom = new FlatControls.Controls.FlatLabel();
			this.flatList = new FlatControls.Controls.FlatList();
			this.panelTitre.SuspendLayout();
			this.panelCorps.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelCorps
			// 
			this.panelCorps.Controls.Add(this.flatDataGridView);
			this.panelCorps.Controls.Add(this.flatListBoxLocataireCourant);
			this.panelCorps.Controls.Add(this.flatLabelLocataireCourant);
			this.panelCorps.Controls.Add(this.flatTextBoxCycle);
			this.panelCorps.Controls.Add(this.flatLabelCycle);
			this.panelCorps.Controls.Add(this.flatButtonAjouter);
			this.panelCorps.Controls.Add(this.flatTextBoxDatteDebut);
			this.panelCorps.Controls.Add(this.flatLabelDateDebut);
			this.panelCorps.Controls.Add(this.flatTextName);
			this.panelCorps.Controls.Add(this.flatLabelNom);
			this.panelCorps.Controls.Add(this.flatList);
			// 
			// flatDataGridView
			// 
			this.flatDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flatDataGridView.Location = new System.Drawing.Point(1497, 6);
			this.flatDataGridView.Name = "flatDataGridView";
			this.flatDataGridView.Size = new System.Drawing.Size(356, 434);
			this.flatDataGridView.TabIndex = 20;
			// 
			// flatListBoxLocataireCourant
			// 
			this.flatListBoxLocataireCourant.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flatListBoxLocataireCourant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.flatListBoxLocataireCourant.Location = new System.Drawing.Point(191, 276);
			this.flatListBoxLocataireCourant.Margin = new System.Windows.Forms.Padding(0);
			this.flatListBoxLocataireCourant.MinimumSize = new System.Drawing.Size(150, 40);
			this.flatListBoxLocataireCourant.Name = "flatListBoxLocataireCourant";
			this.flatListBoxLocataireCourant.Size = new System.Drawing.Size(237, 40);
			this.flatListBoxLocataireCourant.TabIndex = 19;
			// 
			// flatLabelLocataireCourant
			// 
			this.flatLabelLocataireCourant.AutoSize = true;
			this.flatLabelLocataireCourant.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelLocataireCourant.ForeColor = System.Drawing.Color.Black;
			this.flatLabelLocataireCourant.Location = new System.Drawing.Point(5, 276);
			this.flatLabelLocataireCourant.Name = "flatLabelLocataireCourant";
			this.flatLabelLocataireCourant.Size = new System.Drawing.Size(188, 32);
			this.flatLabelLocataireCourant.TabIndex = 18;
			this.flatLabelLocataireCourant.Text = "Locataire actuel";
			// 
			// flatTextBoxCycle
			// 
			this.flatTextBoxCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextBoxCycle.IsPassword = false;
			this.flatTextBoxCycle.Location = new System.Drawing.Point(191, 190);
			this.flatTextBoxCycle.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextBoxCycle.Name = "flatTextBoxCycle";
			this.flatTextBoxCycle.Size = new System.Drawing.Size(237, 40);
			this.flatTextBoxCycle.TabIndex = 17;
			// 
			// flatLabelCycle
			// 
			this.flatLabelCycle.AutoSize = true;
			this.flatLabelCycle.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelCycle.ForeColor = System.Drawing.Color.Black;
			this.flatLabelCycle.Location = new System.Drawing.Point(5, 190);
			this.flatLabelCycle.Name = "flatLabelCycle";
			this.flatLabelCycle.Size = new System.Drawing.Size(177, 32);
			this.flatLabelCycle.TabIndex = 16;
			this.flatLabelCycle.Text = "Temps en jours";
			// 
			// flatButtonAjouter
			// 
			this.flatButtonAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.flatButtonAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
			this.flatButtonAjouter.FlatAppearance.BorderSize = 0;
			this.flatButtonAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatButtonAjouter.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatButtonAjouter.ForeColor = System.Drawing.Color.White;
			this.flatButtonAjouter.Location = new System.Drawing.Point(215, 701);
			this.flatButtonAjouter.Name = "flatButtonAjouter";
			this.flatButtonAjouter.Size = new System.Drawing.Size(237, 56);
			this.flatButtonAjouter.TabIndex = 15;
			this.flatButtonAjouter.Text = "Ajouter";
			this.flatButtonAjouter.UseVisualStyleBackColor = false;
			this.flatButtonAjouter.Click += new System.EventHandler(this.flatButtonAjouter_Click);
			// 
			// flatTextBoxDatteDebut
			// 
			this.flatTextBoxDatteDebut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextBoxDatteDebut.IsPassword = false;
			this.flatTextBoxDatteDebut.Location = new System.Drawing.Point(191, 104);
			this.flatTextBoxDatteDebut.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextBoxDatteDebut.Name = "flatTextBoxDatteDebut";
			this.flatTextBoxDatteDebut.Size = new System.Drawing.Size(237, 40);
			this.flatTextBoxDatteDebut.TabIndex = 14;
			// 
			// flatLabelDateDebut
			// 
			this.flatLabelDateDebut.AutoSize = true;
			this.flatLabelDateDebut.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelDateDebut.ForeColor = System.Drawing.Color.Black;
			this.flatLabelDateDebut.Location = new System.Drawing.Point(5, 104);
			this.flatLabelDateDebut.Name = "flatLabelDateDebut";
			this.flatLabelDateDebut.Size = new System.Drawing.Size(138, 32);
			this.flatLabelDateDebut.TabIndex = 13;
			this.flatLabelDateDebut.Text = "Date début";
			// 
			// flatTextName
			// 
			this.flatTextName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
			this.flatTextName.IsPassword = false;
			this.flatTextName.Location = new System.Drawing.Point(191, 18);
			this.flatTextName.Margin = new System.Windows.Forms.Padding(0);
			this.flatTextName.Name = "flatTextName";
			this.flatTextName.Size = new System.Drawing.Size(237, 40);
			this.flatTextName.TabIndex = 12;
			// 
			// flatLabelNom
			// 
			this.flatLabelNom.AutoSize = true;
			this.flatLabelNom.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabelNom.ForeColor = System.Drawing.Color.Black;
			this.flatLabelNom.Location = new System.Drawing.Point(5, 18);
			this.flatLabelNom.Name = "flatLabelNom";
			this.flatLabelNom.Size = new System.Drawing.Size(68, 32);
			this.flatLabelNom.TabIndex = 11;
			this.flatLabelNom.Text = "Nom";
			// 
			// flatList
			// 
			this.flatList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flatList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flatList.BackColor = System.Drawing.Color.White;
			this.flatList.Location = new System.Drawing.Point(2000, 18);
			this.flatList.Name = "flatList";
			this.flatList.Size = new System.Drawing.Size(235, 317);
			this.flatList.TabIndex = 0;
			// 
			// Ajouter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Name = "Ajouter";
			this.Load += new System.EventHandler(this.Ajouter_Load);
			this.panelTitre.ResumeLayout(false);
			this.panelTitre.PerformLayout();
			this.panelCorps.ResumeLayout(false);
			this.panelCorps.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private FlatList flatList;
		private FlatButton flatButtonAjouter;
		private FlatTextBox flatTextBoxDatteDebut;
		private FlatLabel flatLabelDateDebut;
		private FlatTextBox flatTextName;
		private FlatLabel flatLabelNom;
		private FlatTextBox flatTextBoxCycle;
		private FlatLabel flatLabelCycle;
		private FlatLabel flatLabelLocataireCourant;
		private FlatListBox flatListBoxLocataireCourant;
		private FlatDataGridView flatDataGridView;
	}
}
