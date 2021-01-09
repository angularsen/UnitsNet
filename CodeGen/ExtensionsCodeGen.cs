using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeGen.Generators;
using CodeGen.Generators.UnitsNetGen;
using CodeGen.JsonTypes;
using Serilog;
using Serilog.Events;

namespace UnitsNet.CodeGen
{
    public sealed class GenerateOptions
    {
        public string TargetFolderPath { get; set; }
        public string TargetFilename { get; set; }
        public string NamespaceName { get; set; } // TODO
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class Options
    {
        // TODO: file header
        public string SourceFolderPath { get; set; }
        public bool GenerateStaticQuantityFactory => StaticQuantityFactory != null;
        public bool UseNullableReferenceTypes { get; set; } = false;
        public bool ClearFoldersFirst { get; set; } = true; // TODO
        public bool LogVerbose { get; set; } = false;
        public GenerateOptions Quantities { get; set; }
        public GenerateOptions Units { get; set; }
        public GenerateOptions QuantityTestClass { get; set; }
        public bool GenerateQuantityTestClass => QuantityTestClass != null;
        public GenerateOptions QuantityTestBaseClass { get; set; }
        public bool GenerateQuantityTestBaseClass => QuantityTestBaseClass != null;
        public GenerateOptions ExtensionMethods { get; set; }
        public bool GenerateExtensionMethods => ExtensionMethods != null;
        public GenerateOptions ExtensionMethodsTests { get; set; }
        public bool GenerateExtensionMethodsTests => GenerateExtensionMethods && ExtensionMethodsTests != null;
        public GenerateOptions QuantityFactory { get; set; }
        public bool GenerateQuantityFactory => QuantityFactory != null;
        public GenerateOptions StaticQuantityFactory { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class ExtensionsCodeGen
    {
        private readonly Options _options;

        /// <summary>
        /// 
        /// </summary>
        public ExtensionsCodeGen(Options options)
        {
            _options = options;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Generate()
        {
            // TODO: parametrize QuantityType
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .Console(_options.LogVerbose ? LogEventLevel.Verbose : LogEventLevel.Information)
                .CreateLogger();

            Quantity[]? quantities = QuantityJsonFilesParser.ParseQuantities(_options.SourceFolderPath);
            foreach (var quantity in quantities)
            {
                var sb = new StringBuilder($"{quantity.Name}:".PadRight(UnitsNetGenerator.AlignPad));

                var quantityFile = $"{quantity.Name}.g.cs";
                var quantityFullFilePath = Path.Combine(_options.Quantities.TargetFolderPath, quantityFile);
                var usingNamespaces = new List<string> { "UnitsNet", _options.Units.NamespaceName };
                GenerateQuantity(sb, quantity, quantityFullFilePath, _options.Quantities.NamespaceName, usingNamespaces);

                var unitsFile = $"{quantity.Name}Unit.g.cs";
                var unitFullFilePath = Path.Combine(_options.Units.TargetFolderPath, unitsFile);
                GenerateUnitType(sb, quantity, unitFullFilePath, _options.Units.NamespaceName);

                if (_options.GenerateExtensionMethods)
                {
                    string file = $"NumberTo{quantity.Name}Extensions.g.cs";
                    string extensionMethodsFullFilePath = Path.Combine(_options.ExtensionMethods.TargetFolderPath, file);
                    GenerateNumberToExtensions(sb, quantity, extensionMethodsFullFilePath);
                }
                if (_options.GenerateExtensionMethodsTests)
                {
                    string file = $"NumberTo{quantity.Name}ExtensionsTest.g.cs";
                    string extensionMethodsTestsFullFilePath = Path.Combine(_options.ExtensionMethodsTests.TargetFolderPath, file);
                    GenerateNumberToExtensionsTestClass(sb, quantity, extensionMethodsTestsFullFilePath);
                }

                // Example: CustomCode/Quantities/LengthTests inherits GeneratedCode/TestsBase/LengthTestsBase
                // This way when new units are added to the quantity JSON definition, we auto-generate the new
                // conversion function tests that needs to be manually implemented by the developer to fix the compile error
                // so it cannot be forgotten.

                if (_options.GenerateQuantityTestClass)
                {
                    var file = $"{quantity.Name}TestsBase.g.cs";
                    var quantityTestBaseClassFullFilePath = Path.Combine(_options.QuantityTestClass.TargetFolderPath, file);
                    GenerateQuantityTestBaseClass(sb, quantity, quantityTestBaseClassFullFilePath);
                }
                if (_options.GenerateQuantityTestBaseClass)
                {
                    var file = $"{quantity.Name}Tests.cs";
                    var quantityTestBaseClassFullFilePath = Path.Combine(_options.QuantityTestBaseClass.TargetFolderPath, file);
                    GenerateQuantityTestClassIfNotExists(sb, quantity, quantityTestBaseClassFullFilePath);
                }

                Log.Information(sb.ToString());
            }

            //GenerateIQuantityTests(quantities, $"{testOutputDir}/IQuantityTests.g.cs");

            Log.Information("");
            if (_options.GenerateStaticQuantityFactory)
            {
                var file = $"{_options.StaticQuantityFactory.TargetFilename}.g.cs";
                var staticQuantityFullFilePath = Path.Combine(_options.StaticQuantityFactory.TargetFolderPath, file);
                var name = _options.StaticQuantityFactory.TargetFilename;
                var qns = _options.Quantities.NamespaceName;
                var uns = _options.Units.NamespaceName;
                var usingNamespaces = new List<string> { "UnitsNet", _options.Units.NamespaceName, _options.Quantities.NamespaceName };
                GenerateStaticQuantity(quantities, staticQuantityFullFilePath, name, _options.StaticQuantityFactory.NamespaceName, _options.UseNullableReferenceTypes, usingNamespaces);
            }
            if (_options.GenerateQuantityFactory)
            {
                //var file = $"{_options.StaticQuantityFactory.TargetFilename}.g.cs";
                //var staticQuantityFullFilePath = Path.Combine(_options.StaticQuantityFactory.TargetFolderPath, file);
                //GenerateStaticQuantity(quantities, staticQuantityFullFilePath, _options.StaticQuantityFactory.NamespaceName);
            }
            //GenerateUnitAbbreviationsCache(quantities, $"{outputDir}/UnitAbbreviationsCache.g.cs");
            //GenerateUnitConverter(quantities, $"{outputDir}/UnitConverter.g.cs");

            var unitCount = quantities.SelectMany(q => q.Units).Count();
            Log.Information("");
            Log.Information($"Total of {unitCount} units and {quantities.Length} quantities.");
            Log.Information("");
        }

        private static void GenerateQuantityTestClassIfNotExists(StringBuilder sb, Quantity quantity, string filePath)
        {
            if (File.Exists(filePath))
            {
                sb.Append("test stub(skip) ");
                return;
            }

            var content = new UnitTestStubGenerator(quantity).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("test stub(OK) ");
        }

        private void GenerateQuantity(StringBuilder sb, Quantity quantity, string filePath, string namespaceName, IEnumerable<string> usingNamespaces)
        {
            var content = new QuantityGenerator(quantity, _options.UseNullableReferenceTypes, false, namespaceName, usingNamespaces).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("quantity(OK) ");
        }

        private static void GenerateNumberToExtensions(StringBuilder sb, Quantity quantity, string filePath)
        {
            var content = new NumberExtensionsGenerator(quantity).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("number extensions(OK) ");
        }

        private static void GenerateNumberToExtensionsTestClass(StringBuilder sb, Quantity quantity, string filePath)
        {
            var content = new NumberExtensionsTestClassGenerator(quantity).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("number extensions tests(OK) ");
        }

        private static void GenerateUnitType(StringBuilder sb, Quantity quantity, string filePath, string namespaceName)
        {
            var content = new UnitTypeGenerator(quantity, namespaceName).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("unit(OK) ");
        }

        private static void GenerateQuantityTestBaseClass(StringBuilder sb, Quantity quantity, string filePath)
        {
            var content = new UnitTestBaseClassGenerator(quantity).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("test base(OK) ");
        }

        private static void GenerateIQuantityTests(Quantity[] quantities, string filePath)
        {
            var content = new IQuantityTestClassGenerator(quantities).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            Log.Information("IQuantityTests.g.cs: ".PadRight(UnitsNetGenerator.AlignPad) + "(OK)");
        }

        private static void GenerateUnitAbbreviationsCache(Quantity[] quantities, string filePath)
        {
            var content = new UnitAbbreviationsCacheGenerator(quantities).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            Log.Information("UnitAbbreviationsCache.g.cs: ".PadRight(UnitsNetGenerator.AlignPad) + "(OK)");
        }

        private static void GenerateStaticQuantity(Quantity[] quantities, string filePath, string name, string namespaceName, bool useNullity, IEnumerable<string> usingNamespaces)
        {
            var content = new StaticQuantityGenerator(quantities, false, name, namespaceName, useNullity, usingNamespaces, false).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            Log.Information("Quantity.g.cs: ".PadRight(UnitsNetGenerator.AlignPad) + "(OK)");
        }

        private static void GenerateUnitConverter(Quantity[] quantities, string filePath)
        {
            var content = new UnitConverterGenerator(quantities).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            Log.Information("UnitConverter.g.cs: ".PadRight(UnitsNetGenerator.AlignPad) + "(OK)");
        }
    }
}
