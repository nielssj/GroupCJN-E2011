using System;
using System.Windows.Forms;

namespace DigitalVoterList.Central.Views
{
    using System.ComponentModel;

    using DigitalVoterList.Central.Models;

    public partial class VoterCardGeneratorWindow : Form, ISubView
    {
        private readonly VoterCardGenerator model;

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

        /// <summary> Notify me when the generate button is clicked. </summary>
        /// <param name="handler">The handler to be called upon click.</param>
        public void AddGenerateHandler(Action<String, int, int> handler)
        {
            btnGenerate.Click += (a, eA) => this.fetchGrouping(handler);
        }

        /// <summary> Notify me when the view has been ordered to close. </summary>
        /// <param name="handler">The handler to be called.</param>
        public void AddClosingHandler(Action<ISubModel> handler)
        {
            this.Disposed += (o, eA) => handler(model);
        }

        public ISubModel GetModel()
        {
            return model;
        }

        private void fetchGrouping(Action<String, int, int> handler)
        {
            int property = -1;
            int limit = -1;

            if (chbProperty.Checked) property = cbxProperty.SelectedIndex;
            if (chbLimit.Checked) limit = Convert.ToInt16(txbLimit.Text);
            
            handler(txbDestination.Text, property, limit);
        }

        private void UpdateCurrentGroup(string groupName)
        {
            lblCurrentGroup.Text = groupName;
            this.Refresh();
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
