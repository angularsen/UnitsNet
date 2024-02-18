// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Resources;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Cache of the mapping between unit enum values and unit abbreviation strings for one or more cultures.
    ///     A static instance <see cref="Default"/> is used internally for ToString() and Parse() of quantities and units.
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
        ///     The static instance used internally for ToString() and Parse() of quantities and units.
        /// </summary>
        [Obsolete("Use UnitsNetSetup.Default.UnitAbbreviations instead.")]
        public static UnitAbbreviationsCache Default => UnitsNetSetup.Default.UnitAbbreviations;

        private QuantityInfoLookup QuantityInfoLookup { get; }

        /// <summary>
        /// Culture name to abbreviations. To add a custom default abbreviation, add to the beginning of the list.
        /// </summary>
        private ConcurrentDictionary<AbbreviationMapKey, IReadOnlyList<string>> AbbreviationsMap { get; } = new();

        /// <summary>
        ///     Create an instance of the cache and load all the abbreviations defined in the library.
        /// </summary>
        // TODO Change this to create an empty cache in v6: https://github.com/angularsen/UnitsNet/issues/1200
        [Obsolete("Use CreateDefault() instead to create an instance that loads the built-in units. The default ctor will change to create an empty cache in UnitsNet v6.")]
        public UnitAbbreviationsCache()
            : this(new QuantityInfoLookup(Quantity.ByName.Values))
        {
        }

        /// <summary>
        ///     Creates an instance of the cache and load all the abbreviations defined in the library.
        /// </summary>
        /// <remarks>
        ///     Access type is <c>internal</c> until this class is matured and ready for external use.
        /// </remarks>
        internal UnitAbbreviationsCache(QuantityInfoLookup quantityInfoLookup)
        {
            QuantityInfoLookup = quantityInfoLookup;
        }

        /// <summary>
        ///     Create an instance with empty cache.
        /// </summary>
        /// <remarks>
        ///     Workaround until v6 changes the default ctor to create an empty cache.<br/>
        /// </remarks>
        /// <returns>Instance with empty cache.</returns>
        // TODO Remove in v6: https://github.com/angularsen/UnitsNet/issues/1200
        public static UnitAbbreviationsCache CreateEmpty() => new(new QuantityInfoLookup(new List<QuantityInfo>()));

        /// <summary>
        ///     Create an instance of the cache and load all the built-in unit abbreviations defined in the library.
        /// </summary>
        /// <returns>Instance with default abbreviations cache.</returns>
        public static UnitAbbreviationsCache CreateDefault() => new(new QuantityInfoLookup(Quantity.ByName.Values));

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, params string[] abbreviations) where TUnitType : Enum
        {
            PerformAbbreviationMapping(unit, CultureInfo.CurrentCulture, false, abbreviations);
        }

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviation">Unit abbreviations to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, string abbreviation) where TUnitType : Enum
        {
            PerformAbbreviationMapping(unit, CultureInfo.CurrentCulture, true, abbreviation);
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
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider, params string[] abbreviations) where TUnitType : Enum
        {
            PerformAbbreviationMapping(unit, formatProvider, false, abbreviations);
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
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider, string abbreviation) where TUnitType : Enum
        {
            PerformAbbreviationMapping(unit, formatProvider, true, abbreviation);
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
            var enumValue = (Enum)Enum.ToObject(unitType, unitValue);
            PerformAbbreviationMapping(enumValue, formatProvider, false, abbreviations);
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
            var enumValue = (Enum)Enum.ToObject(unitType, unitValue);
            PerformAbbreviationMapping(enumValue, formatProvider, true, abbreviation);
        }

        private void PerformAbbreviationMapping(Enum unitValue, IFormatProvider? formatProvider, bool setAsDefault, params string[] abbreviations)
        {
            if(!QuantityInfoLookup.TryGetUnitInfo(unitValue, out UnitInfo? unitInfo))
            {
                unitInfo = new UnitInfo(unitValue, unitValue.ToString(), BaseUnits.Undefined);
                QuantityInfoLookup.AddUnitInfo(unitValue, unitInfo);
            }

            AddAbbreviation(unitInfo, formatProvider, setAsDefault, abbreviations);
        }

        /// <summary>
        /// Gets the default abbreviation for a given unit. If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(LengthUnit.Kilometer) => "km"
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The default unit abbreviation string.</returns>
        public string GetDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum
        {
            Type unitType = typeof(TUnitType);

            // Edge-case: If the value was cast to Enum, it still satisfies the generic constraint so we must get the type from the value instead.
            if (unitType == typeof(Enum)) unitType = unit.GetType();

            return GetDefaultAbbreviation(unitType, Convert.ToInt32(unit), formatProvider);
        }

        /// <summary>
        /// Gets the default abbreviation for a given unit type and its numeric enum value.
        /// If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(typeof(LengthUnit), 1) => "cm"
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>The default unit abbreviation string.</returns>
        public string GetDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            var abbreviations = GetUnitAbbreviations(unitType, unitValue, formatProvider);
            return abbreviations.Length > 0 ? abbreviations[0] : string.Empty;
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public string[] GetUnitAbbreviations<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum
        {
            return GetUnitAbbreviations(typeof(TUnitType), Convert.ToInt32(unit), formatProvider);
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
            formatProvider ??= CultureInfo.CurrentCulture;

            return TryGetUnitAbbreviations(unitType, unitValue, formatProvider, out var abbreviations)
                ? abbreviations
                : throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">The unit abbreviations associated with unit.</param>
        /// <returns>True if found, otherwise false.</returns>
        private bool TryGetUnitAbbreviations(Type unitType, int unitValue, IFormatProvider? formatProvider, out string[] abbreviations)
        {
            var name = Enum.GetName(unitType, unitValue);
            var enumInstance = (Enum)Enum.Parse(unitType, name!);

            if(QuantityInfoLookup.TryGetUnitInfo(enumInstance, out var unitInfo))
            {
                abbreviations = GetAbbreviations(unitInfo, formatProvider!).ToArray();
                return true;
            }
            else
            {
                abbreviations = Array.Empty<string>();
                return false;
            }
        }

        /// <summary>
        ///     Get all abbreviations for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public IReadOnlyList<string> GetAllUnitAbbreviationsForQuantity(Type unitEnumType, IFormatProvider? formatProvider = null)
        {
            var enumValues = Enum.GetValues(unitEnumType).Cast<Enum>();
            var all = GetStringUnitPairs(enumValues, formatProvider);
            return all.Select(pair => pair.Item1).ToList();
        }

        internal List<(string Abbreviation, Enum Unit)> GetStringUnitPairs(IEnumerable<Enum> enumValues, IFormatProvider? formatProvider = null)
        {
            var ret = new List<(string, Enum)>();
            formatProvider ??= CultureInfo.CurrentCulture;

            foreach(var enumValue in enumValues)
            {
                if(TryGetUnitAbbreviations(enumValue.GetType(), Convert.ToInt32(enumValue), formatProvider, out var abbreviations))
                {
                    foreach(var abbrev in abbreviations)
                    {
                        ret.Add((abbrev, enumValue));
                    }
                }
            }

            return ret;
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
            if (formatProvider is not CultureInfo)
                formatProvider = CultureInfo.CurrentCulture;

            var culture = (CultureInfo)formatProvider;
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
            // TODO Enforce quantity name for custom units, optional value was required for backwards compatibility in v5.
            // TODO Support non-enum units, using quantity name and unit name instead.
            var unitTypeName = unitInfo.Value.GetType().FullName ?? throw new InvalidOperationException("Could not resolve unit enum type name."); // .QuantityName ?? "MissingQuantityName";

            return new AbbreviationMapKey(
                UnitTypeName: unitTypeName,
                UnitName: unitInfo.Name,
                CultureName: cultureName);
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

#if NETCOREAPP
        /// <summary>
        ///     Key for looking up unit abbreviations for a given unit and culture.
        /// </summary>
        /// <remarks>
        ///     TODO Use quantity name instead of unit enum name, as part of moving from enums to string-based lookups.
        /// </remarks>
        /// <param name="UnitTypeName">The unit enum type name, such as "UnitsNet.Units.LengthUnit" or "MyApp.HowMuchUnit".</param>
        /// <param name="UnitName">The unit name, such as "Centimeter".</param>
        /// <param name="CultureName">The culture name, such as "en-US".</param>
        [SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Local", Justification = "Only used for hashing and equality.")]
        private record AbbreviationMapKey(string UnitTypeName, string UnitName, string CultureName);
#else
        /// <summary>
        ///     Key for looking up unit abbreviations for a given unit and culture.
        /// </summary>
        /// <remarks>
        ///     TODO Use quantity name instead of unit enum name, as part of moving from enums to string-based lookups.
        /// </remarks>
        private class AbbreviationMapKey : IEquatable<AbbreviationMapKey>
        {
            /// <summary>
            ///     The unit enum type name, such as "UnitsNet.Units.LengthUnit" or "MyApp.HowMuchUnit".
            /// </summary>
            public string UnitTypeName { get; }

            /// <summary>
            ///     The unit name, such as "Centimeter".
            /// </summary>
            public string UnitName { get; }

            /// <summary>
            ///     The culture name, such as "en-US".
            /// </summary>
            public string CultureName { get; }

            [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Matches record naming.")]
            public AbbreviationMapKey(string UnitTypeName, string UnitName, string CultureName)
            {
                this.UnitTypeName = UnitTypeName;
                this.UnitName = UnitName;
                this.CultureName = CultureName;
            }

            public bool Equals(AbbreviationMapKey? other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return UnitTypeName == other.UnitTypeName && UnitName == other.UnitName && CultureName == other.CultureName;
            }

            public override bool Equals(object? obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((AbbreviationMapKey)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = UnitTypeName.GetHashCode();
                    hashCode = (hashCode * 397) ^ UnitName.GetHashCode();
                    hashCode = (hashCode * 397) ^ CultureName.GetHashCode();
                    return hashCode;
                }
            }
        }
#endif

    }
}
