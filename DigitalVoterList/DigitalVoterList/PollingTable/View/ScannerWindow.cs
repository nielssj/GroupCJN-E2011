﻿
// -----------------------------------------------------------------------
// <copyright file="Model.cs" company="">
// Author: Claes Martinsen.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Forms;

namespace DigitalVoterList
{
    using System.Drawing;

    /// <summary>
    /// Window where the user scans or types in the voter card.
    /// </summary>
    public partial class ScannerWindow : Form
    {
        public ScannerWindow()
        {
            InitializeComponent();

            var size = new Size(550, 310);
            this.MinimumSize = size;
            this.MaximumSize = size;

        }
    }
}
