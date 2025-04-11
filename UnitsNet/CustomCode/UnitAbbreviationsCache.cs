// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using UnitsNet.Units;
using AbbreviationMapKey = System.ValueTuple<UnitsNet.UnitKey, string>;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Cache of the mapping between unit enum values and unit abbreviation strings for one or more cultures.
    ///     A static instance <see cref="UnitsNetSetup"/>.<see cref="UnitsNetSetup.Default"/>.<see cref="UnitsNetSetup.UnitAbbreviations"/> is used internally
    ///     for ToString() and Parse() of quantities and units.
    /// </summary>
    public sealed class UnitAbbreviationsCache
    {
        /// <summary>
        ///     Fallback culture used by <see cref="GetUnitAbbreviations{TUnitType}" /> and <see cref="GetDefaultAbbreviation{TUnitType}" />
        ///     if no abbreviations are found with a given culture.
        /// </summary>
        /// <example>
        ///     User wants to call <see cref="UnitParser.Parse{TUnitType}" /> or <see cref="Length.ToString()" /> with Russian
        ///     culture, but no translation is defined, so we return the US English definition as a last resort. If it's not
        ///     defined there either, an exception is thrown.
        /// </example>
        internal static readonly CultureInfo FallbackCulture = CultureInfo.InvariantCulture;

        /// <summary>
        ///     The default singleton instance with the default configured unit abbreviations, used for ToString() and parsing of quantities and units.
        /// </summary>
        /// <remarks>
        ///     Convenience shortcut for <see cref="UnitsNetSetup"/>.<see cref="UnitsNetSetup.Default"/>.<see cref="UnitsNetSetup.UnitAbbreviations"/>.<br />
        ///     You can add custom unit abbreviations at runtime, and this will affect all usages globally in the application.
        /// </remarks>
        public static UnitAbbreviationsCache Default => UnitsNetSetup.Default.UnitAbbreviations;

        private QuantityInfoLookup QuantityInfoLookup { get; }

        /// <summary>
        /// Culture name to abbreviations. To add a custom default abbreviation, add to the beginning of the list.
        /// </summary>
        private ConcurrentDictionary<AbbreviationMapKey, IReadOnlyList<string>> AbbreviationsMap { get; } = new();

        /// <summary>
        ///     Create an empty instance of the cache, with no default abbreviations loaded.
        /// </summary>
        public UnitAbbreviationsCache()
            : this(new QuantityInfoLookup([]))
        {
        }
        
        /// <summary>
        ///     Creates an instance of the cache using the specified set of quantities.
        /// </summary>
        /// <returns>Instance for mapping the units of the provided quantities.</returns>
        public UnitAbbreviationsCache(IEnumerable<QuantityInfo> quantities)
            :this(new QuantityInfoLookup(quantities))
        {
        }
        
        /// <summary>
        ///     Creates an instance of the cache using the specified set of quantities.
        /// </summary>
        /// <remarks>
        ///     Access type is <c>internal</c> until this class is matured and ready for external use.
        /// </remarks>
        internal UnitAbbreviationsCache(QuantityInfoLookup quantityInfoLookup)
        {
            QuantityInfoLookup = quantityInfoLookup;
        }
        
        /// <summary>
        ///     Create an instance of the cache and load all the built-in quantities defined in the library.
        /// </summary>
        /// <returns>Instance for mapping any of the built-in units.</returns>
        public static UnitAbbreviationsCache CreateDefault() => new(new QuantityInfoLookup(Quantity.Infos));

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, params string[] abbreviations) where TUnitType : struct, Enum
        {
            PerformAbbreviationMapping(UnitKey.ForUnit(unit), CultureInfo.CurrentCulture, false, abbreviations);
        }

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviation">Unit abbreviations to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, string abbreviation) where TUnitType : struct, Enum
        {
            PerformAbbreviationMapping(UnitKey.ForUnit(unit), CultureInfo.CurrentCulture, true, abbreviation);
        }

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider, params string[] abbreviations) where TUnitType : struct, Enum
        {
            PerformAbbreviationMapping(UnitKey.ForUnit(unit), formatProvider, false, abbreviations);
        }

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider, string abbreviation) where TUnitType : struct, Enum
        {
            PerformAbbreviationMapping(UnitKey.ForUnit(unit), formatProvider, true, abbreviation);
        }

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        public void MapUnitToAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider, params string[] abbreviations)
        {
            PerformAbbreviationMapping(new UnitKey(unitType, unitValue), formatProvider, false, abbreviations);
        }

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        public void MapUnitToDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider, string abbreviation)
        {
            PerformAbbreviationMapping(new UnitKey(unitType, unitValue), formatProvider, true, abbreviation);
        }

        private void PerformAbbreviationMapping(UnitKey unitValue, IFormatProvider? formatProvider, bool setAsDefault, params string[] abbreviations)
        {
            if(!QuantityInfoLookup.TryGetUnitInfo(unitValue, out UnitInfo? unitInfo))
            {
                // TODO we should throw QuantityNotFoundException here (all QuantityInfos should be provided through the constructor)
                unitInfo = new UnitInfo((Enum)unitValue, unitValue.ToString(), BaseUnits.Undefined);
                QuantityInfoLookup.AddUnitInfo(unitInfo);
            }

            AddAbbreviation(unitInfo, formatProvider, setAsDefault, abbreviations);
        }
        
        /// <summary>
        ///     Gets the default abbreviation for a given unit type and its numeric enum value.
        ///     If a unit has more than one abbreviation defined, then it returns the first one.
        ///     Example: GetDefaultAbbreviation(LengthUnit.Centimeters, 1) => "cm"
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public string GetDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : struct, Enum
        {
            return GetDefaultAbbreviation(UnitKey.ForUnit(unit), formatProvider);
        }
        
        /// <summary>
        ///     Gets the default abbreviation for a given unit type and its numeric enum value.
        ///     If a unit has more than one abbreviation defined, then it returns the first one.
        ///     Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(typeof(LengthUnit), 1) => "cm"
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public string GetDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            return GetDefaultAbbreviation(new UnitKey(unitType, unitValue), formatProvider);
        }
        
        /// <inheritdoc cref="GetDefaultAbbreviation{TUnitType}"/>
        /// <param name="unitKey">The key representing the unit type and value.</param>
        /// <param name="formatProvider">
        ///     The format provider to use for lookup. Defaults to
        ///     <see cref="CultureInfo.CurrentCulture" /> if null.
        /// </param>
        /// <returns>The default unit abbreviation string.</returns>
        public string GetDefaultAbbreviation(UnitKey unitKey, IFormatProvider? formatProvider = null)
        {
            IReadOnlyList<string> abbreviations = GetUnitAbbreviations(unitKey, formatProvider);
            if (abbreviations.Count == 0)
            {
                throw new InvalidOperationException($"No abbreviations were found for {unitKey.UnitType.Name}.{(Enum)unitKey}. Make sure that the unit abbreviations are mapped.");
            }

            return abbreviations[0];
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public string[] GetUnitAbbreviations<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : struct, Enum
        {
            return GetUnitAbbreviations(UnitKey.ForUnit(unit), formatProvider).ToArray();  // TODO can we change this to return an IReadonlyCollection (as the GetAbbreviations)?
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public string[] GetUnitAbbreviations(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            return GetUnitAbbreviations(new UnitKey(unitType, unitValue), formatProvider).ToArray(); // TODO can we change this to return an IReadOnlyList (as the GetAbbreviations)?
        }
        
        /// <summary>
        /// Retrieves the unit abbreviations for a specified unit key and optional format provider.
        /// </summary>
        /// <param name="unitKey">The key representing the unit type and value.</param> 
        /// <param name="formatProvider">An optional format provider to use for culture-specific formatting.</param>
        /// <returns>A read-only collection of unit abbreviation strings.</returns>
        public IReadOnlyList<string> GetUnitAbbreviations(UnitKey unitKey, IFormatProvider? formatProvider = null)
        {
            return GetAbbreviations(QuantityInfoLookup.GetUnitInfo(unitKey), formatProvider);
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitKey">The unit-enum type as a hash-friendly type.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">The unit abbreviations associated with unit.</param>
        /// <returns>True if found, otherwise false.</returns>
        private bool TryGetUnitAbbreviations(UnitKey unitKey, IFormatProvider? formatProvider, out IReadOnlyList<string> abbreviations)
        {
            if(QuantityInfoLookup.TryGetUnitInfo(unitKey, out UnitInfo? unitInfo))
            {
                abbreviations = GetAbbreviations(unitInfo, formatProvider);
                return true;
            }

            abbreviations = [];
            return false;
        }

        /// <summary>
        ///     Get all abbreviations for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public IReadOnlyList<string> GetAllUnitAbbreviationsForQuantity(Type unitEnumType, IFormatProvider? formatProvider = null)
        {
            var allAbbreviations = new List<string>();
            if (!QuantityInfoLookup.TryGetQuantityByUnitType(unitEnumType, out QuantityInfo? quantityInfo))
            {
                // TODO I think we should either return empty or throw QuantityNotFoundException here
                var enumValues = Enum.GetValues(unitEnumType).Cast<Enum>();
                var all = GetStringUnitPairs(enumValues, formatProvider);
                return all.Select(pair => pair.Item2).ToList();
            }
            
            foreach(UnitInfo unitInfo in quantityInfo.UnitInfos)
            {
                if(TryGetUnitAbbreviations(unitInfo.UnitKey, formatProvider, out IReadOnlyList<string> abbreviations))
                {
                    allAbbreviations.AddRange(abbreviations);
                }
            }

            return allAbbreviations;
        }

        internal List<(Enum Unit, string Abbreviation)> GetStringUnitPairs(IEnumerable<Enum> enumValues, IFormatProvider? formatProvider = null)
        {
            var unitAbbreviationsPairs = new List<(Enum, string)>();
            formatProvider ??= CultureInfo.CurrentCulture;

            foreach(var enumValue in enumValues)
            {
                if(TryGetUnitAbbreviations(enumValue, formatProvider, out var abbreviations))
                {
                    foreach(var abbrev in abbreviations)
                    {
                        unitAbbreviationsPairs.Add((enumValue, abbrev));
                    }
                }
            }

            return unitAbbreviationsPairs;
        }

        /// <summary>
        ///    Get all abbreviations for the given unit and culture.
        /// </summary>
        /// <param name="unitInfo">The unit.</param>
        /// <param name="formatProvider">The culture to get localized abbreviations for. Defaults to <see cref="CultureInfo.CurrentCulture"/>.</param>
        /// <returns>The list of abbreviations mapped for this unit. The first in the list is the primary abbreviation used by ToString().</returns>
        /// <exception cref="ArgumentNullException"><paramref name="unitInfo"/> was null.</exception>
        public IReadOnlyList<string> GetAbbreviations(UnitInfo unitInfo, IFormatProvider? formatProvider = null)
        {
            if (unitInfo == null) throw new ArgumentNullException(nameof(unitInfo));
            if (formatProvider is not CultureInfo)
                formatProvider = CultureInfo.CurrentCulture;

            var culture = (CultureInfo)formatProvider;
            var cultureName = GetCultureNameOrEnglish(culture);

            AbbreviationMapKey key = GetAbbreviationMapKey(unitInfo, cultureName);

            IReadOnlyList<string> abbreviations = AbbreviationsMap.GetOrAdd(key,
                valueFactory: _ => ReadAbbreviationsFromResourceFile(unitInfo.QuantityName, unitInfo.PluralName, culture));

            return abbreviations.Count == 0 && !culture.Equals(FallbackCulture)
                ? GetAbbreviations(unitInfo, FallbackCulture)
                : abbreviations;
        }

        /// <summary>
        ///     Add unit abbreviation for the given <paramref name="unitInfo"/>, such as "kg" for <see cref="MassUnit.Kilogram"/>.
        /// </summary>
        /// <param name="unitInfo">The unit to add for.</param>
        /// <param name="formatProvider">The culture this abbreviation is for, defaults to <see cref="CultureInfo.CurrentCulture"/>.</param>
        /// <param name="setAsDefault">Whether to set as the primary/default unit abbreviation used by ToString().</param>
        /// <param name="newAbbreviations">One or more abbreviations to add.</param>
        private void AddAbbreviation(UnitInfo unitInfo, IFormatProvider? formatProvider, bool setAsDefault,
            params string[] newAbbreviations)
        {
            if (formatProvider is not CultureInfo culture)
            {
                culture = CultureInfo.CurrentCulture;
            }

            var cultureName = GetCultureNameOrEnglish(culture);

            AbbreviationMapKey key = GetAbbreviationMapKey(unitInfo, cultureName);

            AbbreviationsMap.AddOrUpdate(key,
                addValueFactory: _ =>
                {
                    List<string> bundledAbbreviations = ReadAbbreviationsFromResourceFile(unitInfo.QuantityName, unitInfo.PluralName, culture).ToList();
                    return AddAbbreviationsToList(setAsDefault, bundledAbbreviations, newAbbreviations);
                },
                updateValueFactory: (_, existingReadOnlyList) => AddAbbreviationsToList(setAsDefault, existingReadOnlyList.ToList(), newAbbreviations));
        }

        private static IReadOnlyList<string> AddAbbreviationsToList(bool setAsDefault, List<string> list, IEnumerable<string> abbreviations)
        {
            foreach (var newAbbrev in abbreviations)
            {
                if (setAsDefault)
                {
                    // Remove if it already exists, then insert at beginning.
                    // Normally only called with a single abbreviation.
                    list.Remove(newAbbrev);
                    list.Insert(0, newAbbrev);
                }
                else if (!list.Contains(newAbbrev))
                {
                    list.Add(newAbbrev);
                }
            }

            return list.AsReadOnly();
        }

        private static AbbreviationMapKey GetAbbreviationMapKey(UnitInfo unitInfo, string cultureName)
        {
            return new AbbreviationMapKey(unitInfo.UnitKey, cultureName);
        }

        private static string GetCultureNameOrEnglish(CultureInfo culture)
        {
            // Fallback culture is invariant to support DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1,
            // but we need to map that to the primary localization, English.
            return culture.Equals(CultureInfo.InvariantCulture)
                ? "en-US"
                : culture.Name;
        }

        private IReadOnlyList<string> ReadAbbreviationsFromResourceFile(string? quantityName, string unitPluralName, CultureInfo culture)
        {
            var abbreviationsList = new List<string>();

            if (quantityName is null) return abbreviationsList.AsReadOnly();

            string resourceName = $"UnitsNet.GeneratedCode.Resources.{quantityName}";
            var resourceManager = new ResourceManager(resourceName, GetType().Assembly);

            var abbreviationsString = resourceManager.GetString(unitPluralName, culture);
            if(abbreviationsString is not null)
                abbreviationsList.AddRange(abbreviationsString.Split(','));

            return abbreviationsList.AsReadOnly();
        }

        /// <summary>
        ///     Retrieves a list of unit information objects that match the specified unit abbreviation.
        /// </summary>
        /// <param name="formatProvider">An optional format provider to use for culture-specific formatting.</param>
        /// <param name="unitAbbreviation">The unit abbreviation to search for.</param>
        /// <returns>A list of <see cref="UnitInfo" /> objects that match the specified unit abbreviation.</returns>
        /// <remarks>
        ///     This method performs a case-sensitive match to reduce ambiguity. For example, "cm" could match both
        ///     <c>LengthUnit.Centimeter</c> (cm) and
        ///     <c>MolarityUnit.CentimolePerLiter</c> (cM).
        /// </remarks>
        internal List<UnitInfo> GetUnitsForAbbreviation(IFormatProvider? formatProvider, string unitAbbreviation)
        {
            // TODO this is certain to have terrible performance (especially on the first run)
            // TODO we should consider adding a (lazy) dictionary for these
            // Use case-sensitive match to reduce ambiguity.
            // Don't use UnitParser.TryParse() here, since it allows case-insensitive match per quantity as long as there are no ambiguous abbreviations for
            // units of that quantity, but here we try all quantities and this results in too high of a chance for ambiguous matches,
            // such as "cm" matching both LengthUnit.Centimeter (cm) and MolarityUnit.CentimolePerLiter (cM).
            return QuantityInfoLookup.Infos
                .SelectMany(quantityInfo => quantityInfo.UnitInfos)
                .Select(unitInfo => GetAbbreviations(unitInfo, formatProvider).Contains(unitAbbreviation, StringComparer.Ordinal)
                    ? unitInfo
                    : null)
                .Where(unitValue => unitValue != null)
                .Select(unitValue => unitValue!)
                .ToList();
        }
    }
}
