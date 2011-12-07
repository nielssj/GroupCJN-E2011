// -----------------------------------------------------------------------
// <copyright file="VoterBoxManagerController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Controllers
{
    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    /// <summary>
    /// The Controller responsible for monitoring the VoterBoxManager (view)
    /// and propagating input in an appropiate fashion to the VoterBoxManager (model).
    /// </summary>
    public class VoterBoxManagerController
    {
        private VoterBoxManager model;
        private VoterBoxManagerWindow view;

        public VoterBoxManagerController(VoterBoxManager model, VoterBoxManagerWindow view)
        {
            this.model = model;
            this.view = view;

            view.Show();
        }
    }
}
