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

    public partial class VoterSelectionWindow : Form
    {
        public VoterSelectionWindow(VoterSelection model)
        {
            InitializeComponent();

            // Get initial values (default selection = no filter)
            this.cbxMunicipalities.DataSource = model.Municipalities;
            this.cbxPollingStation.DataSource = model.PollingStations;
            this.setVoterCount(model.VoterCount);
            

            // Subscribe to updates in model
            model.PollingStationsChanged += this.UpdatePollingStations;
            model.VoterCountChanged += this.UpdateVoterCount;
        }

        public void UpdatePollingStations(List<String> pollingStations)
        {
            // .. Change the view (update combobox content)
        }

        public void UpdateVoterCount(int voterCount)
        {
            // .. Change the view (update 
        }

        public delegate void InputChangedHandler(String changedTo);
        
        /// <summary> Notify me when the polling station selection changes. </summary>
        public void AddPSSelectionChangedHandler(InputChangedHandler handler)
        {
            ComboBox cps = cbxPollingStation;
            cps.SelectedIndexChanged += (o, eA) => handler(cps.SelectedItem.ToString());
        }

        /// <summary> Notify me when the municipality selection changes. </summary>
        public void AddMSelectionChangedHandler(InputChangedHandler handler)
        {
            ComboBox cmp = cbxMunicipalities;
            cmp.SelectedIndexChanged += (o, eA) => handler(cmp.SelectedItem.ToString());
        }

        /// <summary> Notify me when the CPR number text changes.</summary>
        public void addCPRTextChangedHandler(InputChangedHandler handler)
        {
            TextBox tbc = txbCPRNO;
            tbc.TextChanged += (o, eA) => handler(tbc.Text.ToString());
        }

        /// <summary> Notify me when the 'Voter Card Generator' button is clicked. </summary>
        public void AddVCGClickedHandler(EventHandler handler)
        {
            tsbVCG.Click += handler;
            tsmVCG.Click += handler;
        }

        /// <summary> Notify me when the 'Voter Box Manager' button is clicked. </summary>
        public void AddFBMClickedHandler(EventHandler handler)
        {
            tsbVBM.Click += handler;
            tsmVBM.Click += handler;
        }

        private void setVoterCount(int count)
        {
            lblVoterCount.Text = count + " voters selected.";
        }
    }
}
