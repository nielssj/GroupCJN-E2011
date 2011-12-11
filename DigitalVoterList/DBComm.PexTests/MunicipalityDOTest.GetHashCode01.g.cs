// <copyright file="MunicipalityDOTest.GetHashCode01.g.cs">Copyright �  2011</copyright>
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

namespace DBComm.DBComm.DO
{
    public partial class MunicipalityDOTest
    {
[TestMethod]
[PexGeneratedBy(typeof(MunicipalityDOTest))]
public void GetHashCode01420()
{
    MunicipalityDO municipalityDO;
    int i;
    municipalityDO =
      new MunicipalityDO(default(uint?), (string)null, (string)null, "");
    i = this.GetHashCode01(municipalityDO);
    Assert.AreEqual<int>(757602046, i);
    Assert.IsNotNull((object)municipalityDO);
    Assert.IsNotNull(municipalityDO.PollingStations);
    Assert.IsNull((object)(municipalityDO.Id));
    Assert.AreEqual<string>((string)null, municipalityDO.Address);
    Assert.AreEqual<string>((string)null, municipalityDO.City);
    Assert.AreEqual<string>("", municipalityDO.Name);
}
[TestMethod]
[PexGeneratedBy(typeof(MunicipalityDOTest))]
public void GetHashCode01402()
{
    MunicipalityDO municipalityDO;
    int i;
    municipalityDO =
      new MunicipalityDO(default(uint?), (string)null, (string)null, (string)null);
    i = this.GetHashCode01(municipalityDO);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)municipalityDO);
    Assert.IsNotNull(municipalityDO.PollingStations);
    Assert.IsNull((object)(municipalityDO.Id));
    Assert.AreEqual<string>((string)null, municipalityDO.Address);
    Assert.AreEqual<string>((string)null, municipalityDO.City);
    Assert.AreEqual<string>((string)null, municipalityDO.Name);
}
    }
}
