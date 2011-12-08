// -----------------------------------------------------------------------
// <copyright file="VoterBoxManager.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Models
{
    using System.Collections.Generic;

    using DBComm.DBComm.DO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VoterBoxManager : ISubModel
    {
        public IEnumerable<VoterDO> Voters { get; set; }
        public IEnumerable<MunicipalityDO> Municipalities { get; set; }
        public IEnumerable<PollingStationDO> PollingStations { get; set; }
        public VoterFilter Filter { get; private set; }
        
        public VoterBoxManager(VoterFilter filter)
        {
            this.Filter = filter;
        }

    }
}
