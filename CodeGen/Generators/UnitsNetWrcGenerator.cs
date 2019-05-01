// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeGen.Helpers;
using CodeGen.JsonTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using QuantityGenerator = CodeGen.Generators.UnitsNetWrcGen.QuantityGenerator;
using QuantityTypeGenerator = CodeGen.Generators.UnitsNetWrcGen.QuantityTypeGenerator;
using StaticQuantityGenerator = CodeGen.Generators.UnitsNetWrcGen.StaticQuantityGenerator;
using UnitAbbreviationsCacheGenerator = CodeGen.Generators.UnitsNetWrcGen.UnitAbbreviationsCacheGenerator;
using UnitTypeGenerator = CodeGen.Generators.UnitsNetWrcGen.UnitTypeGenerator;

namespace CodeGen.Generators
{
    internal static class UnitsNetWrcGenerator
    {
        private const int AlignPad = 35;

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            // Don't override the C# default assigned values if no value is set in JSON
            NullValueHandling = NullValueHandling.Ignore
        };

        public static void Generate(DirectoryInfo repositoryRoot)
        {
            if (repositoryRoot == null) throw new ArgumentNullException(nameof(repositoryRoot));
            var root = repositoryRoot.FullName;
            var outputDir = $"{root}/UnitsNet.WindowsRuntimeComponent/GeneratedCode";

            var templatesDir = Path.Combine(root, "Common/UnitDefinitions");
            var jsonFiles = Directory.GetFiles(templatesDir, "*.json");
            var quantities = jsonFiles.Select(ParseQuantityFile).ToArray();

            foreach (Quantity quantity in quantities)
            {
                var sb = new StringBuilder($"{quantity.Name}:".PadRight(AlignPad));
                GenerateQuantity(sb, quantity, $"{outputDir}/Quantities/{quantity.Name}.WindowsRuntimeComponent.g.cs");
                GenerateUnitType(sb, quantity, $"{outputDir}/Units/{quantity.Name}Unit.g.cs");
                Log.Information(sb.ToString());
            }

            Log.Information("");
            GenerateUnitAbbreviationsCache(quantities, $"{outputDir}/UnitAbbreviationsCache.g.cs");
            GenerateQuantityType(quantities, $"{outputDir}/QuantityType.g.cs");
            GenerateStaticQuantity(quantities, $"{outputDir}/Quantity.g.cs");

            var unitCount = quantities.SelectMany(q => q.Units).Count();
            Log.Information("");
            Log.Information($"Total of {unitCount} units and {quantities.Length} quantities.");
            Log.Information("");
        }

        private static Quantity ParseQuantityFile(string jsonFile)
        {
            var quantity = JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(jsonFile, Encoding.UTF8), JsonSerializerSettings);
            AddPrefixUnits(quantity);
            FixConversionFunctionsForDecimalValueTypes(quantity);
            OrderUnitsByName(quantity);
            return quantity;
        }

        private static void GenerateQuantity(StringBuilder sb, Quantity quantity, string filePath)
        {
            string content = new QuantityGenerator(quantity).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("quantity(OK) ");
        }

        private static void GenerateUnitType(StringBuilder sb, Quantity quantity, string filePath)
        {
            string content = new UnitTypeGenerator(quantity).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            sb.Append("unit(OK) ");
        }

        private static void GenerateUnitAbbreviationsCache(Quantity[] quantities, string filePath)
        {
            string content = new UnitAbbreviationsCacheGenerator(quantities).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            Log.Information("UnitAbbreviationsCache.g.cs: ".PadRight(AlignPad) + "(OK)");
        }

        private static void GenerateQuantityType(Quantity[] quantities, string filePath)
        {
            string content = new QuantityTypeGenerator(quantities).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            Log.Information("QuantityType.g.cs: ".PadRight(AlignPad) + "(OK)");
        }

        private static void GenerateStaticQuantity(Quantity[] quantities, string filePath)
        {
            string content = new StaticQuantityGenerator(quantities).Generate();
            File.WriteAllText(filePath, content, Encoding.UTF8);
            Log.Information("Quantity.g.cs: ".PadRight(AlignPad) + "(OK)");
        }

        private static void OrderUnitsByName(Quantity quantity)
        {
            quantity.Units = quantity.Units.OrderBy(u => u.SingularName).ToArray();
        }

        private static void FixConversionFunctionsForDecimalValueTypes(Quantity quantity)
        {
            foreach (Unit u in quantity.Units)
            {
                // Use decimal for internal calculations if base type is not double, such as for long or int.
                if (string.Equals(quantity.BaseType, "decimal", StringComparison.OrdinalIgnoreCase))
                {
                    // Change any double literals like "1024d" to decimal literals "1024m"
                    u.FromUnitToBaseFunc = u.FromUnitToBaseFunc.Replace("d", "m");
                    u.FromBaseToUnitFunc = u.FromBaseToUnitFunc.Replace("d", "m");
                }
            }
        }

        private static void AddPrefixUnits(Quantity quantity)
        {
            var unitsToAdd = new List<Unit>();
            foreach (Unit unit in quantity.Units)
            {
                // "Kilo", "Nano" etc.
                for (var prefixIndex = 0; prefixIndex < unit.Prefixes.Length; prefixIndex++)
                {
                    Prefix prefix = unit.Prefixes[prefixIndex];
                    PrefixInfo prefixInfo = PrefixInfo.Entries[prefix];

                    unitsToAdd.Add(new Unit
                    {
                        SingularName = $"{prefix}{unit.SingularName.ToCamelCase()}", // "Kilo" + "NewtonPerMeter" => "KilonewtonPerMeter"
                        PluralName = $"{prefix}{unit.PluralName.ToCamelCase()}",     // "Kilo" + "NewtonsPerMeter" => "KilonewtonsPerMeter"
                        BaseUnits = null, // Can we determine this somehow?
                        FromBaseToUnitFunc = $"({unit.FromBaseToUnitFunc}) / {prefixInfo.Factor}",
                        FromUnitToBaseFunc = $"({unit.FromUnitToBaseFunc}) * {prefixInfo.Factor}",
                        Localization = GetLocalizationForPrefixUnit(unit, prefixIndex, prefixInfo, quantity.Name),
                    });
                }
            }

            quantity.Units = quantity.Units.Concat(unitsToAdd).ToArray();
        }

        private static Localization[] GetLocalizationForPrefixUnit(Unit unit, int prefixIndex, PrefixInfo prefixInfo, string quantityName)
        {
            string[] GetUnitAbbreviationsForPrefix(Localization loc)
            {
                // If no custom abbreviations are specified, prepend the default prefix to each unit abbreviation: kilo ("k") + meter ("m") => kilometer ("km")
                if (loc.AbbreviationsWithPrefixes == null || !loc.AbbreviationsWithPrefixes.Any())
                {
                    string prefix = prefixInfo.Abbreviation;
                    return loc.Abbreviations.Select(unitAbbreviation => $"{prefix}{unitAbbreviation}").ToArray();
                }

                /*
                 Prepend prefix to all abbreviations of a unit.
                 Some languages, like Russian, you can't simply prepend "k" for kilo prefix, so the prefix abbreviations must be explicitly defined
                 with AbbreviationsWithPrefixes.

                 Example 1 - Torque.Newtonmeter has only a single abbreviation in Russian, so AbbreviationsWithPrefixes is an array of strings mapped to each prefix

    {
      "SingularName": "NewtonMeter",
      "PluralName": "NewtonMeters",
      "FromUnitToBaseFunc": "x",
      "FromBaseToUnitFunc": "x",
      "Prefixes": [ "Kilo", "Mega" ],
      "Localization": [
        {
          "Culture": "en-US",
          "Abbreviations": [ "N·m" ]
        },
        {
          "Culture": "ru-RU",
          "Abbreviations": [ "Н·м" ],
          "AbbreviationsWithPrefixes": [ "кН·м", "МН·м" ]
        }
      ]
    },

                Example 2 - Duration.Second has 3 prefixes and 2 abbreviations in Russian, so AbbreviationsWithPrefixes is an array of 3 items where each
                represents the unit abbreviations for that prefix - typically a variant of those in "Abbreviations", but the counts don't have to match.

    {
      "SingularName": "Second",
      "PluralName": "Seconds",
      "BaseUnits": {
        "T": "Second"
      },
      "FromUnitToBaseFunc": "x",
      "FromBaseToUnitFunc": "x",
      "Prefixes": [ "Nano", "Micro", "Milli" ],
      "Localization": [
        {
          "Culture": "en-US",
          "Abbreviations": [ "s", "sec", "secs", "second", "seconds" ]
        },
        {
          "Culture": "ru-RU",
          "Abbreviations": [ "с", "сек" ],
          "AbbreviationsWithPrefixes": [ ["нс", "нсек"], ["мкс", "мксек"], ["мс", "мсек"] ]
        }
      ]
    }
                 */

                EnsureValidAbbreviationsWithPrefixes(loc, unit, quantityName);
                JToken abbreviationsForPrefix = loc.AbbreviationsWithPrefixes[prefixIndex];
                switch (abbreviationsForPrefix.Type)
                {
                    case JTokenType.Array:
                        return abbreviationsForPrefix.ToObject<string[]>();
                    case JTokenType.String:
                        return new[] {abbreviationsForPrefix.ToObject<string>()};
                    default:
                        throw new NotSupportedException("Expect AbbreviationsWithPrefixes to be an array of strings or string arrays.");
                }
            }

            Localization WithPrefixes(Localization loc)
            {
                string[] unitAbbreviationsForPrefix = GetUnitAbbreviationsForPrefix(loc);

                return new Localization
                {
                    Culture = loc.Culture,
                    Abbreviations = unitAbbreviationsForPrefix,
                };
            }

            return unit.Localization.Select(WithPrefixes).ToArray();
        }

        private static void EnsureValidAbbreviationsWithPrefixes(Localization localization, Unit unit, string quantityName)
        {
            if (localization.AbbreviationsWithPrefixes.Length > 0 &&
                localization.AbbreviationsWithPrefixes.Length != unit.Prefixes.Length)
            {
                throw new InvalidDataException(
                    $"The Prefixes array length {unit.Prefixes.Length} does not match Localization.AbbreviationsWithPrefixes array length {localization.AbbreviationsWithPrefixes.Length} for {quantityName}.{unit.SingularName}");
            }
        }
    }
}
