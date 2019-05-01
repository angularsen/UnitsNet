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

namespace CodeGen.Generators
{
    /// <summary>
    ///     Parses JSON files that define quantities and their units.
    ///     This will later be used to generate source code and can be reused for different targets such as .NET framework,
    ///     WindowsRuntimeComponent and even other programming languages.
    /// </summary>
    internal static class QuantityJsonFilesParser
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            // Don't override the C# default assigned values if no value is set in JSON
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        ///     Parses JSON files that define quantities and their units.
        /// </summary>
        /// <param name="rootDir">Repository root directory, where you cloned the repo to such as "c:\dev\UnitsNet".</param>
        /// <returns>The parsed quantities and their units.</returns>
        public static Quantity[] ParseQuantities(string rootDir)
        {
            var jsonDir = Path.Combine(rootDir, "Common/UnitDefinitions");
            var jsonFiles = Directory.GetFiles(jsonDir, "*.json");
            return jsonFiles.Select(ParseQuantityFile).ToArray();
        }

        private static Quantity ParseQuantityFile(string jsonFile)
        {
            try
            {
                var quantity = JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(jsonFile, Encoding.UTF8), JsonSerializerSettings);
                AddPrefixUnits(quantity);
                FixConversionFunctionsForDecimalValueTypes(quantity);
                OrderUnitsByName(quantity);
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception($"Error parsing quantity JSON file: {jsonFile}", e);
            }
        }

        private static void OrderUnitsByName(Quantity quantity)
        {
            quantity.Units = quantity.Units.OrderBy(u => u.SingularName).ToArray();
        }

        private static void FixConversionFunctionsForDecimalValueTypes(Quantity quantity)
        {
            foreach (var u in quantity.Units)
                // Use decimal for internal calculations if base type is not double, such as for long or int.
            {
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
            foreach (var unit in quantity.Units)
            foreach (var prefix in unit.Prefixes)
            {
                try
                {
                    var prefixInfo = PrefixInfo.Entries[prefix];

                    unitsToAdd.Add(new Unit
                    {
                        SingularName = $"{prefix}{unit.SingularName.ToCamelCase()}", // "Kilo" + "NewtonPerMeter" => "KilonewtonPerMeter"
                        PluralName = $"{prefix}{unit.PluralName.ToCamelCase()}", // "Kilo" + "NewtonsPerMeter" => "KilonewtonsPerMeter"
                        BaseUnits = null, // Can we determine this somehow?
                        FromBaseToUnitFunc = $"({unit.FromBaseToUnitFunc}) / {prefixInfo.Factor}",
                        FromUnitToBaseFunc = $"({unit.FromUnitToBaseFunc}) * {prefixInfo.Factor}",
                        Localization = GetLocalizationForPrefixUnit(unit.Localization, prefixInfo)
                    });
                }
                catch (Exception e)
                {
                    throw new Exception($"Error parsing prefix {prefix} for unit {quantity.Name}.{unit.SingularName}.", e);
                }
            }

            quantity.Units = quantity.Units.Concat(unitsToAdd).ToArray();
        }

        /// <summary>
        ///     Create unit abbreviations for a prefix unit, given a unit and the prefix.
        ///     The unit abbreviations are either prefixed with the SI prefix or an explicitly configured abbreviation via
        ///     <see cref="Localization.AbbreviationsForPrefixes" />.
        /// </summary>
        private static Localization[] GetLocalizationForPrefixUnit(IEnumerable<Localization> localizations, PrefixInfo prefixInfo)
        {
            return localizations.Select(loc =>
            {
                if (loc.TryGetAbbreviationsForPrefix(prefixInfo.Prefix, out string[] unitAbbreviationsForPrefix))
                {
                    return new Localization
                    {
                        Culture = loc.Culture,
                        Abbreviations = unitAbbreviationsForPrefix
                    };
                }

                // No prefix unit abbreviations are specified, so fall back to prepending the default SI prefix to each unit abbreviation:
                // kilo ("k") + meter ("m") => kilometer ("km")
                var prefix = prefixInfo.GetPrefixForCultureOrSiPrefix(loc.Culture);
                unitAbbreviationsForPrefix = loc.Abbreviations.Select(unitAbbreviation => $"{prefix}{unitAbbreviation}").ToArray();

                return new Localization
                {
                    Culture = loc.Culture,
                    Abbreviations = unitAbbreviationsForPrefix
                };
            }).ToArray();
        }
    }
}
