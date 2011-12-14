// <copyright file="ModelTest.UnregisterCurrentVoter.g.cs">Copyright �  2011</copyright>
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

namespace DigitalVoterList.PexTests
{
    using System;

    using DBComm.DBComm.DO;

    using Microsoft.Pex.Framework.Explorable;

    using System.Data.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Pex.Framework.Generated;
    using Microsoft.Pex.Engine.Exceptions;

    using global::PollingTable.PollingTable;

    public partial class ModelTest
    {
[TestMethod]
[PexGeneratedBy(typeof(ModelTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void UnregisterCurrentVoterThrowsContractException834()
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
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
    }
}
