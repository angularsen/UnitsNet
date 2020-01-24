using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;

namespace UnitsNet
{
    public partial class Quantity
    {
        private static readonly Lazy<QuantityInfo[]> InfosLazy;

        static Quantity()
        {
            QuantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().Except(new[] {QuantityType.Undefined}).ToList();

            InfosLazy = new Lazy<QuantityInfo[]>(() => Types
                .Select(quantityType => FromQuantityType(quantityType, 0.0).QuantityInfo)
                .OrderBy(quantityInfo => quantityInfo.Name)
                .ToArray());
        }

        private static readonly List<QuantityType> QuantityTypes;

        /// <summary>
        /// All enum values of <see cref="QuantityType"/>, such as <see cref="QuantityType.Length"/> and <see cref="QuantityType.Mass"/>.
        /// </summary>
        public static QuantityType[] Types => QuantityTypes.ToArray();

        /// <summary>
        /// All enum value names of <see cref="QuantityType"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names => QuantityTypes.Select(qt => qt.ToString()).ToArray();

        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>.
        /// </summary>
        public static QuantityInfo[] Infos => InfosLazy.Value;

        /// <summary>
        ///     Dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public static IQuantity From(QuantityValue value, Enum unit)
        {
            return QuantityFactory.Default.From(value, unit);

        }

        /// <inheritdoc cref="TryFrom(QuantityValue,System.Enum,out UnitsNet.IQuantity)"/>
        public static bool TryFrom(double value, Enum unit, out IQuantity quantity)
        {
            return QuantityFactory.Default.TryFrom(value, unit, out quantity);
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        public static IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        public static IQuantity Parse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString)
        {
            return QuantityFactory.Default.Parse(formatProvider, quantityType, quantityString);
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(Type quantityType, string quantityString, out IQuantity quantity)
        {
            return QuantityFactory.Default.TryParse(quantityType, quantityString, out quantity);
        }


        /// <summary>
        ///     Get information about the given quantity type.
        /// </summary>
        /// <param name="quantityType">The quantity type enum value.</param>
        /// <returns>Information about the quantity and its units.</returns>
        public static QuantityInfo GetInfo(QuantityType quantityType)
        {
            return Infos.First(qi => qi.QuantityType == quantityType);
        }

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
