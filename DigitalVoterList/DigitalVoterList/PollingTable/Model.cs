using System.Diagnostics.Contracts;
using DigitalVoterList.PollingTable;
// -----------------------------------------------------------------------
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
        public delegate void ConnectionErrorHandler();

        public event VoterChangedHandler CurrentVoterChanged;
        public event SetupInfoChangedHandler SetupInfoChanged;
        public event ConnectionErrorHandler ConnectionError;

        /// <summary>
        /// 
        /// </summary>
        public void initializeStaticDAO()
        {
            staticPvdao = new PessimisticVoterDAO(setupInfo.Ip, adminPass); //Initialize the pvdao.
            staticPvdao.StartTransaction();
        }

        /// <summary>
        /// 
        /// </summary>
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
            Contract.Requires(cprno != null);
            Contract.Ensures(cprno == currentVoter.PrimaryKey);
            currentVoter = staticPvdao.Read(cprno);

            //Update the current voter with the found voter
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
            try
            {
                staticPvdao.Update((uint)currentVoter.PrimaryKey, true);

                //refresh the current voter to reflect the new voted status
                currentVoter = FetchVoter((uint)currentVoter.PrimaryKey);

                //Update log with write entry
                this.UpdateLog(ActivityEnum.W);
                staticPvdao.EndTransaction();
            }
            catch (Exception)
            {
                ConnectionError();
                return;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cprno"></param>
        /// <returns></returns>
        public VoterDO FetchVoter(uint cprno)
        {
            Contract.Requires(cprno != null);
            Contract.Requires(cprno is uint);
            Contract.Ensures(Contract.Result<VoterDO>() == null ? Contract.Result<VoterDO>().PrimaryKey == cprno : true);
            VoterDO voter;

            try
            {
                voter = staticPvdao.Read(cprno);
            }
            catch (Exception)
            {
                voter = new VoterDO();
                ConnectionError();
            }
            return voter;

        }

        public void UnregisterCurrentVoter()
        {
            Contract.Requires(currentVoter.Voted == true);
            Contract.Requires(currentVoter != null);
            Contract.Ensures(currentVoter.Voted == false);

            try
            {
                staticPvdao.Update((uint)currentVoter.PrimaryKey, false);
                //refresh the current voter to reflect the new voted status
                currentVoter = FetchVoter((uint)currentVoter.PrimaryKey);
                staticPvdao.EndTransaction();
                this.UpdateLog(ActivityEnum.U); //Update log with unregister entry
            }
            catch (Exception)
            {
                ConnectionError();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ae">The activity to be logged</param>
        private void UpdateLog(ActivityEnum ae)
        {
            try
            {
                var ldo = new LogDO((uint)setupInfo.TableNo, currentVoter.PrimaryKey, ae);
                var ldao = new LogDAO(DigitalVoterList.GetInstanceFromServer(setupInfo.Ip));
                ldao.Create(ldo);
            }
            catch (Exception)
            {
                ConnectionError();
            }
        }

        // ##### Utility methods to validate user input ##### //

        /// <summary>
        /// Validate if the length of the cprno is correct.
        /// </summary>
        /// <param name="cpr">the cprno to be validated</param>
        /// <returns>false if cpr is not valid, true if it is.</returns>
        public static bool CprLengtVal(uint cpr)
        {
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
            get { return this.setupInfo; }
            set { this.setupInfo = value; }
        }

        public string AdminPass
        {
            get { return this.adminPass; }
            set { this.adminPass = value; }
        }

        public static PessimisticVoterDAO StaticPvdao
        {
            get { return staticPvdao; }
            set { staticPvdao = value; }
        }
    }
}
