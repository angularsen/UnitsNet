using System;
using System.Collections.Generic;
using System.Linq;
using UnitsNet.InternalHelpers;

namespace UnitsNet
{
    public partial class Quantity
    {
        private static readonly Lazy<QuantityInfo[]> InfosLazy;

        static Quantity()
        {
            var quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().Except(new[] {QuantityType.Undefined}).ToArray();
            Types = quantityTypes;
            Names = quantityTypes.Select(qt => qt.ToString()).ToArray();

            InfosLazy = new Lazy<QuantityInfo[]>(() => Types
                .Select(quantityType => FromQuantityType(quantityType, 0.0).QuantityInfo)
                .OrderBy(quantityInfo => quantityInfo.Name)
                .ToArray());
        }

        /// <summary>
        /// All enum values of <see cref="QuantityType"/>, such as <see cref="QuantityType.Length"/> and <see cref="QuantityType.Mass"/>.
        /// </summary>
        public static QuantityType[] Types { get; }

        /// <summary>
        /// All enum value names of <see cref="QuantityType"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names { get; }

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
            if (TryFrom(value, unit, out IQuantity quantity))
                return quantity;

            throw new ArgumentException(
                $"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a third-party enum type defined outside UnitsNet library?");
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
