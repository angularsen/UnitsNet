using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using CodeGen.Generators;
using CodeGen.Helpers.UnitEnumValueAllocation;
using Serilog;
using Serilog.Events;

namespace CodeGen
{
    /// <summary>
    ///     Code generator for Units.NET.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Code generator for Units.NET.
        ///     Reads unit definitions from JSON files and outputs C# files in GeneratedCode folders:
        ///     <list type="number">
        ///         <item>
        ///             <description>Quantity types (Length, Mass, ...)</description>
        ///         </item>
        ///         <item>
        ///             <description>Unit enum types (LengthUnit, MassUnit, ...)</description>
        ///         </item>
        ///         <item>
        ///             <description>UnitsNet.Quantity class.</description>
        ///         </item>
        ///         <item>
        ///             <description>UnitsNet.UnitAbbreviationsCache class.</description>
        ///         </item>
        ///         <item>
        ///             <description>Test stubs for testing conversion functions of all units, to be fleshed out by a human later</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <remarks>
        ///     System.CommandLine.Dragonfruit based Main method, where CLI arguments are parsed and passed directly to this
        ///     method.
        ///     See https://github.com/dotnet/command-line-api/
        /// </remarks>
        /// <param name="verbose">Verbose output? Defaults to false.</param>
        /// <param name="repositoryRoot">The repository root directory, defaults to searching parent directories for UnitsNet.sln.</param>
        /// <param name="skipNanoFramework">Skip generate nanoFramework Units? Defaults to false</param>
        /// <param name="updateNanoFrameworkDependencies">Update nanoFramework nuget dependencies? Defaults to false.</param>
        public static int Main(bool verbose = false, DirectoryInfo? repositoryRoot = null, bool skipNanoFramework = false, bool updateNanoFrameworkDependencies = false)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .Console(verbose ? LogEventLevel.Verbose : LogEventLevel.Information)
                .CreateLogger();

            // Enable emojis and other UTF8 symbols.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                repositoryRoot ??= FindRepositoryRoot();

                var rootDir = repositoryRoot.FullName;

                Log.Information("Units.NET code generator {Version}", Assembly.GetExecutingAssembly().GetName().Version);
                if (verbose) Log.Debug("Verbose output enabled");

                var sw = Stopwatch.StartNew();
                var quantities = QuantityJsonFilesParser.ParseQuantities(repositoryRoot.FullName);

                QuantityNameToUnitEnumValues quantityNameToUnitEnumValues = UnitEnumValueAllocator.AllocateNewUnitEnumValues($"{rootDir}/Common/UnitEnumValues.g.json", quantities);

                UnitsNetGenerator.Generate(rootDir, quantities, quantityNameToUnitEnumValues);

                if (updateNanoFrameworkDependencies)
                {
                    if (!NanoFrameworkGenerator.UpdateNanoFrameworkDependencies(
                        rootDir,
                        quantities))
                    {
                        return 1;
                    }
                }

                if (!skipNanoFramework)
                {
                    Log.Information("Generate nanoFramework projects\n---");
                    NanoFrameworkGenerator.Generate(rootDir, quantities, quantityNameToUnitEnumValues);
                }

                Log.Information("Completed in {ElapsedMs} ms!", sw.ElapsedMilliseconds);
                return 0;
            }
            catch (Exception e)
            {
                Log.Error(e, "Unexpected error");
                return 1;
            }
        }

        private static DirectoryInfo FindRepositoryRoot()
        {
            var executableParentDir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!);
            Log.Verbose("Executable dir: {ExecutableParentDir}", executableParentDir);

            for (var dir = executableParentDir; dir != null; dir = dir.Parent)
            {
                if (dir.GetFiles("UnitsNet.sln").Any())
                {
                    Log.Verbose("Found repo root: {Dir}", dir);
                    return dir;
                }

                Log.Verbose("Not repo root: {Dir}", dir);
            }

            throw new Exception($"Unable to find repository root in directory hierarchy: {executableParentDir}");
        }
    }
}
