﻿// -----------------------------------------------------------------------
// <copyright file="Controller.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;
    using System.Windows.Forms;
    using DBComm.DBComm.DAO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Controller
    {
        private Model model;
        private PtView view;

        public Controller(Model model, PtView view)
        {
            this.view = view;
            this.model = model;

            view.ScannerWindow.FindVoterButton.Click += this.ReactTofindVoterRequest;
            view.VoterShown += this.ReactToRegisterRequest;
            view.Unregister += this.ReactToUnregRequest;
            view.SetupWindow.ConnectBtn.Click += this.ReactToConnectRequest;

            this.StartPollingTable();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReactTofindVoterRequest(object sender, EventArgs e)
        {
            string cpr = view.ScannerWindow.CprnrTxtBox.Text;
            
            //Validate length of CPRNR. 
            if(!Model.CprLengtVal(cpr)) { view.ShowMessageBox("Length of cprno is not valid."); return; }

            //Validate that CPRNR doesn't contain letters
            if (!Model.CprLetterVal(cpr)) { view.ShowMessageBox("Cprno must only contain numbers."); return; }

            model.initializeStaticDAO();

            try
            {
                if (model.FetchVoter(uint.Parse(cpr)) == null)
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
            //Validate if the voter is listed at the polling station.
            
            // try to fetch the voter from the voter box. If no voter found write an error msg.
            //try
            model.FindVoter(Convert.ToUInt32(view.ScannerWindow.CprnrTxtBox.Text)); 
            //catch (Exception) 
            //{ view.ShowMessageBox("Voter not registered at polling station."); }

            this.ResetCprTxtBox();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReactToRegisterRequest()
        {
            view.ShowMessageBox("The voter card is registered");
            //Update the model so that the voter is registered.
            model.RegisterCurrentVoter();
            this.ResetCprTxtBox();
            view.ScannerWindow.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReactToUnregRequest(string adminPass)
        {
            
            if (!model.AdminPass.Equals(adminPass))
            {
                view.ShowMessageBox("Incorrect password");
                //view.OpenUnregWindow();
                return;
                //TODO clear the password box and set focus
                //React to message box OK button and open. 
            }
            
            //Update the model so that the voter is unregistered.
            model.UnregisterCurrentVoter();
            view.ShowMessageBox("The voter card is now unregistered");
            this.ResetCprTxtBox();
            view.ScannerWindow.CprnrTxtBox.Focus();
        }

        private void ResetCprTxtBox()
        {
            view.ScannerWindow.resetCprTxt(); 
        }


        private void ReactToConnectRequest(object o, EventArgs e)
        {

            SetupInfo setupInfo = new SetupInfo(); //The setup info to be checked and then updated to the setup info in model if valid. 
            setupInfo.Ip = view.SetupWindow.IpTextBox;
            setupInfo.TableNo = uint.Parse(view.SetupWindow.TableBox);

            //check the password before continuation
            //if (!Model.PswVal(view.SetupWindow.Password))
            //{
            //    view.ShowMessageBox("Incorrect password");
            //    return;
            //}
            //model.SetupInfo.Ip = view.SetupWindow.IpTextBox;
            //model.TableNo = Int32.Parse(view.SetupWindow.TableBox);

            string password = view.SetupWindow.Password; //Password from setup window to be tested.

            try
            {
                //PessimisticVoterDAO pvdao = new PessimisticVoterDAO(setupInfo.Ip, password);
                //pvdao.StartTransaction();
                //pvdao.EndTransaction();
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

            model.SetupInfo = setupInfo;
            model.AdminPass = password;

            try
            {               
                model.WriteToConfig();
            }
            catch(Exception e2)
            {
                view.ShowMessageBox("unable to write to config file. " + e2.StackTrace);
            }
            view.SetupWindow.Hide();
            view.ScannerWindow.Show();
         
        }

        public void StartPollingTable()
        {
            //SetupInfo setupFilter;
            try
            {
                model.ReadConfig();
            }
            catch (Exception e3)
            {
                view.ShowMessageBox("unable to read from or write to config file. " + e3.StackTrace);
                return;
            }
            //view.SetupWindow.IpTextBox = model.SetupInfo.Ip;
            //view.SetupWindow.TableBox = setupFilter.TableNo;

            view.SetupWindow.ShowDialog();
            Application.Run(view.ScannerWindow);
        }

        private void CheckConnection()
        {
            
        }
    }
}

