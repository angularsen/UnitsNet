// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
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
                var quantity = JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(jsonFileName), JsonSerializerSettings)
                               ?? throw new UnitsNetCodeGenException($"Unable to parse quantity from JSON file: {jsonFileName}");

                AddPrefixUnits(quantity);
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
            quantity.Units = quantity.Units.OrderBy(u => u.SingularName, StringComparer.OrdinalIgnoreCase).ToArray();
        }

        private static void AddPrefixUnits(Quantity quantity)
        {
            var unitsToAdd = new List<Unit>();
            foreach (Unit unit in quantity.Units)
            foreach (Prefix prefix in unit.Prefixes)
            {
                try
                {
                    var prefixInfo = PrefixInfo.Entries[prefix];

                    unitsToAdd.Add(new Unit
                    {
                        SingularName = $"{prefix}{unit.SingularName.ToCamelCase()}", // "Kilo" + "NewtonPerMeter" => "KilonewtonPerMeter"
                        PluralName = $"{prefix}{unit.PluralName.ToCamelCase()}", // "Kilo" + "NewtonsPerMeter" => "KilonewtonsPerMeter"
                        BaseUnits = GetPrefixedBaseUnits(quantity.BaseDimensions, unit.BaseUnits, prefixInfo),
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

        /// <summary>
        ///     TODO Improve me, give an overall explanation of the algorithm and 1-2 concrete examples.
        /// </summary>
        /// <param name="dimensions">SI base unit dimensions of quantity, e.g. L=1 for Length or L=1,T=-1 for Speed.</param>
        /// <param name="baseUnits">SI base units for a non-prefixed unit, e.g. L=Meter for Length.Meter or L=Meter,T=Second for Speed.MeterPerSecond.</param>
        /// <param name="prefixInfo">Information about the prefix to apply.</param>
        /// <returns>A new instance of <paramref name="baseUnits"/> after applying the metric prefix <paramref name="prefixInfo"/>.</returns>
        private static BaseUnits? GetPrefixedBaseUnits(BaseDimensions dimensions, BaseUnits? baseUnits, PrefixInfo prefixInfo)
        {
            if (baseUnits is null) return null;

            // Iterate the non-zero dimension exponents in absolute-increasing order, positive first [1, -1, 2, -2...n, -n]
            foreach (int degree in dimensions.GetNonZeroDegrees().OrderBy(int.Abs).ThenByDescending(x => x))
            {
                if (TryPrefixWithDegree(dimensions, baseUnits, prefixInfo.Prefix, degree, out BaseUnits? prefixedUnits))
                {
                    return prefixedUnits;
                }
            }

            return null;
        }

        private static IEnumerable<int> GetNonZeroDegrees(this BaseDimensions dimensions)
        {
            if (dimensions.I != 0)
            {
                yield return dimensions.I;
            }

            if (dimensions.J != 0)
            {
                yield return dimensions.J;
            }

            if (dimensions.L != 0)
            {
                yield return dimensions.L;
            }

            if (dimensions.M != 0)
            {
                yield return dimensions.M;
            }

            if (dimensions.N != 0)
            {
                yield return dimensions.N;
            }

            if (dimensions.T != 0)
            {
                yield return dimensions.T;
            }

            if (dimensions.Θ != 0)
            {
                yield return dimensions.Θ;
            }
        }

        /// <summary>
        ///     TODO Explain this, in particular the degree/exponent stuff.
        /// </summary>
        /// <param name="dimensions"></param>
        /// <param name="baseUnits"></param>
        /// <param name="prefix"></param>
        /// <param name="degree"></param>
        /// <param name="prefixedBaseUnits"></param>
        /// <returns></returns>
        private static bool TryPrefixWithDegree(BaseDimensions dimensions, BaseUnits baseUnits, Prefix prefix, int degree, [NotNullWhen(true)] out BaseUnits? prefixedBaseUnits)
        {
            prefixedBaseUnits = baseUnits.Clone();

            // look for a dimension that is part of the non-zero exponents
            if (baseUnits.N is { } baseAmountUnit && dimensions.N == degree)
            {
                if (TryPrefixUnit(baseAmountUnit, degree, prefix, out var newAmount))
                {
                    prefixedBaseUnits.N = newAmount;
                    return true;
                }
            }

            if (baseUnits.I is { } baseCurrentUnit && dimensions.I == degree)
            {
                if (TryPrefixUnit(baseCurrentUnit, degree, prefix, out var newCurrent))
                {
                    prefixedBaseUnits.I = newCurrent;
                    return true;
                }
            }

            if (baseUnits.L is {} baseLengthUnit && dimensions.L == degree)
            {
                if (TryPrefixUnit(baseLengthUnit, degree, prefix, out var newLength))
                {
                    prefixedBaseUnits.L = newLength;
                    return true;
                }
            }

            if (baseUnits.J is { } baseLuminosityUnit && dimensions.J == degree)
            {
                if (TryPrefixUnit(baseLuminosityUnit, degree, prefix, out var newLuminosity))
                {
                    prefixedBaseUnits.J = newLuminosity;
                    return true;
                }
            }

            if (baseUnits.M is {} baseMassUnit && dimensions.M == degree)
            {
                if (TryPrefixUnit(baseMassUnit, degree, prefix, out var newMass))
                {
                    prefixedBaseUnits.M = newMass;
                    return true;
                }
            }

            if (baseUnits.Θ is {} baseTemperatureUnit && dimensions.Θ == degree)
            {
                if (TryPrefixUnit(baseTemperatureUnit, degree, prefix, out var newTemperature))
                {
                    prefixedBaseUnits.Θ = newTemperature;
                    return true;
                }
            }

            if (baseUnits.T is {} baseDurationUnit && dimensions.T == degree)
            {
                if (TryPrefixUnit(baseDurationUnit, degree, prefix, out var newTime))
                {
                    prefixedBaseUnits.T = newTime;
                    return true;
                }
            }

            return false;
        }

        private static bool TryPrefixUnit(string unitName, int degree, Prefix prefix, [NotNullWhen(true)] out string? prefixedUnitName)
        {
            if (PrefixedStringFactors.TryGetValue(unitName, out UnitPrefixMap? prefixMap) && PrefixFactors.TryGetValue(prefix, out var prefixFactor))
            {
                var (quotient, remainder) = int.DivRem(prefixFactor, degree);
                if (remainder == 0 && PrefixFactorsByValue.TryGetValue(prefixMap.ScaleFactor + quotient, out Prefix calculatedPrefix))
                {
                    if (BaseUnitPrefixConversions.TryGetValue((prefixMap.BaseUnit, calculatedPrefix), out prefixedUnitName))
                    {
                        return true;
                    }
                }
            }

            prefixedUnitName = null;
            return false;
        }

        /// <summary>
        /// A dictionary that maps metric prefixes to their corresponding exponent values.
        /// </summary>
        /// <remarks>
        /// This dictionary excludes binary prefixes such as Kibi, Mebi, Gibi, Tebi, Pebi, and Exbi.
        /// </remarks>
        private static readonly Dictionary<Prefix, int> PrefixFactors = PrefixInfo.Entries
            .Where(x => x.Key is not (Prefix.Kibi or Prefix.Mebi or Prefix.Gibi or Prefix.Tebi or Prefix.Pebi or Prefix.Exbi)).ToDictionary(pair => pair.Key,
                pair => (int)Math.Log10(double.Parse(pair.Value.Factor.TrimEnd('d'), NumberStyles.Any, CultureInfo.InvariantCulture)));

        /// <summary>
        /// A dictionary that maps the exponent values to their corresponding <see cref="Prefix"/>.
        /// This is used to find the appropriate prefix for a given factor.
        /// </summary>
        private static readonly Dictionary<int, Prefix> PrefixFactorsByValue = PrefixFactors.ToDictionary(pair => pair.Value, pair => pair.Key);

        /// <summary>
        /// A dictionary that maps prefixed unit strings to their corresponding base unit and fractional factor.
        /// </summary>
        /// <remarks>
        /// This dictionary is used to handle units with SI prefixes, allowing for the conversion of prefixed units
        /// to their base units and the associated fractional factors. The keys are the prefixed unit strings, and the values
        /// are tuples containing the base unit string and the fractional factor.
        /// </remarks>
        private static readonly Dictionary<string, UnitPrefixMap> PrefixedStringFactors = GetSIPrefixes()
            .SelectMany(pair => pair.Value
                .Select(prefix => new KeyValuePair<string, UnitPrefixMap>(prefix + pair.Key.ToCamelCase(), new UnitPrefixMap(pair.Key, PrefixFactors[prefix])))
                .Prepend(new KeyValuePair<string, UnitPrefixMap>(pair.Key, new UnitPrefixMap(pair.Key, 0)))).ToDictionary();

        /// <summary>
        ///     Describes how to convert from base unit to prefixed unit.
        /// </summary>
        /// <param name="BaseUnit">Name of base unit, e.g. "Meter".</param>
        /// <param name="ScaleFactor">Scale factor, e.g. 1000 for kilometer.</param>
        private record UnitPrefixMap(string BaseUnit, int ScaleFactor);

        /// <summary>
        ///     Lookup of prefixed unit name from base unit + prefix pairs, such as ("Gram", Prefix.Kilo) => "Kilogram".
        /// </summary>
        private static readonly Dictionary<(string, Prefix), string> BaseUnitPrefixConversions = GetSIPrefixes()
            .SelectMany(pair => pair.Value.Select(prefix => (pair.Key, prefix))).ToDictionary(tuple => tuple, tuple => tuple.prefix + tuple.Key.ToCamelCase());

        private static IEnumerable<KeyValuePair<string, Prefix[]>> GetSIPrefixes()
        {
            return GetAmountOfSubstancePrefixes()
                .Concat(GetElectricCurrentPrefixes())
                .Concat(GetMassPrefixes())
                .Concat(GetLengthPrefixes())
                .Concat(GetDurationPrefixes());
        }

        private static IEnumerable<KeyValuePair<string, Prefix[]>> GetAmountOfSubstancePrefixes()
        {
            yield return new KeyValuePair<string, Prefix[]>("Mole",
                [Prefix.Femto, Prefix.Pico, Prefix.Nano, Prefix.Micro, Prefix.Milli, Prefix.Centi, Prefix.Deci, Prefix.Kilo, Prefix.Mega]);
            yield return new KeyValuePair<string, Prefix[]>("PoundMole", [Prefix.Nano, Prefix.Micro, Prefix.Milli, Prefix.Centi, Prefix.Deci, Prefix.Kilo]);
        }

        private static IEnumerable<KeyValuePair<string, Prefix[]>> GetElectricCurrentPrefixes()
        {
            yield return new KeyValuePair<string, Prefix[]>("Ampere",
                [Prefix.Femto, Prefix.Pico, Prefix.Nano, Prefix.Micro, Prefix.Milli, Prefix.Centi, Prefix.Kilo, Prefix.Mega]);
        }

        private static IEnumerable<KeyValuePair<string, Prefix[]>> GetMassPrefixes()
        {
            yield return new KeyValuePair<string, Prefix[]>("Gram",
                [Prefix.Femto, Prefix.Pico, Prefix.Nano, Prefix.Micro, Prefix.Milli, Prefix.Centi, Prefix.Deci, Prefix.Deca, Prefix.Hecto, Prefix.Kilo]);
            yield return new KeyValuePair<string, Prefix[]>("Tonne", [Prefix.Kilo, Prefix.Mega]);
            yield return new KeyValuePair<string, Prefix[]>("Pound", [Prefix.Kilo, Prefix.Mega]);
        }

        private static IEnumerable<KeyValuePair<string, Prefix[]>> GetLengthPrefixes()
        {
            yield return new KeyValuePair<string, Prefix[]>("Meter",
            [
                Prefix.Femto, Prefix.Pico, Prefix.Nano, Prefix.Micro, Prefix.Milli, Prefix.Centi, Prefix.Deci, Prefix.Deca, Prefix.Hecto, Prefix.Kilo,
                Prefix.Mega, Prefix.Giga
            ]);
            yield return new KeyValuePair<string, Prefix[]>("Yard", [Prefix.Kilo]);
            yield return new KeyValuePair<string, Prefix[]>("Foot", [Prefix.Kilo]);
            yield return new KeyValuePair<string, Prefix[]>("Parsec", [Prefix.Kilo, Prefix.Mega]);
            yield return new KeyValuePair<string, Prefix[]>("LightYear", [Prefix.Kilo, Prefix.Mega]);
        }

        private static IEnumerable<KeyValuePair<string, Prefix[]>> GetDurationPrefixes()
        {
            yield return new KeyValuePair<string, Prefix[]>("Second", [Prefix.Nano, Prefix.Micro, Prefix.Milli]);
        }
    }
}
