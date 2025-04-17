// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet;

/// <summary>
///     Parses units given a unit abbreviations cache.
///     A static instance is created in the <see cref="UnitsNetSetup.Default" />, which is used internally to parse
///     quantities and units using the
///     default abbreviations cache for all units and abbreviations defined in the library.
/// </summary>
public sealed class UnitParser
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitParser" /> class using the specified collection of quantity
    ///     information.
    /// </summary>
    /// <param name="quantities">
    ///     A read-only collection of quantity information used to initialize the unit abbreviations cache.
    /// </param>
    public UnitParser(IReadOnlyCollection<QuantityInfo> quantities)
        : this(new UnitAbbreviationsCache(quantities))
    {
    }

    internal UnitParser(QuantityInfoLookup quantitiesLookup)
        : this(new UnitAbbreviationsCache(quantitiesLookup))
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitParser" /> class using the specified unit abbreviations cache.
    /// </summary>
    /// <param name="unitAbbreviationsCache">
    ///     The cache containing unit abbreviations. If null, the default cache will be used.
    /// </param>
    public UnitParser(UnitAbbreviationsCache unitAbbreviationsCache)
    {
        Abbreviations = unitAbbreviationsCache ?? throw new ArgumentNullException(nameof(unitAbbreviationsCache));
    }

    /// <summary>
    ///     Gets the <see cref="UnitAbbreviationsCache" /> instance used by this <see cref="UnitParser" />.
    ///     This cache contains mappings of unit abbreviations to their corresponding units, enabling efficient
    ///     parsing and retrieval of unit information.
    /// </summary>
    public UnitAbbreviationsCache Abbreviations { get; }

    /// <summary>
    ///     Gets the collection of quantities available in this <see cref="UnitParser" /> instance.
    /// </summary>
    /// <remarks>
    ///     This property provides access to the <see cref="QuantityInfoLookup" /> that contains
    ///     information about all quantities and their associated units.
    /// </remarks>
    public QuantityInfoLookup Quantities
    {
        get => Abbreviations.Quantities;
    }

    /// <summary>
    ///     The default static instance used internally to parse quantities and units using the
    ///     default abbreviations cache for all units and abbreviations defined in the library.
    /// </summary>
    public static UnitParser Default => UnitsNetSetup.Default.UnitParser;

    /// <summary>
    ///     Creates a default instance of the <see cref="UnitParser" /> class with all the built-in unit abbreviations defined
    ///     in the library.
    /// </summary>
    /// <returns>A <see cref="UnitParser" /> instance with the default abbreviations cache.</returns>
    public static UnitParser CreateDefault()
    {
        return new UnitParser(UnitAbbreviationsCache.CreateDefault());
    }

    /// <summary>
    ///     Creates an instance of <see cref="UnitParser" /> with the default quantities.
    /// </summary>
    /// <param name="configureQuantities">An action to configure the default quantities.</param>
    /// <returns>An instance of <see cref="UnitParser" /> configured with the default quantities.</returns>
    public static UnitParser CreateDefault(Action<QuantitiesSelector> configureQuantities)
    {
        return new UnitParser(UnitAbbreviationsCache.CreateDefault(configureQuantities));
    }

    /// <summary>
    ///     Creates an instance of <see cref="UnitParser" /> with the default quantities.
    /// </summary>
    /// <param name="configureQuantities">An action to configure the default quantities.</param>
    /// <param name="configureAbbreviations">
    ///     An action to configure the unit abbreviations.
    /// </param>
    /// <returns>An instance of <see cref="UnitParser" /> configured with the default quantities.</returns>
    public static UnitParser CreateDefault(Action<QuantitiesSelector> configureQuantities, Action<UnitAbbreviationsCache> configureAbbreviations)
    {
        var unitAbbreviationsCache = UnitAbbreviationsCache.CreateDefault(configureQuantities);
        configureAbbreviations(unitAbbreviationsCache);
        return new UnitParser(unitAbbreviationsCache);
    }

    /// <summary>
    ///     Creates an instance of the <see cref="UnitParser" /> class.
    /// </summary>
    /// <param name="defaultQuantities">A collection of default quantities to be used by the <see cref="UnitParser" />.</param>
    /// <param name="configureQuantities">An action to configure the quantities using a <see cref="QuantitiesSelector" />.</param>
    /// <returns>A new instance of the <see cref="UnitParser" /> class.</returns>
    public static UnitParser Create(IEnumerable<QuantityInfo> defaultQuantities, Action<QuantitiesSelector> configureQuantities)
    {
        return new UnitParser(UnitAbbreviationsCache.Create(defaultQuantities, configureQuantities));
    }

    /// <summary>
    ///     Creates an instance of the <see cref="UnitParser" /> class.
    /// </summary>
    /// <param name="defaultQuantities">A collection of default quantities to be used by the <see cref="UnitParser" />.</param>
    /// <param name="configureQuantities">An action to configure the quantities using a <see cref="QuantitiesSelector" />.</param>
    /// <param name="configureAbbreviations">
    ///     An action to configure the unit abbreviations.
    /// </param>
    /// <returns>A new instance of the <see cref="UnitParser" /> class.</returns>
    public static UnitParser Create(IEnumerable<QuantityInfo> defaultQuantities, Action<QuantitiesSelector> configureQuantities,
        Action<UnitAbbreviationsCache> configureAbbreviations)
    {
        var unitAbbreviationsCache = UnitAbbreviationsCache.Create(defaultQuantities, configureQuantities);
        configureAbbreviations(unitAbbreviationsCache);
        return new UnitParser(unitAbbreviationsCache);
    }

    /// <summary>
    ///     Parses a unit abbreviation for a given unit enumeration type.
    ///     Example: Parse&lt;LengthUnit&gt;("km") => LengthUnit.Kilometer
    /// </summary>
    /// <param name="unitAbbreviation"></param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <typeparam name="TUnitType"></typeparam>
    /// <returns></returns>
    public TUnitType Parse<TUnitType>(string unitAbbreviation, IFormatProvider? formatProvider = null)
        where TUnitType : struct, Enum
    {
        if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));

        QuantityInfo quantityInfo = Quantities.GetQuantityByUnitType(typeof(TUnitType));
        return Parse(unitAbbreviation, quantityInfo.UnitInfos, formatProvider).UnitKey.ToUnit<TUnitType>();
    }

    /// <summary>
    ///     Parse a unit abbreviation, such as "kg" or "m", to the unit enum value of the enum type
    ///     <paramref name="unitType" />.
    /// </summary>
    /// <param name="unitAbbreviation">
    ///     Unit abbreviation, such as "kg" or "m" for <see cref="MassUnit.Kilogram" /> and
    ///     <see cref="LengthUnit.Meter" /> respectively.
    /// </param>
    /// <param name="unitType">Unit enum type, such as <see cref="MassUnit" /> and <see cref="LengthUnit" />.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <returns>Unit enum value, such as <see cref="MassUnit.Kilogram" />.</returns>
    /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
    /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
    public Enum Parse(string unitAbbreviation, Type unitType, IFormatProvider? formatProvider = null)
    {
        if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));

        QuantityInfo quantityInfo = Quantities.GetQuantityByUnitType(unitType);
        return Parse(unitAbbreviation, quantityInfo.UnitInfos, formatProvider).Value;
    }

    /// <summary>
    ///     Retrieves the <see cref="UnitInfo" /> corresponding to the specified unit abbreviation within a given quantity.
    /// </summary>
    /// <param name="quantityName">The name of the quantity to which the unit belongs.</param>
    /// <param name="unitAbbreviation">The abbreviation of the unit to retrieve.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <returns>
    ///     The <see cref="UnitInfo" /> that matches the specified unit abbreviation within the given quantity.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown if the specified <paramref name="quantityName" /> does not correspond to a known quantity.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if the <paramref name="unitAbbreviation" /> cannot be resolved to a valid unit for the specified quantity.
    /// </exception>
    /// <remarks>
    ///     When a specific <paramref name="formatProvider"/> is provided, both localized and non-localized units would be compared.
    ///     <para>Both the <paramref name="quantityName" /> and the <paramref name="unitAbbreviation" /> comparisons are case-insensitive.</para>
    /// </remarks>
    public UnitInfo GetUnitFromAbbreviation(string quantityName, string unitAbbreviation, IFormatProvider? formatProvider)
    {
        if (quantityName == null) throw new ArgumentNullException(nameof(quantityName));
        if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));

        QuantityInfo quantityInfo = Quantities.GetQuantityByName(quantityName);
        return Parse(unitAbbreviation, quantityInfo.UnitInfos, formatProvider);
    }

    /// <summary>
    ///     Retrieves the <see cref="UnitInfo" /> corresponding to the specified unit abbreviation within a given quantity.
    /// </summary>
    /// <param name="quantityType">The type of the quantity to which the unit belongs.</param>
    /// <param name="unitAbbreviation">The abbreviation of the unit to retrieve.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <returns>
    ///     The <see cref="UnitInfo" /> that matches the specified unit abbreviation within the given quantity.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown if the specified <paramref name="quantityType" /> does not correspond to a known quantity.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if the <paramref name="unitAbbreviation" /> cannot be resolved to a valid unit for the specified quantity.
    /// </exception>
    /// <remarks>
    ///     When a specific <paramref name="formatProvider" /> is provided, both localized and non-localized units would be compared.
    ///     <para>The <paramref name="unitAbbreviation" /> comparisons are case-insensitive.</para>
    /// </remarks>
    public UnitInfo GetUnitFromAbbreviation(Type quantityType, string unitAbbreviation, IFormatProvider? formatProvider)
    {
        if (quantityType == null) throw new ArgumentNullException(nameof(quantityType));
        if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));

        QuantityInfo quantityInfo = Quantities.GetQuantityInfo(quantityType);
        return Parse(unitAbbreviation, quantityInfo.UnitInfos, formatProvider);
    }

    /// <summary>
    ///     Parses the specified unit abbreviation, such as "kg" or "m", to find the corresponding unit information.
    /// </summary>
    /// <typeparam name="TUnitInfo">The type of the unit information.</typeparam>
    /// <param name="unitAbbreviation">The abbreviation of the unit to parse.</param>
    /// <param name="units">A collection of unit information to search through.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <returns>The unit information that matches the specified abbreviation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitAbbreviation" /> is null.</exception>
    /// <exception cref="UnitNotFoundException">Thrown when no matching unit is found.</exception>
    /// <exception cref="AmbiguousUnitParseException">Thrown when multiple matching units are found.</exception>
    internal TUnitInfo Parse<TUnitInfo>(string unitAbbreviation, IReadOnlyList<TUnitInfo> units, IFormatProvider? formatProvider = null)
        where TUnitInfo : UnitInfo
    {
        if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));
        
        if (formatProvider is not CultureInfo culture)
        {
            culture = CultureInfo.CurrentCulture;
        }
        
        unitAbbreviation = unitAbbreviation.Trim();
        while (true)
        {
            List<(TUnitInfo UnitInfo, string Abbreviation)> matches = FindMatchingUnits(unitAbbreviation, units, culture);
            switch (matches.Count)
            {
                case 1:
                    return matches[0].UnitInfo;
                case 0:
                    // Retry with fallback culture, if different.
                    if (UnitAbbreviationsCache.HasFallbackCulture(culture))
                    {
                        culture = UnitAbbreviationsCache.FallbackCulture;
                        continue;
                    }

                    throw new UnitNotFoundException($"Unit not found with abbreviation [{unitAbbreviation}] for unit type [{typeof(TUnitInfo)}].");
                default:
                    var unitsCsv = string.Join(", ", matches.Select(x => $"{x.UnitInfo.Name} (\"{x.Abbreviation}\")").OrderBy(x => x));
                    throw new AmbiguousUnitParseException($"Cannot parse \"{unitAbbreviation}\" since it matches multiple units: {unitsCsv}.");
            }
        }
    }
    

    internal static string NormalizeUnitString(string unitAbbreviation)
    {
        var abbreviationLength = unitAbbreviation.Length;
        if (abbreviationLength == 0)
        {
            return unitAbbreviation;
        }

        // Remove all whitespace using StringBuilder
        var sb = new StringBuilder(abbreviationLength);
        for (var i = 0; i < unitAbbreviation.Length; i++)
        {
            var character = unitAbbreviation[i];
            if (!char.IsWhiteSpace(character))
            {
                sb.Append(character);
            }
        }

        // Perform replacements using StringBuilder
        sb.Replace("^-9", "⁻⁹")
            .Replace("^-8", "⁻⁸")
            .Replace("^-7", "⁻⁷")
            .Replace("^-6", "⁻⁶")
            .Replace("^-5", "⁻⁵")
            .Replace("^-4", "⁻⁴")
            .Replace("^-3", "⁻³")
            .Replace("^-2", "⁻²")
            .Replace("^-1", "⁻¹")
            .Replace("^1", "")
            .Replace("^2", "²")
            .Replace("^3", "³")
            .Replace("^4", "⁴")
            .Replace("^5", "⁵")
            .Replace("^6", "⁶")
            .Replace("^7", "⁷")
            .Replace("^8", "⁸")
            .Replace("^9", "⁹")
            .Replace("*", "·")
            .Replace("\u03bc", "\u00b5"); // Greek letter 'Mu' to Micro sign
        
        return sb.ToString();
    }

    /// <summary>
    ///     Try to parse a unit abbreviation.
    /// </summary>
    /// <param name="unitAbbreviation">The string value.</param>
    /// <param name="unit">The unit enum value as out result.</param>
    /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
    /// <returns>True if successful.</returns>
    public bool TryParse<TUnitType>([NotNullWhen(true)] string? unitAbbreviation, out TUnitType unit)
        where TUnitType : struct, Enum
    {
        return TryParse(unitAbbreviation, null, out unit);
    }

    /// <summary>
    ///     Try to parse a unit abbreviation.
    /// </summary>
    /// <param name="unitAbbreviation">The string value.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <param name="unit">The unit enum value as out result.</param>
    /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
    /// <returns>True if successful.</returns>
    public bool TryParse<TUnitType>([NotNullWhen(true)] string? unitAbbreviation, IFormatProvider? formatProvider, out TUnitType unit)
        where TUnitType : struct, Enum
    {
        if (!TryParse(unitAbbreviation, typeof(TUnitType), formatProvider, out Enum? unitObj))
        {
            unit = default;
            return false;
        }

        unit = (TUnitType)unitObj;
        return true;
    }

    /// <summary>
    ///     Try to parse a unit abbreviation.
    /// </summary>
    /// <param name="unitAbbreviation">The string value.</param>
    /// <param name="unitType">Type of unit enum.</param>
    /// <param name="unit">The unit enum value as out result.</param>
    /// <returns>True if successful.</returns>
    public bool TryParse([NotNullWhen(true)]string? unitAbbreviation, Type unitType, [NotNullWhen(true)] out Enum? unit)
    {
        return TryParse(unitAbbreviation, unitType, null, out unit);
    }

    /// <summary>
    ///     Try to parse a unit abbreviation.
    /// </summary>
    /// <param name="unitAbbreviation">The string value.</param>
    /// <param name="unitType">Type of unit enum.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <param name="unit">The unit enum value as out result.</param>
    /// <returns>True if successful.</returns>
    public bool TryParse([NotNullWhen(true)] string? unitAbbreviation, Type unitType, IFormatProvider? formatProvider, [NotNullWhen(true)] out Enum? unit)
    {
        if (unitAbbreviation == null)
        {
            unit = null;
            return false;
        }

        if (Quantities.TryGetQuantityByUnitType(unitType, out QuantityInfo? quantityInfo) &&
            TryParse(unitAbbreviation, quantityInfo.UnitInfos, formatProvider, out UnitInfo? unitInfo))
        {
            unit = unitInfo.Value;
            return true;
        }

        unit = null;
        return false;
    }

    /// <summary>
    ///     Attempts to parse the specified unit abbreviation, such as "kg" or "m", into a unit of the specified type.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit enumeration.</typeparam>
    /// <param name="unitAbbreviation">The unit abbreviation to parse.</param>
    /// <param name="quantityInfo">The quantity information that provides context for the unit.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <param name="unit">
    ///     When this method returns, contains the parsed unit if the parsing succeeded, or <c>null</c> if the parsing failed.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the unit abbreviation was successfully parsed; otherwise, <c>false</c>.
    /// </returns>
    internal bool TryParse<TUnit>([NotNullWhen(true)] string? unitAbbreviation, QuantityInfo<TUnit> quantityInfo, IFormatProvider? formatProvider,
        out TUnit unit)
        where TUnit : struct, Enum
    {
        if (TryParse(unitAbbreviation, quantityInfo.UnitInfos, formatProvider, out UnitInfo<TUnit>? unitInfo))
        {
            unit = unitInfo.Value;
            return true;
        }

        unit = default;
        return false;
    }


    /// <summary>
    ///     Attempts to retrieve the <see cref="UnitInfo" /> corresponding to the specified unit abbreviation within a given
    ///     quantity.
    /// </summary>
    /// <param name="quantityName">The name of the quantity to which the unit belongs.</param>
    /// <param name="unitAbbreviation">
    ///     The abbreviation of the unit to retrieve. Can be <c>null</c>, in which case the method will return <c>false</c>.
    /// </param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <param name="unitInfo">
    ///     When this method returns, contains the <see cref="UnitInfo" /> that matches the specified unit abbreviation
    ///     within the given quantity, if the operation succeeds; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the unit abbreviation was successfully resolved to a <see cref="UnitInfo" />; otherwise,
    ///     <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     This method does not throw exceptions for invalid input or unresolved unit abbreviations. Instead, it returns
    ///     <c>false</c>.
    /// </remarks>
    public bool TryGetUnitFromAbbreviation(string quantityName, string? unitAbbreviation, IFormatProvider? formatProvider, [NotNullWhen(true)] out UnitInfo? unitInfo)
    {
        if (unitAbbreviation != null && Quantities.TryGetQuantityByName(quantityName, out QuantityInfo? quantityInfo))
        {
            return TryParse(unitAbbreviation, quantityInfo.UnitInfos, formatProvider, out unitInfo);
        }

        unitInfo = null;
        return false;
    }
    
    /// <summary>
    ///     Attempts to match the provided unit abbreviation against the defined abbreviations for the units and returns the
    ///     matching unit information.
    /// </summary>
    /// <typeparam name="TUnitInfo">The type of the unit information.</typeparam>
    /// <param name="unitAbbreviation">The unit abbreviation to match.</param>
    /// <param name="units">The collection of units to match against.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <param name="unit">
    ///     When this method returns, contains the matching unit information if the match was successful; otherwise, the
    ///     default value for the type of the unit parameter.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the unit abbreviation was successfully matched; otherwise, <c>false</c>.
    /// </returns>
    internal bool TryParse<TUnitInfo>([NotNullWhen(true)] string? unitAbbreviation, IReadOnlyList<TUnitInfo> units, IFormatProvider? formatProvider,
        [NotNullWhen(true)] out TUnitInfo? unit)
        where TUnitInfo : UnitInfo
    {
        unit = null;
        if (unitAbbreviation == null)
        {
            return false;
        }
        
        unitAbbreviation = unitAbbreviation.Trim();
        
        if (formatProvider is not CultureInfo culture)
        {
            culture = CultureInfo.CurrentCulture;
        }
        
        List<(TUnitInfo UnitInfo, string Abbreviation)> matches = FindMatchingUnits(unitAbbreviation, units, culture);
        
        if (matches.Count == 1)
        {
            unit = matches[0].UnitInfo;
            return true;
        }

        if (matches.Count != 0 || !UnitAbbreviationsCache.HasFallbackCulture(culture))
        {
            return false; // either there are duplicates or nothing was matched and we're already using the fallback culture
        }

        // retry the lookup using the fallback culture
        matches = FindMatchingUnits(unitAbbreviation, units, UnitAbbreviationsCache.FallbackCulture);
        if (matches.Count != 1)
        {
            return false;
        }
        
        unit = matches[0].UnitInfo;
        return true;
    }

    private List<(TUnitInfo UnitInfo, string Abbreviation)> FindMatchingUnits<TUnitInfo>(string unitAbbreviation, IReadOnlyList<TUnitInfo> units,
        CultureInfo culture)
        where TUnitInfo : UnitInfo
    {
        List<(TUnitInfo UnitInfo, string Abbreviation)> caseInsensitiveMatches = FindMatchingUnitsForCulture(units, unitAbbreviation, culture, StringComparison.OrdinalIgnoreCase);

        if (caseInsensitiveMatches.Count == 0)
        {
            var normalizeUnitString = NormalizeUnitString(unitAbbreviation);
            if (unitAbbreviation == normalizeUnitString)
            {
                return caseInsensitiveMatches;
            }

            unitAbbreviation = normalizeUnitString;
            caseInsensitiveMatches = FindMatchingUnitsForCulture(units, unitAbbreviation, culture, StringComparison.OrdinalIgnoreCase);
            if (caseInsensitiveMatches.Count == 0)
            {
                return caseInsensitiveMatches;
            }
        }

        var nbAbbreviationsFound = caseInsensitiveMatches.Count;
        if (nbAbbreviationsFound == 1)
        {
            return caseInsensitiveMatches;
        }

        // Narrow the search if too many hits, for example Megabar "Mbar" and Millibar "mbar" need to be distinguished
        var caseSensitiveMatches = new List<(TUnitInfo UnitInfo, string Abbreviation)>(nbAbbreviationsFound);
        for (var i = 0; i < nbAbbreviationsFound; i++)
        {
            (TUnitInfo UnitInfo, string Abbreviation) match = caseInsensitiveMatches[i];
            if (unitAbbreviation == match.Abbreviation)
            {
                caseSensitiveMatches.Add(match);
            }
        }

        return caseSensitiveMatches.Count == 0 ? caseInsensitiveMatches : caseSensitiveMatches;
    }

    private List<(TUnitInfo UnitInfo, string Abbreviation)> FindMatchingUnitsForCulture<TUnitInfo>(IReadOnlyList<TUnitInfo> unitInfos, string unitAbbreviation,
        CultureInfo culture, StringComparison comparison)
        where TUnitInfo: UnitInfo
    {
        var unitAbbreviationsPairs = new List<(TUnitInfo, string)>();
        var nbUnits = unitInfos.Count;
        for (var i = 0; i < nbUnits; i++)
        {
            TUnitInfo unitInfo = unitInfos[i];
            IReadOnlyList<string> abbreviations = Abbreviations.GetAbbreviationsForCulture(unitInfo, culture);
            var nbAbbreviations = abbreviations.Count;
            for (var p = 0; p < nbAbbreviations; p++)
            {
                var abbreviation = abbreviations[p];
                if (unitAbbreviation.Equals(abbreviation, comparison))
                {
                    unitAbbreviationsPairs.Add((unitInfo, abbreviation));
                }
            }
        }

        return unitAbbreviationsPairs;
    }


    private List<(UnitInfo UnitInfo, string Abbreviation)> FindAllMatchingUnitsForCulture(string unitAbbreviation, CultureInfo culture,
        StringComparison comparison)
    {
        var unitAbbreviationsPairs = new List<(UnitInfo, string)>();
        foreach (QuantityInfo quantityInfo in Quantities.Infos)
        {
            IReadOnlyList<UnitInfo> unitInfos = quantityInfo.UnitInfos;
            var nbUnits = unitInfos.Count;
            for (var i = 0; i < nbUnits; i++)
            {
                UnitInfo unitInfo = unitInfos[i];
                IReadOnlyList<string> abbreviations = Abbreviations.GetAbbreviationsForCulture(unitInfo, culture);
                var nbAbbreviations = abbreviations.Count;
                for (var p = 0; p < nbAbbreviations; p++)
                {
                    var abbreviation = abbreviations[p];
                    if (unitAbbreviation.Equals(abbreviation, comparison))
                    {
                        unitAbbreviationsPairs.Add((unitInfo, abbreviation));
                    }
                }
            }
        }

        return unitAbbreviationsPairs;
    }


    /// <summary>
    ///     Retrieves the unit information corresponding to the specified unit abbreviation.
    /// </summary>
    /// <param name="unitAbbreviation">The unit abbreviation to parse. Cannot be null or empty.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <returns>The <see cref="UnitInfo" /> instance representing the parsed unit.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="unitAbbreviation" /> is null.
    /// </exception>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when the unit abbreviation is not recognized as a valid unit for the specified culture.
    /// </exception>
    /// <exception cref="AmbiguousUnitParseException">
    ///     Thrown when multiple units match the given unit abbreviation, making the result ambiguous.
    /// </exception>
    /// <remarks>
    ///     This method performs a series of searches to find the unit:
    ///     <list type="number">
    ///         <item>Case-sensitive search using the current culture.</item>
    ///         <item>Case-sensitive search using the fallback culture, if applicable.</item>
    ///         <item>Case-insensitive search.</item>
    ///     </list>
    ///     Note that this method is not optimized for performance, as it enumerates all units and their abbreviations
    ///     during each invocation.
    /// </remarks>
    public UnitInfo GetUnitFromAbbreviation(string unitAbbreviation, IFormatProvider? formatProvider)
    {
        if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));
        
        if (formatProvider is not CultureInfo culture)
        {
            culture = CultureInfo.CurrentCulture;
        }
        
        unitAbbreviation = unitAbbreviation.Trim();
        StringComparison comparison = StringComparison.Ordinal;
        while (true)
        {
            List<(UnitInfo UnitInfo, string Abbreviation)> matches = FindAllMatchingUnitsForCulture(unitAbbreviation, culture, comparison);
            switch (matches.Count)
            {
                case 1:
                    return matches[0].UnitInfo;
                case 0:
                    // Retry with fallback culture, if different.
                    if (UnitAbbreviationsCache.HasFallbackCulture(culture))
                    {
                        culture = UnitAbbreviationsCache.FallbackCulture;
                        continue;
                    }
                    
                    var normalizedUnitString = NormalizeUnitString(unitAbbreviation);
                    if (normalizedUnitString != unitAbbreviation)
                    {
                        unitAbbreviation = normalizedUnitString;
                        continue;
                    }

                    if (comparison == StringComparison.Ordinal)
                    {
                        comparison = StringComparison.OrdinalIgnoreCase;
                        continue;
                    }

                    throw new UnitNotFoundException($"Unit not found with abbreviation [{unitAbbreviation}].");
                default:
                    var unitsCsv = string.Join(", ", matches.Select(x => $"{x.UnitInfo.Name} (\"{x.Abbreviation}\")").OrderBy(x => x));
                    throw new AmbiguousUnitParseException($"Cannot parse \"{unitAbbreviation}\" since it matches multiple units: {unitsCsv}.");
            }
        }
    }

    /// <summary>
    ///     Attempts to parse the specified unit abbreviation into an <see cref="UnitInfo" /> object.
    /// </summary>
    /// <param name="unitAbbreviation">The unit abbreviation to parse.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <param name="unit">
    ///     When this method returns, contains the parsed <see cref="UnitInfo" /> object if the parsing succeeded,
    ///     or <c>null</c> if the parsing failed. This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the unit abbreviation was successfully parsed; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     This method performs a series of searches to find the unit:
    ///     <list type="number">
    ///         <item>Case-sensitive search using the current culture.</item>
    ///         <item>Case-sensitive search using the fallback culture, if applicable.</item>
    ///         <item>Case-insensitive search.</item>
    ///     </list>
    ///     Note that this method is not optimized for performance, as it enumerates all units and their abbreviations
    ///     during each invocation.
    /// </remarks>
    public bool TryGetUnitFromAbbreviation([NotNullWhen(true)]string? unitAbbreviation, IFormatProvider? formatProvider, [NotNullWhen(true)] out UnitInfo? unit)
    {
        if (unitAbbreviation == null)
        {
            unit = null;
            return false;
        }
        
        unitAbbreviation = unitAbbreviation.Trim();
        
        if (formatProvider is not CultureInfo culture)
        {
            culture = CultureInfo.CurrentCulture;
        }
        
        StringComparison comparison = StringComparison.Ordinal;
        while (true)
        {
            List<(UnitInfo UnitInfo, string Abbreviation)> matches = FindAllMatchingUnitsForCulture(unitAbbreviation, culture, comparison);
            switch (matches.Count)
            {
                case 1:
                    unit = matches[0].UnitInfo;
                    return true;
                case 0:
                    // Retry with fallback culture, if different.
                    if (UnitAbbreviationsCache.HasFallbackCulture(culture))
                    {
                        culture = UnitAbbreviationsCache.FallbackCulture;
                        continue;
                    }
                    
                    var normalizedUnitString = NormalizeUnitString(unitAbbreviation);
                    if (normalizedUnitString != unitAbbreviation)
                    {
                        unitAbbreviation = normalizedUnitString;
                        continue;
                    }

                    if (comparison == StringComparison.Ordinal)
                    {
                        comparison = StringComparison.OrdinalIgnoreCase;
                        continue;
                    }
                    
                    unit = null;
                    return false;
                default:
                {
                    unit = null;
                    return false;
                }
            }
        }
    }
    
    /// <summary>
    ///     Dynamically construct a quantity from a numeric value and a unit abbreviation.
    /// </summary>
    /// <remarks>
    ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations
    ///     each time.<br />
    ///     Unit abbreviation matching in the <see cref="Parse" /> overload is case-insensitive.<br />
    ///     <br />
    ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br />
    /// </remarks>
    /// <param name="value">Numeric value.</param>
    /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram" />.</param>
    /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <returns>An <see cref="IQuantity" /> object.</returns>
    /// <exception cref="UnitNotFoundException">Unit abbreviation is not known.</exception>
    /// <exception cref="AmbiguousUnitParseException">Multiple units found matching the given unit abbreviation.</exception>
    internal IQuantity FromUnitAbbreviation(QuantityValue value, string unitAbbreviation, IFormatProvider? formatProvider)
    {
        return GetUnitFromAbbreviation(unitAbbreviation, formatProvider).From(value);
    }
    
    /// <inheritdoc cref="UnitAbbreviationsCache.GetUnitAbbreviations(UnitKey,IFormatProvider?)" />
    public IReadOnlyList<string> GetUnitAbbreviations(UnitKey unitKey, IFormatProvider? formatProvider)
    {
        return Abbreviations.GetUnitAbbreviations(unitKey, formatProvider);
    }

    /// <inheritdoc cref="UnitAbbreviationsCache.GetAllUnitAbbreviationsForQuantity" />
    public IReadOnlyList<string> GetAllUnitAbbreviationsForQuantity(Type unitType, IFormatProvider? formatProvider)
    {
        return Abbreviations.GetAllUnitAbbreviationsForQuantity(unitType, formatProvider);
    }
}
