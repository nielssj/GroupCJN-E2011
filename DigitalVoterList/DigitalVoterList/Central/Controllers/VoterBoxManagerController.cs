// -----------------------------------------------------------------------
// <copyright file="VoterBoxManagerController.cs" company="DVL">
// <author>Jan Meier</author>
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
            if (model.Filter != null)
            {
                view.UpdateProgressText("Selecting municipality: " + model.Filter.Municipality);
                view.UpdateProgressText("Selecting polling station: " + model.Filter.PollingStation);
                view.UpdateProgressText("Selecting voter: " + model.Filter.CPRNO);
            }
            else
            {
                view.UpdateProgressText("Please specify a filter in the previous window.");
            }

        }

        public void Validate()
        {
            try
            {
                view.UpdateProgressText(model.ValidateMunicipalities() ? "Municipalities successfully validated" : "Municipality validation un-sucessful. Please reconnect to the server and try to transfer again.");
                view.UpdateProgressText(model.ValidatePollingStations() ? "Polling stations successfully validated" : "Polling station validation un-sucessful. Please reconnect to the server and try to transfer again.");
                view.UpdateProgressText(model.ValidateVoters() ? "Voters successfully validated" : "Voter validation un-sucessful. Please reconnect to the server and try to transfer again.");
                view.UpdateProgress();
            }
            catch (Exception e)
            {
                view.UpdateProgressText("The system was not able to validate. The system said:");
                view.UpdateProgressText(e.Message);
                return;
            }
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