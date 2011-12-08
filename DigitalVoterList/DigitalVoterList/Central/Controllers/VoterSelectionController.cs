// -----------------------------------------------------------------------
// <copyright file="VoterSelectionController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Controllers
{
    using System;
    using System.Windows.Forms;

    using DBComm.DBComm.DO;

    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VoterSelectionController
    {
        private VoterSelection mainModel;
        private VoterSelectionWindow view;

        private bool _updating = false;

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
        public void MSelectionChanged(object changedTo)
        {
            if (!_updating)
            {
                _updating = true;

                MunicipalityDO m = changedTo as MunicipalityDO;
                VoterFilter filter = new VoterFilter(m);

                mainModel.ReplaceFilter(filter);

                System.Windows.Forms.MessageBox.Show(view, "Municipality Selected: " + changedTo);
            }
            _updating = false;
        }

        /// <summary> 
        /// React to polling station filter selection.
        /// </summary>
        /// <param name="changedTo">The polling station that has been selected.</param>
        public void PSSelectionChanged(object changedTo)
        {
            if (!_updating)
            {
                _updating = true;

                PollingStationDO p = changedTo as PollingStationDO;
                VoterFilter filter = new VoterFilter(p.Municipality, p);

                Console.WriteLine(p.Municipality);

                mainModel.ReplaceFilter(filter);

                System.Windows.Forms.MessageBox.Show(view, "Polling Station Selected: " + changedTo);
            }
            _updating = false;
        }

        /// <summary>
        /// React to CPR number search.
        /// </summary>
        /// <param name="changedTo">The CPR number that is being searched for.</param>
        public void CPRTextChanged(string changedTo)
        {
            if (!_updating)
            {
                _updating = true;

                string cprString = changedTo;

                if (cprString.Length == 10)
                {
                    long cpr = long.Parse(cprString); // It is possible for the use to type in 9999999999, which would not fit an int.
                    if (cpr >= 101000001 && cpr <= 3112999999) mainModel.ReplaceFilter(new VoterFilter(null, null, (int)cpr));
                }
            }
            _updating = false;
        }
    }
}
