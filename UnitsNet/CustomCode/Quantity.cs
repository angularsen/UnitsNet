using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial class Quantity
    {
        private static QuantityInfoLookup Default => UnitsNetSetup.Default.QuantityInfoLookup;

        /// <summary>
        /// All enum value names of <see cref="Infos"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names { get => Default.Names; }

        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>.
        /// </summary>
        public static QuantityInfo[] Infos => Default.Infos;

        /// <summary>
        /// Get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static UnitInfo GetUnitInfo(Enum unitEnum) => Default.GetUnitInfo(unitEnum);

        /// <summary>
        /// Try to get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static bool TryGetUnitInfo(Enum unitEnum, [NotNullWhen(true)] out UnitInfo? unitInfo) =>
            Default.TryGetUnitInfo(unitEnum, out unitInfo);

        /// <summary>
        ///
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="unitInfo"></param>
        public static void AddUnitInfo(Enum unit, UnitInfo unitInfo) => Default.AddUnitInfo(unit, unitInfo);

        /// <summary>
        ///     Dynamically constructs a quantity from a numeric value and a unit enum value.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit value is not a known unit enum type.</exception>
        public static IQuantity From(QuantityValue value, Enum unit)
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
        /// <exception cref="ArgumentException">Unit value is not a known unit enum type.</exception>
        public static IQuantity From(QuantityValue value, string quantityName, string unitName)
        {
            // Get enum value for this unit, f.ex. LengthUnit.Meter for unit name "Meter".
            return UnitConverter.TryParseUnit(quantityName, unitName, out Enum? unitValue) &&
                   TryFrom(value, unitValue, out IQuantity? quantity)
                ? quantity
                : throw new UnitNotFoundException($"Unit [{unitName}] not found for quantity [{quantityName}].");
        }

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation using <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(UnitsNet.QuantityValue,System.Enum)"/> or <see cref="From(UnitsNet.QuantityValue,string,string)"/> instead.
        /// </remarks>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit abbreviation is not known.</exception>
        /// <exception cref="AmbiguousUnitParseException">Multiple units found matching the given unit abbreviation.</exception>
        public static IQuantity FromUnitAbbreviation(QuantityValue value, string unitAbbreviation) => FromUnitAbbreviation(null, value, unitAbbreviation);

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(UnitsNet.QuantityValue,System.Enum)"/> or <see cref="From(UnitsNet.QuantityValue,string,string)"/> instead.
        /// </remarks>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit abbreviation is not known.</exception>
        /// <exception cref="AmbiguousUnitParseException">Multiple units found matching the given unit abbreviation.</exception>
        public static IQuantity FromUnitAbbreviation(IFormatProvider? formatProvider, QuantityValue value, string unitAbbreviation)
        {
            // TODO Optimize this with UnitValueAbbreviationLookup via UnitAbbreviationsCache.TryGetUnitValueAbbreviationLookup.
            List<Enum> units = GetUnitsForAbbreviation(formatProvider, unitAbbreviation);
            if (units.Count > 1)
            {
                throw new AmbiguousUnitParseException($"Multiple units found matching the given unit abbreviation: {unitAbbreviation}");
            }

            if (units.Count == 0)
            {
                throw new UnitNotFoundException($"Unit abbreviation {unitAbbreviation} is not known. Did you pass in a custom unit abbreviation defined outside the UnitsNet library? This is currently not supported.");
            }

            Enum unit = units.Single();
            return From(value, unit);
        }

        /// <inheritdoc cref="TryFrom(QuantityValue,System.Enum,out UnitsNet.IQuantity)"/>
        public static bool TryFrom(double value, Enum unit, [NotNullWhen(true)] out IQuantity? quantity)
        {
            quantity = default;

            // Implicit cast to QuantityValue would prevent TryFrom from being called,
            // so we need to explicitly check this here for double arguments.
            return !double.IsNaN(value) &&
                   !double.IsInfinity(value) &&
                   TryFrom((QuantityValue)value, unit, out quantity);
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
            quantity = default;

            return UnitConverter.TryParseUnit(quantityName, unitName, out Enum? unitValue) &&
                   TryFrom(value, unitValue, out quantity);
        }

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation using <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(UnitsNet.QuantityValue,System.Enum)"/> or <see cref="From(UnitsNet.QuantityValue,string,string)"/> instead.
        /// </remarks>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <param name="quantity">The quantity if successful, otherwise null.</param>
        /// <returns>True if successful.</returns>
        /// <exception cref="ArgumentException">Unit value is not a known unit enum type.</exception>
        public static bool TryFromUnitAbbreviation(QuantityValue value, string unitAbbreviation, [NotNullWhen(true)] out IQuantity? quantity) =>
            TryFromUnitAbbreviation(null, value, unitAbbreviation, out quantity);

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(UnitsNet.QuantityValue,System.Enum)"/> or <see cref="From(UnitsNet.QuantityValue,string,string)"/> instead.
        /// </remarks>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <param name="quantity">The quantity if successful, otherwise null.</param>
        /// <returns>True if successful.</returns>
        /// <exception cref="ArgumentException">Unit value is not a known unit enum type.</exception>
        public static bool TryFromUnitAbbreviation(IFormatProvider? formatProvider, QuantityValue value, string unitAbbreviation, [NotNullWhen(true)] out IQuantity? quantity)
        {
            // TODO Optimize this with UnitValueAbbreviationLookup via UnitAbbreviationsCache.TryGetUnitValueAbbreviationLookup.
            List<Enum> units = GetUnitsForAbbreviation(formatProvider, unitAbbreviation);
            if (units.Count == 1)
            {
                Enum? unit = units.SingleOrDefault();
                return TryFrom(value, unit, out quantity);
            }

            quantity = default;
            return false;
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        public static IQuantity Parse(Type quantityType, string quantityString) => Default.Parse(null, quantityType, quantityString);

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
            return Default.Parse(formatProvider, quantityType, quantityString);
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(Type quantityType, string quantityString, [NotNullWhen(true)] out IQuantity? quantity) =>
            Default.TryParse(quantityType, quantityString, out quantity);

        /// <summary>
        ///     Get a list of quantities that has the given base dimensions.
        /// </summary>
        /// <param name="baseDimensions">The base dimensions to match.</param>
        public static IEnumerable<QuantityInfo> GetQuantitiesWithBaseDimensions(BaseDimensions baseDimensions)
        {
            return Default.GetQuantitiesWithBaseDimensions(baseDimensions);
        }

        private static List<Enum> GetUnitsForAbbreviation(IFormatProvider? formatProvider, string unitAbbreviation)
        {
            // Use case-sensitive match to reduce ambiguity.
            // Don't use UnitParser.TryParse() here, since it allows case-insensitive match per quantity as long as there are no ambiguous abbreviations for
            // units of that quantity, but here we try all quantities and this results in too high of a chance for ambiguous matches,
            // such as "cm" matching both LengthUnit.Centimeter (cm) and MolarityUnit.CentimolePerLiter (cM).
            return Infos
                .SelectMany(i => i.UnitInfos)
                .Select(ui => UnitAbbreviationsCache.Default
                    .GetUnitAbbreviations(ui.Value.GetType(), Convert.ToInt32(ui.Value), formatProvider)
                    .Contains(unitAbbreviation, StringComparer.Ordinal)
                    ? ui.Value
                    : null)
                .Where(unitValue => unitValue != null)
                .Select(unitValue => unitValue!)
                .ToList();
        }
    }
}
