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
                        BaseUnits = GetBaseUnitFromPrefix(unit, prefix), // Can we determine this better somehow?
                        FromBaseToUnitFunc = $"({unit.FromBaseToUnitFunc}) / {prefixInfo.Factor}",
                        FromUnitToBaseFunc = $"({unit.FromUnitToBaseFunc}) * {prefixInfo.Factor}",
                        Localization = GetLocalizationForPrefixUnit(unit.Localization, prefixInfo),
                        ObsoleteText = unit.ObsoleteText,
                        SkipConversionGeneration = unit.SkipConversionGeneration,
                        AllowAbbreviationLookup = unit.AllowAbbreviationLookup
                    } );
                }
                catch (Exception e)
                {
                    throw new Exception($"Error parsing prefix {prefix} for unit {quantity.Name}.{unit.SingularName}.", e);
                }
            }

            quantity.Units = quantity.Units.Concat(unitsToAdd).ToArray();
        }

        private static BaseUnits? GetBaseUnitFromPrefix(Unit unit, Prefix prefix)
        {
            if (unit.BaseUnits is null)
                return null;
            BaseUnits? dup = JsonConvert.DeserializeObject<BaseUnits>(JsonConvert.SerializeObject(unit.BaseUnits));
            string[] words = ToWords(unit.SingularName);
            //First Word is not Enough (Ex. PoundMole)
            for (int i = 0; i < words.Length; i++)
            {
                BaseUnits? ret = AddPrefixToBaseUnits(dup, string.Join("", words.Take(i + 1)), prefix);
                if (ret is not null)
                    return ret;
            }
            
            return null;
        }

        private static BaseUnits? AddPrefixToBaseUnits(BaseUnits? ret, string firstWord, Prefix prefix)
        {
            if (ret is null)
                return null;
            else if (ret.N is not null && ret.N == firstWord)
            {
                ret.N = prefix.ToString() + ret.N.ToCamelCase();
                return ret;
            }
            else if (ret.I is not null && ret.I == firstWord)
            {
                ret.I = prefix.ToString() + ret.I.ToCamelCase();
                return ret;
            }
            else if (ret.L is not null && ret.L == firstWord)
            {
                ret.L = prefix.ToString() + ret.L.ToCamelCase();
                return ret;
            }
            else if (ret.J is not null && ret.J == firstWord)
            {
                ret.J = prefix.ToString() + ret.J.ToCamelCase();
                return ret;
            }
            else if (ret.M is not null && ret.M == firstWord)
            {
                ret.M = prefix.ToString() + ret.M.ToCamelCase();
                return ret;
            }
            else if (ret.Θ is not null && ret.Θ == firstWord)
            {
                ret.Θ = prefix.ToString() + ret.Θ.ToCamelCase();
                return ret;
            }
            else if (ret.T is not null && ret.T == firstWord)
            {
                ret.T = prefix.ToString() + ret.T.ToCamelCase();
                return ret;
            }
            else
                return null;
        }

        public static string[] ToWords(string str)
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
