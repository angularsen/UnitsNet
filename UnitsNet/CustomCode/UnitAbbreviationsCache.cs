// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Resources;
using AbbreviationMapKey = System.ValueTuple<UnitsNet.UnitKey, string>;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Cache of the mapping between unit enum values and unit abbreviation strings for one or more cultures.
    ///     A static instance is created in the <see cref="UnitsNetSetup.Default"/>, which is used for ToString() and Parse() of quantities and units.
    /// </summary>
    public sealed class UnitAbbreviationsCache
    {
        /// <summary>
        ///     Fallback culture used by <see cref="GetUnitAbbreviations(UnitKey,IFormatProvider?)" /> and <see cref="GetDefaultAbbreviation(UnitKey,IFormatProvider?)" />
        ///     if no abbreviations are found with a given culture.
        /// </summary>
        /// <example>
        ///     User wants to call <see cref="UnitParser.Parse{TUnitType}(string,IFormatProvider?)" /> or <see cref="Length.ToString()" /> with Russian
        ///     culture, but no translation is defined, so we return the US English (en-US)  definition as a last resort. If it's not
        ///     defined there either, an exception is thrown.
        /// </example>
        internal static readonly CultureInfo FallbackCulture = CultureInfo.InvariantCulture;

        /// <summary>
        ///     The static instance used internally for ToString() and Parse() of quantities and units.
        /// </summary>
        public static UnitAbbreviationsCache Default => UnitsNetSetup.Default.UnitAbbreviations;

        /// <summary>
        ///     Gets the lookup table for quantity information used by this cache.
        /// </summary>
        /// <remarks>
        ///     This property provides access to the <see cref="QuantityInfoLookup" /> instance that contains
        ///     information about quantities and their associated units. It is used internally to map units
        ///     to their abbreviations and vice versa.
        /// </remarks>
        public QuantityInfoLookup Quantities { get; }

        /// <summary>
        /// Culture name to abbreviations. To add a custom default abbreviation, add to the beginning of the list.
        /// </summary>
        private ConcurrentDictionary<AbbreviationMapKey, IReadOnlyList<string>> AbbreviationsMap { get; } = new();

        /// <summary>
        ///      Create an instance of the cache and load all the built-in quantities defined in the library.
        /// </summary>
        /// <returns>Instance for mapping any of the built-in units.</returns>
        public UnitAbbreviationsCache()
            :this(UnitsNetSetup.Default.Quantities)
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
        internal UnitAbbreviationsCache(QuantityInfoLookup quantities)
        {
            Quantities = quantities;
        }

        /// <summary>
        ///     Create an instance of the cache and load all the built-in quantities defined in the library.
        /// </summary>
        /// <returns>Instance for mapping any of the built-in units.</returns>
        public static UnitAbbreviationsCache CreateDefault()
        {
            return new UnitAbbreviationsCache();
        }

        /// <summary>
        ///     Creates an instance of <see cref="UnitAbbreviationsCache" /> that maps to the default quantities, with an option to
        ///     customize the selection.
        /// </summary>
        /// <param name="configureQuantities">An action to configure the <see cref="QuantitiesSelector" />.</param>
        /// <returns>An instance of <see cref="UnitAbbreviationsCache" /> mapped to the default quantities.</returns>
        public static UnitAbbreviationsCache CreateDefault(Action<QuantitiesSelector> configureQuantities)
        {
            return Create(Quantity.DefaultProvider.Quantities, configureQuantities);
        }

        /// <summary>
        ///     Creates an instance of the <see cref="UnitAbbreviationsCache" /> class with a specified selection of default
        ///     quantities
        ///     and an action to configure the quantities selector.
        /// </summary>
        /// <param name="defaultQuantities">The collection of default quantities to be used.</param>
        /// <param name="configureQuantities">An action to configure the quantities selector.</param>
        /// <returns>A new instance of the <see cref="UnitAbbreviationsCache" /> class.</returns>
        public static UnitAbbreviationsCache Create(IEnumerable<QuantityInfo> defaultQuantities, Action<QuantitiesSelector> configureQuantities)
        {
            return new UnitAbbreviationsCache(QuantityInfoLookup.Create(defaultQuantities, configureQuantities));
        }

        #region MapUnitToAbbreviation overloads

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}(string,IFormatProvider?)"/> or <see cref="GetDefaultAbbreviation(UnitKey,IFormatProvider?)"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit information is found for the specified
        ///     <paramref name="unit" />.
        /// </exception>
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, params IEnumerable<string> abbreviations)
            where TUnitType : struct, Enum
        {
            MapUnitToAbbreviation(UnitKey.ForUnit(unit), abbreviations);
        }

        /// <inheritdoc cref="MapUnitToAbbreviation{TUnitType}(TUnitType,IEnumerable{string})"/>>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the provided type is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the provided type is not an enumeration type.
        /// </exception>
        public void MapUnitToAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider, params IEnumerable<string> abbreviations)
        {
            MapUnitToAbbreviation(UnitKey.Create(unitType, unitValue), formatProvider, abbreviations);
        }

        /// <inheritdoc cref="MapUnitToAbbreviation{TUnitType}(TUnitType,IEnumerable{string})"/>>
        /// <param name="unitKey">The unit key value.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        public void MapUnitToAbbreviation(UnitKey unitKey, params IEnumerable<string> abbreviations)
        {
            MapUnitToAbbreviation(unitKey, CultureInfo.CurrentCulture, abbreviations);
        }

        /// <inheritdoc cref="MapUnitToAbbreviation{TUnitType}(TUnitType,IEnumerable{string})"/>>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider, params IEnumerable<string> abbreviations)
            where TUnitType : struct, Enum
        {
            MapUnitToAbbreviation(UnitKey.ForUnit(unit), formatProvider, abbreviations);
        }
        
        /// <inheritdoc cref="MapUnitToAbbreviation{TUnitType}(TUnitType,IEnumerable{string})"/>>
        /// <param name="unitKey">The unit key value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        public void MapUnitToAbbreviation(UnitKey unitKey, IFormatProvider? formatProvider, params IEnumerable<string> abbreviations)
        {
            PerformAbbreviationMapping(unitKey, formatProvider, false, abbreviations);
        }

        #endregion

        #region MapUnitToDefaultAbbreviation overloads

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}(string,IFormatProvider?)"/> or <see cref="GetDefaultAbbreviation(UnitKey,IFormatProvider?)"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviation">Unit abbreviations to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit information is found for the specified
        ///     <paramref name="unit" />.
        /// </exception>
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, string abbreviation)
            where TUnitType : struct, Enum
        {
            MapUnitToDefaultAbbreviation(UnitKey.ForUnit(unit), abbreviation);
        }

        /// <inheritdoc cref="MapUnitToDefaultAbbreviation{TUnitType}(TUnitType,string)"/>>
        /// <param name="unitKey">The unit key value.</param>
        /// <param name="abbreviation">Unit abbreviations to add as default.</param>
        public void MapUnitToDefaultAbbreviation(UnitKey unitKey, string abbreviation)
        {
            MapUnitToDefaultAbbreviation(unitKey, CultureInfo.CurrentCulture, abbreviation);
        }

        /// <inheritdoc cref="MapUnitToDefaultAbbreviation{TUnitType}(TUnitType,string)"/>>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider, string abbreviation)
            where TUnitType : struct, Enum
        {
            MapUnitToDefaultAbbreviation(UnitKey.ForUnit(unit), formatProvider, abbreviation);
        }

        /// <inheritdoc cref="MapUnitToDefaultAbbreviation{TUnitType}(TUnitType,string)"/>>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the provided type is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the provided type is not an enumeration type.
        /// </exception>
        public void MapUnitToDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider, string abbreviation)
        {
            MapUnitToDefaultAbbreviation(UnitKey.Create(unitType, unitValue), formatProvider, abbreviation);
        }

        /// <inheritdoc cref="MapUnitToDefaultAbbreviation{TUnitType}(TUnitType,string)"/>>
        /// <param name="unitKey">The unit key value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        public void MapUnitToDefaultAbbreviation(UnitKey unitKey, IFormatProvider? formatProvider, string abbreviation)
        {
            PerformAbbreviationMapping(unitKey, formatProvider, true, abbreviation);
        }

        #endregion

        private void PerformAbbreviationMapping(UnitKey unitKey, IFormatProvider? formatProvider, bool setAsDefault, params IEnumerable<string> abbreviations)
        {
            AddAbbreviation(Quantities.GetUnitInfo(unitKey), formatProvider, setAsDefault, abbreviations);
        }
        
        /// <summary>
        ///     Gets the default abbreviation for a given unit type and its numeric enum value.
        ///     If a unit has more than one abbreviation defined, then it returns the first one.
        ///     Example: GetDefaultAbbreviation(LengthUnit.Centimeters, 1) => "cm"
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The default unit abbreviation string.</returns>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit information is found for the specified
        ///     <paramref name="unit" />.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when no abbreviations are mapped for the specified unit.
        /// </exception>
        public string GetDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null)
            where TUnitType : struct, Enum
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the provided type is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the provided type is not an enumeration type.
        /// </exception>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit information is found for the specified
        ///     <paramref name="unitType" /> and <paramref name="unitValue" />.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when no abbreviations are mapped for the specified unit.
        /// </exception>
        public string GetDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            return GetDefaultAbbreviation(UnitKey.Create(unitType, unitValue), formatProvider);
        }

        /// <inheritdoc cref="GetDefaultAbbreviation{TUnitType}" />
        /// <param name="unitKey">The key representing the unit type and value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit information is found for the specified
        ///     <paramref name="unitKey" />.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when no abbreviations are mapped for the specified unit.
        /// </exception>
        public string GetDefaultAbbreviation(UnitKey unitKey, IFormatProvider? formatProvider = null)
        {
            IReadOnlyList<string> abbreviations = GetUnitAbbreviations(unitKey, formatProvider);
            if (abbreviations.Count == 0)
            {
                throw new InvalidOperationException($"No abbreviations were found for {unitKey.UnitEnumType.Name}.{(Enum)unitKey}. Make sure that the unit abbreviations are mapped.");
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
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit information is found for the specified
        ///     <paramref name="unit" />.
        /// </exception>
        public IReadOnlyList<string> GetUnitAbbreviations<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null)
            where TUnitType : struct, Enum
        {
            return GetUnitAbbreviations(UnitKey.ForUnit(unit), formatProvider);
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the provided type is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the provided type is not an enumeration type.
        /// </exception>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit information is found for the specified
        ///     <paramref name="unitType" /> and <paramref name="unitValue" />.
        /// </exception>
        public IReadOnlyList<string> GetUnitAbbreviations(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            return GetUnitAbbreviations(UnitKey.Create(unitType, unitValue), formatProvider);
        }
        
        /// <summary>
        /// Retrieves the unit abbreviations for a specified unit key and optional format provider.
        /// </summary>
        /// <param name="unitKey">The key representing the unit type and value.</param> 
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>A read-only collection of unit abbreviation strings.</returns>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit information is found for the specified
        ///     <paramref name="unitKey" />.
        /// </exception>
        public IReadOnlyList<string> GetUnitAbbreviations(UnitKey unitKey, IFormatProvider? formatProvider = null)
        {
            if (formatProvider is not CultureInfo culture)
            {
                culture = CultureInfo.CurrentCulture;
            }

            return GetAbbreviationsWithFallbackCulture(Quantities.GetUnitInfo(unitKey), culture);
        }

        /// <summary>
        ///     Retrieves all abbreviations for all units of a specified quantity.
        /// </summary>
        /// <param name="unitEnumType">
        ///     The enum type representing the unit. This must be a valid unit type.
        /// </param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>
        ///     A read-only list of unit abbreviations associated with the specified unit type.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the provided type is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the provided type is not an enumeration type.
        /// </exception>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no quantity is found for the specified unit type.
        /// </exception>
        public IReadOnlyList<string> GetAllUnitAbbreviationsForQuantity(Type unitEnumType, IFormatProvider? formatProvider = null)
        {
            if (unitEnumType == null)
            {
                throw new ArgumentNullException(nameof(unitEnumType));
            }
            
            if (!Quantities.TryGetQuantityByUnitType(unitEnumType, out QuantityInfo? quantityInfo))
            {
                if (!unitEnumType.IsEnum)
                {
                    throw new ArgumentException($"Unit type must be an enumeration, but was {unitEnumType.FullName}.", nameof(unitEnumType));
                }
                
                throw new UnitNotFoundException($"No quantity was found with the specified unit type: '{unitEnumType}'.") { Data = { ["unitType"] = unitEnumType.Name } };
            }
            
            if (formatProvider is not CultureInfo culture)
            {
                culture = CultureInfo.CurrentCulture;
            }

            var allAbbreviations = new List<string>();
            foreach(UnitInfo unitInfo in quantityInfo.UnitInfos)
            {
                allAbbreviations.AddRange(GetAbbreviationsWithFallbackCulture(unitInfo, culture));
            }

            return allAbbreviations;
        }

        /// <summary>
        ///    Get all abbreviations for the given unit and culture.
        /// </summary>
        /// <param name="unitInfo">The unit.</param>
        /// <param name="culture">The culture to get localized abbreviations for.</param>
        /// <returns>The list of abbreviations mapped for this unit. The first in the list is the primary abbreviation used by ToString().</returns>
        /// <exception cref="ArgumentNullException"><paramref name="unitInfo"/> was null.</exception>
        internal IReadOnlyList<string> GetAbbreviationsWithFallbackCulture(UnitInfo unitInfo, CultureInfo culture) 
        {
            IReadOnlyList<string> abbreviations = GetAbbreviationsForCulture(unitInfo, culture);

            return abbreviations.Count == 0 && HasFallbackCulture(culture)
                ? GetAbbreviationsForCulture(unitInfo, FallbackCulture)
                : abbreviations;
        }

        internal static bool HasFallbackCulture(CultureInfo culture)
        {
            // accounting for the fact that we're using the same abbreviations for both "en-US" and the "Invariant" culture (Name == string.Empty) 
            return culture.Name != string.Empty && culture.Name != FallbackCulture.Name;
        }

        internal IReadOnlyList<string> GetAbbreviationsForCulture(UnitInfo unitInfo, CultureInfo culture)
        {
            AbbreviationMapKey abbreviationMapKey = GetAbbreviationMapKey(unitInfo, culture);
#if NET
            return AbbreviationsMap.GetOrAdd(abbreviationMapKey, ReadAbbreviationsForCulture, (unitInfo, culture));
            static IReadOnlyList<string> ReadAbbreviationsForCulture(AbbreviationMapKey key, (UnitInfo unitInfo, CultureInfo culture) unitForCulture)
            {
                return ReadAbbreviationsFromResourceFile(unitForCulture.unitInfo, unitForCulture.culture);
            }
#else
            // intentionally not using the factory overload here, as it causes an extra allocation for the Func
            return AbbreviationsMap.TryGetValue(abbreviationMapKey, out IReadOnlyList<string> abbreviations)
                ? abbreviations
                : AbbreviationsMap.GetOrAdd(abbreviationMapKey, _ => ReadAbbreviationsFromResourceFile(unitInfo, culture));
#endif
        }
        
        /// <summary>
        ///     Add unit abbreviation for the given <paramref name="unitInfo"/>, such as "kg" for <see cref="MassUnit.Kilogram"/>.
        /// </summary>
        /// <param name="unitInfo">The unit to add for.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="setAsDefault">Whether to set as the primary/default unit abbreviation used by ToString().</param>
        /// <param name="newAbbreviations">One or more abbreviations to add.</param>
        private void AddAbbreviation(UnitInfo unitInfo, IFormatProvider? formatProvider, bool setAsDefault, params IEnumerable<string> newAbbreviations)
        {
            if (formatProvider is not CultureInfo culture)
            {
                culture = CultureInfo.CurrentCulture;
            }

            AbbreviationMapKey key = GetAbbreviationMapKey(unitInfo, culture);

            AbbreviationsMap.AddOrUpdate(key,
                addValueFactory: _ =>
                {
                    List<string> bundledAbbreviations = ReadAbbreviationsFromResourceFile(unitInfo, culture);
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

        private static AbbreviationMapKey GetAbbreviationMapKey(UnitInfo unitInfo, CultureInfo culture)
        {
            // In order to support running in "invariant mode" (DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1) the FallbackCulture is set to the InvariantCulture.
            // However, if we want to avoid having two entries in the cache ("", "en-US"), we need to map the invariant culture name to the primary localization language.
            return new AbbreviationMapKey(unitInfo.UnitKey, culture.Name == string.Empty ? "en-US" : culture.Name);
        }
        
        private static List<string> ReadAbbreviationsFromResourceFile(UnitInfo unitInfo, CultureInfo culture)
        {
            var abbreviationsList = new List<string>();
            QuantityInfo quantityInfo = unitInfo.QuantityInfo;
            ResourceManager? resourceManager = quantityInfo.UnitAbbreviations;
            if (resourceManager is null)
            {
                return abbreviationsList;
            }

            var abbreviationsString = resourceManager.GetString(unitInfo.PluralName, culture);
            if (abbreviationsString is not null)
            {
                abbreviationsList.AddRange(abbreviationsString.Split(','));
            }

            return abbreviationsList;
        }
    }
}
