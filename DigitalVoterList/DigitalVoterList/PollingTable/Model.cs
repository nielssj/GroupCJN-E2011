﻿// -----------------------------------------------------------------------
// <copyright file="Model.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using DBComm.DBComm.DO;

    //using System.Diagnostics.Contracts;

    using DBComm.DAO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Model
    {
        public VoterDO currentVoter = null;
        private List<VoterDO> voterList;

        public delegate void VoterChangedHandler(VoterDO voter);
        public event VoterChangedHandler CurrentVoterChanged;

        public Model()
        {

            VoterDO v1 = new VoterDO(1, 1, "Peter Henningsen", "Tjørnevænget 10", "Ballerup", true, false);
            VoterDO v2 = new VoterDO(1, 2, "Henning Petersen", "Tjørnevænget 10", "ballerup", true, true);
            VoterDO v3 = new VoterDO(1, 42, "Peter Nielsen", "Testvej 1", "ballerup", true, false);

            voterList = new List<VoterDO>();
            voterList.Add(v1);
            voterList.Add(v2);
            voterList.Add(v3);

            //Start program.
        }

        public bool findVoter(int CPRNO)
        {
            //System.Windows.Forms.MessageBox.Show("Glen");
            //1) Check if cprnr exists. If not get an error. else update current voter
            foreach (var voterDo in voterList)
            {
                if (voterDo.PrimaryKey == CPRNO)
                {
                    currentVoter = voterDo;
                    CurrentVoterChanged(currentVoter);
                    return true;
                }
            }
            return false;
        }

        public void RegisterCurrentVoter()
        {
            Contract.Requires(currentVoter.Voted == false);
            Contract.Requires(currentVoter != null);
            Contract.Ensures(currentVoter.Voted == true);
            PessimisticVoterDAO pvdo = new PessimisticVoterDAO();
            pvdo.StartTransaction();
            pvdo.Update((uint)currentVoter.Cpr, true);
            pvdo.EndTransaction();
        }


    }
}
