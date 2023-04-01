// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using CodeGen.Exceptions;
using CodeGen.Helpers;
using CodeGen.JsonTypes;
using Newtonsoft.Json;

namespace CodeGen.Generators
{
    /// <summary>
    ///     Parses JSON files that define quantities and their units.
    ///     This will later be used to generate source code and can be reused for different targets such as .NET framework,
    ///     .NET Core, .NET nanoFramework and even other programming languages.
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
            var jsonFileNames = Directory.GetFiles(jsonDir, "*.json");
            return jsonFileNames
                .OrderBy(fn => fn, StringComparer.InvariantCultureIgnoreCase)
                .Select(ParseQuantityFile)
                .ToArray();
        }

        private static Quantity ParseQuantityFile(string jsonFileName)
        {
            try
            {
                Quantity quantity = JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(jsonFileName), JsonSerializerSettings)
                               ?? throw new UnitsNetCodeGenException($"Unable to parse quantity from JSON file: {jsonFileName}");

                AddPrefixUnits(quantity);
                FixConversionFunctionsForDecimalValueTypes(quantity);
                OrderUnitsByName(quantity);
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception($"Error parsing quantity JSON file: {jsonFileName}", e);
            }
        }

        private static void OrderUnitsByName(Quantity quantity)
        {
            quantity.Units = quantity.Units.OrderBy(u => u.SingularName).ToArray();
        }

        private static void FixConversionFunctionsForDecimalValueTypes(Quantity quantity)
        {
            foreach (Unit u in quantity.Units)
                // Use decimal for internal calculations if base type is not double, such as for long or int.
            {
                if (string.Equals(quantity.ValueType, "decimal", StringComparison.OrdinalIgnoreCase))
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
            foreach (Prefix prefix in unit.Prefixes)
            {
                try
                {
                    PrefixInfo prefixInfo = PrefixInfo.Entries[prefix];

                    unitsToAdd.Add(new Unit
                    {
                        SingularName = $"{prefix}{unit.SingularName.ToCamelCase()}", // "Kilo" + "NewtonPerMeter" => "KilonewtonPerMeter"
                        PluralName = $"{prefix}{unit.PluralName.ToCamelCase()}", // "Kilo" + "NewtonsPerMeter" => "KilonewtonsPerMeter"
                        BaseUnits = GetBaseUnitForPrefixUnit(prefix, unit),
                        FromBaseToUnitFunc = $"({unit.FromBaseToUnitFunc}) / {prefixInfo.Factor}",
                        FromUnitToBaseFunc = $"({unit.FromUnitToBaseFunc}) * {prefixInfo.Factor}",
                        Localization = GetLocalizationForPrefixUnit(unit.Localization, prefixInfo),
                        ObsoleteText = unit.ObsoleteText,
                        SkipConversionGeneration = unit.SkipConversionGeneration,
                        AllowAbbreviationLookup = unit.AllowAbbreviationLookup
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
        ///     Try to determine the SI base units for a prefix of a given unit, by matching the start of the unit name with one of the base unit names.
        ///     <br /><br />
        ///     A unit may have prefixes like Nano, Micros, Milli, Kilo, Mega, etc. and we try to determine the base units for each prefixed unit.<br />
        ///     As an example, applying the prefix Nano:
        ///     <br /><br />
        ///     Example: Nano prefix for Acceleration unit MeterPerSecondSquared.<br />
        ///     SI base units: Length (L) = "Meter", Time (T) = "Second"<br />
        ///     Starting with the first word, "Meter", the first match is Length (L) = "Meter" and with the Nano prefix we get L = "Nanometer".
        ///     <br /><br />
        ///     Example: Mega prefix for AmountOfSubstance unit PoundMole.<br />
        ///     SI base units: AmountOfSubstance (N) = "PoundMole"<br />
        ///     Starting with the first word "Pound", there is no match on base units.<br />
        ///     Starting with the first 2 words "PoundMole", the first match is base unit AmountOfSubstance (N) = "PoundMole" and with the prefix we
        ///     get N = "NanopoundMole".
        /// </summary>
        /// <param name="prefix">The SI prefix.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        private static BaseUnits? GetBaseUnitForPrefixUnit(Prefix prefix, Unit unit)
        {
            if (unit.BaseUnits is null) return null;
            BaseUnits baseUnits = unit.BaseUnits;

            BaseUnits? dup = JsonConvert.DeserializeObject<BaseUnits>(JsonConvert.SerializeObject(baseUnits));
            string[] words = ToWords(unit.SingularName);

            // Try the N first PascalCase words, starting with the first word, the 2 first words, the 3 first words, etc.
            // This allows matching SI base unit names with multiple words, like PoundMole.
            for (var i = 0; i < words.Length; i++)
            {
                BaseUnits? ret = AddPrefixToBaseUnits(dup, string.Join("", words.Take(i + 1)), prefix);
                if (ret is not null)
                    return ret;
            }

            return null;
        }

        private static BaseUnits? AddPrefixToBaseUnits(BaseUnits? ret, string firstWord, Prefix prefix)
        {
            if (ret is null) return null;

            if (ret.N is not null && ret.N == firstWord)
            {
                ret.N = prefix + ret.N.ToCamelCase();
                return ret;
            }

            if (ret.I is not null && ret.I == firstWord)
            {
                ret.I = prefix + ret.I.ToCamelCase();
                return ret;
            }

            if (ret.L is not null && ret.L == firstWord)
            {
                ret.L = prefix + ret.L.ToCamelCase();
                return ret;
            }

            if (ret.J is not null && ret.J == firstWord)
            {
                ret.J = prefix + ret.J.ToCamelCase();
                return ret;
            }

            if (ret.M is not null && ret.M == firstWord)
            {
                ret.M = prefix + ret.M.ToCamelCase();
                return ret;
            }

            if (ret.Θ is not null && ret.Θ == firstWord)
            {
                ret.Θ = prefix + ret.Θ.ToCamelCase();
                return ret;
            }

            if (ret.T is not null && ret.T == firstWord)
            {
                ret.T = prefix + ret.T.ToCamelCase();
                return ret;
            }

            return null;
        }

        private static string[] ToWords(string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {m.Value[1]}")
                .Split(' ');
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
                if (loc.TryGetAbbreviationsForPrefix(prefixInfo.Prefix, out string[]? unitAbbreviationsForPrefix))
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
