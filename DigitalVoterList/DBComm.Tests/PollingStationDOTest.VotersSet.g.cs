// <copyright file="PollingStationDOTest.VotersSet.g.cs">Copyright �  2011</copyright>
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
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Framework.Moles;
using System.Collections.Generic.Moles;
using Microsoft.Pex.Framework;
using Microsoft.Moles.Framework;
using System.Data.Linq;
using Microsoft.Pex.Engine.Exceptions;

namespace DBComm.DBComm.DO
{
    public partial class PollingStationDOTest
    {
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void VotersSet556()
{
    PollingStationDO pollingStationDO;
    pollingStationDO = new PollingStationDO
                           (default(uint?), default(uint?), (string)null, (string)null);
    VoterDO[] voterDOs = new VoterDO[3];
    this.VotersSet(pollingStationDO, (ICollection<VoterDO>)voterDOs);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNull((object)(pollingStationDO.PrimaryKey));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>((string)null, pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void VotersSet900()
{
    PollingStationDO pollingStationDO;
    pollingStationDO = new PollingStationDO
                           (default(uint?), default(uint?), (string)null, (string)null);
    VoterDO[] voterDOs = new VoterDO[2];
    this.VotersSet(pollingStationDO, (ICollection<VoterDO>)voterDOs);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNull((object)(pollingStationDO.PrimaryKey));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>((string)null, pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
[Ignore]
[PexDescription("the test state was: duplicate path")]
public void VotersSetThrowsOverflowException319()
{
    using (PexChooseBehavedBehavior.Setup())
    {
      PollingStationDO pollingStationDO;
      SICollection01<VoterDO> sICollection01;
      pollingStationDO = new PollingStationDO
                             (default(uint?), default(uint?), (string)null, (string)null);
      sICollection01 = new SICollection01<VoterDO>();
      sICollection01.CopyToTArrayInt32 =
        PexChoose.CreateDelegate<MolesDelegates.Action<VoterDO[], int>>();
      IPexChoiceRecorder choices = PexChoose.Replay.Setup();
      choices.NextSegment(2).DefaultSession
          .At(0, 
                                            "sICollection01`1.System.Collections.Generic.ICollection`1<!0>.get_Count", 
                                            (object)int.MinValue);
      this.VotersSet(pollingStationDO, (ICollection<VoterDO>)sICollection01);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void VotersSet862()
{
    using (PexChooseBehavedBehavior.Setup())
    {
      PollingStationDO pollingStationDO;
      SICollection01<VoterDO> sICollection01;
      pollingStationDO = new PollingStationDO
                             (default(uint?), default(uint?), (string)null, (string)null);
      sICollection01 = new SICollection01<VoterDO>();
      sICollection01.CountGet = PexChoose.CreateDelegate<MolesDelegates.Func<int>>();
      this.VotersSet(pollingStationDO, (ICollection<VoterDO>)sICollection01);
      Assert.IsNotNull((object)pollingStationDO);
      Assert.IsNull((object)(pollingStationDO.PrimaryKey));
      Assert.IsNull((object)(pollingStationDO.MunicipalityId));
      Assert.AreEqual<string>((string)null, pollingStationDO.Name);
      Assert.AreEqual<string>((string)null, pollingStationDO.Address);
      Assert.IsNotNull(pollingStationDO.Voters);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void VotersSet798()
{
    PollingStationDO pollingStationDO;
    pollingStationDO = new PollingStationDO
                           (default(uint?), default(uint?), (string)null, (string)null);
    VoterDO[] voterDOs = new VoterDO[1];
    this.VotersSet(pollingStationDO, (ICollection<VoterDO>)voterDOs);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNull((object)(pollingStationDO.PrimaryKey));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>((string)null, pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void VotersSet623()
{
    PollingStationDO pollingStationDO;
    pollingStationDO = new PollingStationDO
                           (default(uint?), default(uint?), (string)null, (string)null);
    VoterDO[] voterDOs = new VoterDO[0];
    this.VotersSet(pollingStationDO, (ICollection<VoterDO>)voterDOs);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNull((object)(pollingStationDO.PrimaryKey));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>((string)null, pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void VotersSet820()
{
    PollingStationDO pollingStationDO;
    pollingStationDO = new PollingStationDO
                           (default(uint?), default(uint?), (string)null, (string)null);
    EntitySet<VoterDO> entitySet = new EntitySet<VoterDO>();
    this.VotersSet(pollingStationDO, (ICollection<VoterDO>)entitySet);
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
public void VotersSetThrowsContractException949()
{
    try
    {
      PollingStationDO pollingStationDO;
      pollingStationDO = new PollingStationDO
                             (default(uint?), default(uint?), (string)null, (string)null);
      this.VotersSet(pollingStationDO, (ICollection<VoterDO>)null);
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