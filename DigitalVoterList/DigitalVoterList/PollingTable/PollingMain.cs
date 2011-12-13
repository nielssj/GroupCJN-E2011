// -----------------------------------------------------------------------
// <copyright file="PollingMain.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    

    //using PtView = DigitalVoterList.PollingTable.PtView.PtView;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PollingMain
    {
        //Determindes if it is alowed to have multible instances of polling table open.
        private const bool SingleInstance = true;

        public PollingMain()
        {

            Model model = new Model();
            PtView view = new PtView(model);
            Controller controller = new Controller(model, view);

        //    this.SetupDVL();

            if (SingleInstance)
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
                
                view.SetupWindow.ShowDialog();
                view.ScannerWindow.TableNumber.Text = model.SetupInfo.TableNo.ToString();
                Application.Run(view.ScannerWindow);
            }
            else
//Only used when allowing more than one instance of the polling table.
#pragma warning disable 162
            {
                view.SetupWindow.ShowDialog();
                view.ScannerWindow.TableNumber.Text = model.SetupInfo.TableNo.ToString();
                Application.Run(view.ScannerWindow);
            }
#pragma warning restore 162
        } 
    }
}
