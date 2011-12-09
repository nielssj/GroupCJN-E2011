// <copyright file="PollingStationDOTest.cs">Copyright ©  2011</copyright>

using System;
using DBComm.DBComm.DO;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DBComm.DBComm.DO
{
    [TestClass]
    [PexClass(typeof(PollingStationDO))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PollingStationDOTest
    {
        [PexMethod]
        public void VotersSet([PexAssumeUnderTest]PollingStationDO target, ICollection<VoterDO> value)
        {
            target.Voters = value;
            // TODO: add assertions to method PollingStationDOTest.VotersSet(PollingStationDO, ICollection`1<VoterDO>)
        }
        [PexMethod]
        public ICollection<VoterDO> VotersGet([PexAssumeUnderTest]PollingStationDO target)
        {
            ICollection<VoterDO> result = target.Voters;
            return result;
            // TODO: add assertions to method PollingStationDOTest.VotersGet(PollingStationDO)
        }
        [PexMethod]
        public void UpdateValues([PexAssumeUnderTest]PollingStationDO target, IDataObject dummy)
        {
            target.UpdateValues(dummy);
            // TODO: add assertions to method PollingStationDOTest.UpdateValues(PollingStationDO, IDataObject)
        }
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]PollingStationDO target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method PollingStationDOTest.ToString01(PollingStationDO)
        }
        [PexMethod]
        public void MunicipalitySet([PexAssumeUnderTest]PollingStationDO target, MunicipalityDO value)
        {
            target.Municipality = value;
            // TODO: add assertions to method PollingStationDOTest.MunicipalitySet(PollingStationDO, MunicipalityDO)
        }
        [PexMethod]
        public MunicipalityDO MunicipalityGet([PexAssumeUnderTest]PollingStationDO target)
        {
            MunicipalityDO result = target.Municipality;
            return result;
            // TODO: add assertions to method PollingStationDOTest.MunicipalityGet(PollingStationDO)
        }
        [PexMethod]
        public int GetHashCode01([PexAssumeUnderTest]PollingStationDO target)
        {
            int result = target.GetHashCode();
            return result;
            // TODO: add assertions to method PollingStationDOTest.GetHashCode01(PollingStationDO)
        }
        [PexMethod]
        public bool FullyInitialized([PexAssumeUnderTest]PollingStationDO target)
        {
            bool result = target.FullyInitialized();
            return result;
            // TODO: add assertions to method PollingStationDOTest.FullyInitialized(PollingStationDO)
        }
        [PexMethod]
        public bool Equals01([PexAssumeUnderTest]PollingStationDO target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method PollingStationDOTest.Equals01(PollingStationDO, Object)
        }
        [PexMethod]
        public PollingStationDO Constructor01()
        {
            PollingStationDO target = new PollingStationDO();
            return target;
            // TODO: add assertions to method PollingStationDOTest.Constructor01()
        }
        [PexMethod]
        public PollingStationDO Constructor(
            uint? municipalityId,
            uint? id,
            string name,
            string address
        )
        {
            PollingStationDO target = new PollingStationDO(municipalityId, id, name, address);
            return target;
            // TODO: add assertions to method PollingStationDOTest.Constructor(Nullable`1<UInt32>, Nullable`1<UInt32>, String, String)
        }
    }
}
