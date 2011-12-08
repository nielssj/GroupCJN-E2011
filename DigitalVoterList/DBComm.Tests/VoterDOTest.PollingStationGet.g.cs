// <copyright file="VoterDOTest.PollingStationGet.g.cs">Copyright �  2011</copyright>
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
using Microsoft.Pex.Framework.Explorable;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace DBComm.DBComm.DO
{
    public partial class VoterDOTest
    {
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void PollingStationGet796()
{
    VoterDO voterDO;
    PollingStationDO pollingStationDO;
    voterDO = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO, "<PrimaryKey>k__BackingField", default(uint?));
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
    pollingStationDO = this.PollingStationGet(voterDO);
    Assert.IsNull((object)pollingStationDO);
    Assert.IsNotNull((object)voterDO);
    Assert.IsNull((object)(voterDO.PrimaryKey));
    Assert.IsNull((object)(voterDO.PollingStationId));
    Assert.AreEqual<string>((string)null, voterDO.Name);
    Assert.AreEqual<string>((string)null, voterDO.Address);
    Assert.AreEqual<string>((string)null, voterDO.City);
    Assert.IsNotNull((object)(voterDO.CardPrinted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.CardPrinted)));
    Assert.IsNotNull((object)(voterDO.Voted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.Voted)));
}
    }
}
