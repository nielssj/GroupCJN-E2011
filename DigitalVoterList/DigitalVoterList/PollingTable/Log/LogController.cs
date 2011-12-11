// -----------------------------------------------------------------------
// <copyright file="LogController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable.Log
{
    using System;

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

            this.view.ResetFields();

            view.Show();

            view.SetDataSource(model.Logs);
        }

        public void Update(object o)
        {
            model.Update();
            view.VotersText = model.VotedVoters + " out of " + model.TotalVoters + " have voted thus far";
        }

        public void RefreshClicked()
        {
            uint cprInt;
            uint.TryParse(view.Cpr, out cprInt);

            uint tableInt;
            uint.TryParse(view.Table, out tableInt);

            LogFilter l = new LogFilter()
                {
                    Activity = view.Activity,
                    Cpr = cprInt != 0 ? cprInt : (uint?)null,
                    From = view.From != view.To ? view.From : (DateTime?)null,
                    Table = tableInt != 0 ? tableInt : (uint?)null,
                    To = view.To != view.From ? view.To : (DateTime?)null
                };

            this.model.UpdateFilter(l);
        }
    }
}