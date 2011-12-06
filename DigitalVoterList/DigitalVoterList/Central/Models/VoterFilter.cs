namespace DigitalVoterList.Central.Models
{
    /// <summary>
    /// An immutable filter describing a subset of voters.
    /// </summary>
    public class VoterFilter
    {
        /// <summary> Initializes a new instance of the <see cref="VoterFilter"/> class. </summary>
        /// <param name="municipality"> The selected municipality (null means not selected).</param>
        /// <param name="pollingStation"> The Selected polling station (null means not selected). </param>
        /// <param name="cprno"> The selected CPR number (0 means not selected). </param>
        public VoterFilter(string municipality = null, string pollingStation = null, int cprno = 0)
        {
            this.Municipality = municipality;
            this.PollingStation = pollingStation;
            this.CPRNO = cprno;
        }

        /// <summary> What is the selected municipality? </summary>
        public string Municipality { get; private set; }

        /// <summary> What is the selected polling station? </summary>
        public string PollingStation { get; private set; }

        /// <summary> What is the selected cprnr? </summary>
        public int CPRNO { get; private set; }
    }
}