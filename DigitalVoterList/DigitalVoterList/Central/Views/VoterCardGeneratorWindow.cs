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

            // Subscribe to changes in model.
            model.VoterCountChanged += (i => pbrVoters.Maximum = i);
            model.VoterDoneCountChanged += (i => pbrVoters.Value = i);
            model.GroupCountChanged += (i => pbrGroups.Maximum = i);
            model.GroupDoneCountChanged += (i => pbrGroups.Value = i);
            model.CurrentGroupChanged += this.UpdateCurrentGroup;
        }

        private void UpdateCurrentGroup(string groupName)
        {
            lblCurrentGroup.Text = groupName;
            this.Refresh();
        }

        /// <summary> Notify me when the window is closing. </summary>
        /// <param name="handler">The handler to be called upon closing.</param>
        public void AddClosingHandler(CancelEventHandler handler)
        {
            this.Closing += handler;
        }

        /// <summary> Notify me when the generate button is clicked. </summary>
        /// <param name="handler">The handler to be called upon click.</param>
        public void AddGenerateHandler(Action<String, int, int> handler)
        {
            btnGenerate.Click += (a, eA) => this.fetchGrouping(handler);
        }

        private void fetchGrouping(Action<String, int, int> handler)
        {
            int property = -1;
            int limit = -1;

            if (chbProperty.Checked) property = cbxProperty.SelectedIndex;
            if (chbLimit.Checked) limit = Convert.ToInt16(txbLimit.Text);
            
            handler(txbDestination.Text, property, limit);
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
