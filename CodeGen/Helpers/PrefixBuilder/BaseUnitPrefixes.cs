// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Helpers.PrefixBuilder;

/// <summary>
///     Represents a collection of base unit prefixes and their associated mappings.
/// </summary>
/// <remarks>
///     This class provides functionality to manage and retrieve mappings between base units and their prefixed
///     counterparts,
///     including scale factors and prefixed unit names. It supports operations such as creating mappings from a collection
///     of base units and finding matching prefixes for specific units.
/// </remarks>
internal class BaseUnitPrefixes
{
    /// <summary>
    ///     A dictionary that maps metric prefixes to their corresponding exponent values.
    /// </summary>
    /// <remarks>
    ///     This dictionary excludes binary prefixes such as Kibi, Mebi, Gibi, Tebi, Pebi, and Exbi.
    /// </remarks>
    private static readonly Dictionary<Prefix, int> MetricPrefixFactors = PrefixInfo.Entries.Where(x => x.Key.IsMetricPrefix())
        .ToDictionary(pair => pair.Key, pair => pair.Value.GetDecimalExponent());

    /// <summary>
    ///     A dictionary that maps the exponent values to their corresponding <see cref="Prefix" />.
    ///     This is used to find the appropriate prefix for a given factor.
    /// </summary>
    private static readonly Dictionary<int, Prefix> PrefixFactorsByValue = MetricPrefixFactors.ToDictionary(pair => pair.Value, pair => pair.Key);

    /// <summary>
    ///     Lookup of prefixed unit name from base unit + prefix pairs, such as ("Gram", Prefix.Kilo) => "Kilogram".
    /// </summary>
    private readonly Dictionary<BaseUnitPrefix, string> _baseUnitPrefixConversions;

    /// <summary>
    ///     A dictionary that maps prefixed unit strings to their corresponding base unit and fractional factor.
    /// </summary>
    /// <remarks>
    ///     This dictionary is used to handle units with SI prefixes, allowing for the conversion of prefixed units
    ///     to their base units and the associated fractional factors. The keys are the prefixed unit strings, and the values
    ///     are tuples containing the base unit string and the fractional factor.
    /// </remarks>
    private readonly Dictionary<string, PrefixScaleFactor> _prefixedStringFactors;

    private BaseUnitPrefixes(Dictionary<string, PrefixScaleFactor> prefixedStringFactors, Dictionary<BaseUnitPrefix, string> baseUnitPrefixConversions)
    {
        _prefixedStringFactors = prefixedStringFactors;
        _baseUnitPrefixConversions = baseUnitPrefixConversions;
    }

    /// <summary>
    ///     Creates an instance of <see cref="BaseUnitPrefixes" /> from a collection of base units.
    /// </summary>
    /// <param name="baseUnits">
    ///     A collection of base units, each containing a singular name and associated prefixes.
    /// </param>
    /// <returns>
    ///     A new instance of <see cref="BaseUnitPrefixes" /> containing mappings of base units
    ///     and their prefixed counterparts.
    /// </returns>
    /// <remarks>
    ///     This method processes the provided base units to generate mappings between base unit prefixes
    ///     and their corresponding prefixed unit names, as well as scale factors for each prefixed unit.
    /// </remarks>
    public static BaseUnitPrefixes FromBaseUnits(IEnumerable<Unit> baseUnits)
    {
        var baseUnitPrefixConversions = new Dictionary<BaseUnitPrefix, string>();
        var prefixedStringFactors = new Dictionary<string, PrefixScaleFactor>();
        foreach (Unit baseUnit in baseUnits)
        {
            var unitName = baseUnit.SingularName;
            prefixedStringFactors[unitName] = new PrefixScaleFactor(unitName, 0);
            baseUnitPrefixConversions[new BaseUnitPrefix(unitName, null)] = unitName;
            foreach (Prefix prefix in baseUnit.Prefixes)
            {
                var prefixedUnitName = prefix + unitName.ToCamelCase();
                baseUnitPrefixConversions[new BaseUnitPrefix(unitName, prefix)] = prefixedUnitName;
                prefixedStringFactors[prefixedUnitName] = new PrefixScaleFactor(unitName, MetricPrefixFactors[prefix]);
            }
        }

        return new BaseUnitPrefixes(prefixedStringFactors, baseUnitPrefixConversions);
    }

    /// <summary>
    ///     Attempts to find a matching prefix for a given unit name, exponent, and prefix.
    /// </summary>
    /// <param name="unitName">
    ///     The name of the unit to match. For example, "Meter".
    /// </param>
    /// <param name="exponent">
    ///     The exponent associated with the unit. For example, 3 for cubic meters.
    /// </param>
    /// <param name="prefix">
    ///     The prefix to match. For example, <see cref="Prefix.Kilo" />.
    /// </param>
    /// <param name="matchingPrefix">
    ///     When this method returns, contains the matching <see cref="BaseUnitPrefix" /> if a match is found;
    ///     otherwise, the default value of <see cref="BaseUnitPrefix" />.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if a matching prefix is found; otherwise, <see langword="false" />.
    /// </returns>
    /// <remarks>
    ///     This method determines if a given unit can be associated with a specific prefix, given the exponent of the
    ///     associated dimension.
    /// </remarks>
    internal bool TryGetMatchingPrefix(string unitName, int exponent, Prefix prefix, out BaseUnitPrefix matchingPrefix)
    {
        if (exponent == 0 || !_prefixedStringFactors.TryGetValue(unitName, out PrefixScaleFactor? targetPrefixFactor))
        {
            matchingPrefix = default;
            return false;
        }

        if (MetricPrefixFactors.TryGetValue(prefix, out var prefixFactor))
        {
            var (quotient, remainder) = int.DivRem(prefixFactor, exponent);
            // Ensure the prefix factor is divisible by the exponent without a remainder and that there is a valid prefix matching the target scale
            if (remainder == 0)
            {
                if (targetPrefixFactor.ScaleFactor + quotient == 0)
                {
                    // when the resulting exponent is 0: return the non-prefixed BaseUnit
                    matchingPrefix = new BaseUnitPrefix(targetPrefixFactor.BaseUnit, null);
                    return true;
                }

                if (TryGetPrefixWithScale(targetPrefixFactor.ScaleFactor + quotient, out Prefix calculatedPrefix))
                {
                    matchingPrefix = new BaseUnitPrefix(targetPrefixFactor.BaseUnit, calculatedPrefix);
                    return true;
                }
            }
        }

        matchingPrefix = default;
        return false;
    }

    private static bool TryGetPrefixWithScale(int logScale, out Prefix calculatedPrefix)
    {
        return PrefixFactorsByValue.TryGetValue(logScale, out calculatedPrefix);
    }

    /// <summary>
    ///     Attempts to retrieve the prefixed unit name for a given base unit and prefix combination.
    /// </summary>
    /// <param name="prefix">
    ///     A <see cref="BaseUnitPrefix" /> representing the combination of a base unit and a prefix.
    /// </param>
    /// <param name="prefixedUnitName">
    ///     When this method returns, contains the prefixed unit name if the lookup was successful; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the prefixed unit name was successfully retrieved; otherwise, <c>false</c>.
    /// </returns>
    internal bool TryGetPrefixForUnit(BaseUnitPrefix prefix, [NotNullWhen(true)] out string? prefixedUnitName)
    {
        return _baseUnitPrefixConversions.TryGetValue(prefix, out prefixedUnitName);
    }

    /// <summary>
    ///     Represents the scaling factor that is required for converting from the <see cref="BaseUnit" />.
    /// </summary>
    /// <param name="BaseUnit">Name of base unit, e.g. "Meter".</param>
    /// <param name="ScaleFactor">The log-scale factor, e.g. 3 for kilometer.</param>
    private record PrefixScaleFactor(string BaseUnit, int ScaleFactor);
}
