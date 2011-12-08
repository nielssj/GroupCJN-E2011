// -----------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;
    using System.Windows.Forms;

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
            

            //Validate length of CPRNR. 
            int i = view.ScannerWindow.CprnrTextBox.Text.Length;
            if ( i > 10 || i < 10)
            {
                MessageBox.Show("Length of cprno is not valid");
                view.ScannerWindow.CprnrTextBox.Text = ""; 
                return;
            }
            //validate if cprno is on the DB. If not show messagebox.
            //Should be done in the model...

            //System.Windows.Forms.MessageBox.Show(view.ScannerWindow.CprnrTextBox.ToString());
            
            model.FindVoter(Convert.ToUInt32(view.ScannerWindow.CprnrTextBox.Text)); 
        }

        private void ReactToRegisterRequest()
        {
            //Console.WriteLine("Glen");
            System.Windows.Forms.MessageBox.Show("The voter card is registered");
            //Update the model so that the voter is registered.
            model.RegisterCurrentVoter();
            
        }

        private void ReactToUnregRequest()
        {
            System.Windows.Forms.MessageBox.Show("The voter card is Unregistered");
            model.unregisterCurrentVoter();
        }
    }
}

