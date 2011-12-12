using System;
using System.Windows.Forms;

namespace DigitalVoterList.Central.Views
{
    using System.ComponentModel;
    using System.IO;

    using DigitalVoterList.Central.Models;

    public partial class VoterCardGeneratorWindow : Form, ISubView
    {
        private const string DefaultDestination = "C:\\VoterCards";

        private readonly VoterCardGenerator model;

        public VoterCardGeneratorWindow(VoterCardGenerator model)
        {
            InitializeComponent();
            this.model = model;
            this.InitialValues();    // Set up initial values for controls.
            this.SubscribeToModel(); // Subscribe to changes in model.
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
        /// <param name="handler">The handler to be called upon closing.</param>
        public void AddClosingHandler(Action<ISubModel> handler)
        {
            this.Disposed += (o, eA) => handler(model);
        }

        // Switch to 'generating state'.
        public void GenerateMode(String status)
        {
            btnAbort.Visible = true;
            btnGenerate.Visible = false;
            this.lblStatus.Text = status;
        }

        // Return to original state.
        public void NormalMode(String status)
        {
            btnGenerate.Visible = true;
            btnAbort.Visible = false;
            this.lblStatus.Text = status;
        }

        /// <summary> What model is associated with this view? </summary>
        /// <returns>The associated model.</returns>
        public ISubModel GetModel()
        {
            return model;
        }

        // Set up initial values for controls
        private void InitialValues()
        {
            VoterFilter filter = model.Filter;
            if (filter != null)
            {
                if (filter.Municipality != null) txbMunicipality.Text = filter.Municipality.Name;
                if (filter.PollingStation != null) txbPollingStation.Text = filter.PollingStation.Name;
                if (filter.CPRNO > 0) txbCPR.Text = filter.CPRNO.ToString();
            }
            txbDestination.Text = DefaultDestination;
        }

        // Subscribe to changes in model.
        private void SubscribeToModel()
        {
            this.model.VoterDonePercChanged += (i => pbrVoters.Value = i);
            this.model.GroupCountChanged += (i => pbrGroups.Maximum = i);
            this.model.GroupDoneCountChanged += (i => pbrGroups.Value = i);
            this.model.CurrentGroupChanged += this.UpdateCurrentGroup;
            this.model.GenerationEnded += this.NormalMode;
        }

        // Update the current group label 
        // (requires an explicit refresh to avoid being overshadowed by ProgressBar updates).
        private void UpdateCurrentGroup(string groupName)
        {
            this.lblStatus.Text = groupName;
            this.Refresh();
        }

        // Open FolderBrowser upon 'Browse' button clicked.
        private void Browse(object sender, EventArgs e)
        {
            destinationFolderBrowser.ShowDialog();
            txbDestination.Text = destinationFolderBrowser.SelectedPath;
        }

        // Prepare for generation and call generate handler when done.
        private void SetUpGeneration(Action<String, int, int> handler)
        {
            // Retrieve grouping input, if checked by user.
            string destination = txbDestination.Text;
            int property = -1;
            int limit = -1;
            if (chbProperty.Checked) property = cbxProperty.SelectedIndex;
            if (chbLimit.Checked) limit = Convert.ToInt32(txbLimit.Text);
            
            // Go! (call generate handler)
            handler(destination, property, limit);
        }
    }
}
