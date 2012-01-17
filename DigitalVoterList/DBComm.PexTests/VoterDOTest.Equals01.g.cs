// <copyright file="VoterDOTest.Equals01.g.cs">Copyright �  2011</copyright>
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

namespace DBComm.PexTests
{
    using Microsoft.Pex.Framework.Explorable;

    using System.Data.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Pex.Framework.Generated;

    using global::DBComm.DBComm.DO;

    public partial class VoterDOTest
    {
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void Equals01352()
{
    VoterDO voterDO;
    bool b;
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
    object s0 = new object();
    b = this.Equals01(voterDO, s0);
    Assert.AreEqual<bool>(false, b);
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
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void Equals01356()
{
    VoterDO voterDO;
    bool b;
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
    b = this.Equals01(voterDO, (object)null);
    Assert.AreEqual<bool>(false, b);
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
