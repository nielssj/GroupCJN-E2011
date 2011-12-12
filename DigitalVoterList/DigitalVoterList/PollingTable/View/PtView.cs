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

        private UnRegVW unregWindow;

        public delegate void VoterShownHandler();
        public delegate void UnlockHandler();
        public delegate void UnregisterHandler(string admpass);
        
        public event VoterShownHandler VoterShown;
        public event UnlockHandler Unlock;
        public event UnregisterHandler Unregister;


        public PtView(Model model)
        {
            this.model = model;
            scannerWindow = new ScannerWindow();
            
            setupWindow = new SetupWindow(); 

            scannerWindow.LockBtn.Click += (o, eA) => this.OpenLogWindow();
            
            model.CurrentVoterChanged += this.ShowSpecificVoter;
            model.SetupInfoChanged += this.UpdateSetupWindow;

            this.Unlock += this.OpenUnregWindow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voter"></param>
        public void ShowSpecificVoter(VoterDO voter)
        {
            //If the voter is null it doesn't exists in the 
            if(voter == null)
            {
                return;
            }

            //Open an ordinary voter window if the voter has not voted yet.
            if (voter.Voted == false)
            {
                NormVW nvw = new NormVW(voter);
                nvw.RegButton.Click += (o, eA) => this.VoterShown();
                nvw.RegButton.Click += (o, eA) => nvw.Close();
                nvw.ShowDialog();
            }

            //Open a voter window with warning message indicating that the voter has alredy voted.
            if (voter.Voted == true)
            {
                WarningVW wvw = new WarningVW(voter);
                wvw.UnlockButton.Click += (o, eA) => this.Unlock();
                wvw.UnlockButton.Click += (o, eA) => wvw.Close();
                wvw.ShowDialog();
            }
        }

        /// <summary>
        /// When the user presses the lock 
        /// </summary>
        public void OpenUnregWindow()
        {
            this.unregWindow = new UnRegVW(model.currentVoter);
            this.unregWindow.UnregisterButton.Click += (o, eA) => this.Unregister(this.unregWindow.AdmPass.Text);
            //unregWindow.UnregisterButton.Click += (o, eA) => unregWindow.Close();
            this.unregWindow.ShowDialog();
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

        

        //TODO PAssword msg box. -> after show clear the password box. 

        private void UpdateSetupWindow(SetupInfo setupInfo)
        {
            this.SetupWindow.TableBox = setupInfo.TableNo.ToString();
            this.SetupWindow.IpTextBox = setupInfo.Ip;
        }

        public ScannerWindow ScannerWindow { get { return scannerWindow; } }
        public SetupWindow SetupWindow { get { return setupWindow; } }

        public UnRegVW UnregWindow
        {
            get
            {
                return this.unregWindow;
            }
        }
    }
}
