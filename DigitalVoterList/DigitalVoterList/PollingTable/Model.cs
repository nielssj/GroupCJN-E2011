// -----------------------------------------------------------------------
// <copyright file="Model.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using DBComm.DBComm.DO;

    //using System.Diagnostics.Contracts;

    using DBComm.DBComm.DAO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Model
    {
        public VoterDO currentVoter = null;
        //private List<VoterDO> voterList;

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
            currentVoter = FetchVoter((uint)currentVoter.PrimaryKey);
            this.UpdateLog(true);

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

        public void unregisterCurrentVoter()
        {
            PessimisticVoterDAO pvdao = new PessimisticVoterDAO();
            pvdao.StartTransaction();
            pvdao.Update((uint)currentVoter.PrimaryKey, false);
            pvdao.EndTransaction();
            currentVoter = FetchVoter((uint)currentVoter.PrimaryKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wr">True means to log a write, false means to log a read</param>
        private void UpdateLog(bool wr)
        {
            LogDO ldo = new LogDO(5, DateTime.Now, currentVoter.PrimaryKey, 5,  ActivityEnum.R);
            LogDAO ldao = new LogDAO();
            ldao.Create(ldo);
        }
    }
}
