using FlatControls.Controls.Buttons;

namespace Wallon.Fenetres
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.panelContainer = new System.Windows.Forms.Panel();
			this.panelHeader = new System.Windows.Forms.Panel();
			this.pictureBoxReduce = new System.Windows.Forms.PictureBox();
			this.pictureBoxClose = new System.Windows.Forms.PictureBox();
			this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
			this.pictureBoxResize = new System.Windows.Forms.PictureBox();
			this.mainMenu = new FlatControls.Controls.MainMenu.MainMenu();
			this.panelHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxReduce)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResize)).BeginInit();
			this.SuspendLayout();
			// 
			// panelContainer
			// 
			this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelContainer.Location = new System.Drawing.Point(272, 90);
			this.panelContainer.Name = "panelContainer";
			this.panelContainer.Size = new System.Drawing.Size(800, 700);
			this.panelContainer.TabIndex = 4;
			// 
			// panelHeader
			// 
			this.panelHeader.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.panelHeader.Controls.Add(this.pictureBoxReduce);
			this.panelHeader.Controls.Add(this.pictureBoxClose);
			this.panelHeader.Controls.Add(this.pictureBoxLogo);
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHeader.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panelHeader.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panelHeader.Location = new System.Drawing.Point(0, 0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(1072, 90);
			this.panelHeader.TabIndex = 5;
			this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
			// 
			// pictureBoxReduce
			// 
			this.pictureBoxReduce.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.pictureBoxReduce.Location = new System.Drawing.Point(949, 28);
			this.pictureBoxReduce.Name = "pictureBoxReduce";
			this.pictureBoxReduce.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxReduce.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxReduce.TabIndex = 1;
			this.pictureBoxReduce.TabStop = false;
			this.pictureBoxReduce.Click += new System.EventHandler(this.pictureBoxReduce_Click);
			this.pictureBoxReduce.MouseEnter += new System.EventHandler(this.pictureBoxReduce_MouseEnter);
			this.pictureBoxReduce.MouseLeave += new System.EventHandler(this.pictureBoxReduce_MouseLeave);
			// 
			// pictureBoxClose
			// 
			this.pictureBoxClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.pictureBoxClose.Location = new System.Drawing.Point(1011, 28);
			this.pictureBoxClose.Name = "pictureBoxClose";
			this.pictureBoxClose.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxClose.TabIndex = 0;
			this.pictureBoxClose.TabStop = false;
			this.pictureBoxClose.Click += new System.EventHandler(this.buttonClose_Click);
			this.pictureBoxClose.MouseEnter += new System.EventHandler(this.pictureBoxClose_MouseEnter);
			this.pictureBoxClose.MouseLeave += new System.EventHandler(this.pictureBoxClose_MouseLeave);
			// 
			// pictureBoxLogo
			// 
			this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
			this.pictureBoxLogo.Location = new System.Drawing.Point(37, 3);
			this.pictureBoxLogo.Name = "pictureBoxLogo";
			this.pictureBoxLogo.Size = new System.Drawing.Size(185, 88);
			this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxLogo.TabIndex = 0;
			this.pictureBoxLogo.TabStop = false;
			this.pictureBoxLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseMove);
			// 
			// pictureBoxResize
			// 
			this.pictureBoxResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
			this.pictureBoxResize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxResize.Image")));
			this.pictureBoxResize.Location = new System.Drawing.Point(1046, 764);
			this.pictureBoxResize.Name = "pictureBoxResize";
			this.pictureBoxResize.Size = new System.Drawing.Size(24, 24);
			this.pictureBoxResize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxResize.TabIndex = 2;
			this.pictureBoxResize.TabStop = false;
			this.pictureBoxResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxResize_MouseDown);
			this.pictureBoxResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxResize_MouseMove);
			this.pictureBoxResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxResize_MouseUp);
			// 
			// mainMenu
			// 
			this.mainMenu.BackColorSub = System.Drawing.Color.Empty;
			this.mainMenu.DefaultCallback = null;
			this.mainMenu.DefaultPath = null;
			this.mainMenu.Dock = System.Windows.Forms.DockStyle.Left;
			this.mainMenu.HeightItem = 80;
			this.mainMenu.HeightSubItem = 60;
			this.mainMenu.Location = new System.Drawing.Point(0, 90);
			this.mainMenu.Margin = new System.Windows.Forms.Padding(0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(277, 700);
			this.mainMenu.SpeedStep = 7;
			this.mainMenu.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1072, 790);
			this.Controls.Add(this.mainMenu);
			this.Controls.Add(this.pictureBoxResize);
			this.Controls.Add(this.panelHeader);
			this.Controls.Add(this.panelContainer);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(1072, 790);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MySyno";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.panelHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxReduce)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResize)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxReduce;
        private System.Windows.Forms.PictureBox pictureBoxResize;
		private FlatControls.Controls.MainMenu.MainMenu mainMenu;
	}
}

