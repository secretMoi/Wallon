using Controls;
using FlatControls.Controls;

namespace Wallon.Fenetres
{
	partial class Dialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog));
			this.panelHeader = new System.Windows.Forms.Panel();
			this.flatLabel1 = new FlatControls.Controls.FlatLabel();
			this.panelHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelHeader
			// 
			this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(193)))));
			this.panelHeader.Controls.Add(this.flatLabel1);
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHeader.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panelHeader.Location = new System.Drawing.Point(0, 0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(600, 94);
			this.panelHeader.TabIndex = 6;
			this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
			// 
			// flatLabel1
			// 
			this.flatLabel1.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flatLabel1.ForeColor = System.Drawing.Color.White;
			this.flatLabel1.Location = new System.Drawing.Point(12, 9);
			this.flatLabel1.Name = "flatLabel1";
			this.flatLabel1.Size = new System.Drawing.Size(576, 72);
			this.flatLabel1.TabIndex = 8;
			this.flatLabel1.Text = "flatLabel1";
			this.flatLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flatLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
			// 
			// Dialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(600, 250);
			this.Controls.Add(this.panelHeader);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Dialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dialog";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dialog_Paint);
			this.panelHeader.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelHeader;
		private FlatControls.Controls.FlatLabel flatLabel1;
	}
}