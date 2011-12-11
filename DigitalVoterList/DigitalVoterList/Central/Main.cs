// -----------------------------------------------------------------------
// <copyright file="Main.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central
{
    using System.Windows.Forms;

    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Controllers;

    using View = DigitalVoterList.Central.Views.View;

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

            Application.Run();
        }
    }
}
