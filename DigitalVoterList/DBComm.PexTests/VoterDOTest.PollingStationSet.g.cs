// <copyright file="VoterDOTest.PollingStationSet.g.cs">Copyright �  2011</copyright>
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
using DBComm.DBComm.DO.Moles;
using Microsoft.Pex.Framework.Explorable;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Engine.Exceptions;

namespace DBComm.DBComm.DO
{
    public partial class VoterDOTest
    {
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void PollingStationSet854()
{
    VoterDO voterDO;
    SPollingStationDO sPollingStationDO;
    voterDO = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO, "<PollingStationId>k__BackingField", new uint?(1u));
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
    sPollingStationDO = new SPollingStationDO();
    this.PollingStationSet(voterDO, (PollingStationDO)sPollingStationDO);
    Assert.IsNotNull((object)voterDO);
    Assert.IsNull((object)(voterDO.PrimaryKey));
    Assert.IsNotNull((object)(voterDO.PollingStationId));
    Assert.AreEqual<uint>(1u, (uint)((object)(voterDO.PollingStationId)));
    Assert.AreEqual<string>((string)null, voterDO.Name);
    Assert.AreEqual<string>((string)null, voterDO.Address);
    Assert.AreEqual<string>((string)null, voterDO.City);
    Assert.IsNotNull((object)(voterDO.CardPrinted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.CardPrinted)));
    Assert.IsNotNull((object)(voterDO.Voted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.Voted)));
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PollingStationSetThrowsContractException528()
{
    try
    {
      VoterDO voterDO;
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
      this.PollingStationSet(voterDO, (PollingStationDO)null);
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
