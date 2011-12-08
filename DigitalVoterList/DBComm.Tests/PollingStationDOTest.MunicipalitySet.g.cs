// <copyright file="PollingStationDOTest.MunicipalitySet.g.cs">Copyright �  2011</copyright>
// <auto-generated>
// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
// </auto-generated>
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using DBComm.DBComm.DO.Moles;
using Microsoft.Pex.Engine.Exceptions;

namespace DBComm.DBComm.DO
{
    public partial class PollingStationDOTest
    {
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void MunicipalitySet738()
{
    PollingStationDO pollingStationDO;
    MunicipalityDO municipalityDO;
    pollingStationDO = new PollingStationDO
                           (default(uint?), default(uint?), (string)null, (string)null);
    municipalityDO =
      new MunicipalityDO(default(uint?), (string)null, (string)null, (string)null);
    this.MunicipalitySet(pollingStationDO, municipalityDO);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNull((object)(pollingStationDO.PrimaryKey));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>((string)null, pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void MunicipalitySet317()
{
    PollingStationDO pollingStationDO;
    SMunicipalityDO sMunicipalityDO;
    pollingStationDO = new PollingStationDO
                           (default(uint?), default(uint?), (string)null, (string)null);
    sMunicipalityDO = new SMunicipalityDO();
    this.MunicipalitySet(pollingStationDO, (MunicipalityDO)sMunicipalityDO);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNull((object)(pollingStationDO.PrimaryKey));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>((string)null, pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void MunicipalitySetThrowsContractException673()
{
    try
    {
      PollingStationDO pollingStationDO;
      pollingStationDO = new PollingStationDO
                             (default(uint?), default(uint?), (string)null, (string)null);
      this.MunicipalitySet(pollingStationDO, (MunicipalityDO)null);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
    }
}