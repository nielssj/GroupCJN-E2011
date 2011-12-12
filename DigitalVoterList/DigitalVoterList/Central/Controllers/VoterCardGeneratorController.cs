// -----------------------------------------------------------------------
// <copyright file="VoterCardController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Controllers
{
    using System.IO;
    using System.Windows.Forms;

    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    /// <summary>
    /// The Controller responsible for monitoring the VoterCardGeneartorWindow (view)
    /// and propagating input in an appropiate fashion to the VoterCardGenerator (model).
    /// </summary>
    public class VoterCardGeneratorController
    {
        private VoterCardGenerator model;
        private VoterCardGeneratorWindow view;

        public VoterCardGeneratorController(VoterCardGenerator model, VoterCardGeneratorWindow view)
        {
            this.model = model;
            this.view = view;

            // Subscribe to View
            view.AddGenerateHandler(this.GenerateHandler);
            view.AddAbortHandler(model.Abort);

            // Show View
            view.Show();
        }

        public void GenerateHandler(string destination, int property, int limit)
        {
            // Selection validation.
            int old = model.ValidateSelection();
            DialogResult result = DialogResult.None;
            if (old > 0) result = MessageBox.Show("The selection contains " + old + " voters who already had their voter cards generated previously, do you wish to continue?", "Cards already generated", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // Destination validation.
            result = DialogResult.None;
            if (!model.ValidateDestination(destination)) result = MessageBox.Show("The specified folder does not exist and will be created, do you wish to continue?", "Unknown folder", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK) Directory.CreateDirectory(destination);
            else if (result == DialogResult.Cancel) return;

            view.GenerateMode("Initializing..");
            model.Generate(destination, property, limit);
        }
    }
}
