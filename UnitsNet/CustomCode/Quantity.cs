using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace UnitsNet
{
    public partial class Quantity
    {
        private static readonly Lazy<QuantityInfo[]> InfosLazy;
        private static readonly Lazy<Dictionary<(Type, string), UnitInfo>> UnitTypeAndNameToUnitInfoLazy;

        static Quantity()
        {
            ICollection<QuantityInfo> quantityInfos = ByName.Values;
            Names = quantityInfos.Select(qt => qt.Name).ToArray();

            InfosLazy = new Lazy<QuantityInfo[]>(() => quantityInfos
                .OrderBy(quantityInfo => quantityInfo.Name)
                .ToArray());

            UnitTypeAndNameToUnitInfoLazy = new Lazy<Dictionary<(Type, string), UnitInfo>>(() =>
            {
                return Infos
                    .SelectMany(quantityInfo => quantityInfo.UnitInfos
                        .Select(unitInfo => new KeyValuePair<(Type, string), UnitInfo>(
                            (unitInfo.Value.GetType(), unitInfo.Name),
                            unitInfo)))
                    .ToDictionary(x => x.Key, x => x.Value);
            });
        }

        /// <summary>
        /// All enum value names of <see cref="Infos"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names { get; }

        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>.
        /// </summary>
        public static QuantityInfo[] Infos => InfosLazy.Value;

        /// <summary>
        /// Get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static UnitInfo GetUnitInfo(Enum unitEnum) => UnitTypeAndNameToUnitInfoLazy.Value[(unitEnum.GetType(), unitEnum.ToString())];

        /// <summary>
        /// Try to get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static bool TryGetUnitInfo(Enum unitEnum, [NotNullWhen(true)] out UnitInfo? unitInfo) =>
            UnitTypeAndNameToUnitInfoLazy.Value.TryGetValue((unitEnum.GetType(), unitEnum.ToString()), out unitInfo);

        /// <summary>
        ///     Dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public static IQuantity From(QuantityValue value, Enum unit)
        {
            return TryFrom(value, unit, out IQuantity? quantity)
                ? quantity
                : throw new ArgumentException($"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a third-party enum type defined outside UnitsNet library?");
        }

        /// <summary>
        ///     Dynamically construct a quantity from a value, the quantity name and the unit name.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="unitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public static IQuantity From(QuantityValue value, string quantityName, string unitName)
        {
            // Get enum value for this unit, f.ex. LengthUnit.Meter for unit name "Meter".
            return UnitConverter.TryParseUnit(quantityName, unitName, out Enum? unitValue)
                ? From(value, unitValue)
                : throw new UnitNotFoundException($"Unit [{unitName}] not found for quantity [{quantityName}].");
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
        public static IQuantity Parse(IFormatProvider? formatProvider, Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).IsAssignableFrom(quantityType))
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");

            if (TryParse(formatProvider, quantityType, quantityString, out IQuantity? quantity))
                return quantity;

            throw new ArgumentException($"Quantity string could not be parsed to quantity {quantityType}.");
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(Type quantityType, string quantityString, [NotNullWhen(true)] out IQuantity? quantity) =>
            TryParse(null, quantityType, quantityString, out quantity);

        /// <summary>
        ///     Get a list of quantities that has the given base dimensions.
        /// </summary>
        /// <param name="baseDimensions">The base dimensions to match.</param>
        public static IEnumerable<QuantityInfo> GetQuantitiesWithBaseDimensions(BaseDimensions baseDimensions)
        {
            return InfosLazy.Value.Where(info => info.BaseDimensions.Equals(baseDimensions));
        }
    }
}
