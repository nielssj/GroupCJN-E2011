using System.Windows.Forms;

namespace DigitalVoterList
{
    using DBComm.DBComm.DO;

    public partial class NormVW : Form
    {

        private VoterDO currentVoter;

        public NormVW(VoterDO voter)
        {
            InitializeComponent();

            this.currentVoter = voter;

            voterNameLabel.Text = voter.Name;
            voterAddressLabel.Text = voter.Address;
            voterCityLabel.Text = voter.City;
        }
    }
}
