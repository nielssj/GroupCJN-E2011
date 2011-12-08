// <copyright file="PexAssemblyInfo.cs">Copyright ©  2011</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Moles;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;
using Microsoft.Pex.Linq;
using System;
using System.Globalization;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("DBComm")]
[assembly: PexInstrumentAssembly("MySql.Data")]
[assembly: PexInstrumentAssembly("System.Data")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("System.Data.Linq")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "MySql.Data")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Data")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Data.Linq")]

// Microsoft.Pex.Framework.Moles
[assembly: PexAssumeContractEnsuresFailureAtBehavedSurface]
[assembly: PexChooseAsBehavedCurrentBehavior]

// Microsoft.Pex.Linq
[assembly: PexLinqPackage]

[assembly: PexInstrumentType(typeof(Random))]
[assembly: PexInstrumentType("mscorlib", "System.Text.InternalEncoderBestFitFallback")]
[assembly: PexInstrumentType("mscorlib", "System.Text.InternalDecoderBestFitFallback")]
[assembly: PexInstrumentType(typeof(TimeZoneInfo))]
[assembly: PexInstrumentAssembly("System.Transactions")]
[assembly: PexInstrumentType(typeof(DaylightTime))]
[assembly: PexInstrumentType(typeof(TextInfo))]
[assembly: PexInstrumentAssembly("System.Transactions")]
[assembly: PexInstrumentType(typeof(TextInfo))]
[assembly: PexInstrumentAssembly("System.Transactions")]
[assembly: PexInstrumentAssembly("System.Transactions")]
[assembly: PexInstrumentType(typeof(TextInfo))]
