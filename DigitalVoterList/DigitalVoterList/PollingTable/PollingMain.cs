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
        //Determindes if it is alowed to have multible instances of polling table open.
        private readonly bool singleInstance = false; 

        public PollingMain()
        {
            Model model = new Model();
            PtView view = new PtView(model);
            Controller controller = new Controller(model, view);

            if (singleInstance)
            {
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
                else 
                Application.Run(view.ScannerWindow);
            }
            Application.Run(view.ScannerWindow);
        } 
    }
}
