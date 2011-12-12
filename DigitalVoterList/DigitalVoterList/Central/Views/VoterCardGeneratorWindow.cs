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
            model.VoterDonePercChanged += (i => pbrVoters.Value = i);
            model.GroupCountChanged += (i => pbrGroups.Maximum = i);
            model.GroupDoneCountChanged += (i => pbrGroups.Value = i);
            model.CurrentGroupChanged += this.UpdateCurrentGroup;
            model.GenerationEnded += this.TearDownGeneration;
        }

        /// <summary> Notify me when the generate button is clicked. </summary>
        /// <param name="handler">The handler to be called upon click.</param>
        public void AddGenerateHandler(Action<String, int, int> handler)
        {
            btnGenerate.Click += (a, eA) => this.SetUpGeneration(handler);
        }

        /// <summary> Notify me when the abort button is clicked. </summary>
        /// <param name="handler">The handler to be called upon click.</param>
        public void AddAbortHandler(Action handler)
        {
            btnAbort.Click += (a, eA) => handler();
        }

        /// <summary> Notify me when the view has been ordered to close. </summary>
        /// <param name="handler">The handler to be called.</param>
        public void AddClosingHandler(Action<ISubModel> handler)
        {
            this.Disposed += (o, eA) => handler(model);
        }

        /// <summary> What model is associated with this view? </summary>
        /// <returns>The associated model.</returns>
        public ISubModel GetModel()
        {
            return model;
        }

        // Prepare for generation.
        // Retrieve grouping data and change state.
        private void SetUpGeneration(Action<String, int, int> handler)
        {
            // Retrieve grouping input, if checked by user.
            int property = -1;
            int limit = -1;
            if (chbProperty.Checked) property = cbxProperty.SelectedIndex;
            if (chbLimit.Checked) limit = Convert.ToInt16(txbLimit.Text);

            // Go into 'generating state'.
            btnAbort.Visible = true;
            btnGenerate.Visible = false;
            
            handler(txbDestination.Text, property, limit);
        }

        // Return to original state.
        private void TearDownGeneration(String cause)
        {
            btnGenerate.Visible = true;
            btnAbort.Visible = false;
            lblCurrentGroup.Text = cause;
        }

        // Update the current group label 
        // (requires an explicit refresh to avoid being overshadowed by progress bar updates).
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
    }
}
