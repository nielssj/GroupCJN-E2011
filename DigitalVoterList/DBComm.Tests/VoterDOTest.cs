// <copyright file="VoterDOTest.cs">Copyright ©  2011</copyright>

using System;
using DBComm.DBComm.DO;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBComm.DBComm.DO
{
    [TestClass]
    [PexClass(typeof(VoterDO))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class VoterDOTest
    {
        [PexMethod]
        public void PollingStationSet([PexAssumeUnderTest]VoterDO target, PollingStationDO value)
        {
            target.PollingStation = value;
            // TODO: add assertions to method VoterDOTest.PollingStationSet(VoterDO, PollingStationDO)
        }
        [PexMethod]
        public void CprSet([PexAssumeUnderTest]VoterDO target, uint? value)
        {
            target.Cpr = value;
            // TODO: add assertions to method VoterDOTest.CprSet(VoterDO, Nullable`1<UInt32>)
        }
        [PexMethod]
        public PollingStationDO PollingStationGet([PexAssumeUnderTest]VoterDO target)
        {
            PollingStationDO result = target.PollingStation;
            return result;
            // TODO: add assertions to method VoterDOTest.PollingStationGet(VoterDO)
        }
        [PexMethod]
        public string CprStringGet([PexAssumeUnderTest]VoterDO target)
        {
            string result = target.CprString;
            return result;
            // TODO: add assertions to method VoterDOTest.CprStringGet(VoterDO)
        }
        [PexMethod]
        public uint? CprGet([PexAssumeUnderTest]VoterDO target)
        {
            uint? result = target.Cpr;
            return result;
            // TODO: add assertions to method VoterDOTest.CprGet(VoterDO)
        }
        [PexMethod]
        public void UpdateValues([PexAssumeUnderTest]VoterDO target, IDataObject dummy)
        {
            target.UpdateValues(dummy);
            // TODO: add assertions to method VoterDOTest.UpdateValues(VoterDO, IDataObject)
        }
        [PexMethod]
        public bool FullyInitialized([PexAssumeUnderTest]VoterDO target)
        {
            bool result = target.FullyInitialized();
            return result;
            // TODO: add assertions to method VoterDOTest.FullyInitialized(VoterDO)
        }
        [PexMethod]
        public VoterDO Constructor01()
        {
            VoterDO target = new VoterDO();
            return target;
            // TODO: add assertions to method VoterDOTest.Constructor01()
        }
        [PexMethod]
        public VoterDO Constructor(
            uint pollingStationId,
            uint cpr,
            string name,
            string address,
            string city,
            bool cardPrinted,
            bool voted
        )
        {
            VoterDO target = new VoterDO(pollingStationId, cpr, name, address, city, cardPrinted, voted);
            return target;
            // TODO: add assertions to method VoterDOTest.Constructor(UInt32, UInt32, String, String, String, Boolean, Boolean)
        }
    }
}
