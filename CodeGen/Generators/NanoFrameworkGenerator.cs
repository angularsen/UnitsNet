using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using CodeGen.Generators.NanoFrameworkGen;
using CodeGen.JsonTypes;
using Serilog;

namespace CodeGen.Generators
{
    /// <summary>
    /// Code generator for nanoFramework
    /// Will generate 1 nanoFramework project per unit, a common property folder and a common package file
    /// </summary>
    internal static class NanoFrameworkGenerator
    {
        private const int AlignPad = 35;

        /// <summary>
        /// Create the root folder NanoFramewok
        /// Create all the quantities unit and quantities file
        /// Create all individual nanoFramework projects
        /// Create common package file
        /// Create common properties file
        /// </summary>
        /// <param name="rootDir">The root directory</param>
        /// <param name="quantities">The quantities to create</param>
        public static void Generate(string rootDir, Quantity[] quantities)
        {
            var outputDir = Path.Combine(rootDir, "UnitsNet.NanoFramework", "GeneratedCode");
            var outputQuantitites = Path.Combine(outputDir, "Quantities");
            var outputUnits = Path.Combine(outputDir, "Units");
            var outputProperties = Path.Combine(outputDir, "Properties");
            // Ensure output directories exist

            Directory.CreateDirectory(outputQuantitites);
            Directory.CreateDirectory(outputUnits);
            Directory.CreateDirectory(outputProperties);

            Log.Information($"Directory NanoFramework creation(OK)");

            GenerateProperties(Path.Combine(outputProperties, "AssemblyInfo.cs"));
            Log.Information($"Property(OK)");

            int numberQuantity = 0;
            foreach (var quantity in quantities)
            {
                // Skip decimal based units, they are not supported by nanoFramework
                if (quantity.BaseType == "decimal")
                {
                    Log.Information($"Skipping {quantity.Name} as it's decimal based");
                    continue;
                }

                Log.Information($"Creating .NET nanoFramework project for {quantity.Name}");

                var projectPath = Path.Combine(outputDir, quantity.Name);

                GeneratePackage(Path.Combine(projectPath, "packages.config"));
                Log.Information($"Package(OK)");

                var sb = new StringBuilder($"{quantity.Name}:".PadRight(AlignPad));
                GenerateUnitType(sb, quantity, Path.Combine(outputUnits, $"{quantity.Name}Unit.g.cs"));
                GenerateQuantity(sb, quantity, Path.Combine(outputQuantitites, $"{quantity.Name}.g.cs"));
                GenerateProject(sb, quantity, Path.Combine(projectPath, $"{quantity.Name}.nfproj"));
                Log.Information(sb.ToString());
                numberQuantity++;
            }

            GenerateSolution(quantities, outputDir);
            Log.Information("UnitsNet.nanoFrmawork.sln generated");
            Log.Information($"Total quantities generated: {numberQuantity}");
        }

        private static void GeneratePackage(string filePath)
        {
            var content = new PackageGenerator().Generate();
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
            var content = new ProjectGenerator(quantity, @"$(MSBuildToolsPath)..\..\..\nanoFramework\v1.0\").Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("project(OK) ");
        }

        private static void GenerateSolution(Quantity[] quantities, string outputDir)
        {
            var content = new SolutionGenerator(quantities, outputDir).Generate();

            var filePath = Path.Combine(outputDir, "UnitsNet.nanoFramework.sln");

            File.WriteAllText(filePath, content, Encoding.UTF8);
        }
    }
}
