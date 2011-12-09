// -----------------------------------------------------------------------
// <copyright file="Model.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using DBComm.DBComm.DO;

    using DBComm.DBComm.DAO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Model
    {
        public VoterDO currentVoter = null;

        private readonly string adminPass = "abc123";

        public delegate void VoterChangedHandler(VoterDO voter);
        
        public event VoterChangedHandler CurrentVoterChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cprno"></param>
        public void FindVoter(uint cprno)
        {
            this.currentVoter = FetchVoter(cprno);
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
            PessimisticVoterDAO pvdao = new PessimisticVoterDAO();
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
        private VoterDO FetchVoter(uint cprno)
        {
            VoterDAO vdao = new VoterDAO();
            return vdao.Read(v => v.PrimaryKey == cprno).ToList().Single();
        }

        public void UnregisterCurrentVoter()
        {
            ///contracts
            PessimisticVoterDAO pvdao = new PessimisticVoterDAO();
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
            LogDO ldo = new LogDO(5, currentVoter.PrimaryKey, ae);
            LogDAO ldao = new LogDAO();
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
            int result;
            bool res = Int32.TryParse(cpr, out result);
            if (!res) return false;
            return true;
        }

        public string AdmPass
        {
            get
            {
                return adminPass;
            }
        }
    }
}
