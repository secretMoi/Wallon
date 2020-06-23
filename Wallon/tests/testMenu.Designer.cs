namespace Wallon.tests
{
	partial class TestMenu
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
			this.mainMenu1 = new Wallon.tests.MainMenu();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.AutoScroll = true;
			this.mainMenu1.DefaultCallback = null;
			this.mainMenu1.Dock = System.Windows.Forms.DockStyle.Left;
			this.mainMenu1.HeightItem = 70;
			this.mainMenu1.Location = new System.Drawing.Point(0, 0);
			this.mainMenu1.Margin = new System.Windows.Forms.Padding(0);
			this.mainMenu1.Name = "mainMenu1";
			this.mainMenu1.Size = new System.Drawing.Size(171, 450);
			this.mainMenu1.SpeedStep = 7;
			this.mainMenu1.TabIndex = 0;
			// 
			// TestMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.mainMenu1);
			this.Name = "TestMenu";
			this.Text = "testMenu";
			this.ResumeLayout(false);

		}

		#endregion

		private MainMenu mainMenu1;
	}
}