using System;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.NanoFrameworkGen
{
    class NuspecGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;
        private readonly string _mscorlibNuGetVersion;
        private readonly string _mathNuGetVersion;

        public NuspecGenerator(
            Quantity quantity,
            string mscorlibNuGetVersion,
            string mathNuGetVersion)
        {
            _quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
            _mscorlibNuGetVersion = mscorlibNuGetVersion;
            _mathNuGetVersion = mathNuGetVersion;
        }

        public string Generate()
        {
            Writer.WL($@"<?xml version=""1.0"" encoding=""utf-8""?>
<package xmlns=""http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd"">
  <metadata>
    <id>UnitsNet.nanoFramework.{_quantity.Name}</id>
    <version>6.0.0-pre019</version>
    <title>Units.NET {_quantity.Name} - nanoFramework</title>
    <authors>Andreas Gullberg Larsen,nanoframework</authors>
    <owners>UnitsNet</owners>
    <license type=""expression"">MIT-0</license>
    <projectUrl>https://github.com/angularsen/UnitsNet</projectUrl>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <description>Adds {_quantity.Name} units for Units.NET on .NET nanoFramework. For .NET or .NET Core, use UnitsNet instead.</description>
    <iconUrl>https://raw.githubusercontent.com/angularsen/UnitsNet/ce85185429be345d77eb2ce09c99d59cc9ab8aed/Docs/Images/logo-32.png</iconUrl>
    <releaseNotes>
    </releaseNotes>
    <copyright>Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).</copyright>
    <language>en-US</language>
    <tags>nanoframework {_quantity.Name.ToLower()} unit units quantity quantities measurement si metric imperial abbreviation abbreviations convert conversion parse immutable</tags>
    <dependencies>
      <dependency id=""nanoFramework.CoreLibrary"" version=""{_mscorlibNuGetVersion}"" />");

    if (NanoFrameworkGenerator.ProjectsRequiringMath.Contains(_quantity.Name))
    {
                Writer.WL($@"
      <dependency id=""nanoFramework.System.Math"" version=""{_mathNuGetVersion}"" />");
    }

            Writer.WL($@"
    </dependencies>
  </metadata>
  <files>
    <file src=""..\..\..\Artifacts\UnitsNet.NanoFramework\{_quantity.Name}\UnitsNet.*"" target=""lib"" />
  </files>
</package>");

            return Writer.ToString();
        }
    }
}
