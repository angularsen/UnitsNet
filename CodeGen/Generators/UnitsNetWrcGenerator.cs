// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.IO;
using System.Linq;
using CodeGen.Generators.UnitsNetWrcGen;
using CodeGen.JsonTypes;
using Serilog;

namespace CodeGen.Generators
{
    /// <summary>
    ///     Code generator for UnitsNet.WindowsRuntimeComponent project.
    /// </summary>
    internal static class UnitsNetWrcGenerator
    {
        private const int AlignPad = 35;

        /// <summary>
        ///     Generate source code for UnitsNet project for the given parsed quantities.
        ///     Outputs files relative to the given root dir to these locations:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>
        ///                 UnitsNet.WindowsRuntimeComponent/GeneratedCode (quantity and unit types, Quantity,
        ///                 UnitAbbreviationCache)
        ///             </description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="rootDir">Path to repository root directory.</param>
        /// <param name="quantities">The parsed quantities.</param>
        /// <remarks>
        ///     NOTE! WRC target is deprecated and no longer actively maintained and will receive no new features.
        ///     No tests are generated or run for WRC and the code generator scripts are only updated to work when JSON schema
        ///     changes.
        /// </remarks>
        public static void Generate(string rootDir, Quantity[] quantities)
        {
            var outputDir = $"{rootDir}/UnitsNet.WindowsRuntimeComponent/GeneratedCode";

            // Ensure output directories exist
            Directory.CreateDirectory($"{outputDir}/Quantities");
            Directory.CreateDirectory($"{outputDir}/Units");

            foreach (var quantity in quantities)
            {
                GenerateQuantity(quantity, $"{outputDir}/Quantities/{quantity.Name}.g.cs");
                GenerateUnitType(quantity, $"{outputDir}/Units/{quantity.Name}Unit.g.cs");
                Log.Information("✅ {Quantity} (WRC)", quantity.Name);
            }

            Log.Information("");
            GenerateUnitAbbreviationsCache(quantities, $"{outputDir}/UnitAbbreviationsCache.g.cs");
            GenerateUnitSingularNamesCache(quantities, $"{outputDir}/UnitSingularNamesCache.g.cs");
            GenerateQuantityType(quantities, $"{outputDir}/QuantityType.g.cs");
            GenerateStaticQuantity(quantities, $"{outputDir}/Quantity.g.cs");

            var unitCount = quantities.SelectMany(q => q.Units).Count();
            Log.Information("");
            Log.Information("Total of {UnitCount} units and {QuantityCount} quantities (Windows Runtime Component)", unitCount, quantities.Length);
            Log.Information("");
        }

        private static void GenerateQuantity(Quantity quantity, string filePath)
        {
            var content = new QuantityGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateUnitType(Quantity quantity, string filePath)
        {
            var content = new UnitTypeGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateUnitAbbreviationsCache(Quantity[] quantities, string filePath)
        {
            var content = new UnitAbbreviationsCacheGenerator(quantities).Generate();
            File.WriteAllText(filePath, content);
            Log.Information("✅ UnitAbbreviationsCache.g.cs (WRC)");
        }

        private static void GenerateUnitSingularNamesCache(Quantity[] quantities, string filePath)
        {
            var content = new UnitSingularNamesCacheGenerator(quantities).Generate();
            File.WriteAllText(filePath, content);
            Log.Information("✅ UnitSingularNamesCache.g.cs (WRC)");
        }

        private static void GenerateQuantityType(Quantity[] quantities, string filePath)
        {
            var content = new QuantityTypeGenerator(quantities).Generate();
            File.WriteAllText(filePath, content);
            Log.Information("✅ QuantityType.g.cs (WRC)");
        }

        private static void GenerateStaticQuantity(Quantity[] quantities, string filePath)
        {
            var content = new StaticQuantityGenerator(quantities).Generate();
            File.WriteAllText(filePath, content);
            Log.Information("✅ Quantity.g.cs (WRC)");
        }
    }
}
