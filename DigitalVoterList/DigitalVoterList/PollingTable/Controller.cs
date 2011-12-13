// -----------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
// Author: Claes Martinsen
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;
    using DBComm.DBComm.DAO;

    /// <summary>
    /// The main controller of the application. 
    /// It is responsible for reacting on user input, validating and propergating on to model.
    /// </summary>
    public class Controller
    {
        private Model model;
        private PtView view;

        public Controller(Model model, PtView view)
        {
            this.view = view;
            this.model = model;

           //Button subscriptions. When the user presses a button the controller is notified. 
            view.ScannerWindow.FindVoterButton.Click += this.ReactTofindVoterRequest;
            view.VoterShown += this.ReactToRegisterRequest;
            view.Unregister += this.ReactToUnregRequest;
            view.SetupWindow.ConnectBtn.Click += this.ReactToConnectRequest;

            this.SetupPollingTable(); //Setup polling table with setup.conf information.
        }

        /// <summary>
        /// Reacts to the find voter request.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReactTofindVoterRequest(object sender, EventArgs e)
        {
            string cprStr = view.ScannerWindow.CprnrTxtBox.Text;

            //Validate that CPRNO doesn't contain letters
            if (!Model.CprLetterVal(cprStr))
            {
                view.ShowMessageBox("Cprno must only contain numbers.");
                return;
            }

            uint cpr;

            //unhash the cpr nr if it has a length of 11 chars or above.
            if (cprStr.Length > 10)
            {
                cpr = Central.Utility.BarCodeHashing.UnHash(cprStr);
            }
            else
            {
                uint result;
                bool res = uint.TryParse(cprStr, out result);
                if (!res)
                {
                    view.ShowMessageBox("Cprno is not valid.");
                    return;
                }
                cpr = Convert.ToUInt32(cprStr);
                
            }
            //Validate length of CPRNO.
            if (!Model.CprLengtVal(cpr))
            {
                view.ShowMessageBox("Length of cprno is not valid.");
                return;
            }

            //uint cpr = this.Validate();
            try
            {
                model.initializeStaticDAO();
            }
            catch (Exception)
            {
                view.ShowMessageBox("Connetcion Lost");
            }

            try
            {
                //Validate if the voter is listed at the polling station.
                if (model.FetchVoter(cpr) == null)
                {
                    view.ShowMessageBox("Voter is not listed at polling station");
                    return;
                }
            }
            catch (Exception e4)
            {
                if (e4.Message.Contains("timeout"))
                {
                    view.ShowMessageBox("The voter card is being accessed at another table!");
                    return;
                }
            }
            try
            {
                model.FindVoter(cpr);
                this.ResetCprTxtBox();
            }
            catch (Exception)
            {
                view.ShowMessageBox("Connection lost.");
            }

        }

        /// <summary>
        /// Reacts when user request to register voter.
        /// </summary>
        private void ReactToRegisterRequest()
        {
            //Update the model so that the voter is registered.
            model.RegisterCurrentVoter();
            view.ShowMessageBox("The voter card is registered");
            this.ResetCprTxtBox();
            view.ScannerWindow.Focus();
        }

        /// <summary>
        /// Reacts when user request to unregister voter.
        /// </summary>
        private void ReactToUnregRequest(string adminPass)
        {

            if (!model.AdminPass.Equals(adminPass))
            {
                view.ShowMessageBox("Incorrect password");
                view.UnregWindow.AdmPass.Text = "";
            }
            else
            {
                //Update the model so that the voter is unregistered.
                model.UnregisterCurrentVoter();
                view.ShowMessageBox("The voter card is now unregistered");
                view.UnregWindow.Close();
                this.ResetCprTxtBox();
                view.ScannerWindow.CprnrTxtBox.Focus();
            }
        }

        /// <summary>
        /// resets the cpr text box in the scanner window. 
        /// </summary>
        private void ResetCprTxtBox()
        {
            view.ScannerWindow.resetCprTxt();
        }

        /// <summary>
        /// Reacts to connection request.
        /// </summary>
        private void ReactToConnectRequest(object o, EventArgs e)
        {
            SetupInfo setupInfo = new SetupInfo(); //The setup info to be checked and then updated to the setup info in model if valid. 
            setupInfo.Ip = view.SetupWindow.IpTextBox;

            uint result;
            bool res = uint.TryParse(view.SetupWindow.TableBox, out result);
            if(!res)
            {
                view.ShowMessageBox("Table number cannot be negative");
                return;
            }
            setupInfo.TableNo = uint.Parse(view.SetupWindow.TableBox);

            string password = view.SetupWindow.Password; //Password from setup window to be tested.

            try
            {
                //Tests inf there is a connection to the voter box.
                PessimisticVoterDAO pvdao = new PessimisticVoterDAO(setupInfo.Ip, password);
                pvdao.StartTransaction();
                pvdao.EndTransaction();
            }
            catch (Exception e1)
            {
                if (e1.Message.Contains("Access"))
                {
                    view.ShowMessageBox("Incorrect password");
                    return;
                }
                if (e1.Message.Contains("connect"))
                {
                    view.ShowMessageBox("No connection to server. Please check connection or target address.");
                    return;
                }
            }

            //feed the model with setup information.
            model.SetupInfo = setupInfo;
            model.AdminPass = password;

            //Tries to write setup information to the setup.conf file. 
            try
            {
                model.WriteToConfig();
            }
            catch (Exception e2)
            {
                view.ShowMessageBox("unable to write to config file. " + e2.StackTrace);
            }
            view.SetupWindow.Hide();
            view.ScannerWindow.Show();
        }

        /// <summary>
        /// Set's up the polling table information from the setup.conf file.
        /// </summary>
        private void SetupPollingTable()
        {
            try
            {
                model.ReadConfig();
            }
            catch (Exception e3)
            {
                view.ShowMessageBox("unable to read from or write to config file. " + e3.StackTrace);
                return;
            }
        }
    }
}

