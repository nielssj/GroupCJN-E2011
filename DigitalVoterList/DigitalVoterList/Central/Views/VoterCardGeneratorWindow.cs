using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalVoterList.Central.Views
{
    using DigitalVoterList.Central.Models;

    public partial class VoterCardGeneratorWindow : Form, ISubView
    {
        private VoterCardGenerator model;

        public VoterCardGeneratorWindow(VoterCardGenerator model)
        {
            InitializeComponent();

            this.model = model;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            destinationFolderBrowser.ShowDialog();
            txbDestination.Text = destinationFolderBrowser.SelectedPath;
        }
    }
}
