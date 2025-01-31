using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial class Quantity
    {
        private static QuantityInfoLookup Quantities => UnitsNetSetup.Default.QuantityInfoLookup;
        private static UnitParser UnitParser => UnitsNetSetup.Default.UnitParser;

        /// <summary>
        /// All enum value names of <see cref="Infos"/>, such as "Length" and "Mass".
        /// </summary>
        public static IReadOnlyCollection<string> Names { get => Quantities.Names; }

        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>.
        /// </summary>
        public static IReadOnlyCollection<QuantityInfo> Infos => Quantities.Infos;

        /// <summary>
        /// Get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static UnitInfo GetUnitInfo(Enum unitEnum) => Quantities.GetUnitInfo(unitEnum);

        /// <summary>
        /// Try to get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static bool TryGetUnitInfo(Enum unitEnum, [NotNullWhen(true)] out UnitInfo? unitInfo) =>
            Quantities.TryGetUnitInfo(unitEnum, out unitInfo);

        /// <summary>
        ///
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="unitInfo"></param>
        public static void AddUnitInfo(Enum unit, UnitInfo unitInfo) => Quantities.AddUnitInfo(unitInfo);

        /// <summary>
        ///     Dynamically constructs a quantity from a numeric value and a unit enum value.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit value is not a known unit enum type.</exception>
        public static IQuantity From(double value, Enum unit)
        {
            return TryFrom(value, unit, out IQuantity? quantity)
                ? quantity
                : throw new UnitNotFoundException($"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a custom enum type defined outside the UnitsNet library?");
        }

        /// <summary>
        ///     Dynamically construct a quantity from a value, the quantity name and the unit name.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="unitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="QuantityNotFoundException">
        ///     Thrown when no quantity information is found for the specified quantity name.
        /// </exception>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit is found for the specified quantity name and unit name.
        /// </exception>
        public static IQuantity From(double value, string quantityName, string unitName)
        {
            return From(value, Quantities.GetUnitByName(quantityName, unitName).Value);
        }

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation using <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(double,System.Enum)"/> or <see cref="From(double,string,string)"/> instead.
        /// </remarks>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit abbreviation is not known.</exception>
        /// <exception cref="AmbiguousUnitParseException">Multiple units found matching the given unit abbreviation.</exception>
        public static IQuantity FromUnitAbbreviation(double value, string unitAbbreviation) => FromUnitAbbreviation(null, value, unitAbbreviation);

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(double,System.Enum)"/> or <see cref="From(double,string,string)"/> instead.
        /// </remarks>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit abbreviation is not known.</exception>
        /// <exception cref="AmbiguousUnitParseException">Multiple units found matching the given unit abbreviation.</exception>
        public static IQuantity FromUnitAbbreviation(IFormatProvider? formatProvider, double value, string unitAbbreviation)
        {
            return From(value, UnitParser.GetUnitFromAbbreviation(unitAbbreviation, formatProvider).Value);
        }

        /// <summary>
        ///     Try to dynamically construct a quantity from a value, the quantity name and the unit name.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="quantity">The constructed quantity, if successful, otherwise null.</param>
        /// <returns><c>True</c> if successful with <paramref name="quantity"/> assigned the value, otherwise <c>false</c>.</returns>
        public static bool TryFrom(double value, string quantityName, string unitName, [NotNullWhen(true)] out IQuantity? quantity)
        {
            if (Quantities.TryGetUnitByName(quantityName, unitName, out UnitInfo? unitInfo))
            {
                return TryFrom(value, unitInfo.Value, out quantity);
            }
            
            quantity = null;
            return false;
        }

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation using <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(double,System.Enum)"/> or <see cref="From(double,string,string)"/> instead.
        /// </remarks>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <param name="quantity">The quantity if successful, otherwise null.</param>
        /// <returns>True if successful.</returns>
        /// <exception cref="ArgumentException">Unit value is not a known unit enum type.</exception>
        public static bool TryFromUnitAbbreviation(double value, string unitAbbreviation, [NotNullWhen(true)] out IQuantity? quantity) =>
            TryFromUnitAbbreviation(null, value, unitAbbreviation, out quantity);

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(double,System.Enum)"/> or <see cref="From(double,string,string)"/> instead.
        /// </remarks>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <param name="quantity">The quantity if successful, otherwise null.</param>
        /// <returns>True if successful.</returns>
        /// <exception cref="ArgumentException">Unit value is not a known unit enum type.</exception>
        public static bool TryFromUnitAbbreviation(IFormatProvider? formatProvider, double value, string unitAbbreviation, [NotNullWhen(true)] out IQuantity? quantity)
        {
            if (UnitParser.TryGetUnitFromAbbreviation(unitAbbreviation, formatProvider, out UnitInfo? unitInfo))
            {
                return TryFrom(value, unitInfo.Value, out quantity);
            }

            quantity = null;
            return false;
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        public static IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        /// <exception cref="UnitNotFoundException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        public static IQuantity Parse(IFormatProvider? formatProvider, Type quantityType, string quantityString)
        {
            // TODO Support custom units (via the QuantityParser), currently only hardcoded built-in quantities are supported.
            if (!typeof(IQuantity).IsAssignableFrom(quantityType))
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");

            if (TryParse(formatProvider, quantityType, quantityString, out IQuantity? quantity))
                return quantity;

            throw new UnitNotFoundException($"Quantity string '{quantityString}' could not be parsed to quantity '{quantityType}'.");
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(Type quantityType, string quantityString, [NotNullWhen(true)] out IQuantity? quantity)
        {
            // TODO Support custom units (via the QuantityParser), currently only hardcoded built-in quantities are supported.
            return TryParse(null, quantityType, quantityString, out quantity);
        }

        /// <summary>
        ///     Get a list of quantities that has the given base dimensions.
        /// </summary>
        /// <param name="baseDimensions">The base dimensions to match.</param>
        public static IEnumerable<QuantityInfo> GetQuantitiesWithBaseDimensions(BaseDimensions baseDimensions)
        {
            return Infos.GetQuantitiesWithBaseDimensions(baseDimensions);
        }
    }
}
