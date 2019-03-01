// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    public sealed class UnitParser
    {
        private readonly UnitAbbreviationsCache _unitAbbreviationsCache;

        public static UnitParser Default { get; }

        public UnitParser(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            _unitAbbreviationsCache = unitAbbreviationsCache ?? UnitAbbreviationsCache.Default;
        }

        static UnitParser()
        {
            Default = new UnitParser(UnitAbbreviationsCache.Default);
        }

        /// <summary>
        /// Parses a unit abbreviation for a given unit enumeration type.
        /// Example: Parse&lt;LengthUnit&gt;("km") => LengthUnit.Kilometer
        /// </summary>
        /// <param name="unitAbbreviation"></param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <typeparam name="TUnitType"></typeparam>
        /// <returns></returns>
        internal TUnitType Parse<TUnitType>(string unitAbbreviation, [CanBeNull] IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            return (TUnitType)Parse(unitAbbreviation, typeof(TUnitType));
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
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>Unit enum value, such as <see cref="MassUnit.Kilogram" />.</returns>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        internal Enum Parse([NotNull] string unitAbbreviation, Type unitType, [CanBeNull] IFormatProvider formatProvider = null)
        {
            if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));
            unitAbbreviation = unitAbbreviation.Trim();

            if(!_unitAbbreviationsCache.TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var abbreviations))
                throw new UnitNotFoundException($"No abbreviations defined for unit type [{unitType}] for culture [{formatProvider}].");

            var unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: true);

            // Narrow the search if too many hits, for example Megabar "Mbar" and Millibar "mbar" need to be distinguished
            if (unitIntValues.Count > 1)
                unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: false);

            switch (unitIntValues.Count)
            {
                case 1:
                    return (Enum) Enum.ToObject(unitType, unitIntValues[0]);
                case 0:
                    throw new UnitNotFoundException($"Unit not found with abbreviation [{unitAbbreviation}] for unit type [{unitType}].");
                default:
                    string unitsCsv = string.Join(", ", unitIntValues.Select(x => Enum.GetName(unitType, x)).ToArray());
                    throw new AmbiguousUnitParseException(
                        $"Cannot parse \"{unitAbbreviation}\" since it could be either of these: {unitsCsv}");
            }
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
        /// <returns>True if successful.</returns>
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal bool TryParse<TUnitType>(string unitAbbreviation, out TUnitType unit) where TUnitType : Enum
        {
            return TryParse(unitAbbreviation, null, out unit);
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
        /// <returns>True if successful.</returns>
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal bool TryParse<TUnitType>(string unitAbbreviation, [CanBeNull] IFormatProvider formatProvider, out TUnitType unit) where TUnitType : Enum
        {
            unit = default;

            if(!TryParse(unitAbbreviation, typeof(TUnitType), formatProvider, out var unitObj))
                return false;

            unit = (TUnitType)unitObj;
            return true;
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unitType">Type of unit enum.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <returns>True if successful.</returns>
        internal bool TryParse(string unitAbbreviation, Type unitType, out Enum unit)
        {
            return TryParse(unitAbbreviation, unitType, null, out unit);
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unitType">Type of unit enum.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <returns>True if successful.</returns>
        internal bool TryParse(string unitAbbreviation, Type unitType, [CanBeNull] IFormatProvider formatProvider, out Enum unit)
        {
            if (unitAbbreviation == null)
            {
                unit = default;
                return false;
            }

            unitAbbreviation = unitAbbreviation.Trim();
            unit = default;

            if(!_unitAbbreviationsCache.TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var abbreviations))
                return false;

            var unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: true);

            // Narrow the search if too many hits, for example Megabar "Mbar" and Millibar "mbar" need to be distinguished
            if (unitIntValues.Count > 1)
                unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: false);

            if(unitIntValues.Count != 1)
                return false;

            unit = (Enum)Enum.ToObject(unitType, unitIntValues[0]);
            return true;
        }
    }
}
