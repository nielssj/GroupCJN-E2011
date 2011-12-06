// -----------------------------------------------------------------------
// <copyright file="VoterCardController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Controllers
{
    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VoterCardGeneratorController
    {
        private VoterCardGenerator model;
        private VoterCardGeneratorWindow view;

        public VoterCardGeneratorController(VoterCardGenerator model, VoterCardGeneratorWindow view)
        {
            this.model = model;
            this.view = view;

            view.Show();
        }
    }
}
