// -----------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;

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
            view.VoterShown += this.ReactToRegisterRequest;
            view.Unregister += this.ReactToUnregRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReactTofindVoterRequest(object sender, EventArgs e)
        {
            string cpr = view.ScannerWindow.CprnrTxtBox.Text;
            
            //Validate length of CPRNR. 
            if(!Model.CprLengtVal(cpr)) { view.ShowMessageBox("Length of cprno is not valid."); return; }

            //Validate that CPRNR doesn't contain letters
            if (!Model.CprLetterVal(cpr)) { view.ShowMessageBox("Cprno must only contain numbers."); return; }
            
            // try to fetch the voter from the voter box. If no voter found write an error msg.
            //try
            //{ model.FindVoter(Convert.ToUInt32(view.ScannerWindow.CprnrTxtBox.Text)); }
            //catch (Exception) 
            //{ view.ShowMessageBox("Voter not registered at polling station."); }
            view.ScannerWindow.resetCprTxt(); // resets the cpr field in the scanner window
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReactToRegisterRequest()
        {
            view.ShowMessageBox("The voter card is registered");
            //Update the model so that the voter is registered.
            model.RegisterCurrentVoter();
            view.ScannerWindow.resetCprTxt(); // resets the cpr field in the scanner window
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReactToUnregRequest()
        {
            view.ShowMessageBox("The voter card is Unregistered");
            //Update the model so that the voter is unregistered.
            model.UnregisterCurrentVoter();
            view.ScannerWindow.resetCprTxt(); // resets the cpr field in the scanner window
        }
    }
}

