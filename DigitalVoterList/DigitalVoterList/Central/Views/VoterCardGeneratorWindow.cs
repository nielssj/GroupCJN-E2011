using System;
using System.Windows.Forms;

namespace DigitalVoterList.Central.Views
{
    using System.ComponentModel;

    using DigitalVoterList.Central.Models;

    public partial class VoterCardGeneratorWindow : Form, ISubView
    {
        private VoterCardGenerator model;

        public VoterCardGeneratorWindow(VoterCardGenerator model)
        {
            InitializeComponent();

            this.model = model;
        }

        /// <summary> Notify me when the window is closing. </summary>
        /// <param name="handler">The handler to be called upon closing.</param>
        public void AddClosingHandler(CancelEventHandler handler)
        {
            this.Closing += handler;
        }

        // Open folderBrowser upon 'Browse' button clicked.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            destinationFolderBrowser.ShowDialog();
            txbDestination.Text = destinationFolderBrowser.SelectedPath;
        }

        // Close upon 'Cancel' button clicked.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
