﻿
// -----------------------------------------------------------------------
// <copyright file="Model.cs" company="">
// Author: Claes Martinsen.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Forms;

namespace DigitalVoterList
{
    using DBComm.DBComm.DO;

    public partial class NormVW : Form
    {
        /// <summary>
        /// Window where the user can register the voter and where the voter's information is shown
        /// </summary>
        /// <param name="voter">The voter to be shown.</param>
        public NormVW(VoterDO voter)
        {
            InitializeComponent();

            voterNameLabel.Text = voter.Name;
            voterAddressLabel.Text = voter.Address;
            voterCityLabel.Text = voter.City;
        }
    }
}
