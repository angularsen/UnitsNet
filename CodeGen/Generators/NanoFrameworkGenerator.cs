using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CodeGen.Generators.NanoFrameworkGen;
using CodeGen.Helpers;
using CodeGen.JsonTypes;
using NuGet.Common;
using Serilog;
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

        internal static string MscorlibVersion = "1.10.5.0";
        internal static string MscorlibNuGetVersion = "1.10.5-preview.18";
        internal static string MathVersion = "1.4.1.0";
        internal static string MathNuGetVersion = "1.4.1-preview.7";

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
        public static void Generate(string rootDir, Quantity[] quantities)
        {
            // get latest version of .NET nanoFramework mscorlib
            ILogger logger = NullLogger.Instance;

            logger.LogInformation($"Referencing nanoFramework.CoreLibrary {MscorlibNuGetVersion}");
            logger.LogInformation($"Referencing nanoFramework.System.Math {MathNuGetVersion}");

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

            int numberQuantity = 0;
            foreach (var quantity in quantities)
            {
                var projectPath = Path.Combine(outputDir, quantity.Name);
                Directory.CreateDirectory(projectPath);

                GeneratePackageConfig(
                    projectPath,
                    quantity.Name,
                    MscorlibNuGetVersion,
                    MathNuGetVersion);

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

        /// <summary>
        /// Updates existing nanoFramework projects and nuspecs with the latest versions.
        /// </summary>
        /// <param name="rootDir">The root directory</param>
        /// <param name="quantities">The quantities to update nuspecs</param>
        public static void UpdateNanoFrameworkDependencies(
            string rootDir,
            Quantity[] quantities)
        {
            // working path
            string path = Path.Combine(rootDir, "UnitsNet.NanoFramework\\GeneratedCode");

            Log.Information("");
            Log.Information("Updating .NET nanoFramework references using nuget CLI");

            // run nuget CLI
            var nugetCLI = new System.Diagnostics.Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "Tools/nuget.exe",
                    Arguments = $"update {path}\\UnitsNet.nanoFramework.sln -PreRelease",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            nugetCLI.Start();

            // start nuget CLI and wait for exit
            if (!nugetCLI.Start())
            {
                Log.Information("");
                Log.Information("Failed to start nuget CLI to update .NET nanoFramework projects");
                Log.Information("");
            }
            else
            {
                // wait for exit, within 2 minutes
                if (!nugetCLI.WaitForExit((int)TimeSpan.FromMinutes(2).TotalMilliseconds))
                {
                    Log.Information("");
                    Log.Information("Failed to complete execution of nuget CLI to update .NET nanoFramework projects");
                    Log.Information("");
                }
                else
                {
                    if (nugetCLI.ExitCode == 0)
                    {
                        Log.Information("Done!");
                        Log.Information("");

                        Log.Information("Updating .NET nanoFramework nuspec files");
                        Log.Information("");

                        int numberQuantity = 0;

                        foreach (var quantity in quantities)
                        {
                            var projectPath = Path.Combine(path, quantity.Name);

                            // read packages.config content
                            var packagesConfig = Path.Combine(projectPath, "packages.config");

                            var mscorlibVersion = ParseVersion(File.ReadAllText(packagesConfig),
                                new Regex("CoreLibrary\\\" version=\\\"(?<version>.+)\\\" targetFramework", RegexOptions.IgnoreCase),
                                "projectVersion");

                            // don't throw on failure because not all packages have System.Math
                            var mathVersion = ParseVersion(File.ReadAllText(packagesConfig),
                                new Regex("Math\\\" version=\\\"(?<version>.+)\\\" targetFramework", RegexOptions.IgnoreCase),
                                "projectVersion",
                                false);

                            // update nuspec
                            GenerateNuspec(
                                projectPath,
                                quantity,
                                mscorlibVersion,
                                mathVersion);

                            Log.Information("✅ {Quantity} (nanoFramework)", quantity.Name);
                            numberQuantity++;
                        }
                    }
                    else
                    {
                        Log.Information("");
                        Log.Information($"nuget CLI executed with {nugetCLI.ExitCode} exit code");
                    }
                }
            }

            Log.Information("");
        }

        /// <summary>
        /// Update NanoFrameworkGenerator source file with new assembly and NuGet packages versions.
        /// </summary>
        /// <param name="rootDir">The repository root directory.</param>
        public static void UpdateNanoFrameworkGenerator(string rootDir)
        {
            // Angle has both mscorlib and System.Math dependency
            string generatedCodePath = Path.Combine(rootDir, "UnitsNet.NanoFramework\\GeneratedCode");
            var angleProjectFile = Path.Combine(generatedCodePath, "Angle", "Angle.nfproj");
            var projectFileContent = File.ReadAllText(angleProjectFile);

            // save current versions
            string prevMscorlibVersion = MscorlibVersion;
            string prevMscorlibNuGetVersion = MscorlibNuGetVersion;
            string prevMathVersion = MathVersion;
            string prevMathNuGetVersion = MathNuGetVersion;

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

            // re-write NanoFrameworkGenerator.cs
            var nanoFrameworkGeneratorFilePath = Path.Combine(rootDir, "CodeGen", "Generators", "NanoFrameworkGenerator.cs");

            var nanoFrameworkGeneratorFileContent = File.ReadAllText(nanoFrameworkGeneratorFilePath);

            // replace content of version static properties
            nanoFrameworkGeneratorFileContent = nanoFrameworkGeneratorFileContent.Replace($"MscorlibVersion = \"{prevMscorlibVersion}\";", $"MscorlibVersion = \"{MscorlibVersion}\";");
            nanoFrameworkGeneratorFileContent = nanoFrameworkGeneratorFileContent.Replace($"MscorlibNuGetVersion = \"{prevMscorlibNuGetVersion}\";", $"MscorlibNuGetVersion = \"{MscorlibNuGetVersion}\";");
            nanoFrameworkGeneratorFileContent = nanoFrameworkGeneratorFileContent.Replace($"MathVersion = \"{prevMathVersion}\";", $"MathVersion = \"{MathVersion}\";");
            nanoFrameworkGeneratorFileContent = nanoFrameworkGeneratorFileContent.Replace($"MathNuGetVersion = \"{prevMathNuGetVersion}\";", $"MathNuGetVersion = \"{MathNuGetVersion}\";");

            // save updated NanoFrameworkGenerator.cs
            File.WriteAllText(nanoFrameworkGeneratorFilePath, nanoFrameworkGeneratorFileContent);
        }

        private static string ParseVersion(
            string projectFileContent,
            Regex versionRegex,
            string descriptiveName,
            bool throwOnFailure = true)
        {
            var match = versionRegex.Match(projectFileContent);

            if (!match.Success && throwOnFailure)
            {
                throw new InvalidOperationException($"Unable to parse version {descriptiveName} from project file.");
            }

            return match.Groups["version"].Value;
        }

        private static void GeneratePackageConfig(
            string projectPath,
            string quantityName,
            string mscorlibNuGetVersion,
            string mathNuGetVersion)
        {
            string filePath = Path.Combine(projectPath, "packages.config");

            var content = GeneratePackageConfigFile(quantityName, mscorlibNuGetVersion, mathNuGetVersion);

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

        private static string GeneratePackageConfigFile(
            string quantityName,
            string mscorlibNuGetVersion,
            string mathNuGetVersion)
        {
            MyTextWriter writer = new();

            writer.WL($@"
<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""nanoFramework.CoreLibrary"" version=""{mscorlibNuGetVersion}"" targetFramework=""netnanoframework10"" />");


            if (NanoFrameworkGenerator.ProjectsRequiringMath.Contains(quantityName))
            {
                writer.WL($@"
  <package id=""nanoFramework.System.Math"" version=""{mathNuGetVersion}"" targetFramework=""netnanoframework10"" />");
            }

            writer.WL($@"</packages>");

            return writer.ToString();
        }
    }
}
