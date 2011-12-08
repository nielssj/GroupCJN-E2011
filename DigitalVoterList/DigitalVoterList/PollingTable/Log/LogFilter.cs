// -----------------------------------------------------------------------
// <copyright file="LogFilter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable.Log
{
    using System;

    using DBComm.DBComm.DO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public struct LogFilter
    {
        public uint? Id { get; set; }

        public uint? Table { get; set; }

        public uint? Cpr { get; set; }

        public ActivityEnum? Activity { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}
