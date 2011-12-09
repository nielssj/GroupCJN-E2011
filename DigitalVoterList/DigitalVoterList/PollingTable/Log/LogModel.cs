// -----------------------------------------------------------------------
// <copyright file="LogModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable.Log
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using DBComm.DBComm.DAO;
    using DBComm.DBComm.DO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LogModel
    {
        private BindingList<LogDO> logs;
        private LogDAO lDAO;

        private IEnumerable<VoterDO> voters;
        private VoterDAO vDAO;

        private LogFilter filter;

        private int totalVoters;
        private int votedVoters;

        public BindingList<LogDO> Logs
        {
            get
            {
                return this.logs;
            }
        }

        public int TotalVoters
        {
            get
            {
                return totalVoters;
            }
        }

        public int VotedVoters
        {
            get
            {
                return votedVoters;
            }
        }

        public LogModel()
        {
            this.logs = new BindingList<LogDO>();
            this.lDAO = new LogDAO();

            this.vDAO = new VoterDAO();

            this.Update();

            this.filter = new LogFilter();
        }

        public void UpdateFilter(LogFilter f)
        {
            this.filter = f;
            this.logs.Clear();
            this.Update();
        }

        public void Update()
        {
            var result = this.lDAO.Read(l =>
                (this.filter.Activity != null ? l.Activity == this.filter.Activity : true) &&
                (this.filter.Cpr != null ? l.Cpr == this.filter.Cpr : true) &&
                (this.filter.From != null ? l.Time >= this.filter.From : true) &&
                (this.filter.To != null ? l.Time <= this.filter.To : true) &&
                (this.filter.Table != null ? l.Table == this.filter.Table : true));

            foreach (var logDO in result)
            {
                if (!logs.Contains(logDO)) logs.Add(logDO);
            }

            voters = vDAO.Read(v => true).ToList();

            totalVoters = voters.Count();

            votedVoters = voters.Count(v => v.Voted == true);
        }
    }
}