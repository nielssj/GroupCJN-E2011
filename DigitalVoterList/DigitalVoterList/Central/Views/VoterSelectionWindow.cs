using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DigitalVoterList.Central.Views
{
    using DBComm.DBComm.DO;

    using DigitalVoterList.Central.Models;

    public partial class VoterSelectionWindow : Form
    {
        private VoterSelection model;

        public VoterSelectionWindow(VoterSelection model)
        {
            InitializeComponent();

            this.model = model;

            // Get initial values (default selection = no filter)
            this.cbxMunicipalities.DataSource = model.Municipalities;
            this.cbxPollingStation.DataSource = model.PollingStations;
            this.setVoterCount(model.VoterCount);

            // Subscribe to updates in model
            model.PollingStationsChanged += this.UpdatePollingStations;
            model.VoterCountChanged += this.UpdateVoterCount;
            model.SelectedMunicipalityChanged += this.UpdateSelectedMunicipality;
            model.SelectedPollingStationChanged += this.UpdateSelectedPollingStation;

            // Setup text box
            this.txbCPRNO.KeyPress += this.TextBoxOnlyAllowDigits;
        }

        public void UpdatePollingStations(IEnumerable<PollingStationDO> pollingStations)
        {
            this.cbxPollingStation.DataSource = pollingStations;
        }

        public void UpdateVoterCount(int voterCount)
        {
            this.setVoterCount(voterCount);
        }

        public void UpdateSelectedMunicipality(MunicipalityDO municipality)
        {
            this.cbxMunicipalities.SelectedIndex = this.cbxMunicipalities.Items.IndexOf(municipality);
        }

        public void UpdateSelectedPollingStation(PollingStationDO pollingStation)
        {
            this.cbxPollingStation.SelectedIndex = this.cbxPollingStation.Items.IndexOf(pollingStation);
        }

        public delegate void CBInputChangedHandler(IDataObject changedTo);

        public delegate void TextInputChangedHandler(string changedTo);

        /// <summary> Notify me when the polling station selection changes. </summary>
        public void AddPSSelectionChangedHandler(CBInputChangedHandler handler)
        {
            ComboBox cps = cbxPollingStation;
            cps.SelectedIndexChanged += (o, eA) => handler(cps.SelectedItem as IDataObject);
        }

        /// <summary> Notify me when the municipality selection changes. </summary>
        public void AddMSelectionChangedHandler(CBInputChangedHandler handler)
        {
            ComboBox cmp = cbxMunicipalities;
            cmp.SelectedIndexChanged += (o, eA) => handler((IDataObject)cmp.SelectedItem);
        }

        /// <summary> Notify me when the CPR number text changes.</summary>
        public void addCPRTextChangedHandler(TextInputChangedHandler handler)
        {
            TextBox tbc = txbCPRNO;
            tbc.TextChanged += (o, eA) => handler(tbc.Text);
        }

        /// <summary> Notify me when the 'Voter Card Generator' button is clicked. </summary>
        public void AddVCGClickedHandler(Action<VoterFilter> handler)
        {
            tsbVCG.Click += (o, eA) => handler(model.CurrentFilter);
            tsmVCG.Click += (o, eA) => handler(model.CurrentFilter);
        }

        /// <summary> Notify me when the 'Voter Box Manager' button is clicked. </summary>
        public void AddVBMClickedHandler(EventHandler handler)
        {
            tsbVBM.Click += handler;
            tsmVBM.Click += handler;
        }

        private void setVoterCount(int count)
        {
            lblVoterCount.Text = count + " voters selected.";
        }

        private void TextBoxOnlyAllowDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lblVoterCount_Click(object sender, EventArgs e)
        {

        }
    }
}
