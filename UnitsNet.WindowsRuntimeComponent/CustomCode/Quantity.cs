using System;
using System.Linq;

namespace UnitsNet
{
        internal partial class Quantity
    {
        static Quantity()
        {
            var quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().Except(new[] {QuantityType.Undefined}).ToArray();
            Types = quantityTypes;
            Names = quantityTypes.Select(qt => qt.ToString()).ToArray();
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
        ///     Dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        internal static IQuantity From(double value, Enum unit)
        {
            if (TryFrom(value, unit, out IQuantity quantity))
                return quantity;

            throw new ArgumentException(
                $"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a third-party enum type defined outside UnitsNet library?");
        }
    }
}
