﻿// -----------------------------------------------------------------------
// <copyright file="LogController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable.Log
{
    using System;
    using System.Windows.Forms;

    using Timer = System.Threading.Timer;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LogController
    {
        private LogWindow view;
        private LogModel model;

        public LogController(LogWindow view, LogModel model)
        {
            this.view = view;
            this.model = model;

            this.view.AddRefreshButtonClicked(this.RefreshClicked);
            this.view.AddResetButtonClicked(this.RefreshClicked);

            Timer t = new Timer(Update, null, 100, 60000);

            Application.Run(view);
        }

        public void Update(object o)
        {
            model.Update();
            view.RefreshGrid(model.Logs);
        }

        public void RefreshClicked()
        {
            uint cprInt;
            uint.TryParse(view.Cpr, out cprInt);

            uint idInt;
            uint.TryParse(view.Id, out idInt);

            uint tableInt;
            uint.TryParse(view.Table, out tableInt);

            LogFilter l = new LogFilter()
                {
                    Activity = view.Activity,
                    Cpr = cprInt != 0 ? cprInt : (uint?)null,
                    From = view.From != view.To ? view.From : (DateTime?)null,
                    Id = idInt != 0 ? idInt : (uint?)null,
                    Table = tableInt != 0 ? tableInt : (uint?)null,
                    To = view.To != view.From ? view.To : (DateTime?)null
                };

            this.model.UpdateFilter(l);
        }
    }
}