// -----------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;

    using DBComm.DBComm.DO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Controller
    {
        private Model model;
        private PtView view;

        public Controller(Model model, PtView view)
        {
            this.view = view;
            this.model = model;

            view.ScannerWindow.FindVoterButton.Click += this.ReactTofindVoterRequest;
            //view.RAC.RegisterBtn.Click += this.ReactToRegisterRequest;
            view.VoterShown += this.ReactToRegisterRequest;
            //view.Unlock += this.ReactToUnlockBtn;
            view.Unregister += this.ReactToUnregRequest;
        }

        private void ReactTofindVoterRequest(object sender, EventArgs e)
        {
            //Validate that CPRNR doesn't contain letters
            //int i = 

            //Validate length of CPRNR. 

            //validate if cprno is on the DB. If not show messagebox.


            //System.Windows.Forms.MessageBox.Show(view.ScannerWindow.CprnrTextBox.ToString());
            
            model.findVoter(Convert.ToInt32(view.ScannerWindow.CprnrTextBox.Text)); 
        }

        private void ReactToRegisterRequest()
        {
            //Console.WriteLine("Glen");
            System.Windows.Forms.MessageBox.Show("The votercard is now registered");
            //Update the model so that the voter is registered.
            
        }

        private void ReactToUnregRequest()
        {
            System.Windows.Forms.MessageBox.Show("Unregistered");
        }
    }
}

