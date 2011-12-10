// -----------------------------------------------------------------------
// <copyright file="PtView.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;

    using DBComm.DBComm.DO;

    using DigitalVoterList.PollingTable.Log;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PtView
    {
        private Model model;
        private ScannerWindow scannerWindow;
        private SetupWindow setupWindow;

        public delegate void VoterShownHandler();
        public delegate void UnlockHandler();
        public delegate void UnregisterHandler(string admpass);
        //public delegate void LogHandler();
        public delegate void SetupHandler(SetupInfo si);
        
        public event VoterShownHandler VoterShown;
        public event UnlockHandler Unlock;
        public event UnregisterHandler Unregister;
        //public event LogHandler ShowLog;


        public PtView(Model model)
        {
            this.model = model;
            scannerWindow = new ScannerWindow();
            //Initialize the setup window with
            setupWindow = new SetupWindow(); 

            scannerWindow.LockBtn.Click += (o, eA) => this.OpenLogWindow();
            
            model.CurrentVoterChanged += this.ShowSpecificVoter;
            this.Unlock += this.OpenUnregWindow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voter"></param>
        public void ShowSpecificVoter(VoterDO voter)
        {
            //Open an ordinary voter window if the voter has not voted yet.
            if (voter.Voted == false)
            {
                NormVW nvw = new NormVW(voter);
                nvw.RegButton.Click += (o, eA) => this.VoterShown();
                nvw.RegButton.Click += (o, eA) => nvw.Close();
                nvw.Show();
            }

            //Open a voter window with warning message indicating that the voter has alredy voted.
            if (voter.Voted == true)
            {
                WarningVW wvw = new WarningVW(voter);
                wvw.UnlockButton.Click += (o, eA) => this.Unlock();
                wvw.UnlockButton.Click += (o, eA) => wvw.Close();
                wvw.Show();
            }
        }

        /// <summary>
        /// When the user presses the lock 
        /// </summary>
        public void OpenUnregWindow()
        {
            UnRegVW uvw = new UnRegVW(model.currentVoter);
            uvw.UnregisterButton.Click += (o, eA) => this.Unregister(uvw.AdmPass);
            uvw.UnregisterButton.Click += (o, eA) => uvw.Close();
            uvw.Show();
        }

        public void OpenLogWindow()
        {
            LogWindow lw = new LogWindow();
            LogModel lm = new LogModel();
            LogController lc = new LogController(lw, lm);
        }

        public void ShowMessageBox(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg);
        }



        public ScannerWindow ScannerWindow { get { return scannerWindow; } }
        public SetupWindow SetupWindow { get { return setupWindow; } }
    }
}
