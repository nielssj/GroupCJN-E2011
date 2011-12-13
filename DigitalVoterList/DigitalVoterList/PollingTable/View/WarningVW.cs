using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalVoterList
{
    using DBComm.DBComm.DO;

    public partial class WarningVW : Form
    {
        private VoterDO currentVoter;

        public WarningVW(VoterDO voter)
        {
            InitializeComponent();

            this.currentVoter = voter;

            voterNameLabel.Text = voter.Name;
            voterAddressLabel.Text = voter.Address;
            voterCityLabel.Text = voter.City;
        }

        public void CloseDialog()
        {
            this.Close();
        }
    }
}
