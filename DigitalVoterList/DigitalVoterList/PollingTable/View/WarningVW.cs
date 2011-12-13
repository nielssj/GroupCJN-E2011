
// -----------------------------------------------------------------------
// <copyright file="Model.cs" company="">
// Author: Claes Martinsen.
// </copyright>
// -----------------------------------------------------------------------


using System.Windows.Forms;

namespace DigitalVoterList
{
    using DBComm.DBComm.DO;

    /// <summary>
    /// Shows a warning screen when the user has already been registered.
    /// </summary>
    public partial class WarningVW : Form
    {
        public WarningVW(VoterDO voter)
        {
            InitializeComponent();

            //this.currentVoter = voter;

            voterNameLabel.Text = voter.Name;
            voterAddressLabel.Text = voter.Address;
            voterCityLabel.Text = voter.City;
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        public void CloseDialog()
        {
            this.Close();
        }
    }
}
