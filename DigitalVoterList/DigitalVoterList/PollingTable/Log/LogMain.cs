// -----------------------------------------------------------------------
// <copyright file="LogMain.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable.Log
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LogMain
    {
        public LogMain()
        {
            var view = new LogWindow();
            var model = new LogModel();

            new LogController(view, model);
        }
    }
}
