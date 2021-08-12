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

        internal static string MscorlibVersion = "";
        internal static string MscorlibNuGetVersion = "";
        internal static string MathVersion = "";
        internal static string MathNuGetVersion = "";

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
        /// Create the root folder NanoFramework
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
            ILogger logger = NullLogger.Instance;
            var ct = CancellationToken.None;

            SourceCacheContext cache = new();
            SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
            FindPackageByIdResource resource = repository.GetResourceAsync<FindPackageByIdResource>(ct).Result;

            var outputDir = Path.Combine(rootDir, "UnitsNet.NanoFramework", "GeneratedCode");
            var outputQuantities = Path.Combine(outputDir, "Quantities");
            var outputUnits = Path.Combine(outputDir, "Units");
            var outputProperties = Path.Combine(outputDir, "Properties");
            // Ensure output directories exist

            Directory.CreateDirectory(outputQuantities);
            Directory.CreateDirectory(outputUnits);
            Directory.CreateDirectory(outputProperties);

            var lengthNuspecFile = Path.Combine(outputDir, "Length", "UnitsNet.NanoFramework.Length.nuspec");
            var projectVersion = ParseVersion(File.ReadAllText(lengthNuspecFile),
                new Regex(@"<version>(?<version>[\d\.]+)</version>", RegexOptions.IgnoreCase),
                "projectVersion");

            SetDependencyVersions(resource, cache, logger, ct, updateNanoFrameworkDependencies, outputDir);

            int numberQuantity = 0;
            foreach (var quantity in quantities)
            {
                var projectPath = Path.Combine(outputDir, quantity.Name);
                Directory.CreateDirectory(projectPath);

                GeneratePackageConfig(projectPath, quantity.Name);

                GenerateNuspec(
                    projectPath,
                    quantity,
                    MscorlibNuGetVersion,
                    MathNuGetVersion);

                GenerateUnitType(quantity, Path.Combine(outputUnits, $"{quantity.Name}Unit.g.cs"));
                GenerateQuantity(quantity, Path.Combine(outputQuantities, $"{quantity.Name}.g.cs"));
                GenerateProject(quantity, Path.Combine(projectPath, $"{quantity.Name}.nfproj"));

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

                Log.Information("✅ {Quantity} (nanoFramework)", quantity.Name);
                numberQuantity++;
            }
            Log.Information("");

            GenerateProperties(Path.Combine(outputProperties, "AssemblyInfo.cs"), projectVersion);
            GenerateSolution(quantities, outputDir);

            var unitCount = quantities.SelectMany(q => q.Units).Count();
            Log.Information("");
            Log.Information("Total of {UnitCount} units and {QuantityCount} quantities (nanoFramework)", unitCount, quantities.Length);
            Log.Information("");
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

                // get NuGet package Version for mscorlib
                // grab latest available (doesn't matter if it's preview or stable)
                NuGetVersion mscorlibVersion = packageVersions.OrderByDescending(v => v).First();
                MscorlibVersion = mscorlibVersion.Version.ToString();
                MscorlibNuGetVersion = mscorlibVersion.ToNormalizedString();

                // System.Math
                packageVersions = resource.GetAllVersionsAsync(
                    "nanoFramework.System.Math",
                    cache,
                    logger,
                    cancellationToken).Result;

                // grab latest available (doesn't matter if it's preview or stable)
                // making an assumption here that the available version is referencing the correct mscolib
                var mathVersion = packageVersions.OrderByDescending(v => v).First();
                MathVersion = mathVersion.Version.ToString();
                MathNuGetVersion = mathVersion.ToNormalizedString();

                logger.LogInformation($"Referencing nanoFramework.CoreLibrary {MscorlibNuGetVersion}");
                logger.LogInformation($"Referencing nanoFramework.System.Math {MathNuGetVersion}");
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
            File.WriteAllText(filePath, content);
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

            File.WriteAllText(filePath, content);
        }

        private static void GenerateProperties(string filePath, string version)
        {
            var content = new PropertyGenerator(version).Generate();
            File.WriteAllText(filePath, content);
            Log.Information("✅ AssemblyInfo.cs (nanoFramework)");
        }

        private static void GenerateUnitType(Quantity quantity, string filePath)
        {
            var content = new UnitTypeGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateQuantity(Quantity quantity, string filePath)
        {
            var content = new QuantityGenerator(quantity).Generate();
            // Replace any Math.PI by the real number 3.1415926535897931
            content = content.Replace("Math.PI", "3.1415926535897931");
            // Replace Math.Pow(0.3048, 4) by 0.0086309748412416
            content = content.Replace("Math.Pow(0.3048, 4)", "0.0086309748412416");
            // Replace Math.Pow(2.54e-2, 4) by 0.0000004162314256
            content = content.Replace("Math.Pow(2.54e-2, 4)", "0.0000004162314256");
            File.WriteAllText(filePath, content);
        }

        private static void GenerateProject(Quantity quantity, string filePath)
        {
            var content = new ProjectGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateSolution(Quantity[] quantities, string outputDir)
        {
            var content = new SolutionGenerator(quantities).Generate();
            var filePath = Path.Combine(outputDir, "UnitsNet.nanoFramework.sln");

            File.WriteAllText(filePath, content);
            Log.Information("✅ UnitsNet.nanoFramework.sln (nanoFramework)");
        }

        private static string GeneratePackageConfigFile(string quantityName)
        {
            MyTextWriter writer = new();

            writer.WL($@"
<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""nanoFramework.CoreLibrary"" version=""{MscorlibNuGetVersion}"" targetFramework=""netnanoframework10"" />");


            if (NanoFrameworkGenerator.ProjectsRequiringMath.Contains(quantityName))
            {
                writer.WL($@"
  <package id=""nanoFramework.System.Math"" version=""{MathNuGetVersion}"" targetFramework=""netnanoframework10"" />");
            }

            writer.WL($@"</packages>");

            return writer.ToString();
        }
    }
}
