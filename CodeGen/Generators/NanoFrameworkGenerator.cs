using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CodeGen.Generators.NanoFrameworkGen;
using CodeGen.JsonTypes;
using Serilog;
using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System.Threading;
using CodeGen.Helpers;
using System.Linq;
using System.Text.RegularExpressions;
using ILogger = NuGet.Common.ILogger;

namespace CodeGen.Generators
{
    /// <summary>
    /// Code generator for nanoFramework
    /// Will generate 1 nanoFramework project per unit, a common property folder and a common package file
    /// </summary>
    internal static class NanoFrameworkGenerator
    {
        private const int AlignPad = 35;

        static internal string MscorlibVersion = "";
        static internal string MscorlibNuGetVersion = "";
        static internal string MathVersion = "";
        static internal string MathNuGetVersion = "";

        /// <summary>
        /// These projects require inclusion of Math NuGet package.
        /// </summary>
        internal static readonly List<string> ProjectsRequiringMath = new()
        {
            "Angle",
            "Frequency",
            "Pressure",
            "Turbidity",
            "WarpingMomentOfInertia"
        };

        /// <summary>
        /// Create the root folder NanoFramewok
        /// Create all the quantities unit and quantities file
        /// Create all individual nanoFramework projects
        /// Create common package file
        /// Create common properties file
        /// </summary>
        /// <param name="rootDir">The root directory</param>
        /// <param name="quantities">The quantities to create</param>
        /// <param name="updateNanoFrameworkDependencies">Update nanoFramework nuget dependencies?</param>
        public static void Generate(string rootDir, Quantity[] quantities, bool updateNanoFrameworkDependencies)
        {
            // get latest version of .NET nanoFramework mscorlib
            NuGet.Common.ILogger logger = NullLogger.Instance;
            CancellationToken cancellationToken = CancellationToken.None;

            SourceCacheContext cache = new SourceCacheContext();
            SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
            FindPackageByIdResource resource = repository.GetResourceAsync<FindPackageByIdResource>().Result;

            var outputDir = Path.Combine(rootDir, "UnitsNet.NanoFramework", "GeneratedCode");
            var outputQuantitites = Path.Combine(outputDir, "Quantities");
            var outputUnits = Path.Combine(outputDir, "Units");
            var outputProperties = Path.Combine(outputDir, "Properties");
            // Ensure output directories exist

            Directory.CreateDirectory(outputQuantitites);
            Directory.CreateDirectory(outputUnits);
            Directory.CreateDirectory(outputProperties);

            Log.Information($"Directory NanoFramework creation(OK)");

            SetDependencyVersions(resource, cache, logger, cancellationToken, updateNanoFrameworkDependencies, outputDir);
            GenerateProperties(Path.Combine(outputProperties, "AssemblyInfo.cs"));
            Log.Information($"Property(OK)");

            int numberQuantity = 0;
            foreach (var quantity in quantities)
            {
                Log.Information($"Creating .NET nanoFramework project for {quantity.Name}");

                var projectPath = Path.Combine(outputDir, quantity.Name);
                Directory.CreateDirectory(projectPath);
                var sb = new StringBuilder($"{quantity.Name}:".PadRight(AlignPad));

                GeneratePackageConfig(projectPath, quantity.Name);

                GenerateNuspec(
                    projectPath,
                    quantity,
                    MscorlibNuGetVersion,
                    MathNuGetVersion);

                GenerateUnitType(sb, quantity, Path.Combine(outputUnits, $"{quantity.Name}Unit.g.cs"));
                GenerateQuantity(sb, quantity, Path.Combine(outputQuantitites, $"{quantity.Name}.g.cs"));
                GenerateProject(sb, quantity, Path.Combine(projectPath, $"{quantity.Name}.nfproj"));

                // Convert decimal based units to floats; decimals are not supported by nanoFramework
                if (quantity.BaseType == "decimal")
                {
                    var replacements = new Dictionary<string, string>
                    {
                        //{ "(\\)sdecimal(\\s)", "$1float$2" }
                        { "(\\d)m", "$1d" },
                        { "(\\d)M", "$1d" },
                        { " decimal ", " double " },
                        { "(decimal ", "(double " }
                    };
                    new FileInfo($"{outputDir}\\Units\\{quantity.Name}Unit.g.cs").EditFile(replacements);
                    new FileInfo($"{outputDir}\\Quantities\\{quantity.Name}.g.cs").EditFile(replacements);
                }

                numberQuantity++;
            }

            GenerateSolution(quantities, outputDir);
            Log.Information("UnitsNet.nanoFramework.sln generated");
            Log.Information($"Count of generated projects: {numberQuantity}");
        }

        private static void SetDependencyVersions(FindPackageByIdResource resource, SourceCacheContext cache, ILogger logger,
            CancellationToken cancellationToken, bool updateNanoFrameworkDependencies, string outputDir)
        {
            if (updateNanoFrameworkDependencies)
            {
                logger.LogInformation("Updating nanoFramework dependencies.");

                // mscorlib
                IEnumerable<NuGetVersion> packageVersions = resource.GetAllVersionsAsync(
                    "nanoFramework.CoreLibrary",
                    cache,
                    logger,
                    cancellationToken).Result;

                // NuGet package Version
                // including preview
                var mscorlibPackage = packageVersions.Where(v => v.IsPrerelease).OrderByDescending(v => v).First();
                // stable only
                //var mscorlibPackage = packageVersions.OrderByDescending(v => v).First();

                MscorlibVersion = mscorlibPackage.Version.ToString();
                MscorlibNuGetVersion = mscorlibPackage.ToNormalizedString();

                // Math
                packageVersions = resource.GetAllVersionsAsync(
                    "nanoFramework.System.Math",
                    cache,
                    logger,
                    cancellationToken).Result;

                // NuGet package Version
                // including preview
                var mathPackage = packageVersions.Where(v => v.IsPrerelease).OrderByDescending(v => v).First();
                // stable only
                //var mathPackage = MathNuGetVersion = packageVersions.OrderByDescending(v => v).First();

                MathVersion = mathPackage.Version.ToString();
                MathNuGetVersion = mathPackage.ToNormalizedString();
            }
            else
            {
                // Angle has both mscorlib and System.Math dependency.
                var anyProjectFile = Path.Combine(outputDir, "Angle", "Angle.nfproj");
                var projectFileContent = File.ReadAllText(anyProjectFile);

                // <Reference Include="mscorlib, Version=1.10.5.0, Culture=neutral, PublicKeyToken=c07d481e9758c731">
                MscorlibVersion = ParseVersion(projectFileContent,
                    new Regex(@"<Reference Include=""mscorlib,\s*Version=(?<version>[\d\.]+),.*"">", RegexOptions.IgnoreCase),
                    nameof(MscorlibVersion));

                // <HintPath>..\packages\nanoFramework.CoreLibrary.1.10.5-preview.18\lib\mscorlib.dll</HintPath>
                MscorlibNuGetVersion = ParseVersion(projectFileContent,
                    new Regex(@"<HintPath>.*[\\\/]nanoFramework\.CoreLibrary\.(?<version>.*?)[\\\/]lib[\\\/]mscorlib.dll<", RegexOptions.IgnoreCase),
                    nameof(MscorlibNuGetVersion));

                // <Reference Include="System.Math, Version=1.4.1.0, Culture=neutral, PublicKeyToken=c07d481e9758c731">
                MathVersion = ParseVersion(projectFileContent,
                    new Regex(@"<Reference Include=""System.Math,\s*Version=(?<version>[\d\.]+),.*"">", RegexOptions.IgnoreCase),
                    nameof(MathVersion));

                //   <HintPath>..\packages\nanoFramework.System.Math.1.4.1-preview.7\lib\System.Math.dll</HintPath>
                MathNuGetVersion = ParseVersion(projectFileContent,
                    new Regex(@"<HintPath>.*[\\\/]nanoFramework\.System\.Math\.(?<version>.*?)[\\\/]lib[\\\/]System.Math.dll<", RegexOptions.IgnoreCase),
                    nameof(MathNuGetVersion));
            }
        }

        private static string ParseVersion(string projectFileContent, Regex versionRegex, string descriptiveName)
        {
            var match = versionRegex.Match(projectFileContent);
            if (!match.Success) throw new InvalidOperationException($"Unable to parse version {descriptiveName} from project file.");

            return match.Groups["version"].Value;
        }

        private static void GeneratePackageConfig(string projectPath, string quantityName)
        {
            string filePath = Path.Combine(projectPath, "packages.config");

            var content = GeneratePackageConfigFile(quantityName);
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }
        private static void GenerateNuspec(
            string projectPath,
            Quantity quantity,
            string mscorlibNuGetVersion,
            string mathNuGetVersion)
        {
            string filePath = Path.Combine(projectPath, $"UnitsNet.NanoFramework.{quantity.Name}.nuspec");

            var content = new NuspecGenerator(
                quantity,
                mscorlibNuGetVersion,
                mathNuGetVersion).Generate();

            File.WriteAllText(filePath, content, Encoding.UTF8);
        }

        private static void GenerateProperties(string filePath)
        {
            var content = new PropertyGenerator().Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }

        private static void GenerateUnitType(StringBuilder sb, Quantity quantity, string filePath)
        {
            var content = new UnitTypeGenerator(quantity).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("unit(OK) ");
        }

        private static void GenerateQuantity(StringBuilder sb, Quantity quantity, string filePath)
        {
            var content = new QuantityGenerator(quantity).Generate();
            // Replace any Math.PI by the real number 3.1415926535897931
            content = content.Replace("Math.PI", "3.1415926535897931");
            // Replace Math.Pow(0.3048, 4) by 0.0086309748412416
            content = content.Replace("Math.Pow(0.3048, 4)", "0.0086309748412416");
            // Replace Math.Pow(2.54e-2, 4) by 0.0000004162314256
            content = content.Replace("Math.Pow(2.54e-2, 4)", "0.0000004162314256");
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("quantity(OK) ");
        }

        private static void GenerateProject(StringBuilder sb, Quantity quantity, string filePath)
        {
            var content = new ProjectGenerator(quantity).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("project(OK) ");
        }

        private static void GenerateSolution(Quantity[] quantities, string outputDir)
        {
            var content = new SolutionGenerator(quantities).Generate();

            var filePath = Path.Combine(outputDir, "UnitsNet.nanoFramework.sln");

            File.WriteAllText(filePath, content, Encoding.UTF8);
        }

        private static string GeneratePackageConfigFile(string quantityName)
        {
            MyTextWriter Writer = new MyTextWriter();

            Writer.WL($@"
<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""nanoFramework.CoreLibrary"" version=""{MscorlibNuGetVersion}"" targetFramework=""netnanoframework10"" />");


            if (NanoFrameworkGenerator.ProjectsRequiringMath.Contains(quantityName))
            {
                Writer.WL($@"
  <package id=""nanoFramework.System.Math"" version=""{MathNuGetVersion}"" targetFramework=""netnanoframework10"" />");
            }

            Writer.WL($@"</packages>");

            return Writer.ToString();
        }
    }
}
