using System.Windows.Forms;

namespace DigitalVoterList
{
    using DBComm.DBComm.DO;

    public partial class VoterWindow : Form
    {

        private VoterDO currentVoter;

        public VoterWindow(VoterDO voter)
        {
            InitializeComponent();

            this.currentVoter = voter;

            voterNameLabel.Text = voter.Name;
            voterAddressLabel.Text = voter.Address;
            voterCityLabel.Text = voter.City;
        }

        //public VoterWindow(string name, string address, string city)
        //{
        //    voterNameLabel.Text = name;
        //    voterAddressLabel.Text = address;
        //    voterCityLabel.Text = city;
        //}
    }
}
