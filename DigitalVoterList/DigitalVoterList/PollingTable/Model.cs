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

    using DBComm.DBComm.DO;
    using DBComm.DBComm.DAO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Model
    {
        public VoterDO currentVoter = null;

        private static string adminPass = "abc123";
        private const string Path = "c:/SetupDVL.conf";
        private string ip;
        private int tableNo;

        public delegate void VoterChangedHandler(VoterDO voter);
        
        public event VoterChangedHandler CurrentVoterChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cprno"></param>
        public void FindVoter(uint cprno)
        {
            
            //this.currentVoter = FetchVoter(cprno);

            PessimisticVoterDAO pvdao = new PessimisticVoterDAO();
            pvdao.StartTransaction();
            currentVoter = pvdao.Read(cprno);
            pvdao.EndTransaction();
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
            var pvdao = new PessimisticVoterDAO();
            pvdao.StartTransaction();
            pvdao.Update((uint)currentVoter.PrimaryKey, true);
            pvdao.EndTransaction();
            //refresh the current voter to reflect the new voted status
            currentVoter = FetchVoter((uint)currentVoter.PrimaryKey);
            //Update log with write entry
            this.UpdateLog(ActivityEnum.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cprno"></param>
        /// <returns></returns>
        public VoterDO FetchVoter(uint cprno)
        {
            var pvdao = new PessimisticVoterDAO();
            //return pvdao.Read(v => v.PrimaryKey == cprno).ToList().Single();
            pvdao.StartTransaction();
            VoterDO voter = pvdao.Read(cprno);
            pvdao.EndTransaction();
            return voter;
            ///TODO use pesimistic. 

        }

        public void UnregisterCurrentVoter()
        {
            ///contracts
            var pvdao = new PessimisticVoterDAO();
            pvdao.StartTransaction();
            pvdao.Update((uint)currentVoter.PrimaryKey, false);
            pvdao.EndTransaction();
            //refresh the current voter to reflect the new voted status
            currentVoter = FetchVoter((uint)currentVoter.PrimaryKey);
            //Update log with unregister entry
            this.UpdateLog(ActivityEnum.U);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wr">True means to log a write, false means to log a read</param>
        private void UpdateLog(ActivityEnum ae)
        {
            ///table number should be a static variable in model read from the config file.
            var ldo = new LogDO(5, currentVoter.PrimaryKey, ae);
            var ldao = new LogDAO();
            ldao.Create(ldo);
        }

        // ##### Utility methods to validate user input ##### //

        /// <summary>
        /// Validate if the length of the cprno is correct.
        /// </summary>
        /// <param name="cpr">the cprno to be validated</param>
        /// <returns>false if cpr is not valid, true if it is.</returns>
        public static bool CprLengtVal(string cpr)
        {
            int j = cpr.Length;
            if (j > 10 || j < 10) return false;
            return true;
        }

        /// <summary>
        /// Validate if the cprno does not contain letters.
        /// </summary>
        /// <param name="cpr">The cprno the be validated</param>
        /// <returns>false if cpr is not valid, true if it is.</returns>
        public static bool CprLetterVal(string cpr)
        {
            uint result;
            bool res = uint.TryParse(cpr, out result);
            if (!res) return false;
            return true;
        }

        /// <summary>
        /// evaluates a password...
        /// </summary>
        /// <param name="psw"></param>
        /// <returns></returns>
        public static bool PswVal(string psw)
        {
            
            return psw.Equals(adminPass);
        }

        public SetupInfo ReadConfig()
        {
            SetupInfo si;

            //If it doesn't exist, create a new one (with blank lines).
            if (!File.Exists(Path))
            {
                string[] write = {};
                File.WriteAllLines(Path, write);
            }
            //try to read the file. 
            string[] arr = File.ReadAllLines(Path);
            if (arr.Length > 0)
            {
                si = new SetupInfo(arr[0], arr[1], "");
            }
            else {si = new SetupInfo("","","");}
            return si;
        }
        
        public void WriteToConfig(SetupInfo si)
        {
            if (!File.Exists(Path))
            {
                this.ReadConfig(); //calling this method creates the config file.
            }
            string[] arr = new string[2];
            arr[0] = si.ip;
            arr[1] = si.Table;
            File.WriteAllLines(Path, arr);
        }
    }
}
