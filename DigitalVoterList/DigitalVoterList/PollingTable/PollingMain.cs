// -----------------------------------------------------------------------
// <copyright file="PollingMain.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System.Windows.Forms;

    

    //using PtView = DigitalVoterList.PollingTable.PtView.PtView;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PollingMain
    {
        public PollingMain()
        {

            var model = new Model();
            PtView view = new PtView(model);
            var controller = new Controller(model, view);

            Application.Run(view.ScannerWindow);
        } 
    }
}
