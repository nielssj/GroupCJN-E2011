// -----------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable.View
{
    using System;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Controller
    {
        private Model model;
        private View view;

        public Controller(Model model, View view)
        {
            this.view = view;
            this.model = model;

            view.ScannerWindow.FindVoterButton.Click += this.reactTofindVoterRequest;
        }

        private void reactTofindVoterRequest(object sender, EventArgs e)
        {
            //Validate that CPRNR doesn't contain letters
            //int i = 

            //Validate length of CPRNR. 


            //System.Windows.Forms.MessageBox.Show(view.ScannerWindow.CprnrTextBox.ToString());
            
            model.findVoter(Convert.ToInt32(view.ScannerWindow.CprnrTextBox.Text));
            
        }
    }
}

