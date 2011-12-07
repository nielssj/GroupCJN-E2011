// <copyright file="MunicipalityDOTest.cs">Copyright ©  2011</copyright>

using System;
using DBComm.DBComm.DO;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DBComm.DBComm.DO
{
    [TestClass]
    [PexClass(typeof(MunicipalityDO))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MunicipalityDOTest
    {
        [PexMethod]
        public void PollingStationsSet([PexAssumeUnderTest]MunicipalityDO target, ICollection<PollingStationDO> value)
        {
            target.PollingStations = value;
            // TODO: add assertions to method MunicipalityDOTest.PollingStationsSet(MunicipalityDO, ICollection`1<PollingStationDO>)
        }
        [PexMethod]
        public uint? PrimaryKeyGet([PexAssumeUnderTest]MunicipalityDO target)
        {
            uint? result = target.PrimaryKey;
            return result;
            // TODO: add assertions to method MunicipalityDOTest.PrimaryKeyGet(MunicipalityDO)
        }
        [PexMethod]
        public ICollection<PollingStationDO> PollingStationsGet([PexAssumeUnderTest]MunicipalityDO target)
        {
            ICollection<PollingStationDO> result = target.PollingStations;
            return result;
            // TODO: add assertions to method MunicipalityDOTest.PollingStationsGet(MunicipalityDO)
        }
        [PexMethod]
        public void UpdateValues([PexAssumeUnderTest]MunicipalityDO target, IDataObject dummy)
        {
            target.UpdateValues(dummy);
            // TODO: add assertions to method MunicipalityDOTest.UpdateValues(MunicipalityDO, IDataObject)
        }
        [PexMethod]
        public bool FullyInitialized([PexAssumeUnderTest]MunicipalityDO target)
        {
            bool result = target.FullyInitialized();
            return result;
            // TODO: add assertions to method MunicipalityDOTest.FullyInitialized(MunicipalityDO)
        }
        [PexMethod]
        public MunicipalityDO Constructor01()
        {
            MunicipalityDO target = new MunicipalityDO();
            return target;
            // TODO: add assertions to method MunicipalityDOTest.Constructor01()
        }
        [PexMethod]
        public MunicipalityDO Constructor(
            uint? id,
            string address,
            string name
        )
        {
            MunicipalityDO target = new MunicipalityDO(id, address, name);
            return target;
            // TODO: add assertions to method MunicipalityDOTest.Constructor(Nullable`1<UInt32>, String, String)
        }
    }
}
