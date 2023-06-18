// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Information about the unit, such as its name and value.
    ///     This is useful to enumerate units and present names with quantities and units
    ///     chosen dynamically at runtime, such as unit conversion apps or allowing the user to change the
    ///     unit representation.
    /// </summary>
    /// <remarks>
    ///     Typically you obtain this by looking it up via <see cref="QuantityInfo.UnitInfos" />.
    /// </remarks>
    public class UnitInfo
    {
        private readonly object _syncRoot = new();

        /// <summary>
        /// Creates an instance of the UnitInfo class.
        /// </summary>
        /// <param name="value">The enum value for this class, for example <see cref="LengthUnit.Meter"/>.</param>
        /// <param name="pluralName">The plural name of the unit, such as "Centimeters".</param>
        /// <param name="baseUnits">The <see cref="BaseUnits"/> for this unit.</param>
        public UnitInfo(Enum value, string pluralName, BaseUnits baseUnits)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Name = value.ToString();
            PluralName = pluralName;
            BaseUnits = baseUnits ?? throw new ArgumentNullException(nameof(baseUnits));

            AbbreviationsMap = new ConcurrentDictionary<string, Lazy<IReadOnlyList<string>>>();
        }

        /// <summary>
        /// Creates an instance of the UnitInfo class.
        /// </summary>
        /// <param name="value">The enum value for this class, for example <see cref="LengthUnit.Meter"/>.</param>
        /// <param name="pluralName">The plural name of the unit, such as "Centimeters".</param>
        /// <param name="baseUnits">The <see cref="BaseUnits"/> for this unit.</param>
        /// <param name="quantityName">The quantity name that this unit is for.</param>
        internal UnitInfo(Enum value, string pluralName, BaseUnits baseUnits, string quantityName) :
            this(value, pluralName, baseUnits)
        {
            QuantityName = quantityName;
        }

        /// <summary>
        /// The enum value of the unit, such as <see cref="LengthUnit.Centimeter" />.
        /// </summary>
        public Enum Value { get; }

        /// <summary>
        /// The singular name of the unit, such as "Centimeter".
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The plural name of the unit, such as "Centimeters".
        /// </summary>
        public string PluralName { get; }

        /// <summary>
        /// Gets the <see cref="BaseUnits"/> for this unit.
        /// </summary>
        public BaseUnits BaseUnits { get; }

        private string? QuantityName { get; }

        /// <summary>
        /// Culture name to abbreviations. To add a custom default abbreviation, add to the beginning of the list.
        /// </summary>
        private IDictionary<string, Lazy<IReadOnlyList<string>>> AbbreviationsMap { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IReadOnlyList<string> GetAbbreviations(IFormatProvider? formatProvider = null)
        {
            if(formatProvider is null || formatProvider is not CultureInfo)
                formatProvider = CultureInfo.CurrentCulture;

            var culture = (CultureInfo)formatProvider;
            var cultureName = GetCultureNameOrEnglish(culture);

            if(!AbbreviationsMap.TryGetValue(cultureName, out var abbreviations))
                AbbreviationsMap[cultureName] = abbreviations = new Lazy<IReadOnlyList<string>>(() => ReadAbbreviationsFromResourceFile(culture));

            if(abbreviations.Value.Count == 0 && !culture.Equals(UnitAbbreviationsCache.FallbackCulture))
                return GetAbbreviations(UnitAbbreviationsCache.FallbackCulture);
            else
                return abbreviations.Value;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="formatProvider"></param>
        /// <param name="setAsDefault"></param>
        /// <param name="allowAbbreviationLookup"></param>
        /// <param name="abbreviations"></param>
        public void AddAbbreviation(IFormatProvider? formatProvider, bool setAsDefault, bool allowAbbreviationLookup, params string[] abbreviations)
        {
            if(formatProvider is null || formatProvider is not CultureInfo)
                formatProvider = CultureInfo.CurrentCulture;

            var culture = (CultureInfo)formatProvider;
            var cultureName = GetCultureNameOrEnglish(culture);

            // Restrict concurrency on writes.
            // By using ConcurrencyDictionary and immutable IReadOnlyList instances, we don't need to lock on reads.
            lock(_syncRoot)
            {
                var currentAbbreviationsList = new List<string>(GetAbbreviations(culture));

                foreach(var abbreviation in abbreviations)
                {
                    if(!currentAbbreviationsList.Contains(abbreviation))
                    {
                        if(setAsDefault)
                            currentAbbreviationsList.Insert(0, abbreviation);
                        else
                            currentAbbreviationsList.Add(abbreviation);
                    }
                }

                AbbreviationsMap[cultureName] = new Lazy<IReadOnlyList<string>>(() => currentAbbreviationsList.AsReadOnly());
            }
        }

        private static string GetCultureNameOrEnglish(CultureInfo culture)
        {
            // Fallback culture is invariant to support DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1,
            // but we need to map that to the primary localization, English.
            return culture.Equals(CultureInfo.InvariantCulture)
                ? "en-US"
                : culture.Name;
        }

        private IReadOnlyList<string> ReadAbbreviationsFromResourceFile(CultureInfo culture)
        {
            var abbreviationsList = new List<string>();

            if(QuantityName is not null)
            {
                string resourceName = $"UnitsNet.GeneratedCode.Resources.{QuantityName}";
                var resourceManager = new ResourceManager(resourceName, GetType().Assembly);

                var abbreviationsString = resourceManager.GetString(PluralName, culture);
                if(abbreviationsString is not null)
                    abbreviationsList.AddRange(abbreviationsString.Split(','));
            }

            return abbreviationsList.AsReadOnly();
        }
    }

    /// <inheritdoc cref="UnitInfo" />
    /// <remarks>
    ///     This is a specialization of <see cref="UnitInfo" />, for when the unit type is known.
    ///     Typically you obtain this by looking it up statically from <see cref="QuantityInfo{LengthUnit}.UnitInfos" /> or
    ///     or dynamically via <see cref="IQuantity{TUnitType}.QuantityInfo" />.
    /// </remarks>
    /// <typeparam name="TUnit">The unit enum type, such as <see cref="LengthUnit" />. </typeparam>
    public class UnitInfo<TUnit> : UnitInfo
        where TUnit : Enum
    {
        /// <inheritdoc />
        public UnitInfo(TUnit value, string pluralName, BaseUnits baseUnits) :
            base(value, pluralName, baseUnits)
        {
            Value = value;
        }

        /// <inheritdoc />
        internal UnitInfo(TUnit value, string pluralName, BaseUnits baseUnits, string quantityName) :
            base(value, pluralName, baseUnits, quantityName)
        {
            Value = value;
        }

        /// <inheritdoc cref="UnitInfo.Value"/>
        public new TUnit Value { get; }
    }
}
