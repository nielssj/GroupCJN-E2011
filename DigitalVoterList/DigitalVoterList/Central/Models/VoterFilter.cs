namespace DigitalVoterList.Central.Models
{
    using System.Diagnostics.Contracts;

    using DBComm.DBComm.DO;

    /// <summary>
    /// An immutable filter describing a subset of voters.
    /// </summary>
    public class VoterFilter
    {
        /// <summary> Initializes a new instance of the <see cref="VoterFilter"/> class. </summary>
        /// <param name="municipality"> The selected municipality (null means not selected).</param>
        /// <param name="pollingStation"> The Selected polling station (null means not selected). </param>
        /// <param name="cprno"> The selected CPR number (0 means not selected). </param>
        public VoterFilter(MunicipalityDO municipality = null, PollingStationDO pollingStation = null, int cprno = 0)
        {
            this.Municipality = municipality;
            this.PollingStation = pollingStation;
            this.CPRNO = cprno;
        }

        /// <summary> What is the selected municipality? </summary>
        public MunicipalityDO Municipality { get; private set; }

        /// <summary> What is the selected polling station? </summary>
        public PollingStationDO PollingStation { get; private set; }

        /// <summary> What is the selected cprnr? </summary>
        public int CPRNO { get; private set; }

        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(Municipality != null || PollingStation != null || CPRNO != 0);
        }
    }
}