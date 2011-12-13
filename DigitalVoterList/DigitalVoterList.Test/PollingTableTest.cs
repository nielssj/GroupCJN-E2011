
using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace DigitalVoterList.Test
{
    using DigitalVoterList.PollingTable;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using global::DBComm.DBComm;
    using global::DBComm.DBComm.DAO;
    using global::DBComm.DBComm.DataGeneration;
    using global::DBComm.DBComm.DO;
    
    [TestClass]
    public class PollingTableTest
    {
        private Model model;

        private VoterDO voter;

        private string password = "abc123";

        private string server = "localhost";

        [TestInitialize]
        public void Setup()
        {
            voter = new VoterDO(1, 3112999900, "Test Person", "TestRoad 31", "Testville", true, false);
        }

        [TestCleanup]
        public void TearDown()
        {
            model = null;
            voter = null;
        }

        [TestMethod]
        public void DAOCleanupTest()
        {
            Model model = new Model();
            SetupInfo si = new SetupInfo(server, 0);
            model.SetupInfo = si;
            model.AdminPass = password;
            model.initializeStaticDAO();
            Assert.IsTrue(Model.StaticPvdao.TransactionStarted());
            Model.cleanUpDAO();
            Assert.IsTrue(Model.StaticPvdao.TransactionStarted() == false);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void FetchVoterTest()
        {
            
            VoterDAO vdao = new VoterDAO(DigitalVoterList.GetInstance("root", password, server));
            vdao.Create(voter);

            Model model = new Model();
            SetupInfo si = new SetupInfo(server, 0);
            model.SetupInfo = si;
            model.AdminPass = password;

            model.initializeStaticDAO();
            VoterDO v = model.FetchVoter((uint)this.voter.PrimaryKey);
            Assert.AreEqual(voter.PrimaryKey, v.PrimaryKey);
            Model.cleanUpDAO();
            vdao.Delete(x => x.PrimaryKey == voter.PrimaryKey);
        }

        public void PutVoterInDB()
        {
            VoterDAO vdao = new VoterDAO(DigitalVoterList.GetInstance("root", password, server));
            vdao.Create(voter);
        }

        [TestMethod]
        public void FindVoterTest()
        {

            VoterDAO vdao = new VoterDAO(DigitalVoterList.GetInstance("root", password, server));
            vdao.Create(voter);

            Model model = new Model();
            SetupInfo si = new SetupInfo(server, 0);
            model.SetupInfo = si;
            model.AdminPass = password;
            model.initializeStaticDAO();

            string msg;
            model.ConnectionError += (x => msg = x);
 
            model.FindVoter((uint)voter.PrimaryKey);
            Assert.AreEqual(model.currentVoter, voter);
            Model.cleanUpDAO();

            vdao.Delete(x => x.PrimaryKey == voter.PrimaryKey);
            

        }

        public void RegisterCurrentVoterTest()
        {
            //covered by the contracts
        }

        public void UnregisterCurrentVoterTest()
        {
            //covered by contracts.
        }
    }
}
