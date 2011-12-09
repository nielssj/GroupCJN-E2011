// -----------------------------------------------------------------------
// <copyright file="PollingMain.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System.Diagnostics;
    using System.Windows.Forms;

    

    //using PtView = DigitalVoterList.PollingTable.PtView.PtView;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PollingMain
    {
        public PollingMain()
        {
            Model model = new Model();
            PtView view = new PtView(model);
            Controller controller = new Controller(model, view);

            // get the name of our process
            string proc = Process.GetCurrentProcess().ProcessName;

            // get the list of all processes by that name
            Process[] processes = Process.GetProcessesByName(proc);

            // if there is more than one process...

            if (processes.Length > 1)
            {
                MessageBox.Show("Application is already running");
                return;
            }
            else Application.Run(view.ScannerWindow);
        } 
    }
}
