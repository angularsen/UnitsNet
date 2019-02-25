// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

using UnitTypeToLookup = System.Collections.Generic.Dictionary<System.Type, UnitsNet.UnitValueAbbreviationLookup>;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    public sealed partial class UnitAbbreviationsCache
    {
        private readonly Dictionary<IFormatProvider, UnitTypeToLookup> _lookupsForCulture;

        /// <summary>
        ///     Fallback culture used by <see cref="GetUnitAbbreviations{TUnitType}" /> and <see cref="GetDefaultAbbreviation{TUnitType}" />
        ///     if no abbreviations are found with a given culture.
        /// </summary>
        /// <example>
        ///     User wants to call <see cref="UnitParser.Parse{TUnitType}" /> or <see cref="Length.ToString()" /> with Russian
        ///     culture, but no translation is defined, so we return the US English definition as a last resort. If it's not
        ///     defined there either, an exception is thrown.
        /// </example>
        private static readonly CultureInfo FallbackCulture = new CultureInfo("en-US");

        public static UnitAbbreviationsCache Default { get; }

        public UnitAbbreviationsCache()
        {
            _lookupsForCulture = new Dictionary<IFormatProvider, UnitTypeToLookup>();

            LoadGeneratedAbbreviations();
        }

        static UnitAbbreviationsCache()
        {
            Default = new UnitAbbreviationsCache();
        }

        private void LoadGeneratedAbbreviations()
        {
            foreach(var localization in GeneratedLocalizations)
            {
                var culture = new CultureInfo(localization.CultureName);
                MapUnitToAbbreviation(localization.UnitType, localization.UnitValue, culture, localization.UnitAbbreviations);
            }
        }

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        private void MapUnitToAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] params string[] abbreviations)
        {
            PerformAbbreviationMapping(unitType, unitValue, formatProvider, false, abbreviations);
        }

        private void PerformAbbreviationMapping(Type unitType, int unitValue, IFormatProvider formatProvider, bool setAsDefault, [NotNull] params string[] abbreviations)
        {
            if (!unitType.Wrap().IsEnum)
                throw new ArgumentException("Must be an enum type.", nameof(unitType));

            if (abbreviations == null)
                throw new ArgumentNullException(nameof(abbreviations));

            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            if (!_lookupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                quantitiesForProvider = _lookupsForCulture[formatProvider] = new UnitTypeToLookup();

            if (!quantitiesForProvider.TryGetValue(unitType, out var unitToAbbreviations))
                unitToAbbreviations = quantitiesForProvider[unitType] = new UnitValueAbbreviationLookup();

            foreach (var abbr in abbreviations)
            {
                unitToAbbreviations.Add(unitValue, abbr, setAsDefault);
            }
        }

        /// <summary>
        /// Gets the default abbreviation for a given unit. If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(LengthUnit.Kilometer) => "km"
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The default unit abbreviation string.</returns>
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal string GetDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            var unitType = typeof(TUnitType);

            if(!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
            {
                if(formatProvider != FallbackCulture)
                    return GetDefaultAbbreviation(unit, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name}.{unit}");
            }

            var abbreviations = lookup.GetAbbreviationsForUnit(unit);
            if(abbreviations.Count == 0)
            {
                if(formatProvider != FallbackCulture)
                    return GetDefaultAbbreviation(unit, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name}.{unit}");
            }

            return abbreviations.First();
        }

        /// <summary>
        /// Gets the default abbreviation for a given unit type and its numeric enum value.
        /// If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(typeof(LengthUnit), 1) => "cm"
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>The default unit abbreviation string.</returns>
        internal string GetDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider = null)
        {
            if(!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
            {
                if(formatProvider != FallbackCulture)
                    return GetDefaultAbbreviation(unitType, unitValue, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");
            }

            var abbreviations = lookup.GetAbbreviationsForUnit(unitValue);
            if(abbreviations.Count == 0)
            {
                if(formatProvider != FallbackCulture)
                    return GetDefaultAbbreviation(unitType, unitValue, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");
            }

            return abbreviations.First();
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal string[] GetUnitAbbreviations<TUnitType>(TUnitType unit, IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            return GetUnitAbbreviations(typeof(TUnitType), Convert.ToInt32(unit), formatProvider);
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        private string[] GetUnitAbbreviations(Type unitType, int unitValue, IFormatProvider formatProvider = null)
        {
            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            if(!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
                return formatProvider != FallbackCulture ? GetUnitAbbreviations(unitType, unitValue, FallbackCulture) : new string[] { };

            var abbreviations = lookup.GetAbbreviationsForUnit(unitValue);
            if(abbreviations.Count == 0)
                return formatProvider != FallbackCulture ? GetUnitAbbreviations(unitType, unitValue, FallbackCulture) : new string[] { };

            return abbreviations.ToArray();
        }

        /// <summary>
        ///     Get all abbreviations for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        internal string[] GetAllUnitAbbreviationsForQuantity(Type unitEnumType, IFormatProvider formatProvider = null)
        {
            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            if(!TryGetUnitValueAbbreviationLookup(unitEnumType, formatProvider, out var lookup))
                return formatProvider != FallbackCulture ? GetAllUnitAbbreviationsForQuantity(unitEnumType, FallbackCulture) : new string[] { };

            return lookup.GetAllUnitAbbreviationsForQuantity();
        }

        internal bool TryGetUnitValueAbbreviationLookup(Type unitType, IFormatProvider formatProvider, out UnitValueAbbreviationLookup unitToAbbreviations)
        {
            unitToAbbreviations = null;

            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            if(!_lookupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                return formatProvider != FallbackCulture ? TryGetUnitValueAbbreviationLookup(unitType, FallbackCulture, out unitToAbbreviations) : false;

            if(!quantitiesForProvider.TryGetValue(unitType, out unitToAbbreviations))
                return formatProvider != FallbackCulture ? TryGetUnitValueAbbreviationLookup(unitType, FallbackCulture, out unitToAbbreviations) : false;

            return true;
        }
    }
}
