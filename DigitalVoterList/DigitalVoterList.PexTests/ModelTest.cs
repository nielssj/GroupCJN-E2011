// <copyright file="ModelTest.cs">Copyright ©  2011</copyright>

/*NOTE: Some pex generated tests could not be run and have been deleted from the PEX test suite. 
/ NOTE: Instead the methods have been tested in the DigitalVoterList pollingTableTest test suite. */

using System;
using DigitalVoterList.PollingTable;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBComm.DBComm.DO;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Framework.Explorable;
using System.Data.Linq;
using Microsoft.Pex.Engine.Exceptions;
using DBComm.DBComm.DAO;

namespace DigitalVoterList.PollingTable
{
    [TestClass]
    [PexClass(typeof(Model))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ModelTest
    {
        [PexMethod]
        public void WriteToConfig([PexAssumeUnderTest]Model target)
        {
            target.WriteToConfig();
            // TODO: add assertions to method ModelTest.WriteToConfig(Model)
        }
        [TestMethod]
        public void WriteToConfig556()
        {
            Model model;
            model = new Model();
            model.currentVoter = (VoterDO)null;
            model.AdminPass = (string)null;
            this.WriteToConfig(model);
            Assert.IsNotNull((object)model);
            Assert.IsNull((object)(model.currentVoter));
            Assert.AreEqual<string>("", model.SetupInfo.Ip);
            Assert.AreEqual<uint>(0u, model.SetupInfo.TableNo);
            Assert.AreEqual<string>((string)null, model.AdminPass);
        }
        [PexMethod]
        public void UnregisterCurrentVoter([PexAssumeUnderTest]Model target)
        {
            target.UnregisterCurrentVoter();
            // TODO: add assertions to method ModelTest.UnregisterCurrentVoter(Model)
        }
        [TestMethod]
        public void UnregisterCurrentVoterThrowsContractException724()
        {
            try
            {
                VoterDO voterDO;
                Model model;
                voterDO = PexInvariant.CreateInstance<VoterDO>();
                PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
                PexInvariant.SetField<EntityRef<PollingStationDO>>
                    ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
                PexInvariant.SetField<uint?>
                    ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
                PexInvariant.SetField<string>
                    ((object)voterDO, "<Name>k__BackingField", (string)null);
                PexInvariant.SetField<string>
                    ((object)voterDO, "<Address>k__BackingField", (string)null);
                PexInvariant.SetField<string>
                    ((object)voterDO, "<City>k__BackingField", (string)null);
                PexInvariant.SetField<bool?>
                    ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
                PexInvariant.SetField<bool?>
                    ((object)voterDO, "<Voted>k__BackingField", new bool?(false));
                PexInvariant.CheckInvariant((object)voterDO);
                model = new Model();
                model.currentVoter = voterDO;
                model.AdminPass = (string)null;
                this.UnregisterCurrentVoter(model);
                throw
                  new AssertFailedException("expected an exception of type ContractException");
            }
            catch (Exception ex)
            {
                if (!PexContract.IsContractException(ex))
                    throw ex;
            }
        }
        
        [PexMethod]
        public void StaticPvdaoSet(PessimisticVoterDAO value)
        {
            Model.StaticPvdao = value;
            // TODO: add assertions to method ModelTest.StaticPvdaoSet(PessimisticVoterDAO)
        }
        [TestMethod]
        public void StaticPvdaoSet666()
        {
            this.StaticPvdaoSet((PessimisticVoterDAO)null);
        }
        [PexMethod]
        public PessimisticVoterDAO StaticPvdaoGet()
        {
            PessimisticVoterDAO result = Model.StaticPvdao;
            return result;
            // TODO: add assertions to method ModelTest.StaticPvdaoGet()
        }
        [TestMethod]
        public void StaticPvdaoGet507()
        {
            PessimisticVoterDAO pessimisticVoterDAO;
            pessimisticVoterDAO = this.StaticPvdaoGet();
            Assert.IsNull((object)pessimisticVoterDAO);
        }
        [PexMethod]
        public void SetupInfoSet([PexAssumeUnderTest]Model target, SetupInfo value)
        {
            target.SetupInfo = value;
            // TODO: add assertions to method ModelTest.SetupInfoSet(Model, SetupInfo)
        }
        [TestMethod]
        public void SetupInfoSet730()
        {
            Model model;
            model = new Model();
            model.currentVoter = (VoterDO)null;
            model.AdminPass = (string)null;
            this.SetupInfoSet(model, default(SetupInfo));
            Assert.IsNotNull((object)model);
            Assert.IsNull((object)(model.currentVoter));
            Assert.AreEqual<string>((string)null, model.SetupInfo.Ip);
            Assert.AreEqual<uint>(0u, model.SetupInfo.TableNo);
            Assert.AreEqual<string>((string)null, model.AdminPass);
        }
        [PexMethod]
        public SetupInfo SetupInfoGet([PexAssumeUnderTest]Model target)
        {
            SetupInfo result = target.SetupInfo;
            return result;
            // TODO: add assertions to method ModelTest.SetupInfoGet(Model)
        }
        [TestMethod]
        public void SetupInfoGet79()
        {
            Model model;
            SetupInfo setupInfo;
            model = new Model();
            model.currentVoter = (VoterDO)null;
            model.AdminPass = (string)null;
            setupInfo = this.SetupInfoGet(model);
            Assert.AreEqual<string>("", setupInfo.Ip);
            Assert.AreEqual<uint>(0u, setupInfo.TableNo);
            Assert.IsNotNull((object)model);
            Assert.IsNull((object)(model.currentVoter));
            Assert.AreEqual<string>("", model.SetupInfo.Ip);
            Assert.AreEqual<uint>(0u, model.SetupInfo.TableNo);
            Assert.AreEqual<string>((string)null, model.AdminPass);
        }
        [PexMethod]
        public void RegisterCurrentVoter([PexAssumeUnderTest]Model target)
        {
            target.RegisterCurrentVoter();
            // TODO: add assertions to method ModelTest.RegisterCurrentVoter(Model)
        }
        
        [TestMethod]
        public void RegisterCurrentVoterThrowsContractException525()
        {
            try
            {
                VoterDO voterDO;
                Model model;
                voterDO = PexInvariant.CreateInstance<VoterDO>();
                PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
                PexInvariant.SetField<EntityRef<PollingStationDO>>
                    ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
                PexInvariant.SetField<uint?>
                    ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
                PexInvariant.SetField<string>
                    ((object)voterDO, "<Name>k__BackingField", (string)null);
                PexInvariant.SetField<string>
                    ((object)voterDO, "<Address>k__BackingField", (string)null);
                PexInvariant.SetField<string>
                    ((object)voterDO, "<City>k__BackingField", (string)null);
                PexInvariant.SetField<bool?>
                    ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
                PexInvariant.SetField<bool?>
                    ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
                PexInvariant.CheckInvariant((object)voterDO);
                model = new Model();
                model.currentVoter = voterDO;
                model.AdminPass = (string)null;
                this.RegisterCurrentVoter(model);
                throw
                  new AssertFailedException("expected an exception of type ContractException");
            }
            catch (Exception ex)
            {
                if (!PexContract.IsContractException(ex))
                    throw ex;
            }
        }
       
        [PexMethod]
        public void ReadConfig([PexAssumeUnderTest]Model target)
        {
            target.ReadConfig();
            // TODO: add assertions to method ModelTest.ReadConfig(Model)
        }
        
        [PexMethod]
        public bool CprLetterVal(string cpr)
        {
            bool result = Model.CprLetterVal(cpr);
            return result;
            // TODO: add assertions to method ModelTest.CprLetterVal(String)

        }
        [TestMethod]
        public void CprLetterVal146()
        {
            bool b;
            b = this.CprLetterVal("2");
            Assert.AreEqual<bool>(true, b);
        }
        [TestMethod]
        public void CprLetterVal719()
        {
            bool b;
            b = this.CprLetterVal((string)null);
            Assert.AreEqual<bool>(false, b);
        }
        [PexMethod]
        public bool CprLengtVal(uint cpr)
        {
            bool result = Model.CprLengtVal(cpr);
            return result;
            // TODO: add assertions to method ModelTest.CprLengtVal(UInt32)
        }
        [TestMethod]
        public void CprLengtVal201()
        {
            bool b;
            b = this.CprLengtVal(11u);
            Assert.AreEqual<bool>(true, b);
        }
        [TestMethod]
        public void CprLengtVal282()
        {
            bool b;
            b = this.CprLengtVal(0u);
            Assert.AreEqual<bool>(true, b);
        }
        [PexMethod]
        public Model Constructor()
        {
            Model target = new Model();
            return target;
            // TODO: add assertions to method ModelTest.Constructor()
        }
        [TestMethod]
        public void Constructor101()
        {
            Model model;
            model = this.Constructor();
            Assert.IsNotNull((object)model);
            Assert.IsNull((object)(model.currentVoter));
            Assert.AreEqual<string>("", model.SetupInfo.Ip);
            Assert.AreEqual<uint>(0u, model.SetupInfo.TableNo);
            Assert.AreEqual<string>("", model.AdminPass);
        }
        [PexMethod]
        public void cleanUpDAO()
        {
            Model.cleanUpDAO();
            // TODO: add assertions to method ModelTest.cleanUpDAO()
        }
        
        [PexMethod]
        public void AdminPassSet([PexAssumeUnderTest]Model target, string value)
        {
            target.AdminPass = value;
            // TODO: add assertions to method ModelTest.AdminPassSet(Model, String)
        }
        [TestMethod]
        public void AdminPassSet133()
        {
            Model model;
            model = new Model();
            model.currentVoter = (VoterDO)null;
            model.AdminPass = (string)null;
            this.AdminPassSet(model, (string)null);
            Assert.IsNotNull((object)model);
            Assert.IsNull((object)(model.currentVoter));
            Assert.AreEqual<string>("", model.SetupInfo.Ip);
            Assert.AreEqual<uint>(0u, model.SetupInfo.TableNo);
            Assert.AreEqual<string>((string)null, model.AdminPass);
        }
        [PexMethod]
        public string AdminPassGet([PexAssumeUnderTest]Model target)
        {
            string result = target.AdminPass;
            return result;
            // TODO: add assertions to method ModelTest.AdminPassGet(Model)
        }
        [TestMethod]
        public void AdminPassGet214()
        {
            Model model;
            string s;
            model = new Model();
            model.currentVoter = (VoterDO)null;
            model.AdminPass = (string)null;
            s = this.AdminPassGet(model);
            Assert.AreEqual<string>((string)null, s);
            Assert.IsNotNull((object)model);
            Assert.IsNull((object)(model.currentVoter));
            Assert.AreEqual<string>("", model.SetupInfo.Ip);
            Assert.AreEqual<uint>(0u, model.SetupInfo.TableNo);
            Assert.AreEqual<string>((string)null, model.AdminPass);
        }
    }
}
