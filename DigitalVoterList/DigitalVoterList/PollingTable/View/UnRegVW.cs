
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
    /// Window that shows the voter and where the user can unregister the voter using the administrator password.
    /// </summary>
    public partial class UnRegVW : Form
    {

        public UnRegVW(VoterDO voter)
        {
            InitializeComponent();

            voterNameLabel.Text = voter.Name;
            voterAddressLabel.Text = voter.Address;
            voterCityLabel.Text = voter.City;

            //Window is not resizable
            var size = new System.Drawing.Size(377, 345);
            this.MinimumSize = size;
            this.MaximumSize = size;
        }
    }
}
