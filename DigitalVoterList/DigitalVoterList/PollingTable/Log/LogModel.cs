// -----------------------------------------------------------------------
// <copyright file="LogModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable.Log
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using DBComm.DBComm.DAO;
    using DBComm.DBComm.DO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LogModel
    {
        private BindingList<LogDO> logs;
        private LogDAO lDAO;

        private List<VoterDO> voters;
        private VoterDAO vDAO;

        private DateTime lastUpdate;

        private LogFilter filter;

        public BindingList<LogDO> Logs
        {
            get
            {
                return this.logs;
            }
        }

        public LogModel()
        {
            this.logs = new BindingList<LogDO>();
            this.lDAO = new LogDAO();

            this.lastUpdate = DateTime.MinValue;

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
            var result = this.lDAO.Read(l => (this.filter.Activity != null ? l.Activity == this.filter.Activity : true) &&
                (this.filter.Cpr != null ? l.Cpr == this.filter.Cpr : true) &&
                (this.filter.From != null ? l.Time >= this.filter.From : true) &&
                (this.filter.To != null ? l.Time <= this.filter.To : true) &&
                (this.filter.Id != null ? l.PrimaryKey == this.filter.Id : true) &&
                (this.filter.Table != null ? l.Table == this.filter.Table : true));

            foreach (var logDO in result)
            {
                if (!logs.Contains(logDO)) logs.Add(logDO);
            }

            this.lastUpdate = DateTime.Now;


        }
    }
}
