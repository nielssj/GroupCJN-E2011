// -----------------------------------------------------------------------
// <copyright file="PtView.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;

    using DigitalVoterList.DBComm.DO;
    using DigitalVoterList.PollingTable.View.Root_elements;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PtView
    {
        private Model model;

        private ScannerWindow scannerWindow;

        public delegate void VoterShownHandler();
        public delegate void UnlockHandler();
        public delegate void UnregisterHandler();
        
        public event VoterShownHandler VoterShown;
        public event UnlockHandler Unlock;
        public event UnlockHandler Unregister;

        public PtView(Model model)
        {
            this.model = model;
            scannerWindow = new ScannerWindow();
            
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
                nvw.Show();
            }

            //Open a voter window with warning message indicating that the voter has alredy voted.
            if (voter.Voted == true)
            {
                WarningVW wvw = new WarningVW(voter);
                wvw.UnlockButton.Click += (o, eA) => this.Unlock();
                wvw.Show();
            }
        }

        /// <summary>
        /// When the user presses the lock 
        /// </summary>
        public void OpenUnregWindow()
        {
            UnRegVW uvw = new UnRegVW();
            uvw.UnregisterButton.Click += (o, eA) => this.Unregister();
            uvw.Show();
        }

        public ScannerWindow ScannerWindow { get { return scannerWindow; } }        
    }
}
