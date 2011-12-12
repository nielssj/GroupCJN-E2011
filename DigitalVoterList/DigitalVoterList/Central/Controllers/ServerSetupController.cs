﻿// -----------------------------------------------------------------------
// <copyright file="ServerSetupController.cs" company="DVL">
// <author>Jan Meier</author>
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Controllers
{
    using System;

    using DBComm.DBComm;

    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    using MySql.Data.MySqlClient;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ServerSetupController
    {
        private ServerSetupWindow view;
        private ServerSetup model;

        public delegate void ConnectedEvent();

        public event ConnectedEvent Connected;

        public void OnConnected()
        {
            Connected();
        }

        public ServerSetupController(ServerSetupWindow view, ServerSetup model)
        {
            this.view = view;
            this.model = model;

            this.view.Closed += (o, eA) => Environment.Exit(-1);

            this.view.ConnectBtn.Click += (o, eA) => this.ConnectClicked();
        }

        public ServerSetupWindow View
        {
            get
            {
                return this.view;
            }
        }

        public void DisposeView()
        {
            this.view.Dispose();
        }

        public void ConnectClicked()
        {
            string address = this.view.Address;
            int port;
            int.TryParse(this.view.Port, out port);
            string user = this.view.User;
            string password = this.view.Pw;

            try
            {
                DigitalVoterList.GetConnectionInstance(user, password, address, port);
            }
            catch (System.FormatException e)
            {
                view.ShowMessageBox("The credentials provided were wrong.");
                return;
            }
            catch (MySqlException e)
            {
                if (e.Message.Contains("Access denied"))
                {
                    view.ShowMessageBox("The credentials provided were wrong.");
                    return;
                }
                if (e.Message.Contains("timeout"))
                {
                    view.ShowMessageBox("The server did not respond in due time, please check your connection.");
                    return;
                }
                if (e.Message.Contains("Unable to connect"))
                {
                    view.ShowMessageBox("The program was not able to connect to the specified server.");
                    return;
                }
                view.ShowMessageBox("Something unexpected went wrong.");
                view.ShowMessageBox(e.Message);
                return;
            }

            this.model.SaveCredentials(address, port, user, password);
            this.OnConnected();
        }
    }
}
