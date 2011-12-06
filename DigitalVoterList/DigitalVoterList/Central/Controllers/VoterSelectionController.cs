// -----------------------------------------------------------------------
// <copyright file="VoterSelectionController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Controllers
{
    using System;
    using System.Windows.Forms;

    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VoterSelectionController
    {
        private VoterSelection mainModel;
        private VoterSelectionWindow view;

        /// <summary> Initializes a new instance of the <see cref="VoterSelectionController"/> class. </summary>
        /// <param name="mainModel"> The main model. </param>
        /// <param name="view"> A voter selection view. </param>
        public VoterSelectionController(VoterSelection mainModel, VoterSelectionWindow view)
        {
            this.mainModel = mainModel;
            this.view = view;

            view.AddPSSelectionChangedHandler(this.PSSelectionChanged);
            view.AddMSelectionChangedHandler(this.MSelectionChanged);
            view.addCPRTextChangedHandler(this.CPRTextChanged);

            Application.Run(view);
        }


        /// <summary>
        /// React to municipality filter selection.
        /// </summary>
        /// <param name="changedTo">The municipality that has been selected.</param>
        public void MSelectionChanged(string changedTo)
        {
            System.Windows.Forms.MessageBox.Show(view, "Municipality Selected: " + changedTo);
        }

        /// <summary> 
        /// React to polling station filter selection.
        /// </summary>
        /// <param name="changedTo">The polling station that has been selected.</param>
        public void PSSelectionChanged(string changedTo)
        {
            System.Windows.Forms.MessageBox.Show(view, "Polling Station Selected: " + changedTo);
        }

        /// <summary>
        /// React to CPR number search.
        /// </summary>
        /// <param name="changedTo">The CPR number that is being searched for.</param>
        public void CPRTextChanged(string changedTo)
        {
            if(changedTo.Length == 10)
                System.Windows.Forms.MessageBox.Show(view, "CPR Number selected: " + changedTo);
        }
    }
}
