// -----------------------------------------------------------------------
// <copyright file="VoterBoxManagerController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Controllers
{
    using System;
    using DBComm.DBComm;
    using DBComm.DBComm.DataGeneration;
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

            view.AddConnectHandler(this.Connect);
            view.AddUploadHandler(this.Upload);
            view.AddValidateHandler(this.Validate);

            view.Show();

            view.UpdateProgressText("Selecting municipality: " + model.Filter.Municipality);
            view.UpdateProgressText("Selecting polling station: " + model.Filter.PollingStation);
            view.UpdateProgressText("Selecting voter: " + model.Filter.CPRNO);
        }

        public void Validate()
        {
            view.UpdateProgressText(model.ValidateMunicipalities() ? "Municipalities successfully validated" : "Something went wrong trying to validate municipalities");
            view.UpdateProgressText(model.ValidatePollingStations() ? "Polling stations successfully validated" : "Something went wrong trying to validate polling stations");
            view.UpdateProgressText(model.ValidateVoters() ? "Voters successfully validated" : "Something went wrong trying to validate voters");
            view.UpdateProgress();
        }

        public void Connect()
        {
            view.UpdateProgressText("Making connection to remote server and creating DB.");
            try
            {
                DBCreator creator = new DBCreator(view.Address, view.Port, view.User, view.Password);
            }
            catch (Exception e)
            {
                view.UpdateProgressText("The system was not able to connect to the remote server. The system said:");
                view.UpdateProgressText(e.Message);
                return;
            }

            view.UpdateProgressText("Connection established and DB created.");
            view.UpdateProgress();
        }

        public void Upload()
        {
            if (model.Filter != null)
            {
                view.UpdateProgressText("Fetching data from local server.");

                try
                {
                    model.FetchData();
                }
                catch (Exception e)
                {
                    view.UpdateProgressText("The system was not able to connect to the local server. The system said:");
                    view.UpdateProgressText(e.Message);
                    return;
                }

                view.UpdateProgress();
                view.UpdateProgressText("Data fetched.");
                view.UpdateProgressText("Inserting data on remote server.");

                try
                {
                    model.InsertData(view.Address, view.Port, view.User, view.Password);
                }
                catch (Exception e)
                {
                    view.UpdateProgressText("The system was not able to connect to the remote server. The system said:");
                    view.UpdateProgressText(e.Message);
                    return;
                }

                view.UpdateProgressText("Data inserted.");
                view.UpdateProgress();
            }
        }
    }
}