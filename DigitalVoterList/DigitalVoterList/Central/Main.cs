// -----------------------------------------------------------------------
// <copyright file="Main.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central
{
    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;
    using DigitalVoterList.Central.Controllers;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Main
    {

        public Main()
        {
            var model = new Model();
            var view = new View(model);
            var controller = new Controller(model, view);
        

            /*var model = new VoterSelection();
            var view = new VoterSelectionWindow(model);
            var controller = new VoterSelectionController(model, view);

            Application.Run(view);*/
        }
    }
}
