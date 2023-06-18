using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial class Quantity
    {
        static Quantity()
        {
            Default = new QuantityInfoLookup();
        }

        private static QuantityInfoLookup Default
        {
            get;
        }

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
            return Default.From(value, unit);
        }

        /// <inheritdoc cref="TryFrom(QuantityValue,System.Enum,out UnitsNet.IQuantity)"/>
        public static bool TryFrom(double value, Enum unit, [NotNullWhen(true)] out IQuantity? quantity)
        {
            return Default.TryFrom(value, unit, out quantity);
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
