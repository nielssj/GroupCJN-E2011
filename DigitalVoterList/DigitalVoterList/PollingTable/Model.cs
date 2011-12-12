﻿// -----------------------------------------------------------------------
// <copyright file="Model.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;

    using DBComm.DBComm;
    using DBComm.DBComm.DO;
    using DBComm.DBComm.DAO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Model
    {
        public VoterDO currentVoter = null;

        private string adminPass = "";

        private const string Path = "c:/SetupDVL.conf";

        private SetupInfo setupInfo = new SetupInfo("", 0);

        private static PessimisticVoterDAO staticPvdao;

        public delegate void VoterChangedHandler(VoterDO voter);

        public delegate void SetupInfoChangedHandler(SetupInfo setupInfo);

        public event VoterChangedHandler CurrentVoterChanged;

        public event SetupInfoChangedHandler SetupInfoChanged;

        public void initializeStaticDAO()
        {
            staticPvdao = new PessimisticVoterDAO(setupInfo.Ip, adminPass); //Initialize the pvdao.
            staticPvdao.StartTransaction();
        }

        public static void cleanUpDAO()
        {
            staticPvdao.EndTransaction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cprno"></param>
        public void FindVoter(uint cprno)
        {
            currentVoter = staticPvdao.Read(cprno);

            //Update the current voter to the 
            CurrentVoterChanged(currentVoter);
            //Update log with read entry
            this.UpdateLog(ActivityEnum.R);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RegisterCurrentVoter()
        {
            Contract.Requires(currentVoter.Voted == false);
            Contract.Requires(currentVoter != null);
            Contract.Ensures(currentVoter.Voted == true);

            staticPvdao.Update((uint)currentVoter.PrimaryKey, true);

            //refresh the current voter to reflect the new voted status
            currentVoter = FetchVoter((uint)currentVoter.PrimaryKey);

            //Update log with write entry
            this.UpdateLog(ActivityEnum.W);
            staticPvdao.EndTransaction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cprno"></param>
        /// <returns></returns>
        public VoterDO FetchVoter(uint cprno)
        {

            VoterDO voter = staticPvdao.Read(cprno);

            return voter;


        }

        public void UnregisterCurrentVoter()
        {
            ///contracts

            staticPvdao.Update((uint)currentVoter.PrimaryKey, false);

            //refresh the current voter to reflect the new voted status
            currentVoter = FetchVoter((uint)currentVoter.PrimaryKey);

            staticPvdao.EndTransaction();
            this.UpdateLog(ActivityEnum.U); //Update log with unregister entry

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ae">The activity to be logged</param>
        private void UpdateLog(ActivityEnum ae)
        {

            var ldo = new LogDO((uint)setupInfo.TableNo, currentVoter.PrimaryKey, ae);
            var ldao = new LogDAO(DigitalVoterList.GetInstanceFromServer(setupInfo.Ip));
            ldao.Create(ldo);
        }

        // ##### Utility methods to validate user input ##### //

        /// <summary>
        /// Validate if the length of the cprno is correct.
        /// </summary>
        /// <param name="cpr">the cprno to be validated</param>
        /// <returns>false if cpr is not valid, true if it is.</returns>
        public static bool CprLengtVal(uint cpr)
        {
            //int j = cpr.Length;
            return (cpr > 10 || cpr < 10);
            
        }

        /// <summary>
        /// Validate if the cprno does not contain letters.
        /// </summary>
        /// <param name="cpr">The cprno the be validated</param>
        /// <returns>false if cpr is not valid, true if it is.</returns>
        public static bool CprLetterVal(string cpr)
        {

            UInt64 result;
            bool res = UInt64.TryParse(cpr, out result);
            if (!res) return false;
            return true;
        }

        public void ReadConfig()
        {
            //If it doesn't exist, create a new one (with blank lines).
            if (!File.Exists(Path))
            {
                string[] write = { };
                File.WriteAllLines(Path, write);
            }
            //try to read the file. 
            string[] arr = File.ReadAllLines(Path);
            if (arr.Length > 0)
            {

                setupInfo.Ip = arr[0];

                //test if the read string can be parsed to an int
                string str = arr[1];
                uint i;
                bool res = UInt32.TryParse(str, out i);
                if (res) setupInfo.TableNo = i;
                SetupInfoChanged(this.setupInfo);
            }
        }

        public void WriteToConfig()
        {
            if (!File.Exists(Path))
            {
                this.ReadConfig(); //calling this method creates the config file.
            }
            string[] arr = new string[2];
            arr[0] = setupInfo.Ip;
            arr[1] = setupInfo.TableNo.ToString();
            File.WriteAllLines(Path, arr);
        }

        public SetupInfo SetupInfo
        {
            get
            {
                return this.setupInfo;
            }
            set
            {
                this.setupInfo = value;
            }
        }

        public string AdminPass
        {
            get
            {
                return this.adminPass;
            }
            set
            {
                this.adminPass = value;
            }
        }


    }
}
