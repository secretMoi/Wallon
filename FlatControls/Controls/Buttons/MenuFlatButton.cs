﻿using System.Drawing;
using System.Windows.Forms;
using FlatControls.Controls.Buttons;

namespace FlatControls.Controls.Buttons
{
    public partial class MenuFlatButton : FlatButton
    {
        public MenuFlatButton()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(25, 118, 211);
            ImageAlign = ContentAlignment.MiddleLeft;
            Size = new Size(275, 70);
            Font = new Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextImageRelation = TextImageRelation.ImageBeforeText;
        }
    }
}
