// -----------------------------------------------------------------------
// <copyright file="PollingProgram.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList
{
    using System.Windows.Forms;

    using DigitalVoterList.PollingTable;
    using DigitalVoterList.PollingTable.View;

    using View = DigitalVoterList.PollingTable.View.View;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PollingProgram
    {
        public PollingProgram()
        {

            var model = new Model();
            var view = new View(model);
            var controller = new Controller(model, view);

            Application.Run(view.ScannerWindow);
        } 
    }
}
